using System;
using System.Collections.Generic;
using System.Threading;
using Siemens.Runtime.HmiUnified;
using System.Text;

namespace Siemens.Runtime.HmiIL.TestClient
{
    class AlarmLoggingSample
    {
        private IAlarmLoggingSubscription _alarm;
        private readonly ManualResetEvent _event;

        private readonly IRuntime _runtime;

        public AlarmLoggingSample(IRuntime runtime)
        {
            _runtime = runtime;
            _event = new ManualResetEvent(false);
        }

        /// <summary>
        /// Read historical alarms and save the result in CSV file.
        /// </summary>
        /// <param name="filePath">CSV file name</param>
        /// <param name="begin">start time</param>
        /// <param name="end">end time</param>
        /// <param name="delimiter">CSV delimiter</param>
        public void ExportAlarms(string filePath, DateTime begin, DateTime end, char delimiter = ',')
        {
            using (var alarm = _runtime.GetObject<IAlarmLogging>(_runtime))
            {
                List<string> systemNames = new List<string>();
                systemNames.Add("SYSTEM1");
                var values = alarm.Read(begin, end, "AlarmClassName = 'Alarm'", 1033, systemNames);

                if (values.Count == 0)
                    return;

                var csv = new StringBuilder();
                var line = string.Format("Name{0}State{0}ModificationTime{0}AlarmClassName{0}AlarmText1", delimiter);
                csv.AppendLine(line);
                foreach (var v in values)
                {
                    line = string.Format("{0}{5}{1}{5}{2}{5}{3}{5}{4}", v.Name, v.State, v.ModificationTime, v.AlarmClassName, v.AlarmText1, delimiter);
                    csv.AppendLine(line);
                }

                System.IO.File.WriteAllText(filePath, csv.ToString());
            }
        }

        public void Read()
        {
            try
            {
                using (var alarm = _runtime.GetObject<IAlarmLogging>())
                {
                    var now = DateTime.UtcNow;
                    var begin = now.AddMinutes(-5);
                    var end = now.AddMinutes(-2);

                    var systemNames = new List<string>();
                    systemNames.Add("SYSTEM1");
                    var values = alarm.Read(begin, end, "", 1033, systemNames);
                    PrintValues(values);
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void ReadAsync()
        {
            try
            {
                var alarm = _runtime.GetObject<IAlarmLogging>();

                var now = DateTime.UtcNow;
                var begin = now.AddMinutes(-5);
                var end = now.AddMinutes(-2);

                var systemNames = new List<string>();
                systemNames.Add("SYSTEM1");
                alarm.OnReadComplete += Alarm_OnReadComplete;
                alarm.ReadAsync(begin, end, "", 1033, systemNames);
                _event.WaitOne();
                _event.Reset();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void CommentAlarms()
        {
            try
            {
                using (var alarm = _runtime.GetObject<IAlarmLogging>())
                {
                    var now = DateTime.UtcNow;
                    var begin = now.AddHours(-5);

                    var systemNames = new List<string>();
                    systemNames.Add("SYSTEM1");
                    var loggedAlarmList = alarm.Read(begin, now, "", 1033, systemNames);

                    foreach (var item in loggedAlarmList)
                    {
                        var comment = string.Format("{0}_{1}_{2}", "comment for alarm", item.LoggedAlarmStateObjectID,
                            item.ModificationTime);
                        uint language = 1033;
                        alarm.AddComment(item, language, comment);
                    }
                }
            }

            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void SubscribeAlarm()
        {
            try
            {
                _alarm = _runtime.GetObject<IAlarmLoggingSubscription>();
                var systemNames = new List<string>();
                systemNames.Add("SYSTEM1");

                // Assign alarm handler
                _alarm.OnDataChanged += Alarm_OnDataChanged;
                _alarm.Filter = "";
                _alarm.Language = 1033;
                _alarm.SystemNames = systemNames;
                _alarm.Start();
                _event.WaitOne();
                _event.Reset();
                _alarm.Stop();
             
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }

            finally
            {
                _alarm.Dispose();
            }
        }


        private void Alarm_OnDataChanged(IAlarmLoggingSubscription sender, uint errorCode,
            IList<ILoggedAlarmResult> values)
        {
            PrintValues(values);
            if (sender != null)
            {
                _event.Set();               
            }
        }

        private void PrintValues(IList<ILoggedAlarmResult> values)
        {
            foreach (var v in values)
            {
                Console.WriteLine("Name: {0} Timestamp: {1} Value: {2}", v.Name, v.RaiseTime, v.Value);
            }
        }

        private void Alarm_OnReadComplete(IAlarmLogging sender, uint errorCode, IList<ILoggedAlarmResult> values,
            bool completed)
        {
            PrintValues(values);

            if (completed)
            {
                _event.Set();
                sender.Dispose();
            }
        }
    }
}
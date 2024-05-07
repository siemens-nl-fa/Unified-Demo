using System;
using System.Collections.Generic;
using System.Threading;
using Siemens.Runtime.HmiUnified;

namespace Siemens.Runtime.HmiIL.TestClient
{
    public class AlarmSample
    {
        private readonly ManualResetEvent _ackevent = new ManualResetEvent(false);
        private readonly ManualResetEvent _event = new ManualResetEvent(false);
        private readonly ManualResetEvent _resetevent = new ManualResetEvent(false);
        private readonly IRuntime runtime = Start.runtime;
        public List<IAlarmResult> AlarmList;

        public void SubscribeAlarm()
        {
            try
            {
                var alarm = runtime.GetObject<IAlarmSubscription>();
                var systemNames = new List<string>();
                systemNames.Add("SYSTEM1");

                // Assign alarm handler
                alarm.OnAlarmHandler += alarm_OnAlarmHandler;
                alarm.OnPendingAlarmCompleteHandler += Alarm_OnPendingAlarmCompleteHandler;
                alarm.Filter = "AlarmClassName != 'SystemWarning'";
                alarm.Language = 1033;
                alarm.SystemNames = systemNames;
                alarm.Start();

                _event.WaitOne();
                _event.Reset();

                //stop alarm subscription
                alarm.Stop();

                //Dispose alarm object
                alarm.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        private void Alarm_OnPendingAlarmCompleteHandler(IAlarmSubscription sender)
        {
            _event.Set();
        }

        public void SubscribeAlarmWithFilterOnOriginAndAlarmclass()
        {
            try
            {
                //  object filter = "AlarmClass = 'AlarmWithOptionalAcknowledgement' AND Origin = 'Boiler'";
                var alarm = runtime.GetObject<IAlarmSubscription>();
                var systemNames = new List<string>();
                systemNames.Add("SYSTEM1");


                // Assign alarm handler
                alarm.OnAlarmHandler += alarm_OnAlarmHandler;
                alarm.OnPendingAlarmCompleteHandler += Alarm_OnPendingAlarmCompleteHandler;
                alarm.Filter = "AlarmClassName = 'AlarmWithOptionalAcknowledgement' AND Origin = 'Boiler'";
                alarm.Language = 1033;
                alarm.SystemNames = systemNames;
                alarm.Start();

                _event.WaitOne();
                _event.Reset();

                //stop alarm subscription
                alarm.Stop();

                //Dispose alarm object
                alarm.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void SubscribeAlarmWithFilterOnAreaAndState()
        {
            try
            {
                // object filter = "Area = 'Area2' AND State = 1";
                var alarm = runtime.GetObject<IAlarmSubscription>();
                var systemNames = new List<string>();
                systemNames.Add("SYSTEM1");


                // Assign alarm handler
                alarm.OnAlarmHandler += alarm_OnAlarmHandler;
                alarm.OnPendingAlarmCompleteHandler += Alarm_OnPendingAlarmCompleteHandler;
                alarm.Filter = "Area = 'Area2' AND State = 1";
                alarm.Language = 1033;
                alarm.SystemNames = systemNames;
                alarm.Start();

                //wait for all alarms
                _event.WaitOne();
                _event.Reset();

                //stop alarm subscription
                alarm.Stop();

                //Dispose alarm object
                alarm.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void alarm_OnAlarmHandler(IAlarmSubscription sender, uint globalError, string systemName,
            IList<IAlarmResult> value)
        {
            if (0 == globalError && value != null)
            {
                AlarmList = new List<IAlarmResult>();
                foreach (var item in value)
                {
                    Console.WriteLine("InstanceID: {0}", item.InstanceID);
                    Console.WriteLine("AcknowledgementTime: {0}", item.AcknowledgementTime);
                    Console.WriteLine("AlarmClass: {0}", item.AlarmClassName);
                    Console.WriteLine("AlarmClassSymbol: {0}", item.AlarmClassSymbol);
                    Console.WriteLine("Id: {0}", item.Id);
                    Console.WriteLine("AlarmParameterValues: {0}", item.AlarmParameterValues);
                    Console.WriteLine("AlarmText1: {0}", item.AlarmText1);
                    Console.WriteLine("AlarmText2: {0}", item.AlarmText2);
                    Console.WriteLine("AlarmText3: {0}", item.AlarmText3);
                    Console.WriteLine("AlarmText4: {0}", item.AlarmText4);
                    Console.WriteLine("AlarmText5: {0}", item.AlarmText5);
                    Console.WriteLine("AlarmText6: {0}", item.AlarmText6);
                    Console.WriteLine("AlarmText7: {0}", item.AlarmText7);
                    Console.WriteLine("AlarmText8: {0}", item.AlarmText8);
                    Console.WriteLine("AlarmText9: {0}", item.AlarmText9);
                    Console.WriteLine("Area: {0}", item.Area);
                    Console.WriteLine("BackColor: {0}", item.BackColor);
                    Console.WriteLine("ChangeReason: {0}", item.ChangeReason);
                    Console.WriteLine("ClearTime: {0}", item.ClearTime);
                    Console.WriteLine("Connection: {0}", item.Connection);
                    Console.WriteLine("DeadBand: {0}", item.DeadBand);
                    Console.WriteLine("EventText: {0}", item.EventText);
                    Console.WriteLine("InfoText: {0}", item.InfoText);
                    Console.WriteLine("Flashing: {0}", item.Flashing);
                    Console.WriteLine("HostName: {0}", item.HostName);
                    Console.WriteLine("InvalidFlags: {0}", item.InvalidFlags);
                    Console.WriteLine("LoopInAlarm: {0}", item.LoopInAlarm);
                    Console.WriteLine("ModificationTime: {0}", item.ModificationTime);
                    Console.WriteLine("Name: {0}", item.Name);
                    Console.WriteLine("Origin: {0}", item.Origin);
                    Console.WriteLine("Priority: {0}", item.Priority);
                    Console.WriteLine("RaiseTime: {0}", item.RaiseTime);
                    Console.WriteLine("ResetTime: {0}", item.ResetTime);
                    Console.WriteLine("SourceID: {0}", item.SourceID);
                    Console.WriteLine("SourceType: {0}", item.SourceType);
                    Console.WriteLine("State: {0}", item.State);
                    Console.WriteLine("StateText: {0}", item.StateText);
                    Console.WriteLine("SuppressionState: {0}", item.SuppressionState);
                    Console.WriteLine("SystemSeverity: {0}", item.SystemSeverity);
                    Console.WriteLine("TextColor: {0}", item.TextColor);
                    Console.WriteLine("User: {0}", item.UserName);
                    Console.WriteLine("UserResponse: {0}", item.UserResponse);
                    Console.WriteLine("Value: {0}", item.Value);
                    Console.WriteLine("ValueLimit: {0}", item.ValueLimit);
                    Console.WriteLine("Notification Reason Type: {0}", item.NotificationReason);
                    Console.WriteLine("GroupID: {0}", item.AlarmGroupID);

                    AlarmList.Add(item);
                }
            }
            else
            {
                _event.Set();
            }
        }


        public void AcknowledgeAlarms()
        {
            SubscribeAlarm();

            if (AlarmList != null)
            {
                try
                {
                    foreach (var alarm in AlarmList)
                    {
                        var alarmAck = runtime.GetObject<IAlarm>(alarm.Name);
                        alarmAck.Acknowledge();
                    }
                }
                catch (OdkException ex)
                {
                    Console.WriteLine("OdkException occured {0}", ex.Message);
                }
            }
        }


        public void AcknowledgeAlarmSet()
        {
            SubscribeAlarm();

            if (AlarmList != null)
            {
                var alarmSet = runtime.GetObject<IAlarmSet>();
                foreach (var alarm in AlarmList)
                {
                    alarmSet.Add(alarm.Name);
                }

                //  Assign callback function
                alarmSet.OnAcknowledgeHandler += alarmSet_OnAcknowledgeHandler;
                try
                {
                    alarmSet.Acknowledge();
                    _ackevent.WaitOne();
                    _ackevent.Reset();
                }
                catch (OdkException ex)
                {
                    Console.WriteLine("OdkException occured {0}", ex.Message);
                }
            }
        }

        public void alarmSet_OnAcknowledgeHandler(IAlarmSet sender, uint errorCode, IList<IAlarmSetResult> values,
            bool completed)
        {
            try
            {
                foreach (var item in values)
                {
                    Console.WriteLine("InstanceId: {0} Name: {1} SystemName: {2} ", item.InstanceId, item.Name,
                        item.SystemName);
                }
            }
            finally
            {
                if (null != sender)
                {
                    sender.Dispose();
                    _ackevent.Set();
                }
            }
        }

        public void ResetAlarms()
        {
            SubscribeAlarm();

            if (AlarmList != null)
            {
                foreach (var alarm in AlarmList)
                {
                    var alarmAck = runtime.GetObject<IAlarm>(alarm.Name);
                    alarmAck.Reset();
                }
            }
        }

        public void ResetAlarmSet()
        {
            SubscribeAlarm();

            if (AlarmList != null)
            {
                var alarmSet = runtime.GetObject<IAlarmSet>();
                foreach (var alarmResult in AlarmList)
                {
                    alarmSet.Add(alarmResult.Name);
                }

                try
                {
                    alarmSet.OnResetHandler += alarmSet_OnReseteHandler;
                    alarmSet.Reset();
                    _resetevent.WaitOne();
                    _resetevent.Reset();
                }
                catch (OdkException ex)
                {
                    Console.WriteLine("OdkException occured {0}", ex.Message);
                }
            }
        }

        public void alarmSet_OnReseteHandler(IAlarmSet sender, uint errorCode, IList<IAlarmSetResult> values,
            bool completed)
        {
            try
            {
                foreach (var item in values)
                {
                    Console.WriteLine("InstanceId: {0} Name: {1} SystemName: {2} ", item.InstanceId, item.Name,
                        item.SystemName);
                }
            }
            finally
            {
                if (null != sender)
                {
                    sender.Dispose();
                    _resetevent.Set();
                }
            }
        }

        public void DisableAndEnableAlarms()
        {
            SubscribeAlarm();

            if (AlarmList != null)
            {
                try
                {
                    foreach (var alarmResult in AlarmList)
                    {
                        var alarmDisable = runtime.GetObject<IAlarm>(alarmResult.Name);
                        alarmDisable.Disable();
                    }

                    foreach (var alarmResult in AlarmList)
                    {
                        var alarmDisable = runtime.GetObject<IAlarm>(alarmResult.Name);
                        alarmDisable.Enable();
                    }
                }
                catch (OdkException ex)
                {
                    Console.WriteLine("OdkException occured {0}", ex.Message);
                }
            }
        }

        public void DisableAndEnableAlarmSet()
        {
            SubscribeAlarm();

            if (AlarmList != null)
            {
                try
                {
                    var alarmSet = runtime.GetObject<IAlarmSet>();
                    foreach (var alarmResult in AlarmList)
                    {
                        alarmSet.Add(alarmResult.Name);
                    }

                    alarmSet.OnDisableHandler += alarmSet_OnDisableHandler;
                    alarmSet.Disable();

                    _event.WaitOne();
                    _event.Reset();

                    alarmSet.OnEnableHandler += alarmSet_OnEnableHandler;
                    alarmSet.Enable();

                    _event.WaitOne();
                    _event.Reset();

                    alarmSet.Dispose();
                }
                catch (OdkException ex)
                {
                    Console.WriteLine("OdkException occured {0}", ex.Message);
                }
            }
        }

        public void alarmSet_OnDisableHandler(IAlarmSet sender, uint errorCode, IList<IAlarmSetResult> values,
            bool completed)
        {
            try
            {
                foreach (var item in values)
                {
                    Console.WriteLine("InstanceId: {0} Name: {1} SystemName: {2} ", item.InstanceId, item.Name,
                        item.SystemName);
                }
            }
            finally
            {
                if (null != sender)
                {
                    _event.Set();
                }
            }
        }

        public void alarmSet_OnEnableHandler(IAlarmSet sender, uint errorCode, IList<IAlarmSetResult> values,
            bool completed)
        {
            try
            {
                foreach (var item in values)
                {
                    Console.WriteLine("InstanceId: {0} Name: {1} SystemName: {2} ", item.InstanceId, item.Name,
                        item.SystemName);
                }
            }
            finally
            {
                if (null != sender)
                {
                    _event.Set();
                }
            }
        }

        public void ShelveAndUnShelveAlarms()
        {
            SubscribeAlarm();

            if (AlarmList != null)
            {
                try
                {
                    foreach (var alarmResult in AlarmList)
                    {
                        var alarmDisable = runtime.GetObject<IAlarm>(alarmResult.Name);
                        alarmDisable.Shelve();
                    }

                    foreach (var alarmResult in AlarmList)
                    {
                        var alarmDisable = runtime.GetObject<IAlarm>(alarmResult.Name);
                        alarmDisable.Unshelve();
                    }
                }
                catch (OdkException ex)
                {
                    Console.WriteLine("OdkException occured {0}", ex.Message);
                }
            }
        }

        public void ShelveAndUnShelveAlarmSet()
        {
            SubscribeAlarm();

            if (AlarmList != null)
            {
                try
                {
                    var alarmSet = runtime.GetObject<IAlarmSet>();
                    foreach (var alarmResult in AlarmList)
                    {
                        alarmSet.Add(alarmResult.Name);
                    }

                    alarmSet.OnShelveHandler += alarmSet_OnShelveHandler;
                    alarmSet.Shelve();

                    _event.WaitOne();
                    _event.Reset();

                    alarmSet.OnUnshelveHandler += alarmSet_OnUnshelveHandler;
                    alarmSet.Unshelve();

                    _event.WaitOne();
                    _event.Reset();

                    alarmSet.Dispose();
                }
                catch (OdkException ex)
                {
                    Console.WriteLine("OdkException occured {0}", ex.Message);
                }
            }
        }

        public void alarmSet_OnShelveHandler(IAlarmSet sender, uint errorCode, IList<IAlarmSetResult> values,
            bool completed)
        {
            try
            {
                foreach (var item in values)
                {
                    Console.WriteLine("InstanceId: {0} Name: {1} SystemName: {2} ", item.InstanceId, item.Name,
                        item.SystemName);
                }
            }
            finally
            {
                if (null != sender)
                {
                    _event.Set();
                }
            }
        }


        public void alarmSet_OnUnshelveHandler(IAlarmSet sender, uint errorCode, IList<IAlarmSetResult> values,
            bool completed)
        {
            try
            {
                foreach (var item in values)
                {
                    Console.WriteLine("InstanceId: {0} Name: {1} SystemName: {2} ", item.InstanceId, item.Name,
                        item.SystemName);
                }
            }
            finally
            {
                if (null != sender)
                {
                    _event.Set();
                }
            }
        }

        public void AcknowledgeAlarmByInstanceId()
        {
            SubscribeAlarm();

            if (AlarmList != null)
            {
                try
                {
                    foreach (var alarm in AlarmList)
                    {
                        var alarmAck = runtime.GetObject<IAlarm>(alarm.Name);
                        alarmAck.Acknowledge(alarm.InstanceID);
                    }
                }
                catch (OdkException ex)
                {
                    Console.WriteLine("OdkException occured {0}", ex.Message);
                }
            }
        }

        public void AcknowledgeAlarmsByInstanceId()
        {
            SubscribeAlarm();

            if (AlarmList != null)
            {
                var alarmSet = runtime.GetObject<IAlarmSet>();
                foreach (var alarmResult in AlarmList)
                {
                    var alarm = alarmSet.Add(alarmResult.Name, alarmResult.InstanceID);
                }

                //  Assign callback function
                alarmSet.OnAcknowledgeHandler += alarmSet_OnAcknowledgeAlarmHandle;
                try
                {
                    alarmSet.Acknowledge();
                    _ackevent.WaitOne();
                    _ackevent.Reset();
                }
                catch (OdkException ex)
                {
                    Console.WriteLine("OdkException occured {0}", ex.Message);
                }
            }
        }

        public void alarmSet_OnAcknowledgeAlarmHandle(IAlarmSet sender, uint errorCode, IList<IAlarmSetResult> values,
            bool completed)
        {
            try
            {
                foreach (var item in values)
                {
                    Console.WriteLine("InstanceId: {0} Name: {1} SystemName: {2} ", item.InstanceId, item.Name,
                        item.SystemName);
                }
            }
            finally
            {
                if (null != sender && completed)
                {
                    sender.Dispose();
                    _ackevent.Set();
                }
            }
        }

        public void ReseteAlarmByInstanceId()
        {
            SubscribeAlarm();

            if (AlarmList != null)
            {
                foreach (var alarmResult in AlarmList)
                {
                    var alarm = runtime.GetObject<IAlarm>(alarmResult.Name);
                    alarm.Reset(alarmResult.InstanceID);
                }
            }
        }

        public void ResetAlarmsByInstanceId()
        {
            SubscribeAlarm();

            if (AlarmList != null)
            {
                var alarmSet = runtime.GetObject<IAlarmSet>();
                foreach (var alarmResult in AlarmList)
                {
                    var alarm = alarmSet.Add(alarmResult.Name, alarmResult.InstanceID);
                }

                //  Assign callback function
                alarmSet.OnResetHandler += alarmSet_OnReseteAlarmHandler;
                try
                {
                    alarmSet.Reset();
                    _resetevent.WaitOne();
                    _resetevent.Reset();
                }
                catch (OdkException ex)
                {
                    Console.WriteLine("OdkException occured {0}", ex.Message);
                }
            }
        }

        public void alarmSet_OnReseteAlarmHandler(IAlarmSet sender, uint errorCode, IList<IAlarmSetResult> values,
            bool completed)
        {
            try
            {
                foreach (var item in values)
                {
                    Console.WriteLine("InstanceId: {0} Name: {1} SystemName: {2} ", item.InstanceId, item.Name,
                        item.SystemName);
                }
            }
            finally
            {
                if (null != sender)
                {
                    sender.Dispose();
                    _resetevent.Set();
                }
            }
        }

        private void Alarm_OnDataChanged(IAlarmLoggingSubscription sender, uint errorCode,
           IList<ILoggedAlarmResult> values)
        {
            if (sender != null && errorCode == 0)
            {
                foreach (var item in values)
                {
                    Console.WriteLine("Name: {0}", item.Name);
                    Console.WriteLine("AlarmClass: {0}", item.AlarmClassName);
                    IReadOnlyList<object> paramValue = item.AlarmParameterValues;
                    for (int Index = 0; Index < paramValue.Count; Index++)
                    {
                        Console.WriteLine("AlarmParameterValues_{0} :{1}", Index, paramValue[Index]);
                    }
                    Console.WriteLine("Area: {0}", item.Area);
                    Console.WriteLine("EventText: {0}", item.EventText);
                    Console.WriteLine("Origin: {0}", item.Origin);
                    Console.WriteLine("User: {0}", item.UserName);
                }
                _event.Set();
            }
            else
            {
                _event.Set();
            }
        }
        public void CreateOperatorInputInformation()
        {
            try
            {
                var alarm = runtime.GetObject<IAlarmLoggingSubscription>();
                var systemNames = new List<string>();
                systemNames.Add("SYSTEM1");

                // Assign alarm handler
                alarm.OnDataChanged += Alarm_OnDataChanged;
                String strTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK");
                alarm.Filter = "AlarmClassName = 'OperatorInputInformation' AND ModificationTime >= '" + strTime + "'";
                alarm.Language = 1033;
                alarm.SystemNames = systemNames;
                alarm.Start();

                using (var systemAlarm = runtime.GetObject<IAlarmTrigger>())
                {
                    systemAlarm.CreateOperatorInputInformation(alarmText: "Alarm Text", area: "Alarm Area",
                        alarmParameterValue1: "param1",
                        alarmParameterValue2: "param2",
                        alarmParameterValue3: "param3",
                        alarmParameterValue4: "param4",
                        alarmParameterValue5: "param5",
                        alarmParameterValue6: "param6",
                        alarmParameterValue7: "param7");
                }
                _event.WaitOne();
                _event.Reset();

                //stop alarm subscription
                alarm.Stop();

                //Dispose alarm object
                alarm.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);

            }

        }

        public void CreateSystemInformation()
        {
            try
            {
                var alarm = runtime.GetObject<IAlarmLoggingSubscription>();
                var systemNames = new List<string>();
                systemNames.Add("SYSTEM1");

                // Assign alarm handler
                alarm.OnDataChanged += Alarm_OnDataChanged;
                String strTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK");
                alarm.Filter = "AlarmClassName = 'SystemInformation' AND ModificationTime >= '" + strTime + "'";
                alarm.Language = 1033;
                alarm.SystemNames = systemNames;
                alarm.Start();

                using (var systemAlarm = runtime.GetObject<IAlarmTrigger>())
                {

                    systemAlarm.CreateSystemInformation(alarmText: "Alarm Text", area: "Area",
                        alarmParameterValue1: "param1",
                        alarmParameterValue2: "param2",
                        alarmParameterValue3: "param3",
                        alarmParameterValue4: "param4",
                        alarmParameterValue5: "param5",
                        alarmParameterValue6: "param6",
                        alarmParameterValue7: "Param7");

                }

                _event.WaitOne();
                _event.Reset();

                //stop alarm subscription
                alarm.Stop();

                //Dispose alarm object
                alarm.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }


        }

        public void CreateSystemAlarm()
        {
            try
            {
                var alarm = runtime.GetObject<IAlarmSubscription>();
                var systemNames = new List<string>();
                systemNames.Add("SYSTEM1");
                alarm.OnAlarmHandler += alarm_OnAlarmHandler;
                alarm.OnPendingAlarmCompleteHandler += Alarm_OnPendingAlarmCompleteHandler;
                alarm.Filter = "AlarmClassName = 'SystemAlarmWithoutClearEvent'";
                alarm.Language = 1033;
                alarm.SystemNames = systemNames;
                alarm.Start();

                using (var systemAlarm = runtime.GetObject<IAlarmTrigger>())
                {

                    systemAlarm.CreateSystemAlarm(alarmText: "Alarm Text", area: "Area",
                        alarmParameterValue1: "Param1",
                        alarmParameterValue2: "Param2",
                        alarmParameterValue3: "Param3",
                        alarmParameterValue4: "Param4",
                        alarmParameterValue5: "Param5",
                        alarmParameterValue6: "Param6",
                        alarmParameterValue7: "Param7");
                }
                _event.WaitOne();
                _event.Reset();

                //stop alarm subscription
                alarm.Stop();

                //Dispose alarm object
                alarm.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }


        }
        public void CreateSystemAlarmWithAlarmTextAsTextList()
        {
            try
            {
                var alarm = runtime.GetObject<IAlarmSubscription>();
                var systemNames = new List<string>();
                systemNames.Add("SYSTEM1");
                alarm.OnAlarmHandler += alarm_OnAlarmHandler;
                alarm.OnPendingAlarmCompleteHandler += Alarm_OnPendingAlarmCompleteHandler;
                alarm.Filter = "AlarmClassName = 'SystemAlarmWithoutClearEvent'";
                alarm.Language = 1033;
                alarm.SystemNames = systemNames;
                alarm.Start();

                using (var systemAlarm = runtime.GetObject<IAlarmTrigger>())
                {
                    using (var texlistforAlarmText = runtime.GetObject<ITextList>())
                    {
                        // Text list: AlarmTextTemplate
                        // Test list entry index: 101
                        // Text: "My input msg. input value  = @1%d@"
                        texlistforAlarmText.Name = "AlarmTextTemplate";
                        texlistforAlarmText.TextListEntryIndex = 101;
                        systemAlarm.CreateSystemAlarm(alarmText: texlistforAlarmText, area: "Area",
                            alarmParameterValue1: "125"); // dynamic value for format specifier @1%d@
                            
                    }
                }
                _event.WaitOne();
                _event.Reset();

                //stop alarm subscription
                alarm.Stop();

                //Dispose alarm object
                alarm.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void CreateSystemAlarmWithTextListAsParameterValue()
        {
            try
            {
                var alarm = runtime.GetObject<IAlarmSubscription>();
                var systemNames = new List<string>();
                systemNames.Add("SYSTEM1");
                alarm.OnAlarmHandler += alarm_OnAlarmHandler;
                alarm.OnPendingAlarmCompleteHandler += Alarm_OnPendingAlarmCompleteHandler;
                alarm.Filter = "AlarmClassName = 'SystemAlarmWithoutClearEvent'";
                alarm.Language = 1033;
                alarm.SystemNames = systemNames;
                alarm.Start();

                using (var systemAlarm = runtime.GetObject<IAlarmTrigger>())
                {
                    using (var textList1 = runtime.GetObject<ITextList>("Text_List_1"))
                    {
                        using (var textList2 = runtime.GetObject<ITextList>("Text_List_2"))
                        {
                            textList1.TextListEntryIndex = 1; //Eng TL @1%t#2T@ Val: @3%s@        
                            systemAlarm.CreateSystemAlarm(alarmText: textList1, area: "Area",
                            alarmParameterValue1: 1, // Index of nested textList2
                            alarmParameterValue2: textList2, // text list object
                            alarmParameterValue3: "Hello"); //  Dynamic value of  @3%s@  
                        }
                    }

                }
                _event.WaitOne();
                _event.Reset();

                //stop alarm subscription
                alarm.Stop();

                //Dispose alarm object
                alarm.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }
    }
}
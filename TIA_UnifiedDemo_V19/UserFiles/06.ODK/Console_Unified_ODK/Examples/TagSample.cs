using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Siemens.Runtime.HmiUnified;

namespace Siemens.Runtime.HmiIL.TestClient
{
    class TagSample
    {
        private readonly IRuntime runtime = Start.runtime;
        private readonly ManualResetEvent _event = new ManualResetEvent(false);

        public void ReadSingleTagSync()
        {
            try
            {
                using (var myTag = runtime.GetObject<ITag>("10_OpenRT_Tag_1"))
                {
                    var value = myTag.Read(HmiReadType.Cache); // Reads value from Cache
                    Console.WriteLine("Name: {0} Timestamp: {1} Value: {2} Quality: {3}", value.Name, value.TimeStamp,
                        value.Value, value.Quality);
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void ReadNotExistingSingleTagSync()
        {
            try
            {
                using (var myTag = runtime.GetObject<ITag>("NotExistingTag1"))
                {
                    var value = myTag.Read(HmiReadType.Cache); // Reads value from Cache
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
                Console.WriteLine("Tag read error: {0} ", ex.ErrorCode);
            }
        }

        public void WriteSingleTagSync()
        {
            try
            {
                using (var odkTag = runtime.GetObject<ITag>("10_OpenRT_Tag_1"))
                {
                    var value = 5;
                    odkTag.Write(value, HmiWriteType.NoWait);
                    // Writes value without waiting that value has been written to PLC
                    var pvalue = odkTag.Read(HmiReadType.Cache);
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void WriteNotExistingSingleTagSync()
        {
            try
            {
                using (var odkTag = runtime.GetObject<ITag>("NotExistingTag1"))
                {
                    var value = 5;
                    odkTag.Write(value, HmiWriteType.NoWait);
                    // Writes value without waiting that value has been written to PLC
                    var pvalue = odkTag.Read(HmiReadType.Cache);
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
                Console.WriteLine("Tag write error: {0} ", ex.ErrorCode);
            }
        }

        public void WriteTagSetSync()
        {
            try
            {
                using (var odkTagSet = runtime.GetObject<ITagSet>())
                {
                    odkTagSet.Add("10_OpenRT_Tag_1", 1);
                    odkTagSet.Add("10_OpenRT_Tag_2", 2);
                    IList<IErrorResult> res = odkTagSet.Write(HmiWriteType.Wait);
                    if (res != null)
                    {
                        var error = runtime.GetObject<IErrorInfo>();
                        foreach (var item in res)
                        {
                            if (item.Error != 0)
                            {
                                Console.WriteLine("{0} {1}", item.Name, error.GetErrorDescription(item.Error));
                            }
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        public void WritePartlyNotExistingTagSetSync()
        {
            try
            {
                using (var odkTagSet = runtime.GetObject<ITagSet>())
                {
                    odkTagSet.Add("10_OpenRT_Tag_1", 1);
                    odkTagSet.Add("10_OpenRT_Tag_2", 2);
                    odkTagSet.Add("NotExistingTag1", 1);
                    odkTagSet.Add("NotExistingTag2", 2);

                    var writeResult = odkTagSet.Write(HmiWriteType.Wait);
                    if (writeResult != null)
                    {
                        foreach (var result in writeResult)
                        {
                            if (result.Error != 0)
                            {
                                Console.WriteLine("Write tag '{0}' failed, error code {1}", result.Name, result.Error);
                            }
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void WriteTagSetQCDSync()
        {
            try
            {
                using (var odkTagSet = runtime.GetObject<ITagSetQCD>())
                {
                    odkTagSet.Add("10_OpenRT_Tag_1", 1, DateTime.Now, 128);
                    odkTagSet.Add("10_OpenRT_Tag_2", 2, DateTime.Now, 128);

                    var writeResult = odkTagSet.Write();
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }



        public void WriteTagSetQCDSyncWithQCBAD()
        {
            try
            {
                using (var odkTagSetQCD = runtime.GetObject<ITagSetQCD>())
                {
                    odkTagSetQCD.Add("HMI_10_OpenRT_Tag_1", 3, DateTime.Now, 1000);
                    odkTagSetQCD.Add("10_OpenRT_Tag_2", 1, DateTime.Now, 1000);

                    var writeResult = odkTagSetQCD.Write();

                }

                using (var odkTagSet = runtime.GetObject<ITagSet>())
                {
                    odkTagSet.Add("HMI_10_OpenRT_Tag_1");
                    odkTagSet.Add("10_OpenRT_Tag_2");
                    var readResult = odkTagSet.Read(HmiReadType.Device);
                    foreach (var values in readResult)
                    {
                        Console.WriteLine("Name:{0} Error: {1} Timestamp: {2} Quality: {3}", values.Name, values.Error, values.TimeStamp, values.Quality);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        /// <summary>
        /// WriteSingleTagQCDSync
        /// </summary>
        public void WriteSingleTagQCDSync()
        {
            try
            {
                using (var odkTag = runtime.GetObject<ITag>("10_OpenRT_Tag_1"))
                {
                    var value = 5;
                    odkTag.WriteQCD(value, DateTime.Now, 128, HmiWriteType.NoWait);

                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }



        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////


        public void WriteTagSetSyncWithChange()
        {
            try
            {
                using (var odkTagSet = runtime.GetObject<ITagSet>())
                {
                    odkTagSet.Add(new[] { "10_OpenRT_Tag_1", "10_OpenRT_Tag_2" });

                    // Modify the value of a tag in the tagset and write
                    odkTagSet["10_OpenRT_Tag_1"] = 5;
                    odkTagSet.Write();
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void ReadTagSetSync()
        {
            try
            {
                using (var odkTagSet = runtime.GetObject<ITagSet>())
                {
                    odkTagSet.Add(new[] { "10_OpenRT_Tag_1", "10_OpenRT_Tag_2" });

                    var values = odkTagSet.Read();

                    foreach (var value in values)
                    {
                        Console.WriteLine("Name: {0} Timestamp: {1} Value: {2} Quality: {3}", value.Name,
                            value.TimeStamp, value.Value, value.Quality);
                        // Get Type information
                        PrintProcessValue(value);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void ReadPartlyNotExistingTagSetSync()
        {
            try
            {
                using (var odkTagSet = runtime.GetObject<ITagSet>())
                {
                    odkTagSet.Add(new[] { "10_OpenRT_Tag_1", "10_OpenRT_Tag_2", "NotExistingTag1", "NotExistingTag2" });

                    var values = odkTagSet.Read();

                    foreach (var value in values)
                    {
                        if (value.Error == 0)
                        {
                            Console.WriteLine("Name: {0} Timestamp: {1} Value: {2} Quality: {3}", value.Name,
                                value.TimeStamp, value.Value, value.Quality);
                        }
                        else
                        {
                            Console.WriteLine("Read Tag Name: {0} failed, error code: {1}", value.Name, value.Error);
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void ReadTagSetAsync()
        {
            try
            {
                var odkTagSet = runtime.GetObject<ITagSet>();
                odkTagSet.Add(new[] { "10_OpenRT_Tag_1", "10_OpenRT_Tag_2" });

                // Assign callback function
                odkTagSet.OnReadResult += OdkTagSet_OnReadResult;
                odkTagSet.ReadAsync();
                _event.WaitOne();
                _event.Reset();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        private void OdkTagSet_OnReadResult(ITagSet sender, IList<IProcessValue> values, bool completed)
        {
            try
            {
                foreach (var value in values)
                    Console.WriteLine("Name: {0} Timestamp: {1} Value: {2} Quality: {3}", value.Name, value.TimeStamp,
                        value.Value, value.Quality);
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
            finally
            {
                if (null != sender && completed)
                {
                    sender.Dispose();
                    _event.Set();
                }
            }
        }

        public void ReadPartlyNotExistingTagSetAsync()
        {
            try
            {
                ITagSet odkTagSet = runtime.GetObject<ITagSet>();
                odkTagSet.Add(new[] { "10_OpenRT_Tag_1", "10_OpenRT_Tag_2", "NotExistingTag1", "NotExistingTag2" });

                // Assign callback function
                odkTagSet.OnReadResult += OdkPartlyNotExistingTagSet_OnReadResult;
                odkTagSet.ReadAsync();
                _event.WaitOne();
                _event.Reset();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }

        }

        private void OdkPartlyNotExistingTagSet_OnReadResult(ITagSet sender, IList<IProcessValue> values, bool completed)
        {
            try
            {
                foreach (var value in values)
                {
                    if (value.Error == 0)
                    {
                        Console.WriteLine("Name: {0} Timestamp: {1} Value: {2} Quality: {3}", value.Name,
                            value.TimeStamp, value.Value, value.Quality);
                    }
                    else
                    {
                        Console.WriteLine("Read Tag Name: {0} failed, error code: {1}", value.Name, value.Error);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
            finally
            {
                if (null != sender && completed)
                {
                    sender.Dispose();
                    _event.Set();
                }
            }
        }

        public void WriteTagSetAsync()
        {
            try
            {
                var odkTagSet = runtime.GetObject<ITagSet>();
                odkTagSet.Add("10_OpenRT_Tag_1", 1);
                odkTagSet.Add("10_OpenRT_Tag_2", 2);

                // Assign callback function
                odkTagSet.OnWriteResult += OdkTagSet_OnWriteResult;
                odkTagSet.WriteAsync();
                _event.WaitOne();
                _event.Reset();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        private void OdkTagSet_OnWriteResult(ITagSet sender, IList<IErrorResult> values, bool completed)
        {
            try
            {
                foreach (var value in values)
                {
                    if (value.Error != 0)
                    {
                        Console.WriteLine("Error = {0} Name = {1}", value.Error, value.Name);
                    }
                }
            }
            finally
            {
                if (null != sender && completed)
                {
                    sender.Dispose();
                    _event.Set();
                }
            }
        }

        public void WritePartlyNotExistingTagSetAsync()
        {
            try
            {
                var odkTagSet = runtime.GetObject<ITagSet>();
                odkTagSet.Add("10_OpenRT_Tag_1", 1);
                odkTagSet.Add("10_OpenRT_Tag_2", 2);
                odkTagSet.Add("NotExistingTag1", 1);
                odkTagSet.Add("NotExistingTag2", 2);

                // Assign callback function
                odkTagSet.OnWriteResult += OdkPartlyNotExistingTagSet_OnWriteResult;
                odkTagSet.WriteAsync();
                _event.WaitOne();
                _event.Reset();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        private void OdkPartlyNotExistingTagSet_OnWriteResult(ITagSet sender, IList<IErrorResult> values, bool completed)
        {
            try
            {
                foreach (var result in values)
                {
                    if (result.Error != 0)
                    {
                        Console.WriteLine("Write tag '{0}' failed, error code {1}", result.Name, result.Error);
                    }
                }
            }
            finally
            {
                if (null != sender && completed)
                {
                    sender.Dispose();
                    _event.Set();
                }
            }
        }

        public void SubscribeTagSet()
        {
            try
            {
                var odkTagSet = runtime.GetObject<ITagSet>();
                odkTagSet.Add(new[] { "10_OpenRT_Tag_1", "10_OpenRT_Tag_2" });

                // Assign callback function
                odkTagSet.OnDataChanged += OdkTagSet_OnDataChanged;
                odkTagSet.Subscribe();
                _event.WaitOne();
                _event.Reset();

                odkTagSet.CancelSubscribe();
                odkTagSet.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void OdkTagSet_OnDataChanged(ITagSet sender, IList<IProcessValue> pItems)
        {
            try
            {
                foreach (var value in pItems)
                    Console.WriteLine("Name: {0} Timestamp: {1} Value: {2} Quality: {3}", value.Name, value.TimeStamp,
                        value.Value, value.Quality);

                // For test purpose: Cancel subscription after first notification
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
            finally
            {
                _event.Set();
            }
        }




        public void TagWriteWithOperatorMsg()
        {
            try
            {
                // Create AlarmSubscription
                IAlarmSubscription alarm = CreateSubscription();
                alarm.Start();
                using (var odkTag = runtime.GetObject<ITag>("10_OpenRT_Tag_1"))
                {
                    //int value = 5;
                    var value = "value";
                    odkTag.WriteWithOperatorMessage(value, "Tag_Reason");
                }

                _event.WaitOne();
                _event.Reset();
                alarm.Stop();
                alarm.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void TagSetWriteWithOperatorMsg()
        {
            try
            {
                // Create AlarmSubscription
                IAlarmSubscription alarm = CreateSubscription();
                alarm.Start();
                using (var odkTagSet = runtime.GetObject<ITagSet>())
                {
                    //odkTagSet.Add("10_OpenRT_Tag_2", "Failed");
                    odkTagSet.Add("10_OpenRT_Tag_1", 2);
                    odkTagSet.WriteWithOperatorMessage("Reason");
                }

                _event.WaitOne();
                _event.Reset();
                alarm.Stop();
                alarm.Dispose();

            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public IAlarmSubscription CreateSubscription()
        {
            IAlarmSubscription alarm;
            try
            {
                alarm = runtime.GetObject<IAlarmSubscription>();
                var systemNames = new List<string>();
                systemNames.Add("SYSTEM1");
                // Assign alarm handler
                alarm.OnAlarmHandler += Alarm_OnAlarmHandler;
                alarm.Filter = "AlarmClassName != 'SystemWarning'";
                alarm.Language = 1033;
                alarm.SystemNames = systemNames;
                return alarm;
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }

            return null;
        }

        public void Alarm_OnAlarmHandler(IAlarmSubscription sender, uint nGlobalError, string systemName,
            IList<IAlarmResult> value)
        {
            if (0 == nGlobalError)
            {
                try
                {
                    foreach (var item in value)
                    {
                        Console.WriteLine(
                            "InstanceID: {0} SourceID: {1} Name: {2} State: {3} EventText: {4} StateText: {5} BackColor: {6} Flashing: {7}  ModificationTime: {8}",
                            item.InstanceID, item.SourceID, item.Name, item.State, item.EventText, item.StateText,
                            item.BackColor, item.Flashing, item.ModificationTime);
                    }
                }
                finally
                {
                    _event.Set();
                }
            }
            else
            {
                Console.WriteLine("AlarmSubscription Failed");
            }
        }

        /// <summary>
        ///     Checks the data type of the process value and displays it in the console
        /// </summary>
        /// <param name="processValue">process value</param>
        private void PrintProcessValue(IProcessValue processValue)
        {
            var value = processValue.Value;
            if (value != null)
            {
                if (value.GetType() == typeof(sbyte))
                {
                    var v = (sbyte)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(string))
                {
                    var v = (string)value;

                    Print(value.GetType(), v);
                }

                if (value.GetType() == typeof(byte))
                {
                    var v = (byte)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(int))
                {
                    var v = (int)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(uint))
                {
                    var v = (uint)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(short))
                {
                    var v = (short)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(ushort))
                {
                    var v = (ushort)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(long))
                {
                    var v = (long)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(ulong))
                {
                    var v = (ulong)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(float))
                {
                    var v = (float)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(double))
                {
                    var v = (double)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(char))
                {
                    var v = (char)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(bool))
                {
                    var v = (bool)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(decimal))
                {
                    var v = (decimal)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(DateTime))
                {
                    var v = (DateTime)value;

                    Print(value.GetType(), v.ToString());
                }

                if (value.GetType() == typeof(TimeSpan))
                {
                    var v = (TimeSpan)value;

                    Print(value.GetType(), v.ToString());
                }
            }
        }

        private void Print(Type type, string value)
        {
            Console.WriteLine("Data type [{0}] \twith value: {1}", type, value);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
        }

        public void BrowseTagSyncWithEmptyFilter()
        {
            try
            {
                using (var odkTags = runtime.GetObject<ITags>())
                {
                    uint daLanguage = 1033;

                    var systemNames = new List<string>();
                    systemNames.Add("RUNTIME_1");
                    var filter = "";
                    var tagAttributes = odkTags.Find(systemNames, filter, daLanguage);
                    foreach (var values in tagAttributes)
                    {
                        Printvalues(values);
                    }
                }
            }

            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void BrowseExactCpmNodeMember()
        {
            try
            {
                using (var odkTags = runtime.GetObject<ITags>())
                {
                    uint daLanguage = 1033;

                    var systemNames = new List<string>();
                    systemNames.Add("RUNTIME_1");
                    var filter = "RUNTIME_1::CpmNode.NewMember_1";
                    var tagAttributes = odkTags.Find(systemNames, filter, daLanguage);
                    foreach (var values in tagAttributes)
                    {
                        Printvalues(values);
                    }
                }
            }

            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void BrowseAllTags()
        {
            try
            {
                using (var odkTags = runtime.GetObject<ITags>())
                {
                    uint daLanguage = 1033;

                    var systemNames = new List<string>();
                    systemNames.Add("RUNTIME_1");
                    var filter = "*";
                    var tagAttributes = odkTags.Find(systemNames, filter, daLanguage);
                    foreach (var values in tagAttributes)
                    {
                        Printvalues(values);
                    }
                }
            }

            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        private void Printvalues(ITagAttributes values)
        {
            Console.WriteLine("Name: {0} ", values.Name);
            Console.WriteLine("Persistent: {0}", values.Persistent);
            Console.WriteLine("DataType: {0}", values.DataType);
            Console.WriteLine("DisplayName: {0}", values.DisplayName);
            Console.WriteLine("InitialValue: {0}", values.InitialValue);
            Console.WriteLine("SubstituteValue: {0}", values.SubstituteValue);
            Console.WriteLine("MaxLength: {0}", values.MaxLength);
            Console.WriteLine("Connection: {0}", values.Connection);
            Console.WriteLine("AcquisitionMode: {0}", values.AcquisitionMode);
            Console.WriteLine("AcquisitionCycle: {0}", values.AcquisitionCycle);
            Console.WriteLine("InitialMinValue: {0} ", values.InitialMinValue);
            Console.WriteLine("InitialMaxValue: {0} ", values.InitialMaxValue);
            Console.WriteLine("SubstituteValueUsage: {0}", values.SubstituteValueUsage);
        }


        public void BrowseTagsAsync()
        {
            try
            {
                using (var odkTags = runtime.GetObject<ITags>())
                {
                    uint daLanguage = 1033;
                    var filter = "";
                    var systemNames = new List<string>();
                    systemNames.Add("RUNTIME_1");
                    odkTags.OnTagAttributesRecieved += OnTags_AttributesRecived;
                    odkTags.FindAsync(systemNames, filter, daLanguage);
                    _event.WaitOne();
                    _event.Reset();
                    odkTags.Dispose();
                }
            }

            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        public void BrowseSimpleTagsSync()
        {
            try
            {
                using (var odkTags = runtime.GetObject<ITags>())
                {
                    uint daLanguage = 1033;

                    var systemNames = new List<string>();
                    systemNames.Add("RUNTIME_1");
                    var filter = "Tag*";
                    var tagAttributes = odkTags.Find(systemNames, filter, daLanguage);
                    foreach (var values in tagAttributes)
                    {
                        Printvalues(values);
                    }
                }
            }

            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }
        public void BrowseSimpleTagsAsync()
        {
            try
            {
                using (var odkTags = runtime.GetObject<ITags>())
                {
                    uint daLanguage = 1033;
                    var filter = "Tag*";
                    var systemNames = new List<string>();
                    systemNames.Add("RUNTIME_1");
                    odkTags.OnTagAttributesRecieved += OnTags_AttributesRecived;
                    odkTags.FindAsync(systemNames, filter, daLanguage);
                    _event.WaitOne();
                    _event.Reset();
                    odkTags.Dispose();
                }
            }

            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }



        public void OnTags_AttributesRecived(ITags sender, ICollection<ITagAttributes> tagAttributes, bool completed)
        {
            try
            {
                if (tagAttributes != null)
                {
                    foreach (var values in tagAttributes)
                    {
                        Printvalues(values);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
            finally
            {
                if (completed)
                {
                    _event.Set();
                }
            }
        }


        public void WriteTagWithUTCTime()
        {
            try
            {
                using (var odkTag = runtime.GetObject<ITag>("10_OpenRT_Tag_2"))
                {
                    DateTime dt = DateTime.UtcNow;
                    odkTag.Write(dt, HmiWriteType.Wait);
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void WriteTagWithLocalTime()
        {
            try
            {
                using (var odkTag = runtime.GetObject<ITag>("10_OpenRT_Tag_2"))
                {
                    DateTime dt = DateTime.Now;
                    odkTag.Write(dt, HmiWriteType.Wait);
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }
    }
}
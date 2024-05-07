using System;
using System.Collections.Generic;
using System.Threading;
using Siemens.Runtime.HmiUnified;
using System.Text;

namespace Siemens.Runtime.HmiIL.TestClient
{
    class LoggingSample
    {
        private readonly ManualResetEvent _event = new ManualResetEvent(false);

        private readonly IRuntime _runtime = Start.runtime;

        /// <summary>
        ///     Reads historical tag data synchronous
        /// </summary>
        public void ReadSingleTag()
        {
            try
            {
                using (var tag = _runtime.GetObject<ILoggedTag>("Tag1:Tag1Logging1"))
                {
                    var begin = DateTime.UtcNow.AddMinutes(-10);
                    var end = DateTime.UtcNow;
                    var values = tag.Read(begin, end, true);
                    Print(values);
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     Print values to console
        /// </summary>
        /// <param name="values"></param>
        private void Print(IList<ILoggedTagValue> values)
        {
            foreach (var v in values)
            {
                UInt32 error = v.Error;

                if (error != 0)
                {
                    var pinfo = _runtime.GetObject<IErrorInfo>();
                    Console.WriteLine();
                    Console.WriteLine("Name: {0} Error:{1}", v.Name, pinfo.GetErrorDescription(error));
                }
                else
                {
                    Console.WriteLine("Name: {0} Timestamp: {1} Value: {2} Quality: {3}", v.Name, v.TimeStamp, v.Value,
                        v.Quality);
                }
                
            }
        }

        /// <summary>
        ///     Reads historical tag data synchronous via tag collection
        /// </summary>
        public void ReadTagSetSync()
        {
            try
            {
                var begin = DateTime.UtcNow.AddHours(-1);
                var end = DateTime.UtcNow;
                using (var tagSet = _runtime.GetObject<ILoggedTagSet>())
                {
                    tagSet.Add("Tag1:Tag1Logging1");
                    tagSet.Add("Tag3:Tag2Logging1");
                    var values = tagSet.Read(begin, end, true);
                    Print(values);
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        /// Read tags and save the result in CSV file.
        /// </summary>
        /// <param name="filePath">CSV file name</param>
        /// <param name="tags">tag names</param>
        /// <param name="begin">start time</param>
        /// <param name="end">end time</param>
        /// <param name="delimiter">CSV delimiter</param>
        public void ExportTags(string filePath, string[] tags, DateTime begin, DateTime end, char delimiter = ',')
        {
            using (var tagSet = _runtime.GetObject<ILoggedTagSet>(_runtime))
            {
                tagSet.Add(tags);
                var values = tagSet.Read(begin, end, true);

                if (values.Count == 0)
                    return;

                var csv = new StringBuilder();
                var line = string.Format("Name{0}Timestamp{0}Value{0}Quality", delimiter);
                csv.AppendLine(line);
                foreach (var v in values)
                {
                    line = string.Format("{0}{4}{1}{4}{2}{4}{3}", v.Name, v.TimeStamp, v.Value, v.Quality, delimiter);
                    csv.AppendLine(line);
                }

                System.IO.File.WriteAllText(filePath, csv.ToString());
            }
        }

        /// <summary>
        ///     Browse Logging tags synchronously
        /// </summary>
        public void BrowseLoggingTagsSync()
        {
            try
            {
                using (var odkTags = _runtime.GetObject<ILoggingTags>())
                {
                    uint daLanguage = 1033;
                    var filter = "*";
                    var systemNames = new List<string>();
                    systemNames.Add("RUNTIME_1");
                    var loggingtagAttributes = odkTags.Find(systemNames, filter, daLanguage);
                    foreach (var values in loggingtagAttributes)
                    {
                        Console.WriteLine("Name: {0} ", values.Name);
                        Console.WriteLine("DataType: {0}", values.DataType);
                        Console.WriteLine("DisplayName: {0}", values.DisplayName);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        /// <summary>
        ///     browse structure tag member and cpm member logging tags
        /// </summary>
        public void BrowseLoggingTagsForMembers()
        {
            try
            {
                using (var odkTags = _runtime.GetObject<ILoggingTags>())
                {
                    uint daLanguage = 1033;
                    var filter = "*::*.**:*";
                    

                    var systemNames = new List<string>();
                    systemNames.Add("RUNTIME_1");
                    var loggingtagAttributes = odkTags.Find(systemNames, filter, daLanguage);
                    foreach (var values in loggingtagAttributes)
                    {
                        Console.WriteLine("Name: {0} ", values.Name);
                        Console.WriteLine("DataType: {0}", values.DataType);
                        Console.WriteLine("DisplayName: {0}", values.DisplayName);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        public void BrowseLoggingTagsSyncWithEmptyFilter()
        {
            try
            {
                using (var odkTags = _runtime.GetObject<ILoggingTags>())
                {
                    uint daLanguage = 1033;
                    var filter = "";
                    var systemNames = new List<string>();
                    systemNames.Add("RUNTIME_1");
                    var loggingtagAttributes = odkTags.Find(systemNames, filter, daLanguage);
                    foreach (var values in loggingtagAttributes)
                    {
                        Console.WriteLine("Name: {0} ", values.Name);
                        Console.WriteLine("DataType: {0}", values.DataType);
                        Console.WriteLine("DisplayName: {0}", values.DisplayName);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     Browse logging tag with full name
        /// </summary>
        public void BrowseLoggingTagsSyncForExactTagName()
        {
            try
            {
                using (var odkTags = _runtime.GetObject<ILoggingTags>())
                {
                    uint daLanguage = 1033;
                    var filter = "node1.CPMChild1:CPMLoggingTag1";

                    var systemNames = new List<string>();
                    systemNames.Add("RUNTIME_1");
                    var loggingtagAttributes = odkTags.Find(systemNames, filter, daLanguage);
                    foreach (var values in loggingtagAttributes)
                    {
                        Console.WriteLine("Name: {0} ", values.Name);
                        Console.WriteLine("DataType: {0}", values.DataType);
                        Console.WriteLine("DisplayName: {0}", values.DisplayName);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        /// <summary>
        ///     Browse logging tags for struture/cpm member
        /// </summary>
        public void BrowseLoggingTagsSyncForMembers()
        {
            try
            {
                using (var odkTags = _runtime.GetObject<ILoggingTags>())
                {
                    uint daLanguage = 1033;
                    var filter = "Tag_0.*:*";

                    var systemNames = new List<string>();
                    systemNames.Add("RUNTIME_1");
                    var loggingtagAttributes = odkTags.Find(systemNames, filter, daLanguage);
                    foreach (var values in loggingtagAttributes)
                    {
                        Console.WriteLine("Name: {0} ", values.Name);
                        Console.WriteLine("DataType: {0}", values.DataType);
                        Console.WriteLine("DisplayName: {0}", values.DisplayName);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     Browse logging tag async
        /// </summary>
        public void BrowsweLoggingTagsAsync()
        {
            try
            {
                using (var odkLoggingTags = _runtime.GetObject<ILoggingTags>())
                {
                    uint daLanguage = 1033;
                    var filter = "";
                    var systemNames = new List<string>();
                    systemNames.Add("RUNTIME_1");
                    odkLoggingTags.OnLoggingTagAttributesReadRecieved += OnLoggingTags_AttributesRecived;
                    odkLoggingTags.FindAsync(systemNames, filter, daLanguage);
                    _event.WaitOne();
                    _event.Reset();
                }
            }

            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     Read a tag collection asynchronous, which means that result comes with callback function
        /// </summary>
        public void ReadTagSetAsync()
        {
            ILoggedTagSet tagSet = null;

            try
            {
                var begin = DateTime.UtcNow.AddHours(-1);
                var end = DateTime.UtcNow;
                tagSet = _runtime.GetObject<ILoggedTagSet>();
                tagSet.OnReadComplete += TagSet_OnReadComplete;
                tagSet.Add("Tag1:Tag1Logging1");
                tagSet.Add("Tag2:Tag2Logging1");
                tagSet.ReadAsync(begin, end, true);
                _event.WaitOne();
                _event.Reset();
            }
            catch (OdkException ex)
            {
                if(tagSet != null)
                    tagSet.Dispose();

                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void OnLoggingTags_AttributesRecived(ILoggingTags sender,
            ICollection<ILoggingTagAttributes> tagAttributes, bool completed)
        {
            try
            {
                if(null != tagAttributes)
                {
                    foreach (var values in tagAttributes)
                    {
                        Console.WriteLine("Name: {0} ", values.Name);
                        Console.WriteLine("Name:{0}", values.DisplayName);
                        Console.WriteLine("DataType: {0}", values.DataType);
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
                    sender.Dispose();
                    _event.Set();
                }
            }
        }

        private void TagSet_OnReadComplete(ILoggedTagSet sender, uint errorCode, IList<ILoggedTagValue> values,
            bool completed)
        {
            Print(values);

            if (completed)
            {
                sender.Dispose();
                _event.Set();
            }
        }

        /// <summary>
        ///     Subscribe a tag collection, which means that result comes with callback function
        /// </summary>
        public void SubscribeTagSet()
        {
            ILoggedTagSet tagSet = null;

            try
            {
                tagSet = _runtime.GetObject<ILoggedTagSet>();
                tagSet.Add("::Int_Tag_Log_1:LoggingTag_1");
                tagSet.OnDataChanged += tagSet_OnDataChanged;
                tagSet.Subscribe();
                _event.WaitOne();
                _event.Reset();
                tagSet.CancelSubscribe();
            }
            catch (OdkException ex)
            {               
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
            finally
            {                
                tagSet.Dispose();
            }
        }

        private void tagSet_OnDataChanged(ILoggedTagSet sender, uint errorCode, IList<ILoggedTagValue> values)
        {
            Print(values);
            _event.Set();           
        }
    }
}
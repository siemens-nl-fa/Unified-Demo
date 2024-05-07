using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siemens.Runtime.HmiUnified;
using System.Threading;

namespace Siemens.Runtime.HmiIL.TestClient
{
    class ContextLoggingSample
    {
        private readonly ManualResetEvent _event = new ManualResetEvent(false);

        private readonly IRuntime _runtime = Start.runtime;

        DateTime startDt, endDt;

        private string strContext_Unique_Num;
        public void CreateContextDefinitions()
        {
            Console.WriteLine("CreateContextDefinitions \n");
            try
            {
                var contextLogging = _runtime.GetObject<IContextLogging>();
                List<IContextDefinition> contextDefnitions = new List<IContextDefinition>();
                for (int i = 0; i < 5; i++)
                {
                    var contextDefinition = _runtime.GetObject<IContextDefinition>();
                    contextDefinition.PlantViewPath = ".hierarchy::Plant/Node1_1";
                    contextDefinition.DataType = HmiContextDataType.DInt;
                    Dictionary<UInt32, string> displayLanguages = new Dictionary<uint, string>();
                    displayLanguages[1033] = "english";
                    displayLanguages[1032] = "deutsch";
                    contextDefinition.DisplayNames = displayLanguages;
                    Random rnd = new Random();
                    int num = rnd.Next(1, 1000);
                    contextDefinition.Name = "CD_" + num + i.ToString();
                    contextDefnitions.Add(contextDefinition);
                }
                contextLogging.OnContextDefinitionCreate += ContextLogging_OnContextDefinitionCreate;
                contextLogging.CreateContextDefinitions(contextDefnitions);

                _event.WaitOne();
                _event.Reset();
                contextLogging.Dispose();

            }
            catch (OdkException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateContextDefinition()
        {
            Console.WriteLine("CreateContextDefinition \n");
            try
            {
                var contextLogging = _runtime.GetObject<IContextLogging>();
                List<IContextDefinition> contextDefnitions = new List<IContextDefinition>();

                var contextDefinition = _runtime.GetObject<IContextDefinition>();
                contextDefinition.PlantViewPath = ".hierarchy::Plant/Node1_1";
                contextDefinition.DataType = HmiContextDataType.String;
                Dictionary<UInt32, string> displayLanguages = new Dictionary<uint, string>();
                displayLanguages[1033] = "english";
                displayLanguages[1032] = "deutsch";
                contextDefinition.DisplayNames = displayLanguages;
                Random rnd = new Random();
                int num = rnd.Next(1, 1000);
                strContext_Unique_Num = num.ToString();
                var strContextName = "ContextName_" + strContext_Unique_Num;
                contextDefinition.Name = strContextName;
                contextDefnitions.Add(contextDefinition);
                contextLogging.OnContextDefinitionCreate += ContextLogging_OnContextDefinitionCreate;
                contextLogging.CreateContextDefinitions(contextDefnitions);

                _event.WaitOne();
                _event.Reset();
                contextLogging.Dispose();

            }
            catch (OdkException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ContextLogging_OnContextDefinitionCreate(IContextLogging sender, UInt32 globalError, string systemName, IList<IContextError> errors, bool completed)
        {
            try
            {
                if (globalError != 0)
                {
                    Console.WriteLine("System Name:{0} Error:{1}", systemName, globalError);

                }
                else
                {
                    PrintContextError(errors);
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (completed)
                {
                    _event.Set();
                }
            }
        }

        public void ReadContextDefinitionsWithOutFilter()
        {
            Console.WriteLine("ReadContextDefinitionsWithOutFilter \n");
            try
            {
                var contextLogging = _runtime.GetObject<IContextLogging>();
                contextLogging.OnContextDefinitionReadReply += OnContextDefinitionReadReplyForContextLogging;
                contextLogging.ReadContextDefinitions(sortingMode: HmiSortingMode.Ascending);

                _event.WaitOne();
                _event.Reset();
                contextLogging.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReadContextDefinitionsWithFilter()
        {
            Console.WriteLine("ReadContextDefinitionsWithFilter \n");
            try
            {
                var contextLogging = _runtime.GetObject<IContextLogging>();
                contextLogging.OnContextDefinitionReadReply += OnContextDefinitionReadReplyForContextLogging;
                List<string> plantobjectsfilter = new List<string>();
                plantobjectsfilter.Add(".hierarchy::Plant/Node1_1");
                List<HmiContextProviderType> contextProviderType = new List<HmiContextProviderType>();
                contextProviderType.Add(HmiContextProviderType.UserDefined);
                contextLogging.ReadContextDefinitions(plantViewPaths: plantobjectsfilter, providerTypes: contextProviderType, sortingMode: HmiSortingMode.Ascending);
                _event.WaitOne();
                _event.Reset();
                contextLogging.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void StartContext()
        {
            Console.WriteLine("StartContext \n");
            try
            {
                using (var contextLogging = _runtime.GetObject<IContextLogging>())
                {
                    startDt = System.DateTime.Now;
                    object value = "Orange Juice";
                    uint quality = 192;
                    var strContextName = "ContextName_" + strContext_Unique_Num;
                    var providerType = HmiContextProviderType.UserDefined;
                    var plantViewPath = ".hierarchy::Plant/Node1_1";
                    contextLogging.StartContext(strContextName, providerType, plantViewPath, value, startDt, quality); ;
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void StopContext()
        {
            Console.WriteLine("StopContext \n");
            try
            {
                using (var contextLogging = _runtime.GetObject<IContextLogging>())
                {
                    endDt = System.DateTime.Now;
                    var strContextName = "ContextName_" + strContext_Unique_Num;
                    var providerType = HmiContextProviderType.UserDefined;
                    var plantViewPath = ".hierarchy::Plant/Node1_1";
                    contextLogging.StopContext(strContextName, providerType,plantViewPath, endDt);
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReadContextWithFilter()
        {
            Console.WriteLine("ReadContextWithFilter \n");
            try
            {
                var contextLogging = _runtime.GetObject<IContextLogging>();
                contextLogging.OnLoggedContextReadReply += OnLoggedContextReadReplyForContextLogging;
                IContextFilter Filter = _runtime.GetObject<IContextFilter>();
                if (Filter != null)
                {
                    Filter.Name = "ContextName_" + strContext_Unique_Num;
                    Filter.ProviderType = HmiContextProviderType.UserDefined;
                    Filter.Operator = "=";
                    Filter.Value = "Orange Juice";
                    Filter.PlantViewPath = ".hierarchy::Plant/Node1_1";
                }
                contextLogging.ReadContexts(startDt, endDt, Filter, HmiSortingMode.Ascending);

                _event.WaitOne();
                _event.Reset();
                contextLogging.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReadContextWithoutFilter()
        {
            Console.WriteLine("ReadContextWithoutFilter \n");
            try
            {
                var contextLogging = _runtime.GetObject<IContextLogging>();
                contextLogging.OnLoggedContextReadReply += OnLoggedContextReadReplyForContextLogging;
                contextLogging.ReadContexts(startDt, endDt);
                _event.WaitOne();
                _event.Reset();
                contextLogging.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Subscribe()
        {
            Console.WriteLine("Subscribe \n");
            try
            {
                var contextLogging = _runtime.GetObject<IContextLogging>();
                contextLogging.OnContextDataChanged += OnContextDataChangedForContextLogging;
                CreateContextDefinition();

                var name = "ContextName_" + strContext_Unique_Num;
                var providerType = HmiContextProviderType.UserDefined;
                var plantViewPath = ".hierarchy::Plant/Node1_1";
                contextLogging.Add(name, providerType,plantViewPath);

                contextLogging.Subscribe();
                StartContext();
                StopContext();
                Thread.Sleep(2000);
                contextLogging.CancelSubscribe();
                contextLogging.Dispose();
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }

        }

        public void OnContextDataChangedForContextLogging(IContextLogging sender, IList<ILoggedContext> loggedContexts)
        {
            try
            {
                PrintLoggedContexts(loggedContexts);
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }
        void OnLoggedContextReadReplyForContextLogging(IContextLogging sender, UInt32 globalErrors, string systemName, IList<ILoggedContext> loggedContexts, bool completed)
        {
            try
            {
                if (globalErrors != 0)
                {
                    Console.WriteLine("System Name:{0} Error:{1}", systemName, globalErrors);
                }
                else
                {
                    PrintLoggedContexts(loggedContexts);
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

        void OnContextDefinitionReadReplyForContextLogging(IContextLogging sender, UInt32 globalErrors, string systemName,
            IList<IContextDefinition> contextDefinitions, bool completed)
        {
            try
            {
                if (globalErrors != 0)
                {
                    Console.WriteLine("System Name:{0} Error:{1}", systemName, globalErrors);

                }
                else
                {
                    PrintContextDefnitions(contextDefinitions);
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

        void PrintContextDefnitions(IList<IContextDefinition> contextDefinitionData)
        {
            try
            {
                if (null != contextDefinitionData)
                {
                    foreach (var cd in contextDefinitionData)
                    {
                        Console.WriteLine("PlantViewPath:{0} Name:{1} Datatype:{2} Error:{3}",
                            cd.PlantViewPath, cd.Name, cd.DataType, cd.Error);
                        Console.WriteLine();
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        void PrintLoggedContexts(IList<ILoggedContext> loggedContexts)
        {
            try
            {
                if (null != loggedContexts)
                {
                    foreach (var lc in loggedContexts)
                    {
                        Console.WriteLine("StartTime:{0} EndTime:{1} Value:{2} Quality:{3} Error:{4} Name:{5} PlantViewPath:{6} ProviderType:{7}",
                            lc.StartTime, lc.EndTime, lc.Value, lc.Quality, lc.Error,lc.Name,lc.PlantViewPath,lc.ProviderType);
                        Console.WriteLine();
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        void PrintContextError(IList<IContextError> errors)
        {
            try
            {
                if (null != errors)
                {
                    foreach (var error in errors)
                    {

                        Console.WriteLine("ContextName:{0} Error:{1}", error.Name, error.Error);
                        Console.WriteLine();

                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }
    }
}
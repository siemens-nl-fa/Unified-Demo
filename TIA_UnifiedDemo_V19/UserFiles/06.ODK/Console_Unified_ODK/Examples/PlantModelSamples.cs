using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Siemens.Runtime.HmiUnified;

namespace Siemens.Runtime.HmiIL.TestClient
{
    class PlantModelSamples
    {
        private readonly IRuntime _runtime = Start.runtime;
        private ManualResetEvent _event = new ManualResetEvent(false);


        /// <summary>
        ///     gets the plantObject
        ///     displays name and hierarchy paths of the fetched plantobjectusing getname and get View path methods.
        /// </summary>
        /// <returns>void</returns>
        public void Odk_GetPlantObject()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node1";

                    //gets node for specified Node path
                    using (var plantObject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("CurrentViewName: {0}, Name: {1}", plantObject.CurrentPlantView,
                            plantObject.Name);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     gets the plantObject
        ///     displays name and hierarchy paths of the fetched plantobjectusing getname and get View path methods.
        /// </summary>
        /// <returns>void</returns>
        public void Odk_GetPlantObjectbyID()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::PlantView";

                    //gets node for specified Node path
                    using (var plantObject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("CurrentViewName: {0} Name: {1}", plantObject.CurrentPlantView,
                            plantObject.Name);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     gets the PlantObjects by Type
        ///     displays name and View paths of the fetched PlantObjects using getname and get View path methods.
        /// </summary>
        /// <returns>void</returns>
        public void Odk_GetPlantObjectsByType()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    //gets node for specified Node path
                    var plantObject = myPlantModel.GetPlantObjectsByType("RUNTIME_1::NodeType1",
                        ".hierarchy::RootNodeName/Node1");
                    if (plantObject != null)
                    {
                        if (plantObject.Count() > 0)
                        {
                            foreach (var item in plantObject)
                            {
                                Console.WriteLine("ViewName: {0} Name: {1}", item.CurrentPlantView, item.Name);
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

        /// <summary>
        ///     gets the PlantObjects by Type
        ///     displays name and View paths of the fetched PlantObjects using getname and get View path methods.
        /// </summary>
        /// <returns>void</returns>
        public void Odk_GetPlantObjectsByType1()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    //gets node for specified Node path
                    var plantObject = myPlantModel.GetPlantObjectsByType("RUNTIME_1::NodeType1");
                    if (plantObject.Count() > 0)
                    {
                        foreach (var item in plantObject)
                        {
                            Console.WriteLine("ViewName: {0} Name: {1}", item.CurrentPlantView, item.Name);
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     gets the PlantObjects by PropertyNames
        ///     displays name and View paths of the fetched PlantObjects using getname and get View path methods.
        /// </summary>
        /// <returns>void</returns>
        public void Odk_GetPlantObjectsByPropertyNames()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    ICollection<string> propertyNames = new[] { "NodeProperty_1", "NodeProperty_2" };
                    //gets node for specified Node path
                    var plantObjects = myPlantModel.GetPlantObjectsByPropertyNames(propertyNames,
                        "RUNTIME_1.hierarchy::RootNodeName/Node4");
                    foreach (var plantObject in plantObjects)
                    {
                        Console.WriteLine("Name {0}", plantObject.Name);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        /// </summary>
        public void Odk_GetPlantObjectsByExpression()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    ICollection<string> propertyNames = new[] { "NodeProperty_1", "NodeProperty_2" };
                    var viewFilter = "RUNTIME_1.hierarchy";
                    var plantObjectTypeFilter = "NodeType1";
                    var expressionFilter = "NodeProperty_1 <= 0";

                    // gets  Plant Objects for specified filter
                    var value = myPlantModel.GetPlantObjectsByExpression(propertyNames, plantObjectTypeFilter,
                        expressionFilter, viewFilter);

                    if (value.Count() > 0)
                    {
                        foreach (var item in value)
                        {
                            Console.WriteLine("ViewName: {0} Name: {1}", item.CurrentPlantView, item.Name);
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        /// <summary>
        ///     Gets children of plantModel node
        ///     Displays node information  of plantobject and its Child nodes if child node is not Available it will retun null
        /// </summary>
        /// <returns>void</returns>
        public void Odk_PlantObjectGetChildren()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node3";

                    //gets node for specified Node path
                    using (var plantobject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("ViewName: {0} Name: {1}", plantobject.CurrentPlantView, plantobject.Name);

                        // Gets Children Cpm Node members 
                        var plantObjectList = plantobject.Children;

                        if (plantObjectList != null && plantObjectList.Count > 0)
                        {
                            foreach (var item in plantObjectList)
                            {
                                Console.WriteLine("ViewName: {0} Name: {1}", item.CurrentPlantView, item.Name);
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


        /// <summary>
        ///     Gets parent of  plant object
        ///     Displays name and hierarchy path of plantobjectand its parentNode
        /// </summary>
        /// <returns>void</returns>
        public void Odk_PlantObjectGetParent()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node3";

                    using (var plantObject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("ViewName: {0} Name: {1}", plantObject.CurrentPlantView, plantObject.Name);

                        //gets parent of specific node
                        using (var plantObjectChild = plantObject.Parent)
                        {
                            Console.WriteLine("ViewName: {0} Name: {1}", plantObjectChild.CurrentPlantView,
                                plantObjectChild.Name);
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     gets Properties Of Plant Object
        ///     gets the Count of properties
        /// </summary>
        /// <returns>void</returns>
        public void Odk_PlantObjectGetProperties()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node1";

                    using (var plantObject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("ViewName: {0} Name: {1}", plantObject.CurrentPlantView, plantObject.Name);

                        // get the  plant objectproperties by propeyty names
                        using (var plantObjectProperties = plantObject.GetProperties())
                        {
                            if (plantObjectProperties != null)
                            {
                                var nCount = plantObjectProperties.Count;
                                var listPropValues = plantObjectProperties.Read();
                                Console.WriteLine("Number of Properties {0}", nCount);
                                foreach (var item in listPropValues)
                                {
                                    Console.WriteLine("Property Name is {0}  ", item.Name);
                                    Console.WriteLine("Property Value is {0}  ", item.Value);
                                    Console.WriteLine("Property Quality is {0} ", item.Quality);
                                    Console.WriteLine("Property Error is {0} ", item.Error);
                                }
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

        /// <summary>
        ///     gets the specified property from the cpm node
        /// </summary>
        /// <returns>void</returns>
        public void Odk_PlantObjectGetPropertyByName()
        {
            try
            {
                Console.WriteLine("Odk_PlantObjectGetProperty");
                using (var myPlantmodel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node1";

                    //gets node for specified Node path
                    using (var plantObject = myPlantmodel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("ViewName: {0} Name: {1}", plantObject.CurrentPlantView, plantObject.Name);

                        var strName = "NodeProperty_1";
                        using (var pObjectProperty = plantObject.GetProperty(strName))
                        {
                            var pValue = pObjectProperty.Read();
                            Console.WriteLine("Property Name: {0} value: {1}", strName, pValue.Value);
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     writes the given value to the specified property of  plant object
        ///     this sample when run first time before and after it will print different values
        ///     from second time onwards it will print same value as
        ///     we already perform write operation before .to print different
        ///     value change the value from 400to some new value
        /// </summary>
        /// <returns>void</returns>
        public void Odk_PlantObjectGetPropertyWrite()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node1";

                    //gets node for specified Node path
                    using (var plantobject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("ViewName: {0} Name: {1}", plantobject.CurrentPlantView, plantobject.Name);

                        var strName = "NodeProperty_1";
                        using (var palntObjectProperty = plantobject.GetProperty(strName))
                        {
                            var pValue = palntObjectProperty.Read();
                            Console.WriteLine("Property Name: {0} property value before write operation: {1}",
                                strName, pValue.Value);
                            object value = 400;
                            // Write Cpm Node Property
                            palntObjectProperty.Write(value);
                            var pValues = palntObjectProperty.Read();
                            Console.WriteLine("Property Name: {0} property value after write operation: {1}",
                                strName, pValues.Value);
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     reads the specified property from the plant object
        /// </summary>
        /// <returns>void</returns>
        public void Odk_PlantObjectGetPropertyRead()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node1";

                    //gets node for specified Node path
                    using (var plantobject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("ViewName: {0} Name: {1}", plantobject.CurrentPlantView, plantobject.Name);

                        var strName = "NodeProperty_1";
                        using (var plantObjectProperty = plantobject.GetProperty(strName))
                        {
                            if (plantObjectProperty != null)
                            {
                                // Read Cpm Node Property
                                var plantObjectPropertyValue = plantObjectProperty.Read();
                                if (null != plantObjectPropertyValue)
                                {
                                    Console.WriteLine(
                                        "Name= {0} TimeStamp {1} QualityCode {2} Error {3} Value {4}",
                                        plantObjectPropertyValue.Name, plantObjectPropertyValue.TimeStamp,
                                        plantObjectPropertyValue.Quality, plantObjectPropertyValue.Error,
                                        plantObjectPropertyValue.Value);
                                }
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

        /// <summary>
        ///     removes the mentioned property from the property set
        ///     reads the properties  after removal of property  and display the count
        /// </summary>
        /// <returns>void</returns>
        public void Odk_PlantObjectPropertySetRemove()
        {
            try
            {
                using (var plantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node1";

                    //gets node for specified Node path
                    using (var plantObject = plantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("ViewName: {0} Name: {1}", plantObject.CurrentPlantView, plantObject.Name);


                        // get the  plant objectproperties by propeyty names
                        using (var plantModelProperties = plantObject.GetProperties())
                        {
                            if (plantModelProperties != null)
                            {
                                var nOldCount = plantModelProperties.Count;
                                var listPropValues = plantModelProperties.Read();
                                Console.WriteLine("Old Count ={0}", nOldCount);
                                for (var index = 0; index < listPropValues.Count(); index++)
                                {
                                    Console.WriteLine("Property Name is {0}  ", listPropValues.ElementAt(index).Name);
                                }
                                var strPropertyName = "NodeProperty_1";
                                //Remove the property from property set
                                plantModelProperties.Remove(strPropertyName);
                                var nNewCount = plantModelProperties.Count;
                                var listPropValue = plantModelProperties.Read();
                                Console.WriteLine("New Count ={0}", nNewCount);
                                foreach (var item in listPropValue)
                                {
                                    Console.WriteLine("Property Name is {0}  ", item.Name);
                                }
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

        /// <summary>
        ///     reads the properties of the specific plantobject
        ///     displays the properties attributes
        /// </summary>
        /// <returns>void</returns>
        public void Odk_PlantObjectGetPropertySetRead()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node1";

                    //gets node for specified Node path
                    using (var plantObject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("ViewName: {0} Name: {1}", plantObject.CurrentPlantView, plantObject.Name);

                        // get the  plant objectproperties by property names
                        using (var plantObjectPropertyset = plantObject.GetProperties())
                        {
                            if (plantObjectPropertyset != null)
                            {
                                //Read Plant Object properties values
                                var listPropValues = plantObjectPropertyset.Read();

                                foreach (var item in listPropValues)
                                {
                                    Console.WriteLine("Property Name is  {0} ", item.Name);
                                    Console.WriteLine("Property Value is  {0}", item.Value);
                                    Console.WriteLine("Property Quality is {0} ", item.Quality);
                                    Console.WriteLine("Property Error is {0} ", item.Error);
                                }
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

        /// <summary>
        ///     sets the value for the mentioned property of the specific plantobject and  writes the propertyset
        /// </summary>
        /// <returns>void</returns>
        public void Odk_PlantObjectGetPropertySetWrite()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strObjectName = ".hierarchy::RootNodeName/Node1";

                    //gets node for specified Node path
                    using (var plantObject = myPlantModel.GetPlantObject(strObjectName))
                    {
                        Console.WriteLine("ViewName: {0} Name: {1}", plantObject.CurrentPlantView, plantObject.Name);

                        // get the  plant objectproperties by propeyty names
                        using (var plantObjectPropertyset = plantObject.GetProperties())
                        {
                            if (plantObjectPropertyset != null)
                            {
                                var strPropName = "NodeProperty_1";
                                object objPropVal = 25;
                                plantObjectPropertyset.Add(strPropName, objPropVal);
                                // Write Plant Object properties
                                plantObjectPropertyset.Write();
                                var listPropValues = plantObjectPropertyset.Read();

                                foreach (var item in listPropValues)
                                {
                                    Console.WriteLine("Property Name is  {0} ", item.Name);
                                    Console.WriteLine("Property Value is  {0}", item.Value);
                                    Console.WriteLine("Property Quality is {0} ", item.Quality);
                                    Console.WriteLine("Property Error is {0} ", item.Error);
                                }
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

        /// <summary>
        ///    reads the propertyset  of the specific plantobject asynchronously
        /// </summary>
        /// <returns>void</returns>
        public void Odk_PlantObjectGetPropertySetReadAsync()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node1";

                    //gets node for specified Node path
                    using (var plantObject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("ViewName: {0} Name: {1}", plantObject.CurrentPlantView, plantObject.Name);

                        // get the  plant objectproperties by propeyty names
                        var plantObjectPropertyset = plantObject.GetProperties();

                        if (plantObjectPropertyset != null)
                        {
                            plantObjectPropertyset.OnPropertySetReadComplete += OdkPlantModel_onReadComplete;
                            // Read Plant Object properties values asynchronously
                            plantObjectPropertyset.ReadAsync();
                            _event.WaitOne();
                            _event.Reset();
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     sets the value for the mentioned property of the specific plantobject
        ///     writes propertyset asynchronously
        /// </summary>
        /// <returns>void</returns>
        public void Odk_PlantObjectGetPropertySetWriteAsync()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node1";

                    //gets node for specified Node path
                    using (var plantObject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("ViewName: {0} Name: {1}", plantObject.CurrentPlantView, plantObject.Name);

                        // get the  plant objectproperties by property names
                        var plantObjectPropertyset = plantObject.GetProperties();

                        if (plantObjectPropertyset != null)
                        {
                            var strPropName = "NewMember_1";
                            object objPropVal = 0;
                            plantObjectPropertyset.Add(strPropName, objPropVal);
                            plantObjectPropertyset.OnPropertySetWriteComplete += OdkPlantModel_OnWriteComplete;
                            //Write Plant Object properties values asynchronously
                            plantObjectPropertyset.WriteAsync();
                            _event.WaitOne();
                            _event.Reset();
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     subscribes the propertyset  of  plant object
        ///     cancels the subscription of the former subscribed propertyset
        /// </summary>
        /// <returns>void</returns>
        public void odk_PlantModelSubscribe()
        {
            try
            {
                using (var myPlantmodel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::PlantView";

                    //gets node for specified Node path
                    using (var plantObject = myPlantmodel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("ViewName: {0} Name: {1}", plantObject.CurrentPlantView, plantObject.Name);

                        var plantObjectPropertyset = plantObject.GetProperties();

                        if (plantObjectPropertyset != null)
                        {
                            // Assign callback function
                            plantObjectPropertyset.OnPlantModelPropertySubscriptionNotification +=
                                OdkPlantModelPropertySet_OnDataChanged;

                            plantObjectPropertyset.Subscribe();

                            _event.WaitOne();
                            _event.Reset();

                            plantObjectPropertyset.CancelSubscribe();
                            plantObjectPropertyset.Dispose();
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        public void Odk_PlantObjectGetCurrentView()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strObjectName = ".hierarchy::RootNodeName/Node1";

                    using (var plantObject = myPlantModel.GetPlantObject(strObjectName))
                    {
                        Console.WriteLine("CurrentPlantView : {0}", plantObject.CurrentPlantView);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void Odk_PlantObjectParentNavigation()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::PlantView/Unit1/Filler1";

                    using (var plantobject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("Name : {0}", plantobject.Name);
                        var parent = plantobject.Parent;
                        Console.WriteLine("Name : {0}", parent.Name);

                        var parent1 = plantobject.Parent.Parent;
                        Console.WriteLine("Name : {0}", parent1.Name);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void Odk_PlantObjectChildernNavigation()
        {
            try
            {
                using (var myplantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node3";

                    using (var plantObject = myplantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("Name : {0}", plantObject.Name);
                        var children = plantObject.Children;
                        foreach (var item in children)
                        {
                            Console.WriteLine("Name : {0}", item.Name);
                        }

                        var children1 = plantObject.Parent.Children;
                        foreach (var item in children1)
                        {
                            Console.WriteLine("Name : {0}", item.Name);
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void Odk_PlantObjectProperty()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::PlantView/Unit1";

                    using (var plantObject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("Name : {0}", plantObject.Name);


                        using (var propertyNode = plantObject.GetProperty("Quality"))
                        {
                            if (propertyNode != null)
                            {
                                Console.WriteLine("PropertyName: {0}", propertyNode.Name);
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

        public void Odk_PlantObjectPropertySet()
        {
            try
            {
                using (var myplantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strObjectName = ".hierarchy::PlantView/Unit1";

                    using (var plantObject = myplantModel.GetPlantObject(strObjectName))
                    {
                        Console.WriteLine("Name : {0}", plantObject.Name);


                        using (var propertySet = plantObject.GetProperties(new[] { "NumberOfNodes", "Quality" }))
                        {
                            var readResult = propertySet.Read();
                            foreach (var item in readResult)
                            {
                                Console.WriteLine("PropertyName: {0} Value: {1}", item.Name, item.Value);
                            }

                            propertySet.Add(new[] { "Quantity" });

                            readResult = propertySet.Read();
                            foreach (var item in readResult)
                            {
                                Console.WriteLine("PropertyName: {0} Value: {1}", item.Name, item.Value);
                            }

                            propertySet["Quantity"] = 1000.0;
                            propertySet.Write();

                            using (var propertySet1 = plantObject.GetProperties())
                            {
                                foreach (var item in propertySet)
                                {
                                    if (item.Key == "Quantity")
                                    {
                                        propertySet1[item.Key] = 2000;
                                    }
                                    if (item.Key == "NumberOfNodes")
                                    {
                                        propertySet1[item.Key] = 2000;
                                    }
                                }

                                propertySet1.Remove("NumberOfNodes");
                                propertySet1.Write();
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

        public void Odk_PlantObjectPropertySetClear()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::PlantView/Unit1";
                    using (var plantObject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("Name : {0}", plantObject.Name);

                        using (var propertySet = plantObject.GetProperties())
                        {
                            Console.WriteLine("PropertySet Count : {0}", propertySet.Count);
                            foreach (var item in propertySet)
                            {
                                Console.WriteLine("Property Name : {0}", item.Key);
                            }
                            propertySet.Clear();
                            Console.WriteLine("PropertySet Count After Clear  : {0}", propertySet.Count);
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void Odk_PlantObjectPropertyLinqSupportTest()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName/Node1";

                    using (var plantObject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("Name : {0}", plantObject.Name);


                        using (var propertySet = plantObject.GetProperties())
                        {
                            var i = 1;
                            foreach (var item in propertySet)
                            {
                                propertySet[item.Key] = i;
                                ++i;
                            }

                            propertySet.Write();

                            var propertyNames = from prop in propertySet select prop.Key;

                            propertyNames = propertySet.Select(item => item.Key);
                            propertyNames = from prop in propertySet select prop.Key;

                            var valuesByName = propertySet.ToDictionary(item => item.Key, item => item.Value);

                            var test = valuesByName["DateActivation"];
                        }
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        public void Odk_PlantObjectSetCurrentView()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::PlantView";

                    using (var plantObject = myPlantModel.GetPlantObject(strNodeName))
                    {
                        Console.WriteLine("Name : {0}", plantObject.Name);

                        plantObject.CurrentPlantView = "hierarchy";

                        var hierarchyChildrenList = plantObject.Children;

                        Console.WriteLine("HierarchName:{0} contains {1} Childern", plantObject.CurrentPlantView,
                            hierarchyChildrenList.Count);
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        public void Odk_PlantObjectPropertyAddWithValue()
        {
            try
            {
                Console.WriteLine("Odk_PlantObjectPropertyAddWithValue");
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strObjectName = ".hierarchy::PlantView/Unit1";

                    using (var plantObject = myPlantModel.GetPlantObject(strObjectName))
                    {
                        Console.WriteLine("Name : {0}", plantObject.Name);


                        using (var propertySet = plantObject.GetProperties())
                        {
                            if (propertySet != null)
                            {
                                propertySet.Clear();

                                propertySet.Add(new[] { "Quality", "Quantity" });

                                foreach (var item in propertySet)
                                {
                                    propertySet[item.Key] = 2000;
                                }

                                propertySet.Add("NumberOfNodes", 2000);

                                propertySet.Write();

                                propertySet.Remove("NumberOfNodes");

                                var nodeValues = propertySet.Read();

                                foreach (var value in nodeValues)
                                {
                                    Console.WriteLine("Name:{0} TimeStamp:{1} Value:{2} Quality:{3} Error:{4}",
                                        value.Name, value.TimeStamp, value.Value, value.Quality, value.Error);
                                }
                                propertySet.Clear();
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

        public void OdkPlantModelPropertySet_OnDataChanged(IPlantObjectPropertySet sender,
            IList<IPlantObjectPropertyValue> values)
        {
            try
            {
                foreach (var value in values)
                {
                    Console.WriteLine("Name {0}", value.Name);
                    Console.WriteLine("TimeStamp {0}", value.TimeStamp);
                    Console.WriteLine("Value {0}", value.Value);
                    Console.WriteLine("Quality {0}", value.Quality);
                    Console.WriteLine("Error {0}", value.Error);
                }
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

        public void OdkPlantModel_onReadComplete(IPlantObjectPropertySet sender, uint systemError,
            IList<IPlantObjectPropertyValue> values)
        {
            try
            {
                foreach (var value in values)
                {
                    Console.WriteLine("Name {0}", value.Name);
                    Console.WriteLine("TimeStamp {0}", value.TimeStamp);
                    Console.WriteLine("Value {0}", value.Value);
                    Console.WriteLine("Quality {0}", value.Quality);
                    Console.WriteLine("Error {0}", value.Error);
                }
            }
            finally
            {
                sender?.Dispose();
                _event.Set();
            }
        }

        public void OdkPlantModel_OnWriteComplete(IPlantObjectPropertySet sender, uint systemError,
            IList<IPlantObjectPropertyValue> values)
        {
            try
            {
                foreach (var value in values)
                {
                    Console.WriteLine("Name {0}", value.Name);
                    Console.WriteLine("Error {0}", value.Error);
                }
            }
            finally
            {
                sender?.Dispose();
                _event.Set();
            }
        }


        public void Odk_GetActiveAlarms()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::RootNodeName";

                    //gets node for specified Node path
                    var plantobject = myPlantModel.GetPlantObject(strNodeName);

                    if (null != plantobject)
                    {
                        var systemNames = new List<string>();
                        systemNames.Add("SYSTEM1");
                        Console.WriteLine("ViewName: {0} Name: {1}", plantobject.CurrentPlantView, plantobject.Name);
                        var daFilter = string.Empty;
                        uint daLanguage = 1033;
                        var includeChildren = true;
                        plantobject.PlantObjectAlarmHandler += Alarm_OnPlantObjectAlarmHandler;
                        plantobject.GetActiveAlarms(daLanguage, includeChildren, daFilter);
                        _event.WaitOne();
                        _event.Reset();

                        //Dispose object after reading all alarms
                        plantobject.Dispose();
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        public void Odk_GetAlarmSubscription()
        {
            try
            {
                using (var myPlantModel = _runtime.GetObject<IPlantModel>())
                {
                    var strNodeName = ".hierarchy::PlantView";

                    //gets node for specified Node path
                    var plantobject = myPlantModel.GetPlantObject(strNodeName);

                    var alarmsub = plantobject.CreateAlarmSubscription();

                    // Assign alarm handler
                    if (alarmsub != null)
                    {
                        alarmsub.OnPlantObjectSubscribeAlarmHandler += Alarm_OnPlantObjectSubscribeAlarmHandler;

                        alarmsub.Filter = "";
                        alarmsub.Language = 1033;
                        alarmsub.IncludeChildren = false;
                        alarmsub.Start();
                        _event.WaitOne();
                        _event.Reset();

                        alarmsub.Stop();

                        //Dispose object after subscription is stoped
                        alarmsub.Dispose();
                    }
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        public void Alarm_OnPlantObjectAlarmHandler(IPlantObject sender, uint globalError, string systemName,
            IList<IAlarmResult> value, bool completed)
        {
            try
            {
                if (0 == globalError && !completed)
                {
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
                        Console.WriteLine("ValueLimit: {0}", item.ValueQuality);

                    }
                }
            }
            finally
            {
                if (completed)
                {
                    _event.Set();
                }
            }
        }

        public void Alarm_OnPlantObjectSubscribeAlarmHandler(IPlantObjectAlarmSubscription sender, uint nGlobalError,
            string systemName, IList<IAlarmResult> value)
        {
            try
            {
                if (value != null && nGlobalError == 0)
                {
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
                        Console.WriteLine("ValueLimit: {0}", item.ValueQuality);
                    }
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
    }
}
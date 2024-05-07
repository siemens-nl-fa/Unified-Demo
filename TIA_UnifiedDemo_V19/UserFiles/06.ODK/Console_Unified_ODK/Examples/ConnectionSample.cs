using System;
using System.Collections.Generic;
using System.Threading;
using Siemens.Runtime.HmiUnified;

namespace Siemens.Runtime.HmiIL.TestClient
{
    public class ConnectionSample
    {
        private readonly ManualResetEvent m_event = new ManualResetEvent(false);
        private readonly IRuntime m_runtime = Start.runtime;

        /// <summary>
        ///     subscribes the connections
        ///     cancels the subscription of the former subscribed connections
        /// </summary>
        /// <returns>void</returns>
        public void ConnnectionSet_Subscribe()
        {
            try
            {
                using (var subscribe = m_runtime.GetObject<IConnectionSet>())
                {
                    ICollection<string> list = new[] {"HMI-Connection", "HMI-ConnectionS7Plus"};
                    subscribe.Add(list);
                    subscribe.OnConnectionStateChanged += Subscribe_OnConnectionStateChanged;
                    subscribe.Subscribe();
                    m_event.WaitOne();
                    m_event.Reset();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     reads the Connections  of the specific connection  asynchronously
        /// </summary>
        /// <returns>void</returns>
        public void ConnectionSet_ReadAsync()
        {
            IConnectionSet readAsync = null;
            try
            {
                readAsync = m_runtime.GetObject<IConnectionSet>();
                if (readAsync != null)
                {
                    ICollection<string> list = new[] {"HMI-Connection", "HMI-ConnectionS7Plus"};
                    readAsync.Add(list);
                    readAsync.OnConnectionRead += Read_OnConnectionComplete;
                    readAsync.ReadAsync();
                    m_event.WaitOne();
                    m_event.Reset();
                }
            }
            catch (Exception ex)
            {
                //Dispose object on exception
                if(readAsync != null)
                    readAsync.Dispose();

                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     reads the properties of the specific Connection
        ///     displays the properties attributes
        /// </summary>
        /// <returns>void</returns>
        public void ConnectionSet_Read()

        {
            try
            {
                using (var read = m_runtime.GetObject<IConnectionSet>())
                {
                    if (read != null)
                    {
                        ICollection<string> list = new[] {"HMI-Connection", "HMI-ConnectionS7Plus"};
                        read.Add(list);

                        var connectionResult = read.Read();

                        foreach (var item in connectionResult)
                        {
                            Console.WriteLine("Connection Name is  {0} ", item.Name);
                            Console.WriteLine("ConnectionState is  {0}", item.ConnectionState);
                            Console.WriteLine("TimeSynchronizationMode is {0} ", item.TimeSynchronizationMode);
                            Console.WriteLine(" Error is {0} ", item.Error);
                            Console.WriteLine("EstablishMentMode is  {0} ", item.EstablishmentMode);
                            Console.WriteLine("Enabled is  {0} ", item.Enabled);
                            Console.WriteLine("DisabledAtStartup is  {0} ", item.DisabledAtStartup);
                            Console.WriteLine("ConnectionType is  {0} ", item.ConnectionType);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     Gets the properties of the specific ConnectionState
        ///     displays the properties attributes
        /// </summary>
        /// <returns>void</returns>
        public void Connectionset_GetConnectionState()
        {
            try
            {
                using (var connectionstate = m_runtime.GetObject<IConnectionSet>())
                {
                    if (connectionstate != null)
                    {
                        ICollection<string> list = new[] {"HMI-Connection", "HMI-ConnectionS7Plus"};
                        connectionstate.Add(list);
                        var connectionResult = connectionstate.GetConnectionState();

                        foreach (var item in connectionResult)
                        {
                            Console.WriteLine("Connection Name is  {0} ", item.Name);
                            Console.WriteLine(" Error is {0} ", item.Error);
                            Console.WriteLine("Connection status is {0}", item.ConnectionStatus);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     reads the properties of the specific Connection
        ///     displays the properties attributes
        /// </summary>
        /// <returns>void</returns>
        public void Connection_Read()
        {
            try
            {
                using (var connection = m_runtime.GetObject<IConnection>("HMI-ConnectionS7Plus"))
                {
                    if (connection != null)
                    {
                        var con = connection.Read();
                        if (con != null)
                        {
                            Console.WriteLine("Connection Name is  {0} ", con.Name);
                            Console.WriteLine("ConnectionState is  {0}", con.ConnectionState);
                            Console.WriteLine("TimeSynchronizationMode is {0} ", con.TimeSynchronizationMode);
                            Console.WriteLine("EstablishMentMode is  {0} ", con.EstablishmentMode);
                            Console.WriteLine("Enabled is  {0} ", con.Enabled);
                            Console.WriteLine("DisabledAtStartup is  {0} ", con.DisabledAtStartup);
                            Console.WriteLine("ConnectionType is  {0} ", con.ConnectionType);
                            Console.WriteLine(" Error is {0} ", con.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }


        /// <summary>
        ///     Add connection to list and remove connection from list
        /// </summary>
        public void Connection_AddRemove()
        {
            try
            {
                using (var read = m_runtime.GetObject<IConnectionSet>())
                {

                    ICollection<string> list = new[] { "HMI-Connection", "HMI-ConnectionS7Plus" };
                    read.Add(list);

                    var connectionResult = read.Read();

                    foreach (var item in connectionResult)
                    {
                        Console.WriteLine("Connection Name is  {0} ", item.Name);
                    }

                    var strPropertyName = "HMI-Connection";
                    read.Remove(strPropertyName);
                    var connectionResults = read.Read();

                    foreach (var item in connectionResults)
                    {
                        Console.WriteLine("Connection Name is  {0} ", item.Name);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     Gets the properties of the specific ConnectionState
        ///     displays the properties attributes
        /// </summary>
        /// <returns>void</returns>
        public void Connection_GetConnectionState()
        {
            try
            {
                using (var connection = m_runtime.GetObject<IConnection>("HMI-ConnectionS7Plus"))
                {
                    var con = connection.GetConnectionState();

                    if (con != null)
                    {
                        Console.WriteLine("Connection Name is : {0} ", con.Name);
                        Console.WriteLine(" Error is : {0} ", con.Error);
                        Console.WriteLine("Connection status is: {0}", con.ConnectionStatus);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     Sets the mode of the specific ConnectionState
        /// </summary>
        /// <returns>void</returns>
        public void Connection_SetConnectionStateDisable()
        {
            try
            {
                using (var connection = m_runtime.GetObject<IConnection>("HMI-ConnectionS7Plus"))
                {
                    if (connection != null)
                    {
                        connection.SetConnectionMode(ConnectionMode.Disabled);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        /// <summary>
        ///     Sets the mode of the specific ConnectionState
        /// </summary>
        /// <returns>void</returns>
        public void Connection_SetConnectionStateEnable()
        {
            try
            {
                using (var connection = m_runtime.GetObject<IConnection>("HMI-ConnectionS7Plus"))
                {
                    if (connection != null)
                    {
                        connection.SetConnectionMode(ConnectionMode.Enabled);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
        }

        private void Subscribe_OnConnectionStateChanged(IConnectionSet sender, uint systemError,
            IList<IConnectionStatusResult> values)
        {
            if (0 == systemError)
            {
                try
                {
                    foreach (var item in values)
                    {
                        Console.WriteLine("Name:{0} ", item.Name);
                        Console.WriteLine("State:{0} ", item.ConnectionStatus);
                        Console.WriteLine("Error:{0} ", item.Error);
                    }
                }
                catch (OdkException ex)
                {
                    Console.WriteLine("OdkException occured {0}", ex.Message);
                }

                finally
                {
                    if (null != sender)
                    {
                        sender.CancelSubscribe();
                        sender.Dispose();
                        m_event.Set();
                    }
                }
            }
            else
            {
                Console.WriteLine("Connection set subscription  Failed");
            }
        }

        private void Read_OnConnectionComplete(IConnectionSet sender, uint systemError, IList<IConnectionResult> values)
        {
            try
            {
                foreach (var item in values)
                {
                    Console.WriteLine("Name:{0} ", item.Name);
                    Console.WriteLine("State:{0} ", item.ConnectionState);
                    Console.WriteLine("establishmentMode:{0} ", item.EstablishmentMode);
                    Console.WriteLine("TimeSynchronizationMode:{0} ", item.TimeSynchronizationMode);
                    Console.WriteLine("ConnectionType:{0} ", item.ConnectionType);
                    Console.WriteLine("Enabled:{0} ", item.Enabled);
                    Console.WriteLine("DisabledAtStartup:{0} ", item.DisabledAtStartup);
                    Console.WriteLine("Error:{0} ", item.Error);
                }
            }
            catch (OdkException ex)
            {
                Console.WriteLine("OdkException occured {0}", ex.Message);
            }
            finally
            {
                if (null != sender)
                {
                    sender.Dispose();
                    m_event.Set();
                }
            }
        }
    }
}
using Siemens.Engineering;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpennessLibrary
{

    public partial class Openness
    {
        public Subnet Subnet_Create(string subnetName)
        {
            if (Project == null)
            {
                return null;
            }
            
            Subnet subnet = null;
            try
            {
            SubnetComposition subnets = Project.Subnets;
            if (subnets.Find(subnetName) == null)
            {
                subnet = subnets.Create("System:Subnet.Ethernet", subnetName);
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
            return subnet;

        }

        public void Subnet_AddDevice(string subnetName, DeviceItem profinetInterface)
        {
            if (Project == null)
            {
                return;
            }

            try
            {
                Subnet subnet = Project.Subnets.Find(subnetName);
                if (subnet != null)
                {
                    NetworkInterface networkInterface = profinetInterface.GetService<NetworkInterface>();
                    NodeComposition nodes = networkInterface.Nodes;
                    nodes.First().ConnectToSubnet(subnet);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        public IoSystem IOSystem_Create(string ioSystemName, DeviceItem profinetInterface)
        {
            if (Project == null)
            {
                return null;
            }

            IoSystem ioSystem = null;
            try
            {
                NetworkInterface networkInterface = profinetInterface.GetService<NetworkInterface>();
                IoControllerComposition ioControllers = networkInterface.IoControllers;
                IoController ioController = ioControllers.First();
                ioSystem = ioController.CreateIoSystem(ioSystemName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }

            return ioSystem;
        }

        public List<IoSystem> Project_GetIOSystems()
        {
            if (Project == null)
            {
                return null;
            }
            
            List<IoSystem> ioSystems = new List<IoSystem>();
            try
            {
                foreach (Subnet subnet in Project.Subnets)
                {
                    foreach (IoSystem ioSystem in subnet.IoSystems)
                    {
                        ioSystems.Add(ioSystem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }

            return ioSystems;
        }

        public void IOSystem_AddDevice(string ioSystemName, DeviceItem profinetInterface)
        {
            try
            {
                IoSystem ioSystem = Project_GetIOSystems().Find(io => io.Name == ioSystemName);
                if (ioSystem != null)
                {
                    NetworkInterface networkInterface = profinetInterface.GetService<NetworkInterface>();
                    IoConnectorComposition ioConnectors = networkInterface.IoConnectors;
                    ioConnectors.First().ConnectToIoSystem(ioSystem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }
    }
}

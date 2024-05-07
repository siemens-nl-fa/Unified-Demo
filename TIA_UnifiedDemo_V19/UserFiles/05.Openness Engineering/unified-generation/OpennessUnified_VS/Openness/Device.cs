using Siemens.Engineering.HW;
using Siemens.Engineering.Library.MasterCopies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpennessLibrary
{
    public partial class Openness
    {
        public List<Device> Project_GetDevices()
        {
            if (Project == null)
            {
                return null;
            }

            List<Device> devices = new List<Device>();
            foreach (Device device in Project.Devices)
            {
                devices.Add(device);
            }
            foreach (Device device in Project.UngroupedDevicesGroup.Devices)
            {
                devices.Add(device);
            }
            foreach (DeviceUserGroup deviceGroup in Project.DeviceGroups)
            {
                List<Device> devicesInGroup = Project_GetDevicesFromGroup(deviceGroup);
                devices.AddRange(devicesInGroup);
            }
            return devices;
        }

        private List<Device> Project_GetDevicesFromGroup(DeviceUserGroup deviceGroup)
        {
            if (Project == null)
            {
                return null;
            }

            List<Device> devices = new List<Device>();
            foreach (Device device in deviceGroup.Devices)
            {
                devices.Add(device);
            }
            foreach (DeviceUserGroup deviceGroupInGroup in deviceGroup.Groups)
            {
                devices.AddRange(Project_GetDevicesFromGroup(deviceGroupInGroup));
            }
            return devices;
        }

        public Device Device_Add(string orderNumber, string name, string deviceName,  DeviceComposition deviceComposition)
        {
            Device device = null;
            if (Project == null)
            {
                return null;
            }

            if (Project_GetDevices().Find(d => d.Name == name) != null)
            {
                return null;
            }

            device = deviceComposition.CreateWithItem($"OrderNumber:{orderNumber}", name, deviceName);
            return device;
        }
        public Device Device_Add(MasterCopy masterCopy, DeviceComposition deviceComposition)
        {
            if (Project == null)
            {
                return null;
            }

            Device device = null;
            device = deviceComposition.CreateFrom(masterCopy);
            return device;
        }

        public DeviceItem Device_GetHM(Device device)
        {
            if (Project == null)
            {
                return null;
            }

            DeviceItem deviceItem = null;
            if (device != null)
            {
                foreach (DeviceItem item in device.DeviceItems)
                {
                    if (item.Classification == DeviceItemClassifications.HM)
                    {
                        deviceItem = item;
                        break;
                    }
                }
            }
            return deviceItem;
        }

        public DeviceItem Device_GetCPU(Device device)
        {
            if (Project == null)
            {
                return null;
            }

            DeviceItem deviceItem = null;
            if (device != null)
            {
                foreach (DeviceItem item in device.DeviceItems)
                {
                    if (item.Classification == DeviceItemClassifications.CPU)
                    {
                        deviceItem = item;
                        break;
                    }
                }
            }
            return deviceItem;
        }

        public List<DeviceItem> Device_GetProfinetInterfaces(Device device)
        {
            if (Project == null)
            {
                return null;
            }

            List<DeviceItem> profinetInterfaces = new List<DeviceItem>();
            if (device != null)
            {
                DeviceItem module = Device_GetCPU(device);
                if (module != null)
                {
                    foreach (DeviceItem item in module.DeviceItems)
                    {
                        if (item.Name.Contains("PROFINET"))
                        {
                            profinetInterfaces.Add(item);
                        }
                    }
                }

                module = Device_GetHM(device);
                if (module != null)
                {
                    foreach (DeviceItem item in module.DeviceItems)
                    {
                        if (item.Name.Contains("PROFINET"))
                        {
                            profinetInterfaces.Add(item);
                        }
                    }
                }
            }
            return profinetInterfaces;
        }

        public DeviceItem Device_GetProfinetInterface(Device device, string profinetInterfaceName)
        {
            if (Project == null)
            {
                return null;
            }

            DeviceItem deviceItem = null;
            if (device != null)
            {
                DeviceItem module = Device_GetCPU(device);
                if (module != null)
                {
                    foreach (DeviceItem item in module.DeviceItems)
                    {
                        if (item.Name == profinetInterfaceName)
                        {
                            deviceItem = item;
                        }
                    }
                }

                module = Device_GetHM(device);
                if (module != null)
                {
                    foreach (DeviceItem item in module.DeviceItems)
                    {
                        if (item.Name == profinetInterfaceName)
                        {
                            deviceItem = item;
                        }
                    }
                }
            }

            return deviceItem;
        }

        public List<DeviceItem> Device_GetNetworkPorts(DeviceItem profinetInterface)
        {
            if (Project == null)
            {
                return null;
            }

            List<DeviceItem> devices = new List<DeviceItem>();
            foreach (DeviceItem item in profinetInterface.DeviceItems)
            {
                if (item.Name.Contains("Port"))
                {
                    devices.Add(item);
                }
            }

            return devices;
        }
    }
}

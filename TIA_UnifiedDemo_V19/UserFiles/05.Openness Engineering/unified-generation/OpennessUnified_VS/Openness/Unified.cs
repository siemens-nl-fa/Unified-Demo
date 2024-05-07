using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siemens.Engineering;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.HmiUnified;
using Siemens.Engineering.HmiUnified.UI.Base;
using Siemens.Engineering.HmiUnified.UI.ScreenGroup;
using Siemens.Engineering.HmiUnified.UI.Screens;
using Siemens.Engineering.HmiUnified.UI.Widgets;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;

namespace OpennessLibrary
{
    public partial class Openness
    {
        public List<HmiScreen> Unified_GetScreens(Device device)
        {
            if (Project == null || device == null)
            {
                return null;
            }

            List<HmiScreen> screens = new List<HmiScreen>();

            HmiSoftware hmiSoftware = Unified_GetHmiSoftware(device);
            if (hmiSoftware != null)
            {
                foreach (HmiScreen screen in hmiSoftware.Screens)
                {
                    screens.Add(screen);
                }


                return screens;
            }
            return null;
        }

        public List<HmiScreen> Unified_GetScreensFromGroup(Device device, HmiScreenGroup group)
        {
            if (Project == null || device == null)
            {
                return null;
            }

            List<HmiScreen> screens = new List<HmiScreen>();

            HmiSoftware hmiSoftware = Unified_GetHmiSoftware(device);
            if (hmiSoftware != null)
            {
                foreach (HmiScreen screen in group.Screens)
                {
                    screens.Add(screen);
                }
                return screens;
            }
            return null;
        }

        public List<HmiScreenGroup> Unified_GetScreenGroups(Device device)
        {
            if (Project == null || device == null)
            {
                return null;
            }

            List<HmiScreenGroup> screenGroups = new List<HmiScreenGroup>();

            HmiSoftware hmiSoftware = Unified_GetHmiSoftware(device);
            if (hmiSoftware != null)
            {
                foreach (HmiScreenGroup screen in hmiSoftware.ScreenGroups)
                {
                    screenGroups.Add(screen);
                }
                return screenGroups;
            }
            return null;
        }

        public HmiSoftware Unified_GetHmiSoftware(Device device)
        {
            if (Project == null || device == null)
            {
                return null;
            }

            HmiSoftware hmiSoftware = null;

            DeviceItemComposition deviceItems = device.DeviceItems;
            foreach (DeviceItem item in deviceItems)
            {
                SoftwareContainer container = item.GetService<SoftwareContainer>();
                if (container != null)
                {
                    hmiSoftware = container.Software as HmiSoftware;
                }
            }

            return hmiSoftware;
        }

        public List<HmiScreenItemBase> Unified_GetScreenItems(HmiScreen screen)
        {
            if (Project == null || screen == null)
            {
                return null;
            }

            List<HmiScreenItemBase> screenItems = new List<HmiScreenItemBase>();

            HmiScreenItemBaseComposition hmiScreenItemBases = screen.ScreenItems;
            foreach (HmiScreenItemBase item in hmiScreenItemBases)
            {
                screenItems.Add(item);
            }

            return screenItems;
        }

        public Device Unified_CreateHMI(string orderNumber, string deviceName)
        {
            if (Project == null || String.IsNullOrEmpty(orderNumber))
            {
                return null;
            }

            DeviceComposition devices = Project.Devices;
            Device device = devices.CreateWithItem($"OrderNumber:{orderNumber}", deviceName, "");

            return device;
        }

        public HmiScreen Unified_CreateScreen(Device device, string screenName)
        {
            if (Project == null)
            {
                return null;
            }

            HmiSoftware hmiSoftware = Unified_GetHmiSoftware(device);
            HmiScreenComposition hmiScreens = hmiSoftware.Screens;
            HmiScreen screen = hmiScreens.Create(screenName);

            return screen;
        }
    }
}

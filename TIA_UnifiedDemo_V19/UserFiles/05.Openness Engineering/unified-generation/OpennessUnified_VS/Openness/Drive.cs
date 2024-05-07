using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siemens.Engineering;
using Siemens.Engineering.HW;
using Siemens.Engineering.MC.Drives;

namespace OpennessLibrary
{
    public partial class Openness
    {
        public DeviceItem Drive_ChangePM(Device device, string ordernumber)
        {
            if (Project == null)
            {
                return null;
            }

            DeviceItem powerModule = null;
            try
            {
                if (device != null)
                {
                    DeviceItem hm = Device_GetHM(device);
                    if (hm != null)
                    {
                        foreach (DeviceItem item in device.DeviceItems)
                        {
                            if (item.PositionNumber == 3)
                            {
                                item.Delete();
                            }
                        }
                        if (hm.CanPlugNew($"OrderNumber:{ordernumber}", "PM", 3))
                        {
                            powerModule = hm.PlugNew($"OrderNumber:{ordernumber}", "PM", 3);
                        } 
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }

            return powerModule;
        }

        public DriveObject Drive_GetDriveObject(Device device)
        {
            if (Project == null)
            {
                return null;
            }

            DriveObject driveObject = null;
            try
            {
                if (device != null)
                {
                    DeviceItem deviceItem = Device_GetHM(device);
                    driveObject = deviceItem.GetService<DriveObjectContainer>().DriveObjects[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }

            return driveObject;
        }
    }
}

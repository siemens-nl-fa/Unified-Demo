using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siemens.Engineering;

namespace OpennessLibrary
{
    public partial class Openness
    {
        #region Fields & Properties
        private TiaPortal _tiaPortal;

        public TiaPortal TiaPortal
        {
            get { return _tiaPortal; }
            set { _tiaPortal = value; }
        }

        private TiaPortalProcess _tiaPortalProcess;

        public TiaPortalProcess TiaPortalProcess
        {
            get { return _tiaPortalProcess; }
            set { _tiaPortalProcess = value; }
        }
        #endregion

        #region Methods
        #region Start
        public TiaPortal TiaPortal_Start(TiaPortalMode tiaPortalMode)
        {
            if (TiaPortal == null && TiaPortalProcess == null)
            {
                try
                {
                    TiaPortal = new TiaPortal(tiaPortalMode);
                    TiaPortalProcess = TiaPortal.GetCurrentProcess();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            return TiaPortal;
        }

        public async Task<TiaPortal> TiaPortal_Start_Async(TiaPortalMode tiaPortalMode)
        {
            if (TiaPortal == null)
            {
                try
                {
                    TiaPortal = await Task.Run(() => new TiaPortal(tiaPortalMode));
                    TiaPortalProcess = TiaPortal.GetCurrentProcess();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            return TiaPortal;
        }
        #endregion

        #region Connect
        public TiaPortal TiaPortal_Connect(TiaPortalProcess process)
        {
            if (TiaPortal == null && TiaPortalProcess == null)
            {
                try
                {
                    TiaPortalProcess = process;
                    TiaPortal = TiaPortalProcess.Attach();
                    if (TiaPortal.Projects[0] != null)
                    {
                        Project = TiaPortal.Projects[0];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            return TiaPortal;
        }

        public async Task<TiaPortal> TiaPortal_Connect_Async(TiaPortalProcess process)
        {
            if (TiaPortal == null && TiaPortalProcess == null)
            {
                try
                {
                    TiaPortalProcess = process;
                    TiaPortal = await Task.Run(() => TiaPortalProcess.Attach());
                    if (TiaPortal.Projects[0] != null)
                    {
                        Project = TiaPortal.Projects[0];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            return TiaPortal;
        }
        #endregion

        #region Disconnect 
        public TiaPortal TiaPortal_Disconnect()
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                try
                {
                    TiaPortal.Dispose();
                    TiaPortal = null;
                    TiaPortalProcess = null;
                    Project = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            return TiaPortal;
        }
        #endregion

        #region Close
        public TiaPortal TiaPortal_Close()
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                try
                {
                    TiaPortal.Dispose();
                    TiaPortalProcess.Dispose();
                    TiaPortal = null;
                    TiaPortalProcess = null;
                    Project = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            return TiaPortal;
        }
        #endregion
        #endregion
    }
}

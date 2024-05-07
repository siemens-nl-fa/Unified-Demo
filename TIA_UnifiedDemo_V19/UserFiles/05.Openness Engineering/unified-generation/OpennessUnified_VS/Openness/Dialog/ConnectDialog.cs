using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siemens.Engineering;

namespace OpennessLibrary
{
    public partial class ConnectDialog : Form
    {
        #region Fields & Properties
        private TiaPortalProcess _selectedProcess;

        public TiaPortalProcess SelectedProcess
        {
            get { return _selectedProcess; }
            set { _selectedProcess = value; }
        }
        #endregion

        public ConnectDialog()
        {
            InitializeComponent();
        }

        private void ConnectDialog_Load(object sender, EventArgs e)
        {
            Populate_DataGridView_TiaPortalProcesses();
            timer_Cyclic_5s.Enabled = true;
            timer_Cyclic_5s.Start();
        }

        #region Buttons
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            Populate_DataGridView_TiaPortalProcesses();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            if (dataGridView_TiaPortalProcesses.SelectedRows.Count > 0)
            {
                SelectedProcess = (TiaPortalProcess)dataGridView_TiaPortalProcesses.SelectedRows[0].Tag;
            }
            if (SelectedProcess != null)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion

        #region Methods

        private void Populate_DataGridView_TiaPortalProcesses()
        {
            foreach (TiaPortalProcess process in TiaPortal.GetProcesses())
            {
                bool isNew = true;
                foreach (DataGridViewRow row in dataGridView_TiaPortalProcesses.Rows)
                {
                    if (((TiaPortalProcess)row.Tag).Id == process.Id)
                    {
                        isNew = false;
                        row.Cells["OpenProject"].Value = process.ProjectPath != null ? process.ProjectPath.Name : "No project open";
                        break;
                    }
                }
                if (isNew)
                {
                    int index = dataGridView_TiaPortalProcesses.Rows.Add(process.Id, process.Mode, process.ProjectPath != null ? process.ProjectPath.Name : "No project open");
                    dataGridView_TiaPortalProcesses.Rows[index].Tag = process;
                }
            }

            foreach (DataGridViewRow row in dataGridView_TiaPortalProcesses.Rows)
            {
                bool exists = false;
                foreach (TiaPortalProcess process in TiaPortal.GetProcesses())
                {
                    if (process.Id == ((TiaPortalProcess)row.Tag).Id)
                    {
                        exists = true;
                        break;
                    }
                }
                if (exists == false)
                {
                    dataGridView_TiaPortalProcesses.Rows.Remove(row);
                }
            }
        }
        #endregion

        private void timer_Cyclic_5s_Tick(object sender, EventArgs e)
        {
            Populate_DataGridView_TiaPortalProcesses();
        }
    }
}

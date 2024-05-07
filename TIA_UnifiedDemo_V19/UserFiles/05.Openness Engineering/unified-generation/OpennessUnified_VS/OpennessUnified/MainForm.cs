using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpennessLibrary;
using System.IO;
using System.Runtime.InteropServices;

using Siemens.Engineering;
using Siemens.Engineering.HW;
using Siemens.Engineering.HmiUnified.UI.Screens;
using Siemens.Engineering.HmiUnified.UI.Base;
using Siemens.Engineering.HmiUnified.UI.Widgets;
using Siemens.Engineering.HmiUnified.UI.Controls;
using Siemens.Engineering.HmiUnified.UI.Dynamization;
using Siemens.Engineering.HmiUnified.UI.Shapes;
using Siemens.Engineering.HmiUnified.UI.Enum;
using Siemens.Engineering.HmiUnified.UI.Events;
using Siemens.Engineering.HmiUnified.UI.ScreenGroup;
using Siemens.Engineering.Hmi.Screen;

namespace OpennessUnified
{
    public partial class MainForm : Form
    {
        public Openness opns { get; set; } = new Openness();

        public MainForm()
        {
            InitializeComponent();
            comboBox_DeviceOrderNumber.SelectedIndex = 0;
        }

        #region TIA Portal + Project
        // Start TIA Portal
        private void button_StartTIA_Click(object sender, EventArgs e)
        {
            opns.TiaPortal_Start(TiaPortalMode.WithUserInterface);
        }

        // Connect to TIA Portal
        private void button_ConnectTIA_Click(object sender, EventArgs e)
        {
            ConnectDialog connectDialog = new ConnectDialog();
            if (connectDialog.ShowDialog() == DialogResult.OK)
            {
                opns.TiaPortal_Connect(connectDialog.SelectedProcess);
                UpdateDevices();
            }
        }

        // Open project 
        private void button_OpenProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                opns.Project_Open(new FileInfo(openFileDialog.FileName));
            }
            UpdateDevices();
        }

        // Save project
        private void button_SaveProject_Click(object sender, EventArgs e)
        {
            opns.Project_Save();
        }

        // Close project
        private void button_CloseProject_Click(object sender, EventArgs e)
        {
            opns.Project_Close();
        }

        // Disconnect TIA Portal
        private void button_DisconnectTIA_Click(object sender, EventArgs e)
        {
            opns.TiaPortal_Disconnect();
        }

        // Close TIA Portal
        private void button_CloseTIA_Click(object sender, EventArgs e)
        {
            opns.TiaPortal_Close();
        }

        // Update connection info
        private void timer_Tick(object sender, EventArgs e)
        {
            if (opns.TiaPortal != null)
            {
                statusLabel_TIAConnectie.Text = $"TIA Portal - Connected ({opns.TiaPortalProcess.Id})";
            }
            else
            {
                statusLabel_TIAConnectie.Text = "TIA Portal - Disconnected";
            }

            if (opns.Project != null)
            {
                statusLabel_ProjectConnectie.Text = $"Project - Connected ({opns.Project.Name})";
            }
            else
            {
                statusLabel_ProjectConnectie.Text = "Project - Disconnected";
            }
        }
        #endregion

        // Restart application
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        // Exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Update Information
        // Update treeview with all the devices in the project
        private void UpdateDevices()
        {
            treeView_Devices.Nodes.Clear();
            if (opns.Project == null)
            {
                return;
            }

            List<Device> devices = opns.Project_GetDevices();
            foreach (Device device in devices)
            {
                TreeNode node = treeView_Devices.Nodes.Add(device.Name);
                node.Tag = device;
            }
        }

        // Update treeview with all the screen from the selected HMI device
        private void UpdateScreens()
        {
            treeView_Screens.Nodes.Clear();
            if (opns.Project == null || treeView_Devices.SelectedNode == null)
            {
                return;
            }

            Device device = (Device)treeView_Devices.SelectedNode.Tag;

            List<HmiScreen> screens = opns.Unified_GetScreens(device);
            List<HmiScreenGroup> groups = opns.Unified_GetScreenGroups(device);

            if (screens != null)
            {
                foreach (HmiScreen screen in screens)
                {
                    TreeNode node = treeView_Screens.Nodes.Add(screen.Name);
                    node.Tag = screen;
                }
                foreach (HmiScreenGroup group in groups)
                {
                    TreeNode groupNode = treeView_Screens.Nodes.Add(group.Name);
                    groupNode.Tag = group.Screens[0];

                    List<HmiScreen> screenFromGroup = opns.Unified_GetScreensFromGroup(device, group);
                    foreach (HmiScreen screen in screenFromGroup)
                    {
                        TreeNode node = groupNode.Nodes.Add(screen.Name);
                        node.Tag = screen;
                    }
                }
            }
        }

        // Update treeview with all the screen items of the selected s
        private void UpdateScreenItems()
        {
            treeView_ScreenItems.Nodes.Clear();
            if (opns.Project == null || treeView_Screens.SelectedNode == null)
            {
                return;
            }

            HmiScreen screen = (HmiScreen)treeView_Screens.SelectedNode.Tag;

            List<HmiScreenItemBase> screenItems = opns.Unified_GetScreenItems(screen);
            foreach (HmiScreenItemBase item in screenItems)
            {
                TreeNode node = treeView_ScreenItems.Nodes.Add(item.Name);
                node.Tag = item;
            }
        }

        // Update attributes of the selected screen item
        private void UpdateScreenAttributes()
        {
            dataGridView_ScreenItemAttributes.Rows.Clear();
            if (opns.Project == null || treeView_ScreenItems.SelectedNode == null)
            {
                return;
            }

            HmiScreenItemBase item = (HmiScreenItemBase)treeView_ScreenItems.SelectedNode.Tag;
            IEnumerable<string> names = new string[] { "Left", "Top", "Height", "Width" };
            IList<object> attributes = item.GetAttributes(names);

            dataGridView_ScreenItemAttributes.Rows.Add("Left", attributes[0]);
            dataGridView_ScreenItemAttributes.Rows.Add("Top", attributes[1]);
            dataGridView_ScreenItemAttributes.Rows.Add("Height", attributes[2]);
            dataGridView_ScreenItemAttributes.Rows.Add("Width", attributes[3]);
        }

        private void button_RefreshDevices_Click(object sender, EventArgs e)
        {
            UpdateDevices();
        }

        private void button_RefreshScreens_Click(object sender, EventArgs e)
        {
            UpdateScreens();
        }

        private void button_RefreshScreenItems_Click(object sender, EventArgs e)
        {
            UpdateScreenItems();
        }

        private void treeView_Devices_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateScreens();
            textBox_SelectedDevices.Text = treeView_Devices.SelectedNode.Text;
        }

        private void treeView_Screens_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateScreenItems();
            textBox_SelectedScreen.Text = treeView_Screens.SelectedNode.Text;
        }

        private void treeView_ScreenItems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateScreenAttributes();
            textBox_SelectedScreenItems.Text = treeView_ScreenItems.SelectedNode.Text;
        }
        #endregion

        // Create device
        private void button_CreateDevice_Click(object sender, EventArgs e)
        {
            if (opns.Project == null)
            {
                return;
            }

            opns.Unified_CreateHMI(comboBox_DeviceOrderNumber.Text, textBox_DeviceName.Text);
            UpdateDevices();
        }

        // Create screen
        private void button_CreateScreen_Click(object sender, EventArgs e)
        {
            if (opns.Project == null)
            {
                return;
            }

            Device device = (Device)treeView_Devices.SelectedNode.Tag;
            opns.Unified_CreateScreen(device, textBox_ScreenName.Text);
            UpdateScreens();
        }

        // Clear screen
        private void button_ClearScreen_Click(object sender, EventArgs e)
        {
            if (opns.Project == null || treeView_Devices.SelectedNode == null)
            {
                return;
            }

            HmiScreen screen = (HmiScreen)treeView_Screens.SelectedNode.Tag;
            List<HmiScreenItemBase> items = new List<HmiScreenItemBase>();
            if (MessageBox.Show("Are you sure you want to delete all objects from the selected screen?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (HmiScreenItemBase item in screen.ScreenItems)
                {
                    items.Add(item);
                }
                foreach (HmiScreenItemBase item in items)
                {
                    item.Delete();
                }
            }
            UpdateScreenItems();
        }

        // Delete screen
        private void button_DeleteScreen_Click(object sender, EventArgs e)
        {
            if (opns.Project == null || treeView_Screens.SelectedNode == null)
            {
                return;
            }

            HmiScreen screen = (HmiScreen)treeView_Screens.SelectedNode.Tag;
            if (MessageBox.Show("Are you sure you want to delete this screen?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                screen.Delete();
                UpdateScreens();
            }
        }

        // Create elements
        private void button_CreateElements_Click(object sender, EventArgs e)
        {
            if (opns.Project == null || treeView_Screens.SelectedNode == null)
            {
                return;
            }
            string errorMsg = String.Empty;
            HmiScreen screen = null;
            HmiScreenItemBaseComposition screenItems = null;

            try
            {
                screen = (HmiScreen)treeView_Screens.SelectedNode.Tag;
                screenItems = screen.ScreenItems;
                screen.Width = 1840;
                screen.Height = 980;
                screen.BackColor = Color.FromArgb(205, 211, 215);

                HmiRectangle rec = screen.ScreenItems.Create<HmiRectangle>("Rectangle_Title bar");
                rec.BackColor = Color.FromArgb(0, 0, 40);
                rec.Height = 80;
                rec.Width = 1840;
                rec.Left = 0;
                rec.Top = 0;

                HmiTextBox textBox = screen.ScreenItems.Create<HmiTextBox>("Text box_Title");
                textBox.Text.Items[0].Text = "<body><p>Openness Engineering</p></body>";
                textBox.ForeColor = Color.White;
                textBox.Padding.Left = 20;
                textBox.Font.Size = 40;
                textBox.Font.Weight = HmiFontWeight.Bold;
                textBox.Height = 80;
                textBox.Width = 500;
                textBox.Left = 0;
                textBox.Top = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (screen != null)
            {
                // Add HmiButton
                if (checkBox_AddButton.Checked)
                {
                    try
                    {
                        HmiButton item = screenItems.Create<HmiButton>("");
                        item.Left = 20;
                        item.Top = 100;
                        item.Text.Items[0].Text = "<body><p>Button</p></body>";
                        HmiButtonEventHandler hmiButtonEventHandler = item.EventHandlers.Create(HmiButtonEventType.Tapped);
                        hmiButtonEventHandler.Script.ScriptCode = "//code";
                    }
                    catch (Exception ex)
                    {
                        errorMsg += $"{ex.Message} {Environment.NewLine}";
                    }

                }

                // Add HmiIOField
                if (checkBox_AddIOField.Checked)
                {
                    try
                    {
                        HmiIOField item = screenItems.Create<HmiIOField>("");
                        item.Left = 20;
                        item.Top = 150;
                        item.ProcessValue = "25";
                        TagDynamization td = item.Dynamizations.Create<TagDynamization>("ProcessValue");
                        td.Tag = "03_Int";
                    }
                    catch (Exception ex)
                    {
                        errorMsg += $"{ex.Message} {Environment.NewLine}";
                    }
                }

                // Add HmiToggleSwitch
                if (checkBox_AddSwitch.Checked)
                {
                    try
                    {
                        HmiToggleSwitch item = screenItems.Create<HmiToggleSwitch>("");
                        item.Left = 20;
                        item.Top = 200;
                        
                    }
                    catch (Exception ex)
                    {
                        errorMsg += $"{ex.Message} {Environment.NewLine}";
                    }
                }

                // Add HmiCheckBoxGroup
                if (checkBox_AddCheckbox.Checked)
                {
                    try
                    {
                        HmiWidgetBase item = screenItems.Create<HmiCheckBoxGroup>("");
                        item.Left = 20;
                        item.Top = 250;
                    }
                    catch (Exception ex)
                    {
                        errorMsg += $"{ex.Message} {Environment.NewLine}";
                    }
                }

                // Add HmiListBox 
                if (checkBox_AddListBox.Checked)
                {
                    try
                    {
                        HmiWidgetBase item = screenItems.Create<HmiListBox>("");
                        item.Left = 190;
                        item.Top = 250;
                    }
                    catch (Exception ex)
                    {
                        errorMsg += $"{ex.Message} {Environment.NewLine}";
                    }
                }

                // Add HmiRadioButtonGroup
                if (checkBox_AddRadioButton.Checked)
                {
                    try
                    {
                        HmiWidgetBase item = screenItems.Create<HmiRadioButtonGroup>("");
                        item.Left = 360;
                        item.Top = 250;
                    }
                    catch (Exception ex)
                    {
                        errorMsg += $"{ex.Message} {Environment.NewLine}";
                    }
                }

                // Add HmiSlider
                if (checkBox_AddSlider.Checked)
                {
                    try
                    {
                        HmiSlider item = screenItems.Create<HmiSlider>("");
                        item.Left = 520;
                        item.Top = 100;
                        item.Width = 120;
                        item.Height = 300;
                        item.ProcessValue = "25";
                        TagDynamization td = item.Dynamizations.Create<TagDynamization>("ProcessValue");
                        td.Tag = "03_Int";
                    }
                    catch (Exception ex)
                    {
                        errorMsg += $"{ex.Message} {Environment.NewLine}";
                    }
                }

                // Add HmiBar
                if (checkBox_AddBar.Checked)
                {
                    try
                    {
                        HmiBar item = screenItems.Create<HmiBar>("");
                        item.Left = 650;
                        item.Top = 100;
                        item.Width = 80;
                        item.Height = 300;
                        item.ProcessValue = "25";
                        TagDynamization td = item.Dynamizations.Create<TagDynamization>("ProcessValue");
                        td.Tag = "03_Int";
                    }
                    catch (Exception ex)
                    {
                        errorMsg += $"{ex.Message} {Environment.NewLine}";
                    }
                }

                // Add HmiGauge
                if (checkBox_AddGauge.Checked)
                {
                    try
                    {
                        HmiWidgetBase item = screenItems.Create<HmiGauge>("");
                        item.Left = 740;
                        item.Top = 100;
                        item.Width = 320;
                        item.Height = 300;
                    }
                    catch (Exception ex)
                    {
                        errorMsg += $"{ex.Message} {Environment.NewLine}";
                    }
                }

                // Add HmiClock
                if (checkBox_AddClock.Checked)
                {
                    try
                    {
                        HmiWidgetBase item = screenItems.Create<HmiClock>("");
                        item.Left = 1070;
                        item.Top = 100;
                        item.Width = 320;
                        item.Height = 300;
                    }
                    catch (Exception ex)
                    {
                        errorMsg += $"{ex.Message} {Environment.NewLine}";
                    }
                }

                // Add HmiScreenWindow
                if (checkBox_AddScreenWindow.Checked)
                {
                    try
                    {
                        HmiScreenWindow item = screenItems.Create<HmiScreenWindow>("");
                        item.Left = 20;
                        item.Top = 420;
                        item.Width = 640;
                        item.Height = 530;
                        item.Screen = "03_Elements";
                        item.Adaption = HmiScreenWindowAdaption.ScreenToWindow;
                    }
                    catch (Exception ex)
                    {
                        errorMsg += $"{ex.Message} {Environment.NewLine}";
                    }
                }

                // Add HmiFaceplateContainer
                if (checkBox_AddFaceplateContainer.Checked)
                {
                    try
                    {
                        HmiFaceplateContainer item = screenItems.Create<HmiFaceplateContainer>("");
                        item.Left = 680;
                        item.Top = 420;
                        item.Width = 450;
                        item.Height = 460;
                        item.WindowFlags = HmiWindowFlag.ShowBorder;
                        item.ContainedType = "V0.0.2\\fpMotor";
                    }
                    catch (Exception ex)
                    {
                        errorMsg += $"{ex.Message} {Environment.NewLine}";
                    }
                }

                if (!String.IsNullOrEmpty(errorMsg))
                {
                    MessageBox.Show(errorMsg, "Exception Error");
                }
            }
            UpdateScreenItems();
        }
    }
}


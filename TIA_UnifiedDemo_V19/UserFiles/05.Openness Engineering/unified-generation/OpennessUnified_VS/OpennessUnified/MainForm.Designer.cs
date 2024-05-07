namespace OpennessUnified
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel_TIAConnectie = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel_ProjectConnectie = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_CloseTIA = new System.Windows.Forms.Button();
            this.button_DisconnectTIA = new System.Windows.Forms.Button();
            this.button_CloseProject = new System.Windows.Forms.Button();
            this.button_SaveProject = new System.Windows.Forms.Button();
            this.button_OpenProject = new System.Windows.Forms.Button();
            this.button_ConnectTIA = new System.Windows.Forms.Button();
            this.button_StartTIA = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabPageEngineering = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView_ScreenItems = new System.Windows.Forms.TreeView();
            this.treeView_Screens = new System.Windows.Forms.TreeView();
            this.button_RefreshScreenItems = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView_ScreenItemAttributes = new System.Windows.Forms.DataGridView();
            this.AttrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttrValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox_AddCheckbox = new System.Windows.Forms.CheckBox();
            this.checkBox_AddRadioButton = new System.Windows.Forms.CheckBox();
            this.checkBox_AddListBox = new System.Windows.Forms.CheckBox();
            this.checkBox_AddGauge = new System.Windows.Forms.CheckBox();
            this.checkBox_AddButton = new System.Windows.Forms.CheckBox();
            this.checkBox_AddIOField = new System.Windows.Forms.CheckBox();
            this.checkBox_AddSwitch = new System.Windows.Forms.CheckBox();
            this.checkBox_AddSlider = new System.Windows.Forms.CheckBox();
            this.checkBox_AddBar = new System.Windows.Forms.CheckBox();
            this.checkBox_AddClock = new System.Windows.Forms.CheckBox();
            this.textBox_SelectedScreenItems = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_DeviceOrderNumber = new System.Windows.Forms.ComboBox();
            this.button_CreateDevice = new System.Windows.Forms.Button();
            this.textBox_SelectedDevices = new System.Windows.Forms.TextBox();
            this.button_DeleteScreen = new System.Windows.Forms.Button();
            this.button_ClearScreen = new System.Windows.Forms.Button();
            this.button_CreateScreen = new System.Windows.Forms.Button();
            this.textBox_ScreenName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_DeviceName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_SelectedScreen = new System.Windows.Forms.TextBox();
            this.button_RefreshDevices = new System.Windows.Forms.Button();
            this.button_RefreshScreens = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.treeView_Devices = new System.Windows.Forms.TreeView();
            this.checkBox_ScreenWindow = new System.Windows.Forms.CheckBox();
            this.checkBox_AddScreenWindow = new System.Windows.Forms.CheckBox();
            this.button_CreateElements = new System.Windows.Forms.Button();
            this.checkBox_AddFaceplateContainer = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageEngineering.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ScreenItemAttributes)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel_TIAConnectie,
            this.toolStripStatusLabel2,
            this.statusLabel_ProjectConnectie});
            this.statusStrip1.Location = new System.Drawing.Point(0, 483);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(949, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel_TIAConnectie
            // 
            this.statusLabel_TIAConnectie.Name = "statusLabel_TIAConnectie";
            this.statusLabel_TIAConnectie.Size = new System.Drawing.Size(141, 17);
            this.statusLabel_TIAConnectie.Text = "TIA Portal - Disconnected";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // statusLabel_ProjectConnectie
            // 
            this.statusLabel_ProjectConnectie.Name = "statusLabel_ProjectConnectie";
            this.statusLabel_ProjectConnectie.Size = new System.Drawing.Size(127, 17);
            this.statusLabel_ProjectConnectie.Text = "Project - Disconnected";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(949, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button_CloseTIA, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.button_DisconnectTIA, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.button_CloseProject, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button_SaveProject, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button_OpenProject, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_ConnectTIA, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_StartTIA, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(106, 459);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // button_CloseTIA
            // 
            this.button_CloseTIA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_CloseTIA.Location = new System.Drawing.Point(3, 183);
            this.button_CloseTIA.Name = "button_CloseTIA";
            this.button_CloseTIA.Size = new System.Drawing.Size(100, 24);
            this.button_CloseTIA.TabIndex = 6;
            this.button_CloseTIA.Text = "Close TIA";
            this.button_CloseTIA.UseVisualStyleBackColor = true;
            this.button_CloseTIA.Click += new System.EventHandler(this.button_CloseTIA_Click);
            // 
            // button_DisconnectTIA
            // 
            this.button_DisconnectTIA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_DisconnectTIA.Location = new System.Drawing.Point(3, 153);
            this.button_DisconnectTIA.Name = "button_DisconnectTIA";
            this.button_DisconnectTIA.Size = new System.Drawing.Size(100, 24);
            this.button_DisconnectTIA.TabIndex = 5;
            this.button_DisconnectTIA.Text = "Disconnect TIA";
            this.button_DisconnectTIA.UseVisualStyleBackColor = true;
            this.button_DisconnectTIA.Click += new System.EventHandler(this.button_DisconnectTIA_Click);
            // 
            // button_CloseProject
            // 
            this.button_CloseProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_CloseProject.Location = new System.Drawing.Point(3, 123);
            this.button_CloseProject.Name = "button_CloseProject";
            this.button_CloseProject.Size = new System.Drawing.Size(100, 24);
            this.button_CloseProject.TabIndex = 4;
            this.button_CloseProject.Text = "Close Project";
            this.button_CloseProject.UseVisualStyleBackColor = true;
            this.button_CloseProject.Click += new System.EventHandler(this.button_CloseProject_Click);
            // 
            // button_SaveProject
            // 
            this.button_SaveProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_SaveProject.Location = new System.Drawing.Point(3, 93);
            this.button_SaveProject.Name = "button_SaveProject";
            this.button_SaveProject.Size = new System.Drawing.Size(100, 24);
            this.button_SaveProject.TabIndex = 3;
            this.button_SaveProject.Text = "Save Project";
            this.button_SaveProject.UseVisualStyleBackColor = true;
            this.button_SaveProject.Click += new System.EventHandler(this.button_SaveProject_Click);
            // 
            // button_OpenProject
            // 
            this.button_OpenProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_OpenProject.Location = new System.Drawing.Point(3, 63);
            this.button_OpenProject.Name = "button_OpenProject";
            this.button_OpenProject.Size = new System.Drawing.Size(100, 24);
            this.button_OpenProject.TabIndex = 2;
            this.button_OpenProject.Text = "Open Project";
            this.button_OpenProject.UseVisualStyleBackColor = true;
            this.button_OpenProject.Click += new System.EventHandler(this.button_OpenProject_Click);
            // 
            // button_ConnectTIA
            // 
            this.button_ConnectTIA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ConnectTIA.Location = new System.Drawing.Point(3, 33);
            this.button_ConnectTIA.Name = "button_ConnectTIA";
            this.button_ConnectTIA.Size = new System.Drawing.Size(100, 24);
            this.button_ConnectTIA.TabIndex = 1;
            this.button_ConnectTIA.Text = "Connect TIA";
            this.button_ConnectTIA.UseVisualStyleBackColor = true;
            this.button_ConnectTIA.Click += new System.EventHandler(this.button_ConnectTIA_Click);
            // 
            // button_StartTIA
            // 
            this.button_StartTIA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_StartTIA.Location = new System.Drawing.Point(3, 3);
            this.button_StartTIA.Name = "button_StartTIA";
            this.button_StartTIA.Size = new System.Drawing.Size(100, 24);
            this.button_StartTIA.TabIndex = 0;
            this.button_StartTIA.Text = "Start TIA ";
            this.button_StartTIA.UseVisualStyleBackColor = true;
            this.button_StartTIA.Click += new System.EventHandler(this.button_StartTIA_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(106, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 459);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // tabPageEngineering
            // 
            this.tabPageEngineering.BackColor = System.Drawing.Color.White;
            this.tabPageEngineering.Controls.Add(this.tableLayoutPanel2);
            this.tabPageEngineering.Location = new System.Drawing.Point(4, 22);
            this.tabPageEngineering.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageEngineering.Name = "tabPageEngineering";
            this.tabPageEngineering.Size = new System.Drawing.Size(832, 433);
            this.tabPageEngineering.TabIndex = 0;
            this.tabPageEngineering.Text = "Engineering";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.treeView_ScreenItems, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.treeView_Screens, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.button_RefreshScreenItems, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView_ScreenItemAttributes, 4, 8);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_AddCheckbox, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_AddRadioButton, 7, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_AddListBox, 7, 3);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_AddGauge, 7, 4);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_AddButton, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_AddIOField, 6, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_AddSwitch, 6, 3);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_AddSlider, 6, 4);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_AddBar, 6, 5);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_AddClock, 7, 5);
            this.tableLayoutPanel2.Controls.Add(this.textBox_SelectedScreenItems, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_DeviceOrderNumber, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.button_CreateDevice, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.textBox_SelectedDevices, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.button_DeleteScreen, 3, 12);
            this.tableLayoutPanel2.Controls.Add(this.button_ClearScreen, 3, 11);
            this.tableLayoutPanel2.Controls.Add(this.button_CreateScreen, 3, 9);
            this.tableLayoutPanel2.Controls.Add(this.textBox_ScreenName, 3, 8);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 8);
            this.tableLayoutPanel2.Controls.Add(this.textBox_DeviceName, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.textBox_SelectedScreen, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.button_RefreshDevices, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.button_RefreshScreens, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.treeView_Devices, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_ScreenWindow, 0, 16);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_AddScreenWindow, 6, 6);
            this.tableLayoutPanel2.Controls.Add(this.button_CreateElements, 7, 8);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_AddFaceplateContainer, 6, 7);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 17;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(832, 433);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // treeView_ScreenItems
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.treeView_ScreenItems, 2);
            this.treeView_ScreenItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_ScreenItems.Location = new System.Drawing.Point(403, 63);
            this.treeView_ScreenItems.Name = "treeView_ScreenItems";
            this.tableLayoutPanel2.SetRowSpan(this.treeView_ScreenItems, 6);
            this.treeView_ScreenItems.Size = new System.Drawing.Size(194, 174);
            this.treeView_ScreenItems.TabIndex = 48;
            this.treeView_ScreenItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_ScreenItems_AfterSelect);
            // 
            // treeView_Screens
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.treeView_Screens, 2);
            this.treeView_Screens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Screens.Location = new System.Drawing.Point(203, 63);
            this.treeView_Screens.Name = "treeView_Screens";
            this.tableLayoutPanel2.SetRowSpan(this.treeView_Screens, 6);
            this.treeView_Screens.Size = new System.Drawing.Size(194, 174);
            this.treeView_Screens.TabIndex = 47;
            this.treeView_Screens.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Screens_AfterSelect);
            // 
            // button_RefreshScreenItems
            // 
            this.button_RefreshScreenItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_RefreshScreenItems.Location = new System.Drawing.Point(503, 33);
            this.button_RefreshScreenItems.Name = "button_RefreshScreenItems";
            this.button_RefreshScreenItems.Size = new System.Drawing.Size(94, 24);
            this.button_RefreshScreenItems.TabIndex = 42;
            this.button_RefreshScreenItems.Text = "Refresh";
            this.button_RefreshScreenItems.UseVisualStyleBackColor = true;
            this.button_RefreshScreenItems.Click += new System.EventHandler(this.button_RefreshScreenItems_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Devices";
            // 
            // dataGridView_ScreenItemAttributes
            // 
            this.dataGridView_ScreenItemAttributes.AllowUserToAddRows = false;
            this.dataGridView_ScreenItemAttributes.AllowUserToDeleteRows = false;
            this.dataGridView_ScreenItemAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ScreenItemAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttrName,
            this.AttrValue});
            this.tableLayoutPanel2.SetColumnSpan(this.dataGridView_ScreenItemAttributes, 2);
            this.dataGridView_ScreenItemAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ScreenItemAttributes.Location = new System.Drawing.Point(403, 243);
            this.dataGridView_ScreenItemAttributes.Name = "dataGridView_ScreenItemAttributes";
            this.dataGridView_ScreenItemAttributes.RowHeadersVisible = false;
            this.tableLayoutPanel2.SetRowSpan(this.dataGridView_ScreenItemAttributes, 6);
            this.dataGridView_ScreenItemAttributes.Size = new System.Drawing.Size(194, 174);
            this.dataGridView_ScreenItemAttributes.TabIndex = 13;
            // 
            // AttrName
            // 
            this.AttrName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AttrName.HeaderText = "AttrName";
            this.AttrName.Name = "AttrName";
            this.AttrName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AttrName.Width = 76;
            // 
            // AttrValue
            // 
            this.AttrValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AttrValue.HeaderText = "AttrValue";
            this.AttrValue.Name = "AttrValue";
            // 
            // checkBox_AddCheckbox
            // 
            this.checkBox_AddCheckbox.AutoSize = true;
            this.checkBox_AddCheckbox.Checked = true;
            this.checkBox_AddCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AddCheckbox.Location = new System.Drawing.Point(703, 33);
            this.checkBox_AddCheckbox.Name = "checkBox_AddCheckbox";
            this.checkBox_AddCheckbox.Size = new System.Drawing.Size(74, 17);
            this.checkBox_AddCheckbox.TabIndex = 20;
            this.checkBox_AddCheckbox.Text = "Checkbox";
            this.checkBox_AddCheckbox.UseVisualStyleBackColor = true;
            // 
            // checkBox_AddRadioButton
            // 
            this.checkBox_AddRadioButton.AutoSize = true;
            this.checkBox_AddRadioButton.Checked = true;
            this.checkBox_AddRadioButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AddRadioButton.Location = new System.Drawing.Point(703, 63);
            this.checkBox_AddRadioButton.Name = "checkBox_AddRadioButton";
            this.checkBox_AddRadioButton.Size = new System.Drawing.Size(87, 17);
            this.checkBox_AddRadioButton.TabIndex = 21;
            this.checkBox_AddRadioButton.Text = "Radio button";
            this.checkBox_AddRadioButton.UseVisualStyleBackColor = true;
            // 
            // checkBox_AddListBox
            // 
            this.checkBox_AddListBox.AutoSize = true;
            this.checkBox_AddListBox.Checked = true;
            this.checkBox_AddListBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AddListBox.Location = new System.Drawing.Point(703, 93);
            this.checkBox_AddListBox.Name = "checkBox_AddListBox";
            this.checkBox_AddListBox.Size = new System.Drawing.Size(62, 17);
            this.checkBox_AddListBox.TabIndex = 22;
            this.checkBox_AddListBox.Text = "List box";
            this.checkBox_AddListBox.UseVisualStyleBackColor = true;
            // 
            // checkBox_AddGauge
            // 
            this.checkBox_AddGauge.AutoSize = true;
            this.checkBox_AddGauge.Checked = true;
            this.checkBox_AddGauge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AddGauge.Location = new System.Drawing.Point(703, 123);
            this.checkBox_AddGauge.Name = "checkBox_AddGauge";
            this.checkBox_AddGauge.Size = new System.Drawing.Size(58, 17);
            this.checkBox_AddGauge.TabIndex = 23;
            this.checkBox_AddGauge.Text = "Gauge";
            this.checkBox_AddGauge.UseVisualStyleBackColor = true;
            // 
            // checkBox_AddButton
            // 
            this.checkBox_AddButton.AutoSize = true;
            this.checkBox_AddButton.Checked = true;
            this.checkBox_AddButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AddButton.Location = new System.Drawing.Point(603, 33);
            this.checkBox_AddButton.Name = "checkBox_AddButton";
            this.checkBox_AddButton.Size = new System.Drawing.Size(57, 17);
            this.checkBox_AddButton.TabIndex = 14;
            this.checkBox_AddButton.Text = "Button";
            this.checkBox_AddButton.UseVisualStyleBackColor = true;
            // 
            // checkBox_AddIOField
            // 
            this.checkBox_AddIOField.AutoSize = true;
            this.checkBox_AddIOField.Checked = true;
            this.checkBox_AddIOField.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AddIOField.Location = new System.Drawing.Point(603, 63);
            this.checkBox_AddIOField.Name = "checkBox_AddIOField";
            this.checkBox_AddIOField.Size = new System.Drawing.Size(62, 17);
            this.checkBox_AddIOField.TabIndex = 15;
            this.checkBox_AddIOField.Text = "IO Field";
            this.checkBox_AddIOField.UseVisualStyleBackColor = true;
            // 
            // checkBox_AddSwitch
            // 
            this.checkBox_AddSwitch.AutoSize = true;
            this.checkBox_AddSwitch.Checked = true;
            this.checkBox_AddSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AddSwitch.Location = new System.Drawing.Point(603, 93);
            this.checkBox_AddSwitch.Name = "checkBox_AddSwitch";
            this.checkBox_AddSwitch.Size = new System.Drawing.Size(58, 17);
            this.checkBox_AddSwitch.TabIndex = 17;
            this.checkBox_AddSwitch.Text = "Switch";
            this.checkBox_AddSwitch.UseVisualStyleBackColor = true;
            // 
            // checkBox_AddSlider
            // 
            this.checkBox_AddSlider.AutoSize = true;
            this.checkBox_AddSlider.Checked = true;
            this.checkBox_AddSlider.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AddSlider.Location = new System.Drawing.Point(603, 123);
            this.checkBox_AddSlider.Name = "checkBox_AddSlider";
            this.checkBox_AddSlider.Size = new System.Drawing.Size(52, 17);
            this.checkBox_AddSlider.TabIndex = 16;
            this.checkBox_AddSlider.Text = "Slider";
            this.checkBox_AddSlider.UseVisualStyleBackColor = true;
            // 
            // checkBox_AddBar
            // 
            this.checkBox_AddBar.AutoSize = true;
            this.checkBox_AddBar.Checked = true;
            this.checkBox_AddBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AddBar.Location = new System.Drawing.Point(603, 153);
            this.checkBox_AddBar.Name = "checkBox_AddBar";
            this.checkBox_AddBar.Size = new System.Drawing.Size(42, 17);
            this.checkBox_AddBar.TabIndex = 19;
            this.checkBox_AddBar.Text = "Bar";
            this.checkBox_AddBar.UseVisualStyleBackColor = true;
            // 
            // checkBox_AddClock
            // 
            this.checkBox_AddClock.AutoSize = true;
            this.checkBox_AddClock.Checked = true;
            this.checkBox_AddClock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AddClock.Location = new System.Drawing.Point(703, 153);
            this.checkBox_AddClock.Name = "checkBox_AddClock";
            this.checkBox_AddClock.Size = new System.Drawing.Size(53, 17);
            this.checkBox_AddClock.TabIndex = 18;
            this.checkBox_AddClock.Text = "Clock";
            this.checkBox_AddClock.UseVisualStyleBackColor = true;
            // 
            // textBox_SelectedScreenItems
            // 
            this.textBox_SelectedScreenItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_SelectedScreenItems.Location = new System.Drawing.Point(403, 33);
            this.textBox_SelectedScreenItems.Name = "textBox_SelectedScreenItems";
            this.textBox_SelectedScreenItems.ReadOnly = true;
            this.textBox_SelectedScreenItems.Size = new System.Drawing.Size(94, 20);
            this.textBox_SelectedScreenItems.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Screens";
            // 
            // comboBox_DeviceOrderNumber
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.comboBox_DeviceOrderNumber, 2);
            this.comboBox_DeviceOrderNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_DeviceOrderNumber.FormattingEnabled = true;
            this.comboBox_DeviceOrderNumber.Items.AddRange(new object[] {
            "6AV2 128-3GB06-0AX0/16.0.0.0",
            "6AV2 128-3KB06-0AX0/16.0.0.0",
            "6AV2 128-3MB06-0AX0/16.0.0.0",
            "6AV2 128-3QB06-0AX0/16.0.0.0",
            "6AV2 128-3UB06-0AX0/16.0.0.0",
            "6AV2 128-3XB06-0AX0/16.0.0.0",
            "6AV2 155-xxxxx-xxxx/16.0.0.0"});
            this.comboBox_DeviceOrderNumber.Location = new System.Drawing.Point(3, 243);
            this.comboBox_DeviceOrderNumber.Name = "comboBox_DeviceOrderNumber";
            this.comboBox_DeviceOrderNumber.Size = new System.Drawing.Size(194, 21);
            this.comboBox_DeviceOrderNumber.TabIndex = 37;
            // 
            // button_CreateDevice
            // 
            this.button_CreateDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_CreateDevice.Location = new System.Drawing.Point(103, 303);
            this.button_CreateDevice.Name = "button_CreateDevice";
            this.button_CreateDevice.Size = new System.Drawing.Size(94, 24);
            this.button_CreateDevice.TabIndex = 36;
            this.button_CreateDevice.Text = "Create Device";
            this.button_CreateDevice.UseVisualStyleBackColor = true;
            this.button_CreateDevice.Click += new System.EventHandler(this.button_CreateDevice_Click);
            // 
            // textBox_SelectedDevices
            // 
            this.textBox_SelectedDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_SelectedDevices.Location = new System.Drawing.Point(3, 33);
            this.textBox_SelectedDevices.Name = "textBox_SelectedDevices";
            this.textBox_SelectedDevices.ReadOnly = true;
            this.textBox_SelectedDevices.Size = new System.Drawing.Size(94, 20);
            this.textBox_SelectedDevices.TabIndex = 35;
            // 
            // button_DeleteScreen
            // 
            this.button_DeleteScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_DeleteScreen.Location = new System.Drawing.Point(303, 363);
            this.button_DeleteScreen.Name = "button_DeleteScreen";
            this.button_DeleteScreen.Size = new System.Drawing.Size(94, 24);
            this.button_DeleteScreen.TabIndex = 8;
            this.button_DeleteScreen.Text = "Delete Screen";
            this.button_DeleteScreen.UseVisualStyleBackColor = true;
            this.button_DeleteScreen.Click += new System.EventHandler(this.button_DeleteScreen_Click);
            // 
            // button_ClearScreen
            // 
            this.button_ClearScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ClearScreen.Location = new System.Drawing.Point(303, 333);
            this.button_ClearScreen.Name = "button_ClearScreen";
            this.button_ClearScreen.Size = new System.Drawing.Size(94, 24);
            this.button_ClearScreen.TabIndex = 2;
            this.button_ClearScreen.Text = "Clear Screen";
            this.button_ClearScreen.UseVisualStyleBackColor = true;
            this.button_ClearScreen.Click += new System.EventHandler(this.button_ClearScreen_Click);
            // 
            // button_CreateScreen
            // 
            this.button_CreateScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_CreateScreen.Location = new System.Drawing.Point(303, 273);
            this.button_CreateScreen.Name = "button_CreateScreen";
            this.button_CreateScreen.Size = new System.Drawing.Size(94, 24);
            this.button_CreateScreen.TabIndex = 5;
            this.button_CreateScreen.Text = "Create Screen";
            this.button_CreateScreen.UseVisualStyleBackColor = true;
            this.button_CreateScreen.Click += new System.EventHandler(this.button_CreateScreen_Click);
            // 
            // textBox_ScreenName
            // 
            this.textBox_ScreenName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ScreenName.Location = new System.Drawing.Point(303, 243);
            this.textBox_ScreenName.Name = "textBox_ScreenName";
            this.textBox_ScreenName.Size = new System.Drawing.Size(94, 20);
            this.textBox_ScreenName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Screen Name:";
            // 
            // textBox_DeviceName
            // 
            this.textBox_DeviceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_DeviceName.Location = new System.Drawing.Point(103, 273);
            this.textBox_DeviceName.Name = "textBox_DeviceName";
            this.textBox_DeviceName.Size = new System.Drawing.Size(94, 20);
            this.textBox_DeviceName.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 30);
            this.label8.TabIndex = 39;
            this.label8.Text = "Device Name:";
            // 
            // textBox_SelectedScreen
            // 
            this.textBox_SelectedScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_SelectedScreen.Location = new System.Drawing.Point(203, 33);
            this.textBox_SelectedScreen.Name = "textBox_SelectedScreen";
            this.textBox_SelectedScreen.ReadOnly = true;
            this.textBox_SelectedScreen.Size = new System.Drawing.Size(94, 20);
            this.textBox_SelectedScreen.TabIndex = 3;
            // 
            // button_RefreshDevices
            // 
            this.button_RefreshDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_RefreshDevices.Location = new System.Drawing.Point(103, 33);
            this.button_RefreshDevices.Name = "button_RefreshDevices";
            this.button_RefreshDevices.Size = new System.Drawing.Size(94, 24);
            this.button_RefreshDevices.TabIndex = 40;
            this.button_RefreshDevices.Text = "Refresh";
            this.button_RefreshDevices.UseVisualStyleBackColor = true;
            this.button_RefreshDevices.Click += new System.EventHandler(this.button_RefreshDevices_Click);
            // 
            // button_RefreshScreens
            // 
            this.button_RefreshScreens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_RefreshScreens.Location = new System.Drawing.Point(303, 33);
            this.button_RefreshScreens.Name = "button_RefreshScreens";
            this.button_RefreshScreens.Size = new System.Drawing.Size(94, 24);
            this.button_RefreshScreens.TabIndex = 41;
            this.button_RefreshScreens.Text = "Refresh";
            this.button_RefreshScreens.UseVisualStyleBackColor = true;
            this.button_RefreshScreens.Click += new System.EventHandler(this.button_RefreshScreens_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Screen Items";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label9, 2);
            this.label9.Location = new System.Drawing.Point(603, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Adding Screen Items";
            // 
            // treeView_Devices
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.treeView_Devices, 2);
            this.treeView_Devices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Devices.Location = new System.Drawing.Point(3, 63);
            this.treeView_Devices.Name = "treeView_Devices";
            this.tableLayoutPanel2.SetRowSpan(this.treeView_Devices, 6);
            this.treeView_Devices.Size = new System.Drawing.Size(194, 174);
            this.treeView_Devices.TabIndex = 46;
            this.treeView_Devices.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Devices_AfterSelect);
            // 
            // checkBox_ScreenWindow
            // 
            this.checkBox_ScreenWindow.AutoSize = true;
            this.checkBox_ScreenWindow.Checked = true;
            this.checkBox_ScreenWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel2.SetColumnSpan(this.checkBox_ScreenWindow, 2);
            this.checkBox_ScreenWindow.Location = new System.Drawing.Point(3, 483);
            this.checkBox_ScreenWindow.Name = "checkBox_ScreenWindow";
            this.checkBox_ScreenWindow.Size = new System.Drawing.Size(102, 1);
            this.checkBox_ScreenWindow.TabIndex = 49;
            this.checkBox_ScreenWindow.Text = "Screen Window";
            this.checkBox_ScreenWindow.UseVisualStyleBackColor = true;
            // 
            // checkBox_AddScreenWindow
            // 
            this.checkBox_AddScreenWindow.AutoSize = true;
            this.checkBox_AddScreenWindow.Checked = true;
            this.checkBox_AddScreenWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel2.SetColumnSpan(this.checkBox_AddScreenWindow, 2);
            this.checkBox_AddScreenWindow.Location = new System.Drawing.Point(603, 183);
            this.checkBox_AddScreenWindow.Name = "checkBox_AddScreenWindow";
            this.checkBox_AddScreenWindow.Size = new System.Drawing.Size(102, 17);
            this.checkBox_AddScreenWindow.TabIndex = 50;
            this.checkBox_AddScreenWindow.Text = "Screen Window";
            this.checkBox_AddScreenWindow.UseVisualStyleBackColor = true;
            // 
            // button_CreateElements
            // 
            this.button_CreateElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_CreateElements.Location = new System.Drawing.Point(703, 243);
            this.button_CreateElements.Name = "button_CreateElements";
            this.button_CreateElements.Size = new System.Drawing.Size(94, 24);
            this.button_CreateElements.TabIndex = 10;
            this.button_CreateElements.Text = "Create Elements";
            this.button_CreateElements.UseVisualStyleBackColor = true;
            this.button_CreateElements.Click += new System.EventHandler(this.button_CreateElements_Click);
            // 
            // checkBox_AddFaceplateContainer
            // 
            this.checkBox_AddFaceplateContainer.AutoSize = true;
            this.checkBox_AddFaceplateContainer.Checked = true;
            this.checkBox_AddFaceplateContainer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel2.SetColumnSpan(this.checkBox_AddFaceplateContainer, 2);
            this.checkBox_AddFaceplateContainer.Location = new System.Drawing.Point(603, 213);
            this.checkBox_AddFaceplateContainer.Name = "checkBox_AddFaceplateContainer";
            this.checkBox_AddFaceplateContainer.Size = new System.Drawing.Size(118, 17);
            this.checkBox_AddFaceplateContainer.TabIndex = 51;
            this.checkBox_AddFaceplateContainer.Text = "FaceplateContainer";
            this.checkBox_AddFaceplateContainer.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageEngineering);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 18);
            this.tabControl1.Location = new System.Drawing.Point(109, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 459);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 14;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 505);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Openness WinCC Unified Demo";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPageEngineering.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ScreenItemAttributes)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_TIAConnectie;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_ProjectConnectie;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_CloseTIA;
        private System.Windows.Forms.Button button_DisconnectTIA;
        private System.Windows.Forms.Button button_CloseProject;
        private System.Windows.Forms.Button button_SaveProject;
        private System.Windows.Forms.Button button_OpenProject;
        private System.Windows.Forms.Button button_ConnectTIA;
        private System.Windows.Forms.Button button_StartTIA;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabPage tabPageEngineering;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox_SelectedScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_DeleteScreen;
        private System.Windows.Forms.Button button_CreateScreen;
        private System.Windows.Forms.TextBox textBox_ScreenName;
        private System.Windows.Forms.Button button_ClearScreen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_CreateElements;
        private System.Windows.Forms.DataGridView dataGridView_ScreenItemAttributes;
        private System.Windows.Forms.CheckBox checkBox_AddButton;
        private System.Windows.Forms.CheckBox checkBox_AddIOField;
        private System.Windows.Forms.CheckBox checkBox_AddSlider;
        private System.Windows.Forms.CheckBox checkBox_AddSwitch;
        private System.Windows.Forms.CheckBox checkBox_AddBar;
        private System.Windows.Forms.CheckBox checkBox_AddClock;
        private System.Windows.Forms.CheckBox checkBox_AddCheckbox;
        private System.Windows.Forms.CheckBox checkBox_AddRadioButton;
        private System.Windows.Forms.CheckBox checkBox_AddListBox;
        private System.Windows.Forms.CheckBox checkBox_AddGauge;
        private System.Windows.Forms.TextBox textBox_SelectedScreenItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_SelectedDevices;
        private System.Windows.Forms.ComboBox comboBox_DeviceOrderNumber;
        private System.Windows.Forms.Button button_CreateDevice;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox_DeviceName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_RefreshDevices;
        private System.Windows.Forms.Button button_RefreshScreens;
        private System.Windows.Forms.Button button_RefreshScreenItems;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TreeView treeView_ScreenItems;
        private System.Windows.Forms.TreeView treeView_Screens;
        private System.Windows.Forms.TreeView treeView_Devices;
        private System.Windows.Forms.CheckBox checkBox_ScreenWindow;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttrValue;
        private System.Windows.Forms.CheckBox checkBox_AddScreenWindow;
        private System.Windows.Forms.CheckBox checkBox_AddFaceplateContainer;
    }
}


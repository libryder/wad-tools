namespace ActiveDirectoryTools
{
    partial class MainWindow
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.exportButton = new System.Windows.Forms.Button();
            this.exportFileBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.exportTypeCombo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.exportSaveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.runCleanupButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mapDriveButton = new System.Windows.Forms.Button();
            this.mapShareTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mapDriveTextBox = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.applicationClose = new System.Windows.Forms.Button();
            this.totalItemsLabel = new System.Windows.Forms.Label();
            this.browseForTxtFile = new System.Windows.Forms.OpenFileDialog();
            this.backgroundLoadObjects = new System.ComponentModel.BackgroundWorker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.startRDSessionButton = new System.Windows.Forms.Button();
            this.disableRemoteButton = new System.Windows.Forms.Button();
            this.enableRemoteButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.loadingGraphic = new System.Windows.Forms.PictureBox();
            this.registerCompButton = new System.Windows.Forms.Button();
            this.filterApplyButton = new System.Windows.Forms.Button();
            this.filterLabel = new System.Windows.Forms.Label();
            this.resolveHostButton = new System.Windows.Forms.Button();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.ipEnterTextBox = new System.Windows.Forms.TextBox();
            this.resolveIPButton = new System.Windows.Forms.Button();
            this.ipEnterCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.syncDatabase = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.countProgressLabel = new System.Windows.Forms.Label();
            this.probeClearButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.probeStopButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.totalErrorsText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.totalOtherText = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.totalCompText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.total520Text = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.total740Text = new System.Windows.Forms.TextBox();
            this.total755Text = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.total760Text = new System.Windows.Forms.TextBox();
            this.total960Text = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.resultList = new System.Windows.Forms.ListView();
            this.computerName = new System.Windows.Forms.ColumnHeader();
            this.model = new System.Windows.Forms.ColumnHeader();
            this.physicalMemory = new System.Windows.Forms.ColumnHeader();
            this.username = new System.Windows.Forms.ColumnHeader();
            this.status = new System.Windows.Forms.ColumnHeader();
            this.freeSpace = new System.Windows.Forms.ColumnHeader();
            this.serviceTag = new System.Windows.Forms.ColumnHeader();
            this.runAsButton = new System.Windows.Forms.Button();
            this.runLocallyCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundRunCleanup = new System.ComponentModel.BackgroundWorker();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.remoteInstallButton = new System.Windows.Forms.Button();
            this.remoteInstallComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.customCommandRunButton = new System.Windows.Forms.Button();
            this.customCommandTextBox = new System.Windows.Forms.TextBox();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.applySearchBackground = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.workstationTab = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ADTab = new System.Windows.Forms.TabPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.queueHideGal = new System.Windows.Forms.Button();
            this.userQueueList = new System.Windows.Forms.ListView();
            this.queueUserCn = new System.Windows.Forms.ColumnHeader();
            this.queueUserDesc = new System.Windows.Forms.ColumnHeader();
            this.queueUser = new System.Windows.Forms.ColumnHeader();
            this.queueOu = new System.Windows.Forms.ColumnHeader();
            this.queueExt = new System.Windows.Forms.ColumnHeader();
            this.clearQueueButton = new System.Windows.Forms.Button();
            this.userChangePwButton = new System.Windows.Forms.Button();
            this.userTermButton = new System.Windows.Forms.Button();
            this.userEnableButton = new System.Windows.Forms.Button();
            this.userDisableButton = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.userOuTreeView = new System.Windows.Forms.TreeView();
            this.userFindCreateGroup = new System.Windows.Forms.GroupBox();
            this.userFindLabel = new System.Windows.Forms.LinkLabel();
            this.userBusyGraphic = new System.Windows.Forms.PictureBox();
            this.userFindButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameFindBox = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.userGroupChangeList = new System.Windows.Forms.ListView();
            this.userCn = new System.Windows.Forms.ColumnHeader();
            this.userDesc = new System.Windows.Forms.ColumnHeader();
            this.user = new System.Windows.Forms.ColumnHeader();
            this.userOu = new System.Windows.Forms.ColumnHeader();
            this.userExt = new System.Windows.Forms.ColumnHeader();
            this.userTotalLabel = new System.Windows.Forms.Label();
            this.userGroupSelectAll = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.userGroupAddGroupCombo = new System.Windows.Forms.ComboBox();
            this.userAddGroupButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.userLoadPropertiesThread = new System.ComponentModel.BackgroundWorker();
            this.termUserThread = new System.ComponentModel.BackgroundWorker();
            this.backgroundFillUserList = new System.ComponentModel.BackgroundWorker();
            this.backgroundUserSearch = new System.ComponentModel.BackgroundWorker();
            this.userContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewEditUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exchangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideMailboxFromGALToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showMailboxInGALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.enableMailboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetLockoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDocumentsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.termUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.exportUserList = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descriptionToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tooltipBackground = new System.ComponentModel.BackgroundWorker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.fillListView = new System.ComponentModel.BackgroundWorker();
            this.getComputers = new System.ComponentModel.BackgroundWorker();
            this.singleListViewBackground = new System.ComponentModel.BackgroundWorker();
            this.fillObjectList = new System.ComponentModel.BackgroundWorker();
            this.exportSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.queueListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeFromQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.computerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.probeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.remoteDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.enableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.runCleanupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportUsersButton = new System.Windows.Forms.Button();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGraphic)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.workstationTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ADTab.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.userFindCreateGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBusyGraphic)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.userContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.queueListContextMenu.SuspendLayout();
            this.computerMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // exportButton
            // 
            this.exportButton.BackColor = System.Drawing.SystemColors.Window;
            this.exportButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exportButton.Location = new System.Drawing.Point(100, 188);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(73, 23);
            this.exportButton.TabIndex = 14;
            this.exportButton.Text = "Open";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.MouseLeave += new System.EventHandler(this.exportButton_MouseLeave);
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            this.exportButton.MouseEnter += new System.EventHandler(this.exportButton_MouseEnter);
            // 
            // exportFileBox
            // 
            this.exportFileBox.Location = new System.Drawing.Point(9, 116);
            this.exportFileBox.Name = "exportFileBox";
            this.exportFileBox.Size = new System.Drawing.Size(164, 20);
            this.exportFileBox.TabIndex = 12;
            this.exportFileBox.Text = "computer_list.txt";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.exportTypeCombo);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.exportSaveButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.exportButton);
            this.groupBox1.Controls.Add(this.exportFileBox);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(432, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 227);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Open object list in notepad";
            // 
            // exportTypeCombo
            // 
            this.exportTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exportTypeCombo.FormattingEnabled = true;
            this.exportTypeCombo.Items.AddRange(new object[] {
            "Excel",
            "Notepad"});
            this.exportTypeCombo.Location = new System.Drawing.Point(9, 49);
            this.exportTypeCombo.Name = "exportTypeCombo";
            this.exportTypeCombo.Size = new System.Drawing.Size(164, 21);
            this.exportTypeCombo.TabIndex = 17;
            this.exportTypeCombo.SelectedIndexChanged += new System.EventHandler(this.exportTypeCombo_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Export using:";
            // 
            // exportSaveButton
            // 
            this.exportSaveButton.Location = new System.Drawing.Point(114, 142);
            this.exportSaveButton.Name = "exportSaveButton";
            this.exportSaveButton.Size = new System.Drawing.Size(59, 23);
            this.exportSaveButton.TabIndex = 15;
            this.exportSaveButton.Text = "Browse";
            this.exportSaveButton.UseVisualStyleBackColor = false;
            this.exportSaveButton.Click += new System.EventHandler(this.exportSaveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Filename";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.runCleanupButton);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(226, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(189, 54);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Disk Cleanup";
            // 
            // runCleanupButton
            // 
            this.runCleanupButton.BackColor = System.Drawing.SystemColors.Window;
            this.runCleanupButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.runCleanupButton.Location = new System.Drawing.Point(17, 19);
            this.runCleanupButton.Name = "runCleanupButton";
            this.runCleanupButton.Size = new System.Drawing.Size(144, 23);
            this.runCleanupButton.TabIndex = 17;
            this.runCleanupButton.Text = "Run on selected computer";
            this.runCleanupButton.UseVisualStyleBackColor = false;
            this.runCleanupButton.MouseLeave += new System.EventHandler(this.runCleanupButton_MouseLeave);
            this.runCleanupButton.Click += new System.EventHandler(this.runCleanupButton_Click);
            this.runCleanupButton.MouseEnter += new System.EventHandler(this.runCleanupButton_MouseEnter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.mapDriveButton);
            this.groupBox4.Controls.Add(this.mapShareTextBox);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.mapDriveTextBox);
            this.groupBox4.Controls.Add(this.checkBox2);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(628, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(179, 135);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Map drive";
            // 
            // mapDriveButton
            // 
            this.mapDriveButton.BackColor = System.Drawing.SystemColors.Window;
            this.mapDriveButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mapDriveButton.Location = new System.Drawing.Point(112, 94);
            this.mapDriveButton.Name = "mapDriveButton";
            this.mapDriveButton.Size = new System.Drawing.Size(61, 23);
            this.mapDriveButton.TabIndex = 21;
            this.mapDriveButton.Text = "Map";
            this.mapDriveButton.UseVisualStyleBackColor = false;
            this.mapDriveButton.MouseLeave += new System.EventHandler(this.mapDriveButton_MouseLeave);
            this.mapDriveButton.Click += new System.EventHandler(this.mapDriveButton_Click);
            this.mapDriveButton.MouseEnter += new System.EventHandler(this.mapDriveButton_MouseEnter);
            // 
            // mapShareTextBox
            // 
            this.mapShareTextBox.Location = new System.Drawing.Point(50, 46);
            this.mapShareTextBox.Name = "mapShareTextBox";
            this.mapShareTextBox.Size = new System.Drawing.Size(123, 20);
            this.mapShareTextBox.TabIndex = 19;
            this.mapShareTextBox.Text = "\\\\ironhide\\public";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Folder:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Drive:";
            // 
            // mapDriveTextBox
            // 
            this.mapDriveTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapDriveTextBox.Items.AddRange(new object[] {
            "A:",
            "B:",
            "C:",
            "D:",
            "E:",
            "F:",
            "G:",
            "H:",
            "I:",
            "J:",
            "K:",
            "L:",
            "M:",
            "N:",
            "O:",
            "P:",
            "Q:",
            "R:",
            "S:",
            "T:",
            "U:",
            "V:",
            "W:",
            "X:",
            "Y:",
            "Z:"});
            this.mapDriveTextBox.Location = new System.Drawing.Point(50, 19);
            this.mapDriveTextBox.Name = "mapDriveTextBox";
            this.mapDriveTextBox.Size = new System.Drawing.Size(56, 21);
            this.mapDriveTextBox.TabIndex = 18;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(28, 94);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(78, 17);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "Persistent?";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // applicationClose
            // 
            this.applicationClose.BackColor = System.Drawing.SystemColors.Window;
            this.applicationClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.applicationClose.Location = new System.Drawing.Point(884, 697);
            this.applicationClose.Name = "applicationClose";
            this.applicationClose.Size = new System.Drawing.Size(75, 23);
            this.applicationClose.TabIndex = 29;
            this.applicationClose.Text = "Close";
            this.applicationClose.UseVisualStyleBackColor = false;
            this.applicationClose.Click += new System.EventHandler(this.applicationClose_Click);
            // 
            // totalItemsLabel
            // 
            this.totalItemsLabel.AutoSize = true;
            this.totalItemsLabel.Location = new System.Drawing.Point(583, 317);
            this.totalItemsLabel.Name = "totalItemsLabel";
            this.totalItemsLabel.Size = new System.Drawing.Size(62, 13);
            this.totalItemsLabel.TabIndex = 13;
            this.totalItemsLabel.Text = "Total Items:";
            this.totalItemsLabel.Visible = false;
            // 
            // browseForTxtFile
            // 
            this.browseForTxtFile.FileName = "openFileDialog1";
            // 
            // backgroundLoadObjects
            // 
            this.backgroundLoadObjects.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundLoadObjects_DoWork);
            this.backgroundLoadObjects.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundLoadObjects_RunWorkerCompleted);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.startRDSessionButton);
            this.groupBox5.Controls.Add(this.disableRemoteButton);
            this.groupBox5.Controls.Add(this.enableRemoteButton);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox5.Location = new System.Drawing.Point(226, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(189, 87);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Remote Desktop";
            // 
            // startRDSessionButton
            // 
            this.startRDSessionButton.BackColor = System.Drawing.SystemColors.Window;
            this.startRDSessionButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startRDSessionButton.Location = new System.Drawing.Point(37, 58);
            this.startRDSessionButton.Name = "startRDSessionButton";
            this.startRDSessionButton.Size = new System.Drawing.Size(105, 23);
            this.startRDSessionButton.TabIndex = 24;
            this.startRDSessionButton.Text = "Start Session";
            this.startRDSessionButton.UseVisualStyleBackColor = false;
            this.startRDSessionButton.MouseLeave += new System.EventHandler(this.startRDSessionButton_MouseLeave);
            this.startRDSessionButton.Click += new System.EventHandler(this.startRDSessionButton_Click);
            this.startRDSessionButton.MouseEnter += new System.EventHandler(this.startRDSessionButton_MouseEnter);
            // 
            // disableRemoteButton
            // 
            this.disableRemoteButton.BackColor = System.Drawing.SystemColors.Window;
            this.disableRemoteButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.disableRemoteButton.Location = new System.Drawing.Point(108, 25);
            this.disableRemoteButton.Name = "disableRemoteButton";
            this.disableRemoteButton.Size = new System.Drawing.Size(75, 23);
            this.disableRemoteButton.TabIndex = 23;
            this.disableRemoteButton.Text = "Disable";
            this.disableRemoteButton.UseVisualStyleBackColor = false;
            this.disableRemoteButton.MouseLeave += new System.EventHandler(this.disableRemoteButton_MouseLeave);
            this.disableRemoteButton.Click += new System.EventHandler(this.disableRemoteButton_Click);
            this.disableRemoteButton.MouseEnter += new System.EventHandler(this.disableRemoteButton_MouseEnter);
            // 
            // enableRemoteButton
            // 
            this.enableRemoteButton.BackColor = System.Drawing.SystemColors.Window;
            this.enableRemoteButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.enableRemoteButton.Location = new System.Drawing.Point(6, 25);
            this.enableRemoteButton.Name = "enableRemoteButton";
            this.enableRemoteButton.Size = new System.Drawing.Size(75, 23);
            this.enableRemoteButton.TabIndex = 22;
            this.enableRemoteButton.Text = "Enable";
            this.enableRemoteButton.UseVisualStyleBackColor = false;
            this.enableRemoteButton.MouseLeave += new System.EventHandler(this.enableRemoteButton_MouseLeave);
            this.enableRemoteButton.Click += new System.EventHandler(this.enableRemoteButton_Click);
            this.enableRemoteButton.MouseEnter += new System.EventHandler(this.enableRemoteButton_MouseEnter);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.loadingGraphic);
            this.groupBox6.Controls.Add(this.registerCompButton);
            this.groupBox6.Controls.Add(this.filterApplyButton);
            this.groupBox6.Controls.Add(this.filterLabel);
            this.groupBox6.Controls.Add(this.resolveHostButton);
            this.groupBox6.Controls.Add(this.filterTextBox);
            this.groupBox6.Controls.Add(this.ipEnterTextBox);
            this.groupBox6.Controls.Add(this.resolveIPButton);
            this.groupBox6.Controls.Add(this.ipEnterCheckBox);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox6.Location = new System.Drawing.Point(9, 7);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(202, 227);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Find or specify computers";
            // 
            // loadingGraphic
            // 
            this.loadingGraphic.Image = global::ActiveDirectoryTools.Properties.Resources._17_11;
            this.loadingGraphic.Location = new System.Drawing.Point(13, 58);
            this.loadingGraphic.Name = "loadingGraphic";
            this.loadingGraphic.Size = new System.Drawing.Size(15, 15);
            this.loadingGraphic.TabIndex = 14;
            this.loadingGraphic.TabStop = false;
            // 
            // registerCompButton
            // 
            this.registerCompButton.BackColor = System.Drawing.SystemColors.Window;
            this.registerCompButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.registerCompButton.Location = new System.Drawing.Point(18, 188);
            this.registerCompButton.Name = "registerCompButton";
            this.registerCompButton.Size = new System.Drawing.Size(163, 23);
            this.registerCompButton.TabIndex = 15;
            this.registerCompButton.Text = "Manually Register Computer";
            this.registerCompButton.UseVisualStyleBackColor = false;
            this.registerCompButton.Click += new System.EventHandler(this.registerCompButton_Click);
            // 
            // filterApplyButton
            // 
            this.filterApplyButton.BackColor = System.Drawing.SystemColors.Window;
            this.filterApplyButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.filterApplyButton.Image = global::ActiveDirectoryTools.Properties.Resources.edit_find;
            this.filterApplyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.filterApplyButton.Location = new System.Drawing.Point(101, 52);
            this.filterApplyButton.Name = "filterApplyButton";
            this.filterApplyButton.Size = new System.Drawing.Size(75, 28);
            this.filterApplyButton.TabIndex = 2;
            this.filterApplyButton.Text = "Search";
            this.filterApplyButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filterApplyButton.UseVisualStyleBackColor = false;
            this.filterApplyButton.Click += new System.EventHandler(this.filterApplyButton_Click);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(6, 27);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(44, 13);
            this.filterLabel.TabIndex = 13;
            this.filterLabel.Text = "Search:";
            // 
            // resolveHostButton
            // 
            this.resolveHostButton.BackColor = System.Drawing.SystemColors.Window;
            this.resolveHostButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resolveHostButton.Location = new System.Drawing.Point(18, 153);
            this.resolveHostButton.Name = "resolveHostButton";
            this.resolveHostButton.Size = new System.Drawing.Size(75, 23);
            this.resolveHostButton.TabIndex = 10;
            this.resolveHostButton.Text = "IP Address";
            this.resolveHostButton.UseVisualStyleBackColor = false;
            this.resolveHostButton.MouseLeave += new System.EventHandler(this.resolveHostButton_MouseLeave);
            this.resolveHostButton.Click += new System.EventHandler(this.resolveHostButton_Click);
            this.resolveHostButton.MouseEnter += new System.EventHandler(this.resolveHostButton_MouseEnter);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(56, 24);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(125, 20);
            this.filterTextBox.TabIndex = 0;
            this.filterTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filterTextBox_KeyDown);
            // 
            // ipEnterTextBox
            // 
            this.ipEnterTextBox.Enabled = false;
            this.ipEnterTextBox.Location = new System.Drawing.Point(18, 121);
            this.ipEnterTextBox.Name = "ipEnterTextBox";
            this.ipEnterTextBox.Size = new System.Drawing.Size(163, 20);
            this.ipEnterTextBox.TabIndex = 7;
            // 
            // resolveIPButton
            // 
            this.resolveIPButton.BackColor = System.Drawing.SystemColors.Window;
            this.resolveIPButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resolveIPButton.Location = new System.Drawing.Point(106, 153);
            this.resolveIPButton.Name = "resolveIPButton";
            this.resolveIPButton.Size = new System.Drawing.Size(75, 23);
            this.resolveIPButton.TabIndex = 9;
            this.resolveIPButton.Text = "Hostname";
            this.resolveIPButton.UseVisualStyleBackColor = false;
            this.resolveIPButton.MouseLeave += new System.EventHandler(this.resolveIPButton_MouseLeave);
            this.resolveIPButton.Click += new System.EventHandler(this.resolveIPButton_Click);
            this.resolveIPButton.MouseEnter += new System.EventHandler(this.resolveIPButton_MouseEnter);
            // 
            // ipEnterCheckBox
            // 
            this.ipEnterCheckBox.AutoSize = true;
            this.ipEnterCheckBox.Location = new System.Drawing.Point(22, 98);
            this.ipEnterCheckBox.Name = "ipEnterCheckBox";
            this.ipEnterCheckBox.Size = new System.Drawing.Size(155, 17);
            this.ipEnterCheckBox.TabIndex = 6;
            this.ipEnterCheckBox.Text = "Enter IP or Computer Name";
            this.ipEnterCheckBox.UseVisualStyleBackColor = true;
            this.ipEnterCheckBox.MouseLeave += new System.EventHandler(this.ipEnterCheckBox_MouseLeave);
            this.ipEnterCheckBox.MouseEnter += new System.EventHandler(this.ipEnterCheckBox_MouseEnter);
            this.ipEnterCheckBox.CheckedChanged += new System.EventHandler(this.ipEnterCheckBox_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.syncDatabase);
            this.groupBox7.Controls.Add(this.groupBox15);
            this.groupBox7.Controls.Add(this.groupBox13);
            this.groupBox7.Controls.Add(this.resultList);
            this.groupBox7.Controls.Add(this.totalItemsLabel);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox7.Location = new System.Drawing.Point(9, 240);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(936, 416);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Network Computers";
            // 
            // syncDatabase
            // 
            this.syncDatabase.Location = new System.Drawing.Point(697, 342);
            this.syncDatabase.Name = "syncDatabase";
            this.syncDatabase.Size = new System.Drawing.Size(75, 23);
            this.syncDatabase.TabIndex = 35;
            this.syncDatabase.Text = "Write Data";
            this.syncDatabase.UseVisualStyleBackColor = true;
            this.syncDatabase.Visible = false;
            this.syncDatabase.Click += new System.EventHandler(this.syncDatabase_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.countProgressLabel);
            this.groupBox15.Controls.Add(this.probeClearButton);
            this.groupBox15.Controls.Add(this.progressBar);
            this.groupBox15.Controls.Add(this.probeStopButton);
            this.groupBox15.Controls.Add(this.runButton);
            this.groupBox15.Location = new System.Drawing.Point(9, 317);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(521, 52);
            this.groupBox15.TabIndex = 34;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Probe all computers in list";
            // 
            // countProgressLabel
            // 
            this.countProgressLabel.AutoSize = true;
            this.countProgressLabel.Location = new System.Drawing.Point(229, 25);
            this.countProgressLabel.Name = "countProgressLabel";
            this.countProgressLabel.Size = new System.Drawing.Size(34, 13);
            this.countProgressLabel.TabIndex = 33;
            this.countProgressLabel.Text = "0 of 0";
            // 
            // probeClearButton
            // 
            this.probeClearButton.Location = new System.Drawing.Point(133, 19);
            this.probeClearButton.Name = "probeClearButton";
            this.probeClearButton.Size = new System.Drawing.Size(90, 23);
            this.probeClearButton.TabIndex = 27;
            this.probeClearButton.Text = "Clear/Cancel";
            this.probeClearButton.UseVisualStyleBackColor = false;
            this.probeClearButton.Click += new System.EventHandler(this.probeClearButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(291, 19);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(215, 19);
            this.progressBar.TabIndex = 32;
            // 
            // probeStopButton
            // 
            this.probeStopButton.Location = new System.Drawing.Point(68, 19);
            this.probeStopButton.Name = "probeStopButton";
            this.probeStopButton.Size = new System.Drawing.Size(59, 23);
            this.probeStopButton.TabIndex = 26;
            this.probeStopButton.Text = "Pause";
            this.probeStopButton.UseVisualStyleBackColor = false;
            this.probeStopButton.Click += new System.EventHandler(this.probeStopButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(6, 19);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(56, 23);
            this.runButton.TabIndex = 25;
            this.runButton.Text = "Probe";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.totalErrorsText);
            this.groupBox13.Controls.Add(this.label7);
            this.groupBox13.Controls.Add(this.totalOtherText);
            this.groupBox13.Controls.Add(this.label35);
            this.groupBox13.Controls.Add(this.totalCompText);
            this.groupBox13.Controls.Add(this.label6);
            this.groupBox13.Controls.Add(this.total520Text);
            this.groupBox13.Controls.Add(this.label8);
            this.groupBox13.Controls.Add(this.total740Text);
            this.groupBox13.Controls.Add(this.total755Text);
            this.groupBox13.Controls.Add(this.label9);
            this.groupBox13.Controls.Add(this.label11);
            this.groupBox13.Controls.Add(this.total760Text);
            this.groupBox13.Controls.Add(this.total960Text);
            this.groupBox13.Controls.Add(this.label12);
            this.groupBox13.Controls.Add(this.label13);
            this.groupBox13.Location = new System.Drawing.Point(771, 19);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(159, 294);
            this.groupBox13.TabIndex = 22;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Summary";
            // 
            // totalErrorsText
            // 
            this.totalErrorsText.BackColor = System.Drawing.Color.White;
            this.totalErrorsText.ForeColor = System.Drawing.Color.Black;
            this.totalErrorsText.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.totalErrorsText.Location = new System.Drawing.Point(95, 223);
            this.totalErrorsText.Name = "totalErrorsText";
            this.totalErrorsText.ReadOnly = true;
            this.totalErrorsText.Size = new System.Drawing.Size(50, 20);
            this.totalErrorsText.TabIndex = 15;
            this.totalErrorsText.Text = "0";
            this.totalErrorsText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Errors";
            // 
            // totalOtherText
            // 
            this.totalOtherText.BackColor = System.Drawing.Color.White;
            this.totalOtherText.ForeColor = System.Drawing.Color.Black;
            this.totalOtherText.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.totalOtherText.Location = new System.Drawing.Point(95, 190);
            this.totalOtherText.Name = "totalOtherText";
            this.totalOtherText.ReadOnly = true;
            this.totalOtherText.Size = new System.Drawing.Size(50, 20);
            this.totalOtherText.TabIndex = 13;
            this.totalOtherText.Text = "0";
            this.totalOtherText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(30, 193);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(33, 13);
            this.label35.TabIndex = 12;
            this.label35.Text = "Other";
            // 
            // totalCompText
            // 
            this.totalCompText.BackColor = System.Drawing.Color.White;
            this.totalCompText.ForeColor = System.Drawing.Color.Black;
            this.totalCompText.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.totalCompText.Location = new System.Drawing.Point(95, 257);
            this.totalCompText.Name = "totalCompText";
            this.totalCompText.ReadOnly = true;
            this.totalCompText.Size = new System.Drawing.Size(50, 20);
            this.totalCompText.TabIndex = 11;
            this.totalCompText.Text = "0";
            this.totalCompText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total Computers";
            // 
            // total520Text
            // 
            this.total520Text.BackColor = System.Drawing.Color.White;
            this.total520Text.ForeColor = System.Drawing.Color.Black;
            this.total520Text.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.total520Text.Location = new System.Drawing.Point(95, 156);
            this.total520Text.Name = "total520Text";
            this.total520Text.ReadOnly = true;
            this.total520Text.Size = new System.Drawing.Size(50, 20);
            this.total520Text.TabIndex = 9;
            this.total520Text.Text = "0";
            this.total520Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Total 520s";
            // 
            // total740Text
            // 
            this.total740Text.BackColor = System.Drawing.Color.White;
            this.total740Text.ForeColor = System.Drawing.Color.Black;
            this.total740Text.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.total740Text.Location = new System.Drawing.Point(95, 121);
            this.total740Text.Name = "total740Text";
            this.total740Text.ReadOnly = true;
            this.total740Text.Size = new System.Drawing.Size(50, 20);
            this.total740Text.TabIndex = 7;
            this.total740Text.Text = "0";
            this.total740Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // total755Text
            // 
            this.total755Text.BackColor = System.Drawing.Color.White;
            this.total755Text.ForeColor = System.Drawing.Color.Black;
            this.total755Text.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.total755Text.Location = new System.Drawing.Point(95, 88);
            this.total755Text.Name = "total755Text";
            this.total755Text.ReadOnly = true;
            this.total755Text.Size = new System.Drawing.Size(50, 20);
            this.total755Text.TabIndex = 6;
            this.total755Text.Text = "0";
            this.total755Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Total 740s";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Total 755s";
            // 
            // total760Text
            // 
            this.total760Text.BackColor = System.Drawing.Color.White;
            this.total760Text.ForeColor = System.Drawing.Color.Black;
            this.total760Text.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.total760Text.Location = new System.Drawing.Point(95, 53);
            this.total760Text.Name = "total760Text";
            this.total760Text.ReadOnly = true;
            this.total760Text.Size = new System.Drawing.Size(50, 20);
            this.total760Text.TabIndex = 3;
            this.total760Text.Text = "0";
            this.total760Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // total960Text
            // 
            this.total960Text.BackColor = System.Drawing.Color.White;
            this.total960Text.ForeColor = System.Drawing.Color.Black;
            this.total960Text.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.total960Text.Location = new System.Drawing.Point(95, 20);
            this.total960Text.Name = "total960Text";
            this.total960Text.ReadOnly = true;
            this.total960Text.Size = new System.Drawing.Size(50, 20);
            this.total960Text.TabIndex = 2;
            this.total960Text.Text = "0";
            this.total960Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Total 760s";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Total 960s";
            // 
            // resultList
            // 
            this.resultList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.computerName,
            this.model,
            this.physicalMemory,
            this.username,
            this.status,
            this.freeSpace,
            this.serviceTag});
            this.resultList.FullRowSelect = true;
            this.resultList.HideSelection = false;
            this.resultList.Location = new System.Drawing.Point(6, 19);
            this.resultList.MultiSelect = false;
            this.resultList.Name = "resultList";
            this.resultList.ShowGroups = false;
            this.resultList.Size = new System.Drawing.Size(750, 292);
            this.resultList.TabIndex = 20;
            this.resultList.UseCompatibleStateImageBehavior = false;
            this.resultList.View = System.Windows.Forms.View.Details;
            this.resultList.SelectedIndexChanged += new System.EventHandler(this.resultListBox_SelectedIndexChanged);
            this.resultList.DoubleClick += new System.EventHandler(this.resultList_DoubleClick);
            this.resultList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resultList_MouseUp);
            this.resultList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.resultList_ColumnClick);
            // 
            // computerName
            // 
            this.computerName.Text = "Computer Name";
            this.computerName.Width = 120;
            // 
            // model
            // 
            this.model.Text = "Model";
            this.model.Width = 120;
            // 
            // physicalMemory
            // 
            this.physicalMemory.Text = "Memory";
            this.physicalMemory.Width = 84;
            // 
            // username
            // 
            this.username.Text = "Current User";
            this.username.Width = 110;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 125;
            // 
            // freeSpace
            // 
            this.freeSpace.Text = "Free Space";
            this.freeSpace.Width = 90;
            // 
            // serviceTag
            // 
            this.serviceTag.Text = "Service Tag";
            this.serviceTag.Width = 80;
            // 
            // runAsButton
            // 
            this.runAsButton.BackColor = System.Drawing.SystemColors.Window;
            this.runAsButton.Enabled = false;
            this.runAsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.runAsButton.Location = new System.Drawing.Point(148, 633);
            this.runAsButton.Name = "runAsButton";
            this.runAsButton.Size = new System.Drawing.Size(75, 23);
            this.runAsButton.TabIndex = 28;
            this.runAsButton.Text = "Login";
            this.runAsButton.UseVisualStyleBackColor = false;
            this.runAsButton.MouseLeave += new System.EventHandler(this.runAsButton_MouseLeave);
            this.runAsButton.Click += new System.EventHandler(this.runAsButton_Click);
            this.runAsButton.MouseEnter += new System.EventHandler(this.runAsButton_MouseEnter);
            // 
            // runLocallyCheckBox
            // 
            this.runLocallyCheckBox.AutoSize = true;
            this.runLocallyCheckBox.Checked = true;
            this.runLocallyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runLocallyCheckBox.Location = new System.Drawing.Point(15, 639);
            this.runLocallyCheckBox.Name = "runLocallyCheckBox";
            this.runLocallyCheckBox.Size = new System.Drawing.Size(127, 17);
            this.runLocallyCheckBox.TabIndex = 27;
            this.runLocallyCheckBox.Text = "Run command locally";
            this.runLocallyCheckBox.UseVisualStyleBackColor = true;
            this.runLocallyCheckBox.MouseLeave += new System.EventHandler(this.runLocallyCheckBox_MouseLeave);
            this.runLocallyCheckBox.MouseEnter += new System.EventHandler(this.runLocallyCheckBox_MouseEnter);
            this.runLocallyCheckBox.CheckedChanged += new System.EventHandler(this.runLocallyCheckBox_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.remoteInstallButton);
            this.groupBox8.Controls.Add(this.remoteInstallComboBox);
            this.groupBox8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox8.Location = new System.Drawing.Point(226, 160);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(189, 74);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Remote Install";
            // 
            // remoteInstallButton
            // 
            this.remoteInstallButton.BackColor = System.Drawing.SystemColors.Window;
            this.remoteInstallButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.remoteInstallButton.Location = new System.Drawing.Point(108, 46);
            this.remoteInstallButton.Name = "remoteInstallButton";
            this.remoteInstallButton.Size = new System.Drawing.Size(75, 23);
            this.remoteInstallButton.TabIndex = 11;
            this.remoteInstallButton.Text = "Install";
            this.remoteInstallButton.UseVisualStyleBackColor = false;
            this.remoteInstallButton.Click += new System.EventHandler(this.remoteInstallButton_Click);
            // 
            // remoteInstallComboBox
            // 
            this.remoteInstallComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.remoteInstallComboBox.FormattingEnabled = true;
            this.remoteInstallComboBox.Items.AddRange(new object[] {
            "MS Paint"});
            this.remoteInstallComboBox.Location = new System.Drawing.Point(6, 20);
            this.remoteInstallComboBox.Name = "remoteInstallComboBox";
            this.remoteInstallComboBox.Size = new System.Drawing.Size(177, 21);
            this.remoteInstallComboBox.TabIndex = 10;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.customCommandRunButton);
            this.groupBox9.Controls.Add(this.customCommandTextBox);
            this.groupBox9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox9.Location = new System.Drawing.Point(628, 148);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(179, 86);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Custom Command";
            // 
            // customCommandRunButton
            // 
            this.customCommandRunButton.BackColor = System.Drawing.SystemColors.Window;
            this.customCommandRunButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customCommandRunButton.Location = new System.Drawing.Point(111, 58);
            this.customCommandRunButton.Name = "customCommandRunButton";
            this.customCommandRunButton.Size = new System.Drawing.Size(61, 23);
            this.customCommandRunButton.TabIndex = 26;
            this.customCommandRunButton.Text = "Run";
            this.customCommandRunButton.UseVisualStyleBackColor = false;
            this.customCommandRunButton.MouseLeave += new System.EventHandler(this.customCommandRunButton_MouseLeave);
            this.customCommandRunButton.Click += new System.EventHandler(this.customCommandRunButton_Click);
            this.customCommandRunButton.MouseEnter += new System.EventHandler(this.customCommandRunButton_MouseEnter);
            // 
            // customCommandTextBox
            // 
            this.customCommandTextBox.Location = new System.Drawing.Point(8, 32);
            this.customCommandTextBox.Name = "customCommandTextBox";
            this.customCommandTextBox.Size = new System.Drawing.Size(165, 20);
            this.customCommandTextBox.TabIndex = 25;
            this.customCommandTextBox.Text = "shutdown /r /t 0";
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 723);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(988, 22);
            this.mainStatusStrip.TabIndex = 30;
            this.mainStatusStrip.Text = "none";
            // 
            // mainToolStripLabel
            // 
            this.mainToolStripLabel.Name = "mainToolStripLabel";
            this.mainToolStripLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // applySearchBackground
            // 
            this.applySearchBackground.DoWork += new System.ComponentModel.DoWorkEventHandler(this.applySearchBackground_DoWork);
            this.applySearchBackground.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.applySearchBackground_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.workstationTab);
            this.tabControl1.Controls.Add(this.ADTab);
            this.tabControl1.Location = new System.Drawing.Point(10, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(967, 688);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // workstationTab
            // 
            this.workstationTab.AutoScroll = true;
            this.workstationTab.BackColor = System.Drawing.SystemColors.Window;
            this.workstationTab.Controls.Add(this.pictureBox1);
            this.workstationTab.Controls.Add(this.groupBox6);
            this.workstationTab.Controls.Add(this.groupBox7);
            this.workstationTab.Controls.Add(this.groupBox9);
            this.workstationTab.Controls.Add(this.groupBox8);
            this.workstationTab.Controls.Add(this.groupBox5);
            this.workstationTab.Controls.Add(this.groupBox1);
            this.workstationTab.Controls.Add(this.groupBox4);
            this.workstationTab.Controls.Add(this.runAsButton);
            this.workstationTab.Controls.Add(this.groupBox3);
            this.workstationTab.Controls.Add(this.runLocallyCheckBox);
            this.workstationTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.workstationTab.Location = new System.Drawing.Point(4, 22);
            this.workstationTab.Name = "workstationTab";
            this.workstationTab.Padding = new System.Windows.Forms.Padding(3);
            this.workstationTab.Size = new System.Drawing.Size(959, 662);
            this.workstationTab.TabIndex = 0;
            this.workstationTab.Text = "Workstations";
            this.workstationTab.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ActiveDirectoryTools.Properties.Resources.Full_Logo_2008;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(870, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 211);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // ADTab
            // 
            this.ADTab.BackColor = System.Drawing.SystemColors.Window;
            this.ADTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ADTab.Controls.Add(this.groupBox14);
            this.ADTab.Controls.Add(this.groupBox12);
            this.ADTab.Controls.Add(this.userFindCreateGroup);
            this.ADTab.Controls.Add(this.groupBox11);
            this.ADTab.Controls.Add(this.groupBox10);
            this.ADTab.Location = new System.Drawing.Point(4, 22);
            this.ADTab.Name = "ADTab";
            this.ADTab.Padding = new System.Windows.Forms.Padding(3);
            this.ADTab.Size = new System.Drawing.Size(959, 662);
            this.ADTab.TabIndex = 1;
            this.ADTab.Text = "Active Directory";
            this.ADTab.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.queueHideGal);
            this.groupBox14.Controls.Add(this.userQueueList);
            this.groupBox14.Controls.Add(this.clearQueueButton);
            this.groupBox14.Controls.Add(this.userChangePwButton);
            this.groupBox14.Controls.Add(this.userTermButton);
            this.groupBox14.Controls.Add(this.userEnableButton);
            this.groupBox14.Controls.Add(this.userDisableButton);
            this.groupBox14.Location = new System.Drawing.Point(299, 455);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(646, 193);
            this.groupBox14.TabIndex = 37;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Batch queue";
            // 
            // queueHideGal
            // 
            this.queueHideGal.Location = new System.Drawing.Point(499, 153);
            this.queueHideGal.Name = "queueHideGal";
            this.queueHideGal.Size = new System.Drawing.Size(108, 25);
            this.queueHideGal.TabIndex = 43;
            this.queueHideGal.Text = "Hide From GAL";
            this.queueHideGal.UseVisualStyleBackColor = false;
            this.queueHideGal.Click += new System.EventHandler(this.queueHideGal_Click);
            // 
            // userQueueList
            // 
            this.userQueueList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.queueUserCn,
            this.queueUserDesc,
            this.queueUser,
            this.queueOu,
            this.queueExt});
            this.userQueueList.FullRowSelect = true;
            this.userQueueList.Location = new System.Drawing.Point(10, 19);
            this.userQueueList.Name = "userQueueList";
            this.userQueueList.Size = new System.Drawing.Size(629, 128);
            this.userQueueList.TabIndex = 42;
            this.userQueueList.UseCompatibleStateImageBehavior = false;
            this.userQueueList.View = System.Windows.Forms.View.Details;
            this.userQueueList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.userQueueList_MouseUp);
            // 
            // queueUserCn
            // 
            this.queueUserCn.Text = "Name";
            this.queueUserCn.Width = 110;
            // 
            // queueUserDesc
            // 
            this.queueUserDesc.Text = "Description";
            this.queueUserDesc.Width = 177;
            // 
            // queueUser
            // 
            this.queueUser.Text = "Username";
            this.queueUser.Width = 100;
            // 
            // queueOu
            // 
            this.queueOu.Text = "OU";
            this.queueOu.Width = 143;
            // 
            // queueExt
            // 
            this.queueExt.Text = "Phone";
            this.queueExt.Width = 80;
            // 
            // clearQueueButton
            // 
            this.clearQueueButton.BackColor = System.Drawing.SystemColors.Window;
            this.clearQueueButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clearQueueButton.Location = new System.Drawing.Point(255, 153);
            this.clearQueueButton.Name = "clearQueueButton";
            this.clearQueueButton.Size = new System.Drawing.Size(76, 25);
            this.clearQueueButton.TabIndex = 1;
            this.clearQueueButton.Text = "Clear";
            this.clearQueueButton.UseVisualStyleBackColor = false;
            this.clearQueueButton.Click += new System.EventHandler(this.clearQueueButton_Click);
            // 
            // userChangePwButton
            // 
            this.userChangePwButton.BackColor = System.Drawing.SystemColors.Window;
            this.userChangePwButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userChangePwButton.Image = global::ActiveDirectoryTools.Properties.Resources.emblem_readonly;
            this.userChangePwButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userChangePwButton.Location = new System.Drawing.Point(336, 153);
            this.userChangePwButton.Name = "userChangePwButton";
            this.userChangePwButton.Size = new System.Drawing.Size(157, 25);
            this.userChangePwButton.TabIndex = 38;
            this.userChangePwButton.Text = "Change Password(s)";
            this.userChangePwButton.UseVisualStyleBackColor = false;
            this.userChangePwButton.MouseLeave += new System.EventHandler(this.userChangePwButton_MouseLeave);
            this.userChangePwButton.Click += new System.EventHandler(this.userChangePwButton_Click);
            this.userChangePwButton.MouseEnter += new System.EventHandler(this.userChangePwButton_MouseEnter);
            // 
            // userTermButton
            // 
            this.userTermButton.BackColor = System.Drawing.SystemColors.Window;
            this.userTermButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userTermButton.Image = global::ActiveDirectoryTools.Properties.Resources.process_stop;
            this.userTermButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userTermButton.Location = new System.Drawing.Point(174, 153);
            this.userTermButton.Name = "userTermButton";
            this.userTermButton.Size = new System.Drawing.Size(76, 25);
            this.userTermButton.TabIndex = 41;
            this.userTermButton.Text = "Term";
            this.userTermButton.UseVisualStyleBackColor = false;
            this.userTermButton.MouseLeave += new System.EventHandler(this.userTermButton_MouseLeave);
            this.userTermButton.Click += new System.EventHandler(this.userTermButton_Click);
            this.userTermButton.MouseEnter += new System.EventHandler(this.userTermButton_MouseEnter);
            // 
            // userEnableButton
            // 
            this.userEnableButton.BackColor = System.Drawing.SystemColors.Window;
            this.userEnableButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userEnableButton.Image = global::ActiveDirectoryTools.Properties.Resources.face_grin;
            this.userEnableButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userEnableButton.Location = new System.Drawing.Point(10, 153);
            this.userEnableButton.Name = "userEnableButton";
            this.userEnableButton.Size = new System.Drawing.Size(76, 25);
            this.userEnableButton.TabIndex = 39;
            this.userEnableButton.Text = "Enable";
            this.userEnableButton.UseVisualStyleBackColor = false;
            this.userEnableButton.MouseLeave += new System.EventHandler(this.userEnableButton_MouseLeave);
            this.userEnableButton.Click += new System.EventHandler(this.userEnableButton_Click);
            this.userEnableButton.MouseEnter += new System.EventHandler(this.userEnableButton_MouseEnter);
            // 
            // userDisableButton
            // 
            this.userDisableButton.BackColor = System.Drawing.SystemColors.Window;
            this.userDisableButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userDisableButton.Image = global::ActiveDirectoryTools.Properties.Resources.face_sad;
            this.userDisableButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userDisableButton.Location = new System.Drawing.Point(91, 153);
            this.userDisableButton.Name = "userDisableButton";
            this.userDisableButton.Size = new System.Drawing.Size(76, 25);
            this.userDisableButton.TabIndex = 40;
            this.userDisableButton.Text = "Disable";
            this.userDisableButton.UseVisualStyleBackColor = false;
            this.userDisableButton.MouseLeave += new System.EventHandler(this.userDisableButton_MouseLeave);
            this.userDisableButton.Click += new System.EventHandler(this.userDisableButton_Click);
            this.userDisableButton.MouseEnter += new System.EventHandler(this.userDisableButton_MouseEnter);
            // 
            // groupBox12
            // 
            this.groupBox12.BackColor = System.Drawing.Color.Transparent;
            this.groupBox12.Controls.Add(this.userOuTreeView);
            this.groupBox12.Location = new System.Drawing.Point(6, 6);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(287, 648);
            this.groupBox12.TabIndex = 35;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Load All Items From OU:";
            // 
            // userOuTreeView
            // 
            this.userOuTreeView.BackColor = System.Drawing.SystemColors.Window;
            this.userOuTreeView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userOuTreeView.LineColor = System.Drawing.Color.SteelBlue;
            this.userOuTreeView.Location = new System.Drawing.Point(10, 19);
            this.userOuTreeView.Name = "userOuTreeView";
            this.userOuTreeView.Size = new System.Drawing.Size(271, 623);
            this.userOuTreeView.TabIndex = 37;
            this.userOuTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.userOuTreeView_AfterSelect);
            this.userOuTreeView.MouseEnter += new System.EventHandler(this.userOuTreeView_MouseEnter);
            this.userOuTreeView.MouseLeave += new System.EventHandler(this.userOuTreeView_MouseLeave);
            // 
            // userFindCreateGroup
            // 
            this.userFindCreateGroup.Controls.Add(this.userFindLabel);
            this.userFindCreateGroup.Controls.Add(this.userBusyGraphic);
            this.userFindCreateGroup.Controls.Add(this.userFindButton);
            this.userFindCreateGroup.Controls.Add(this.label1);
            this.userFindCreateGroup.Controls.Add(this.userNameFindBox);
            this.userFindCreateGroup.Location = new System.Drawing.Point(299, 6);
            this.userFindCreateGroup.Name = "userFindCreateGroup";
            this.userFindCreateGroup.Size = new System.Drawing.Size(372, 110);
            this.userFindCreateGroup.TabIndex = 1;
            this.userFindCreateGroup.TabStop = false;
            this.userFindCreateGroup.Text = "Find User or Group";
            // 
            // userFindLabel
            // 
            this.userFindLabel.AutoSize = true;
            this.userFindLabel.Location = new System.Drawing.Point(141, 73);
            this.userFindLabel.Name = "userFindLabel";
            this.userFindLabel.Size = new System.Drawing.Size(104, 13);
            this.userFindLabel.TabIndex = 16;
            this.userFindLabel.TabStop = true;
            this.userFindLabel.Text = "Enter multiple names";
            this.userFindLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.userFindLabel_LinkClicked);
            // 
            // userBusyGraphic
            // 
            this.userBusyGraphic.Image = global::ActiveDirectoryTools.Properties.Resources._17_11;
            this.userBusyGraphic.Location = new System.Drawing.Point(19, 63);
            this.userBusyGraphic.Name = "userBusyGraphic";
            this.userBusyGraphic.Size = new System.Drawing.Size(15, 15);
            this.userBusyGraphic.TabIndex = 15;
            this.userBusyGraphic.TabStop = false;
            this.userBusyGraphic.Visible = false;
            // 
            // userFindButton
            // 
            this.userFindButton.BackColor = System.Drawing.SystemColors.Window;
            this.userFindButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userFindButton.Image = global::ActiveDirectoryTools.Properties.Resources.edit_find;
            this.userFindButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userFindButton.Location = new System.Drawing.Point(251, 64);
            this.userFindButton.Name = "userFindButton";
            this.userFindButton.Size = new System.Drawing.Size(75, 30);
            this.userFindButton.TabIndex = 1;
            this.userFindButton.Text = "Find";
            this.userFindButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userFindButton.UseVisualStyleBackColor = false;
            this.userFindButton.Click += new System.EventHandler(this.userFindButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // userNameFindBox
            // 
            this.userNameFindBox.BackColor = System.Drawing.SystemColors.Window;
            this.userNameFindBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.userNameFindBox.Location = new System.Drawing.Point(50, 27);
            this.userNameFindBox.Name = "userNameFindBox";
            this.userNameFindBox.Size = new System.Drawing.Size(276, 20);
            this.userNameFindBox.TabIndex = 0;
            this.userNameFindBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userNameFindBox_KeyDown);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.userGroupChangeList);
            this.groupBox11.Controls.Add(this.userTotalLabel);
            this.groupBox11.Controls.Add(this.userGroupSelectAll);
            this.groupBox11.Location = new System.Drawing.Point(299, 116);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(646, 333);
            this.groupBox11.TabIndex = 34;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Users/Groups:";
            // 
            // userGroupChangeList
            // 
            this.userGroupChangeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.userCn,
            this.userDesc,
            this.user,
            this.userOu,
            this.userExt});
            this.userGroupChangeList.FullRowSelect = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.userGroupChangeList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.userGroupChangeList.HideSelection = false;
            this.userGroupChangeList.Location = new System.Drawing.Point(11, 19);
            this.userGroupChangeList.Name = "userGroupChangeList";
            this.userGroupChangeList.ShowGroups = false;
            this.userGroupChangeList.Size = new System.Drawing.Size(629, 285);
            this.userGroupChangeList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.userGroupChangeList.TabIndex = 39;
            this.userGroupChangeList.UseCompatibleStateImageBehavior = false;
            this.userGroupChangeList.View = System.Windows.Forms.View.Details;
            this.userGroupChangeList.DoubleClick += new System.EventHandler(this.userGroupChangeList_DoubleClick);
            this.userGroupChangeList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.userGroupChangeList_MouseUp);
            this.userGroupChangeList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.userGroupChangeList_ColumnClick);
            this.userGroupChangeList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userGroupChangeList_KeyDown);
            // 
            // userCn
            // 
            this.userCn.Text = "Name";
            this.userCn.Width = 110;
            // 
            // userDesc
            // 
            this.userDesc.Text = "Description";
            this.userDesc.Width = 177;
            // 
            // user
            // 
            this.user.Text = "Username";
            this.user.Width = 100;
            // 
            // userOu
            // 
            this.userOu.Text = "OU";
            this.userOu.Width = 143;
            // 
            // userExt
            // 
            this.userExt.Text = "Phone";
            this.userExt.Width = 80;
            // 
            // userTotalLabel
            // 
            this.userTotalLabel.AutoSize = true;
            this.userTotalLabel.Location = new System.Drawing.Point(17, 311);
            this.userTotalLabel.Name = "userTotalLabel";
            this.userTotalLabel.Size = new System.Drawing.Size(44, 13);
            this.userTotalLabel.TabIndex = 38;
            this.userTotalLabel.Text = "Items: 0";
            // 
            // userGroupSelectAll
            // 
            this.userGroupSelectAll.AutoSize = true;
            this.userGroupSelectAll.Location = new System.Drawing.Point(94, 310);
            this.userGroupSelectAll.Name = "userGroupSelectAll";
            this.userGroupSelectAll.Size = new System.Drawing.Size(69, 17);
            this.userGroupSelectAll.TabIndex = 37;
            this.userGroupSelectAll.Text = "Select all";
            this.userGroupSelectAll.UseVisualStyleBackColor = true;
            this.userGroupSelectAll.Click += new System.EventHandler(this.userGroupSelectAll_CheckedChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label10);
            this.groupBox10.Controls.Add(this.userGroupAddGroupCombo);
            this.groupBox10.Controls.Add(this.userAddGroupButton);
            this.groupBox10.Location = new System.Drawing.Point(677, 6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(268, 110);
            this.groupBox10.TabIndex = 31;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Add Selected Users To Group:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Group To Add:";
            // 
            // userGroupAddGroupCombo
            // 
            this.userGroupAddGroupCombo.BackColor = System.Drawing.SystemColors.Window;
            this.userGroupAddGroupCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userGroupAddGroupCombo.FormattingEnabled = true;
            this.userGroupAddGroupCombo.Location = new System.Drawing.Point(10, 43);
            this.userGroupAddGroupCombo.Name = "userGroupAddGroupCombo";
            this.userGroupAddGroupCombo.Size = new System.Drawing.Size(248, 21);
            this.userGroupAddGroupCombo.TabIndex = 33;
            // 
            // userAddGroupButton
            // 
            this.userAddGroupButton.BackColor = System.Drawing.SystemColors.Window;
            this.userAddGroupButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userAddGroupButton.Image = global::ActiveDirectoryTools.Properties.Resources.go_next;
            this.userAddGroupButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userAddGroupButton.Location = new System.Drawing.Point(183, 67);
            this.userAddGroupButton.Name = "userAddGroupButton";
            this.userAddGroupButton.Size = new System.Drawing.Size(75, 24);
            this.userAddGroupButton.TabIndex = 33;
            this.userAddGroupButton.Text = "Apply";
            this.userAddGroupButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userAddGroupButton.UseVisualStyleBackColor = false;
            this.userAddGroupButton.MouseLeave += new System.EventHandler(this.userAddGroupButton_MouseLeave);
            this.userAddGroupButton.Click += new System.EventHandler(this.userAddGroupButton_Click);
            this.userAddGroupButton.MouseEnter += new System.EventHandler(this.userAddGroupButton_MouseEnter);
            // 
            // userLoadPropertiesThread
            // 
            this.userLoadPropertiesThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.userLoadPropertiesThread_DoWork);
            this.userLoadPropertiesThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.userLoadPropertiesThread_RunWorkerCompleted);
            // 
            // backgroundFillUserList
            // 
            this.backgroundFillUserList.WorkerSupportsCancellation = true;
            this.backgroundFillUserList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundFillUserList_DoWork);
            this.backgroundFillUserList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundFillUserList_RunWorkerCompleted);
            // 
            // backgroundUserSearch
            // 
            this.backgroundUserSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundUserSearch_DoWork);
            this.backgroundUserSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundUserSearch_RunWorkerCompleted);
            // 
            // userContextMenu
            // 
            this.userContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewEditUserToolStripMenuItem,
            this.addToQueueToolStripMenuItem,
            this.toolStripSeparator1,
            this.exchangeToolStripMenuItem,
            this.toolStripSeparator3,
            this.copyToolStripMenuItem,
            this.resetPasswordToolStripMenuItem,
            this.moveToToolStripMenuItem,
            this.enableToolStripMenuItem,
            this.disableToolStripMenuItem,
            this.resetLockoutToolStripMenuItem,
            this.openDocumentsFolderToolStripMenuItem,
            this.toolStripSeparator2,
            this.termUsersToolStripMenuItem,
            this.toolStripSeparator8,
            this.exportUserList,
            this.toolStripSeparator9,
            this.reportsToolStripMenuItem});
            this.userContextMenu.Name = "userContextMenu";
            this.userContextMenu.Size = new System.Drawing.Size(199, 342);
            this.userContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.userContextMenu_ItemClicked);
            // 
            // viewEditUserToolStripMenuItem
            // 
            this.viewEditUserToolStripMenuItem.Image = global::ActiveDirectoryTools.Properties.Resources.system_users;
            this.viewEditUserToolStripMenuItem.Name = "viewEditUserToolStripMenuItem";
            this.viewEditUserToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.viewEditUserToolStripMenuItem.Text = "View/Edit User";
            // 
            // addToQueueToolStripMenuItem
            // 
            this.addToQueueToolStripMenuItem.Image = global::ActiveDirectoryTools.Properties.Resources.list_add;
            this.addToQueueToolStripMenuItem.Name = "addToQueueToolStripMenuItem";
            this.addToQueueToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.addToQueueToolStripMenuItem.Text = "Add to queue";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // exchangeToolStripMenuItem
            // 
            this.exchangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideMailboxFromGALToolStripMenuItem1,
            this.showMailboxInGALToolStripMenuItem,
            this.toolStripSeparator5,
            this.enableMailboxToolStripMenuItem});
            this.exchangeToolStripMenuItem.Name = "exchangeToolStripMenuItem";
            this.exchangeToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.exchangeToolStripMenuItem.Text = "Exchange";
            // 
            // hideMailboxFromGALToolStripMenuItem1
            // 
            this.hideMailboxFromGALToolStripMenuItem1.Name = "hideMailboxFromGALToolStripMenuItem1";
            this.hideMailboxFromGALToolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
            this.hideMailboxFromGALToolStripMenuItem1.Text = "Hide mailbox from GAL";
            this.hideMailboxFromGALToolStripMenuItem1.Click += new System.EventHandler(this.hideMailboxFromGALToolStripMenuItem1_Click);
            // 
            // showMailboxInGALToolStripMenuItem
            // 
            this.showMailboxInGALToolStripMenuItem.Name = "showMailboxInGALToolStripMenuItem";
            this.showMailboxInGALToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.showMailboxInGALToolStripMenuItem.Text = "Show mailbox in GAL";
            this.showMailboxInGALToolStripMenuItem.Click += new System.EventHandler(this.showMailboxInGALToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(189, 6);
            // 
            // enableMailboxToolStripMenuItem
            // 
            this.enableMailboxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator4});
            this.enableMailboxToolStripMenuItem.Name = "enableMailboxToolStripMenuItem";
            this.enableMailboxToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.enableMailboxToolStripMenuItem.Text = "Enable Mailbox";
            this.enableMailboxToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.enableMailboxToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem1.Text = "In Folder:";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(129, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(195, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::ActiveDirectoryTools.Properties.Resources.window_new;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // resetPasswordToolStripMenuItem
            // 
            this.resetPasswordToolStripMenuItem.Image = global::ActiveDirectoryTools.Properties.Resources.emblem_readonly;
            this.resetPasswordToolStripMenuItem.Name = "resetPasswordToolStripMenuItem";
            this.resetPasswordToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.resetPasswordToolStripMenuItem.Text = "Change password";
            // 
            // moveToToolStripMenuItem
            // 
            this.moveToToolStripMenuItem.Name = "moveToToolStripMenuItem";
            this.moveToToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.moveToToolStripMenuItem.Text = "Move to";
            this.moveToToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.moveToToolStripMenuItem_DropDownItemClicked);
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Image = global::ActiveDirectoryTools.Properties.Resources.face_grin;
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.enableToolStripMenuItem.Text = "Enable";
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Image = global::ActiveDirectoryTools.Properties.Resources.face_sad;
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.disableToolStripMenuItem.Text = "Disable";
            // 
            // resetLockoutToolStripMenuItem
            // 
            this.resetLockoutToolStripMenuItem.Image = global::ActiveDirectoryTools.Properties.Resources.system_lock_screen;
            this.resetLockoutToolStripMenuItem.Name = "resetLockoutToolStripMenuItem";
            this.resetLockoutToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.resetLockoutToolStripMenuItem.Text = "Reset lockout";
            // 
            // openDocumentsFolderToolStripMenuItem
            // 
            this.openDocumentsFolderToolStripMenuItem.Image = global::ActiveDirectoryTools.Properties.Resources.go_home;
            this.openDocumentsFolderToolStripMenuItem.Name = "openDocumentsFolderToolStripMenuItem";
            this.openDocumentsFolderToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.openDocumentsFolderToolStripMenuItem.Text = "Open Documents folder";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // termUsersToolStripMenuItem
            // 
            this.termUsersToolStripMenuItem.Image = global::ActiveDirectoryTools.Properties.Resources.process_stop;
            this.termUsersToolStripMenuItem.Name = "termUsersToolStripMenuItem";
            this.termUsersToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.termUsersToolStripMenuItem.Text = "Term user(s)";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(195, 6);
            // 
            // exportUserList
            // 
            this.exportUserList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem,
            this.notepadToolStripMenuItem});
            this.exportUserList.Name = "exportUserList";
            this.exportUserList.Size = new System.Drawing.Size(198, 22);
            this.exportUserList.Text = "Export User List";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // notepadToolStripMenuItem
            // 
            this.notepadToolStripMenuItem.Name = "notepadToolStripMenuItem";
            this.notepadToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.notepadToolStripMenuItem.Text = "Notepad";
            this.notepadToolStripMenuItem.Click += new System.EventHandler(this.notepadToolStripMenuItem_Click);
            // 
            // descriptionToolTip
            // 
            this.descriptionToolTip.AutoPopDelay = 5000;
            this.descriptionToolTip.InitialDelay = 500;
            this.descriptionToolTip.ReshowDelay = 800;
            // 
            // tooltipBackground
            // 
            this.tooltipBackground.DoWork += new System.ComponentModel.DoWorkEventHandler(this.tooltipBackground_DoWork);
            this.tooltipBackground.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.tooltipBackground_RunWorkerCompleted);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Items: 0";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Window;
            this.listBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(157, 199);
            this.listBox1.TabIndex = 35;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(85, 223);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(69, 17);
            this.checkBox1.TabIndex = 37;
            this.checkBox1.Text = "Select all";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // fillListView
            // 
            this.fillListView.WorkerReportsProgress = true;
            this.fillListView.WorkerSupportsCancellation = true;
            this.fillListView.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fillListView_DoWork);
            this.fillListView.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fillListView_RunWorkerCompleted);
            this.fillListView.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.fillListView_ProgressChanged);
            // 
            // getComputers
            // 
            this.getComputers.WorkerReportsProgress = true;
            this.getComputers.WorkerSupportsCancellation = true;
            this.getComputers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getComputers_DoWork);
            this.getComputers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.getComputers_RunWorkerCompleted);
            // 
            // singleListViewBackground
            // 
            this.singleListViewBackground.WorkerReportsProgress = true;
            this.singleListViewBackground.DoWork += new System.ComponentModel.DoWorkEventHandler(this.singleListViewBackground_DoWork);
            this.singleListViewBackground.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.singleListViewBackground_RunWorkerCompleted);
            // 
            // fillObjectList
            // 
            this.fillObjectList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fillObjectList_DoWork);
            this.fillObjectList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fillObjectList_RunWorkerCompleted);
            // 
            // queueListContextMenu
            // 
            this.queueListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromQueue});
            this.queueListContextMenu.Name = "queueListContextMenu";
            this.queueListContextMenu.Size = new System.Drawing.Size(183, 26);
            // 
            // removeFromQueue
            // 
            this.removeFromQueue.Name = "removeFromQueue";
            this.removeFromQueue.Size = new System.Drawing.Size(182, 22);
            this.removeFromQueue.Text = "Remove from queue";
            this.removeFromQueue.Click += new System.EventHandler(this.removeFromQueue_Click);
            // 
            // computerMenu
            // 
            this.computerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.probeToolStripMenuItem,
            this.toolStripSeparator7,
            this.remoteDesktopToolStripMenuItem,
            this.toolStripMenuItem2});
            this.computerMenu.Name = "computerMenu";
            this.computerMenu.Size = new System.Drawing.Size(165, 76);
            // 
            // probeToolStripMenuItem
            // 
            this.probeToolStripMenuItem.Name = "probeToolStripMenuItem";
            this.probeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.probeToolStripMenuItem.Text = "Probe";
            this.probeToolStripMenuItem.Click += new System.EventHandler(this.probeToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(161, 6);
            // 
            // remoteDesktopToolStripMenuItem
            // 
            this.remoteDesktopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startSessionToolStripMenuItem,
            this.toolStripSeparator6,
            this.enableToolStripMenuItem1,
            this.disableToolStripMenuItem1});
            this.remoteDesktopToolStripMenuItem.Name = "remoteDesktopToolStripMenuItem";
            this.remoteDesktopToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.remoteDesktopToolStripMenuItem.Text = "Remote Desktop";
            // 
            // startSessionToolStripMenuItem
            // 
            this.startSessionToolStripMenuItem.Name = "startSessionToolStripMenuItem";
            this.startSessionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.startSessionToolStripMenuItem.Text = "Start Session";
            this.startSessionToolStripMenuItem.Click += new System.EventHandler(this.startRdSession);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(145, 6);
            // 
            // enableToolStripMenuItem1
            // 
            this.enableToolStripMenuItem1.Name = "enableToolStripMenuItem1";
            this.enableToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.enableToolStripMenuItem1.Text = "Enable";
            this.enableToolStripMenuItem1.Click += new System.EventHandler(this.enableRD);
            // 
            // disableToolStripMenuItem1
            // 
            this.disableToolStripMenuItem1.Name = "disableToolStripMenuItem1";
            this.disableToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.disableToolStripMenuItem1.Text = "Disable";
            this.disableToolStripMenuItem1.Click += new System.EventHandler(this.disableRD);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runCleanupToolStripMenuItem,
            this.openCDriveToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem2.Text = "Remote drive";
            // 
            // runCleanupToolStripMenuItem
            // 
            this.runCleanupToolStripMenuItem.Name = "runCleanupToolStripMenuItem";
            this.runCleanupToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.runCleanupToolStripMenuItem.Text = "Run cleanup";
            this.runCleanupToolStripMenuItem.Click += new System.EventHandler(this.runCleanupToolStripMenuItem_Click);
            // 
            // openCDriveToolStripMenuItem
            // 
            this.openCDriveToolStripMenuItem.Name = "openCDriveToolStripMenuItem";
            this.openCDriveToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.openCDriveToolStripMenuItem.Text = "Open C:\\ Drive";
            this.openCDriveToolStripMenuItem.Click += new System.EventHandler(this.openCDriveToolStripMenuItem_Click);
            // 
            // exportUsersButton
            // 
            this.exportUsersButton.Location = new System.Drawing.Point(650, 694);
            this.exportUsersButton.Name = "exportUsersButton";
            this.exportUsersButton.Size = new System.Drawing.Size(75, 23);
            this.exportUsersButton.TabIndex = 31;
            this.exportUsersButton.Text = "Export List";
            this.exportUsersButton.UseVisualStyleBackColor = true;
            this.exportUsersButton.Visible = false;
            this.exportUsersButton.Click += new System.EventHandler(this.exportUsersButton_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(195, 6);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(988, 745);
            this.Controls.Add(this.exportUsersButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.applicationClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Remote Management Tools";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGraphic)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.workstationTab.ResumeLayout(false);
            this.workstationTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ADTab.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.userFindCreateGroup.ResumeLayout(false);
            this.userFindCreateGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBusyGraphic)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.userContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.queueListContextMenu.ResumeLayout(false);
            this.computerMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.TextBox exportFileBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button runCleanupButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox mapDriveTextBox;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button mapDriveButton;
        private System.Windows.Forms.TextBox mapShareTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button applicationClose;
        private System.Windows.Forms.Label totalItemsLabel;
        private System.Windows.Forms.OpenFileDialog browseForTxtFile;
        private System.ComponentModel.BackgroundWorker backgroundLoadObjects;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button disableRemoteButton;
        private System.Windows.Forms.Button enableRemoteButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button runAsButton;
        private System.Windows.Forms.CheckBox runLocallyCheckBox;
        private System.Windows.Forms.Button filterApplyButton;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.ComponentModel.BackgroundWorker backgroundRunCleanup;
        private System.Windows.Forms.Button startRDSessionButton;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button customCommandRunButton;
        private System.Windows.Forms.TextBox customCommandTextBox;
        private System.Windows.Forms.Button remoteInstallButton;
        private System.Windows.Forms.ComboBox remoteInstallComboBox;
        private System.Windows.Forms.TextBox ipEnterTextBox;
        private System.Windows.Forms.CheckBox ipEnterCheckBox;
        private System.Windows.Forms.Button resolveIPButton;
        private System.Windows.Forms.Button resolveHostButton;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.ComponentModel.BackgroundWorker applySearchBackground;
        private System.Windows.Forms.ToolStripStatusLabel mainToolStripLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage workstationTab;
        private System.Windows.Forms.TabPage ADTab;
        private System.Windows.Forms.GroupBox userFindCreateGroup;
        private System.Windows.Forms.TextBox userNameFindBox;
        private System.Windows.Forms.Button userFindButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button userAddGroupButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox userGroupAddGroupCombo;
        private System.Windows.Forms.CheckBox userGroupSelectAll;
        private System.ComponentModel.BackgroundWorker userLoadPropertiesThread;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button userDisableButton;
        private System.Windows.Forms.Button userEnableButton;
        private System.Windows.Forms.Button userChangePwButton;
        private System.Windows.Forms.TreeView userOuTreeView;
        private System.Windows.Forms.Button userTermButton;
        private System.ComponentModel.BackgroundWorker termUserThread;
        private System.Windows.Forms.Label userTotalLabel;
        private System.ComponentModel.BackgroundWorker backgroundFillUserList;
        private System.Windows.Forms.PictureBox userBusyGraphic;
        private System.ComponentModel.BackgroundWorker backgroundUserSearch;
        private System.Windows.Forms.ContextMenuStrip userContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetPasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem termUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEditUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetLockoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDocumentsFolderToolStripMenuItem;
        private System.Windows.Forms.ToolTip descriptionToolTip;
        private System.Windows.Forms.PictureBox loadingGraphic;
        private System.ComponentModel.BackgroundWorker tooltipBackground;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.ToolStripMenuItem addToQueueToolStripMenuItem;
        private System.Windows.Forms.Button clearQueueButton;
        private System.Windows.Forms.Button registerCompButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListView userGroupChangeList;
        private System.Windows.Forms.ColumnHeader userCn;
        private System.Windows.Forms.ColumnHeader userDesc;
        private System.Windows.Forms.ListView userQueueList;
        private System.Windows.Forms.ColumnHeader queueUserCn;
        private System.Windows.Forms.ColumnHeader queueUserDesc;
        private System.Windows.Forms.ListView resultList;
        private System.Windows.Forms.ColumnHeader computerName;
        private System.Windows.Forms.ColumnHeader model;
        private System.Windows.Forms.ColumnHeader physicalMemory;
        private System.Windows.Forms.ColumnHeader username;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader freeSpace;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.TextBox totalErrorsText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox totalOtherText;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox totalCompText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox total520Text;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox total740Text;
        private System.Windows.Forms.TextBox total755Text;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox total760Text;
        private System.Windows.Forms.TextBox total960Text;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button probeClearButton;
        private System.Windows.Forms.Button probeStopButton;
        private System.Windows.Forms.Button runButton;
        private System.ComponentModel.BackgroundWorker fillListView;
        private System.ComponentModel.BackgroundWorker getComputers;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label countProgressLabel;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.ComponentModel.BackgroundWorker singleListViewBackground;
        private System.Windows.Forms.ColumnHeader serviceTag;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColumnHeader queueUser;
        private System.Windows.Forms.ColumnHeader user;
        private System.Windows.Forms.ColumnHeader queueOu;
        private System.Windows.Forms.ColumnHeader userOu;
        private System.ComponentModel.BackgroundWorker fillObjectList;
        private System.Windows.Forms.Button syncDatabase;
        private System.Windows.Forms.ComboBox exportTypeCombo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button exportSaveButton;
        private System.Windows.Forms.SaveFileDialog exportSaveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem exchangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideMailboxFromGALToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem enableMailboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ContextMenuStrip queueListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeFromQueue;
        private System.Windows.Forms.ToolStripMenuItem showMailboxInGALToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Button queueHideGal;
        private System.Windows.Forms.ContextMenuStrip computerMenu;
        private System.Windows.Forms.ToolStripMenuItem remoteDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem probeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem startSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem moveToToolStripMenuItem;
        private System.Windows.Forms.Button exportUsersButton;
        private System.Windows.Forms.ColumnHeader userExt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem exportUserList;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notepadToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader queueExt;
        private System.Windows.Forms.LinkLabel userFindLabel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem runCleanupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCDriveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
    }
}


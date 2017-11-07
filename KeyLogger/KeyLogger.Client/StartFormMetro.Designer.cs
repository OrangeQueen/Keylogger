namespace KeyLogger.Client
{
    partial class StartFormMetro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartFormMetro));
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroTabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage_Main = new MetroFramework.Controls.MetroTabPage();
            this.pictureBox_Network = new System.Windows.Forms.PictureBox();
            this.metroLabel_Network = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox_IP = new MetroFramework.Controls.MetroComboBox();
            this.metroButton_AddIP = new MetroFramework.Controls.MetroButton();
            this.metroProgressSpinner_Connect = new MetroFramework.Controls.MetroProgressSpinner();
            this.metroButton_Connect = new MetroFramework.Controls.MetroButton();
            this.metroButton_Discover = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage_Devices = new MetroFramework.Controls.MetroTabPage();
            this.metroToggle_Controller = new MetroFramework.Controls.MetroToggle();
            this.metroToggle_Mouse = new MetroFramework.Controls.MetroToggle();
            this.metroToggle_Keyboard = new MetroFramework.Controls.MetroToggle();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage_Settings = new MetroFramework.Controls.MetroTabPage();
            this.metroToggle_AutoConnect = new MetroFramework.Controls.MetroToggle();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroButton_PortChange = new MetroFramework.Controls.MetroButton();
            this.metroTextBox_Port = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox_Adapter = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.timer_AutoConnect = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon_Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_Tray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Keyboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Mouse = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Controller = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Quit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.metroTabControl.SuspendLayout();
            this.metroTabPage_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Network)).BeginInit();
            this.metroTabPage_Devices.SuspendLayout();
            this.metroTabPage_Settings.SuspendLayout();
            this.contextMenuStrip_Tray.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // metroTabControl
            // 
            this.metroTabControl.Controls.Add(this.metroTabPage_Main);
            this.metroTabControl.Controls.Add(this.metroTabPage_Devices);
            this.metroTabControl.Controls.Add(this.metroTabPage_Settings);
            this.metroTabControl.Location = new System.Drawing.Point(10, 63);
            this.metroTabControl.Name = "metroTabControl";
            this.metroTabControl.SelectedIndex = 0;
            this.metroTabControl.Size = new System.Drawing.Size(336, 184);
            this.metroTabControl.TabIndex = 0;
            this.metroTabControl.UseSelectable = true;
            // 
            // metroTabPage_Main
            // 
            this.metroTabPage_Main.Controls.Add(this.pictureBox_Network);
            this.metroTabPage_Main.Controls.Add(this.metroLabel_Network);
            this.metroTabPage_Main.Controls.Add(this.metroComboBox_IP);
            this.metroTabPage_Main.Controls.Add(this.metroButton_AddIP);
            this.metroTabPage_Main.Controls.Add(this.metroProgressSpinner_Connect);
            this.metroTabPage_Main.Controls.Add(this.metroButton_Connect);
            this.metroTabPage_Main.Controls.Add(this.metroButton_Discover);
            this.metroTabPage_Main.Controls.Add(this.metroLabel1);
            this.metroTabPage_Main.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Main.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Main.HorizontalScrollbarSize = 10;
            this.metroTabPage_Main.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Main.Name = "metroTabPage_Main";
            this.metroTabPage_Main.Size = new System.Drawing.Size(328, 142);
            this.metroTabPage_Main.TabIndex = 0;
            this.metroTabPage_Main.Text = "Main";
            this.metroTabPage_Main.VerticalScrollbarBarColor = true;
            this.metroTabPage_Main.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Main.VerticalScrollbarSize = 10;
            // 
            // pictureBox_Network
            // 
            this.pictureBox_Network.BackColor = System.Drawing.Color.White;
            this.pictureBox_Network.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Network.Image")));
            this.pictureBox_Network.Location = new System.Drawing.Point(286, 114);
            this.pictureBox_Network.Name = "pictureBox_Network";
            this.pictureBox_Network.Size = new System.Drawing.Size(39, 32);
            this.pictureBox_Network.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Network.TabIndex = 16;
            this.pictureBox_Network.TabStop = false;
            // 
            // metroLabel_Network
            // 
            this.metroLabel_Network.Location = new System.Drawing.Point(195, 123);
            this.metroLabel_Network.Name = "metroLabel_Network";
            this.metroLabel_Network.Size = new System.Drawing.Size(94, 19);
            this.metroLabel_Network.TabIndex = 15;
            this.metroLabel_Network.Text = "Disconnected";
            this.metroLabel_Network.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroComboBox_IP
            // 
            this.metroComboBox_IP.FormattingEnabled = true;
            this.metroComboBox_IP.ItemHeight = 23;
            this.metroComboBox_IP.Location = new System.Drawing.Point(85, 23);
            this.metroComboBox_IP.Name = "metroComboBox_IP";
            this.metroComboBox_IP.PromptText = "Select IP";
            this.metroComboBox_IP.Size = new System.Drawing.Size(121, 29);
            this.metroComboBox_IP.TabIndex = 14;
            this.metroComboBox_IP.UseSelectable = true;
            this.metroComboBox_IP.SelectedIndexChanged += new System.EventHandler(this.metroComboBox_IP_SelectedIndexChanged);
            // 
            // metroButton_AddIP
            // 
            this.metroButton_AddIP.Location = new System.Drawing.Point(212, 23);
            this.metroButton_AddIP.Name = "metroButton_AddIP";
            this.metroButton_AddIP.Size = new System.Drawing.Size(45, 29);
            this.metroButton_AddIP.TabIndex = 13;
            this.metroButton_AddIP.Text = "Add IP";
            this.metroButton_AddIP.UseSelectable = true;
            this.metroButton_AddIP.Click += new System.EventHandler(this.metroButton_AddIP_Click);
            // 
            // metroProgressSpinner_Connect
            // 
            this.metroProgressSpinner_Connect.Location = new System.Drawing.Point(153, 110);
            this.metroProgressSpinner_Connect.Maximum = 100;
            this.metroProgressSpinner_Connect.Name = "metroProgressSpinner_Connect";
            this.metroProgressSpinner_Connect.Size = new System.Drawing.Size(25, 25);
            this.metroProgressSpinner_Connect.TabIndex = 12;
            this.metroProgressSpinner_Connect.UseSelectable = true;
            this.metroProgressSpinner_Connect.Value = 50;
            this.metroProgressSpinner_Connect.Visible = false;
            // 
            // metroButton_Connect
            // 
            this.metroButton_Connect.Location = new System.Drawing.Point(9, 75);
            this.metroButton_Connect.Name = "metroButton_Connect";
            this.metroButton_Connect.Size = new System.Drawing.Size(309, 29);
            this.metroButton_Connect.TabIndex = 11;
            this.metroButton_Connect.Text = "Connect";
            this.metroButton_Connect.UseSelectable = true;
            this.metroButton_Connect.Click += new System.EventHandler(this.metroButton_Connect_Click);
            // 
            // metroButton_Discover
            // 
            this.metroButton_Discover.Location = new System.Drawing.Point(263, 23);
            this.metroButton_Discover.Name = "metroButton_Discover";
            this.metroButton_Discover.Size = new System.Drawing.Size(55, 29);
            this.metroButton_Discover.TabIndex = 10;
            this.metroButton_Discover.Text = "Discover";
            this.metroButton_Discover.UseSelectable = true;
            this.metroButton_Discover.Click += new System.EventHandler(this.metroButton_Discover_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(10, 27);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(73, 19);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "IP-Address";
            // 
            // metroTabPage_Devices
            // 
            this.metroTabPage_Devices.Controls.Add(this.metroToggle_Controller);
            this.metroTabPage_Devices.Controls.Add(this.metroToggle_Mouse);
            this.metroTabPage_Devices.Controls.Add(this.metroToggle_Keyboard);
            this.metroTabPage_Devices.Controls.Add(this.metroLabel4);
            this.metroTabPage_Devices.Controls.Add(this.metroLabel3);
            this.metroTabPage_Devices.Controls.Add(this.metroLabel2);
            this.metroTabPage_Devices.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Devices.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Devices.HorizontalScrollbarSize = 10;
            this.metroTabPage_Devices.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Devices.Name = "metroTabPage_Devices";
            this.metroTabPage_Devices.Size = new System.Drawing.Size(328, 142);
            this.metroTabPage_Devices.TabIndex = 2;
            this.metroTabPage_Devices.Text = "Devices";
            this.metroTabPage_Devices.VerticalScrollbarBarColor = true;
            this.metroTabPage_Devices.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Devices.VerticalScrollbarSize = 10;
            // 
            // metroToggle_Controller
            // 
            this.metroToggle_Controller.AutoSize = true;
            this.metroToggle_Controller.DisplayStatus = false;
            this.metroToggle_Controller.Location = new System.Drawing.Point(100, 60);
            this.metroToggle_Controller.Name = "metroToggle_Controller";
            this.metroToggle_Controller.Size = new System.Drawing.Size(50, 17);
            this.metroToggle_Controller.TabIndex = 7;
            this.metroToggle_Controller.Text = "Aus";
            this.metroToggle_Controller.UseSelectable = true;
            this.metroToggle_Controller.CheckedChanged += new System.EventHandler(this.metroToggle_Controller_CheckedChanged);
            // 
            // metroToggle_Mouse
            // 
            this.metroToggle_Mouse.AutoSize = true;
            this.metroToggle_Mouse.DisplayStatus = false;
            this.metroToggle_Mouse.Location = new System.Drawing.Point(100, 37);
            this.metroToggle_Mouse.Name = "metroToggle_Mouse";
            this.metroToggle_Mouse.Size = new System.Drawing.Size(50, 17);
            this.metroToggle_Mouse.TabIndex = 6;
            this.metroToggle_Mouse.Text = "Aus";
            this.metroToggle_Mouse.UseSelectable = true;
            this.metroToggle_Mouse.CheckedChanged += new System.EventHandler(this.metroToggle_Mouse_CheckedChanged);
            // 
            // metroToggle_Keyboard
            // 
            this.metroToggle_Keyboard.AutoSize = true;
            this.metroToggle_Keyboard.DisplayStatus = false;
            this.metroToggle_Keyboard.Location = new System.Drawing.Point(100, 14);
            this.metroToggle_Keyboard.Name = "metroToggle_Keyboard";
            this.metroToggle_Keyboard.Size = new System.Drawing.Size(50, 17);
            this.metroToggle_Keyboard.TabIndex = 5;
            this.metroToggle_Keyboard.Text = "Aus";
            this.metroToggle_Keyboard.UseSelectable = true;
            this.metroToggle_Keyboard.CheckedChanged += new System.EventHandler(this.metroToggle_Keyboard_CheckedChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(10, 59);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(68, 19);
            this.metroLabel4.TabIndex = 4;
            this.metroLabel4.Text = "Controller";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(10, 36);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(48, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Mouse";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(10, 13);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Keyboard";
            // 
            // metroTabPage_Settings
            // 
            this.metroTabPage_Settings.Controls.Add(this.metroToggle_AutoConnect);
            this.metroTabPage_Settings.Controls.Add(this.metroLabel7);
            this.metroTabPage_Settings.Controls.Add(this.metroButton_PortChange);
            this.metroTabPage_Settings.Controls.Add(this.metroTextBox_Port);
            this.metroTabPage_Settings.Controls.Add(this.metroLabel6);
            this.metroTabPage_Settings.Controls.Add(this.metroComboBox_Adapter);
            this.metroTabPage_Settings.Controls.Add(this.metroLabel5);
            this.metroTabPage_Settings.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Settings.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Settings.HorizontalScrollbarSize = 10;
            this.metroTabPage_Settings.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Settings.Name = "metroTabPage_Settings";
            this.metroTabPage_Settings.Size = new System.Drawing.Size(328, 142);
            this.metroTabPage_Settings.TabIndex = 3;
            this.metroTabPage_Settings.Text = "Settings";
            this.metroTabPage_Settings.VerticalScrollbarBarColor = true;
            this.metroTabPage_Settings.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Settings.VerticalScrollbarSize = 10;
            // 
            // metroToggle_AutoConnect
            // 
            this.metroToggle_AutoConnect.AutoSize = true;
            this.metroToggle_AutoConnect.Checked = true;
            this.metroToggle_AutoConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle_AutoConnect.DisplayStatus = false;
            this.metroToggle_AutoConnect.Location = new System.Drawing.Point(214, 96);
            this.metroToggle_AutoConnect.Name = "metroToggle_AutoConnect";
            this.metroToggle_AutoConnect.Size = new System.Drawing.Size(50, 17);
            this.metroToggle_AutoConnect.TabIndex = 8;
            this.metroToggle_AutoConnect.Text = "An";
            this.metroToggle_AutoConnect.UseSelectable = true;
            this.metroToggle_AutoConnect.CheckedChanged += new System.EventHandler(this.metroToggle_AutoConnect_CheckedChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(214, 73);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(89, 19);
            this.metroLabel7.TabIndex = 7;
            this.metroLabel7.Text = "Auto Connect";
            // 
            // metroButton_PortChange
            // 
            this.metroButton_PortChange.Location = new System.Drawing.Point(88, 95);
            this.metroButton_PortChange.Name = "metroButton_PortChange";
            this.metroButton_PortChange.Size = new System.Drawing.Size(75, 29);
            this.metroButton_PortChange.TabIndex = 6;
            this.metroButton_PortChange.Text = "Change";
            this.metroButton_PortChange.UseSelectable = true;
            this.metroButton_PortChange.Click += new System.EventHandler(this.metroButton_PortChange_Click);
            // 
            // metroTextBox_Port
            // 
            this.metroTextBox_Port.Lines = new string[] {
        "2000"};
            this.metroTextBox_Port.Location = new System.Drawing.Point(11, 96);
            this.metroTextBox_Port.MaxLength = 32767;
            this.metroTextBox_Port.Name = "metroTextBox_Port";
            this.metroTextBox_Port.PasswordChar = '\0';
            this.metroTextBox_Port.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_Port.SelectedText = "";
            this.metroTextBox_Port.Size = new System.Drawing.Size(71, 29);
            this.metroTextBox_Port.TabIndex = 5;
            this.metroTextBox_Port.Text = "2000";
            this.metroTextBox_Port.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(9, 73);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(87, 19);
            this.metroLabel6.TabIndex = 4;
            this.metroLabel6.Text = "Network Port";
            // 
            // metroComboBox_Adapter
            // 
            this.metroComboBox_Adapter.FormattingEnabled = true;
            this.metroComboBox_Adapter.ItemHeight = 23;
            this.metroComboBox_Adapter.Location = new System.Drawing.Point(9, 37);
            this.metroComboBox_Adapter.Name = "metroComboBox_Adapter";
            this.metroComboBox_Adapter.PromptText = "LAN-Adapter";
            this.metroComboBox_Adapter.Size = new System.Drawing.Size(234, 29);
            this.metroComboBox_Adapter.TabIndex = 3;
            this.metroComboBox_Adapter.UseSelectable = true;
            this.metroComboBox_Adapter.SelectedIndexChanged += new System.EventHandler(this.metroComboBox_Adapter_SelectedIndexChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(9, 15);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(112, 19);
            this.metroLabel5.TabIndex = 2;
            this.metroLabel5.Text = "Network Interface";
            // 
            // timer_AutoConnect
            // 
            this.timer_AutoConnect.Interval = 30000;
            this.timer_AutoConnect.Tick += new System.EventHandler(this.timer_AutoConnect_Tick);
            // 
            // notifyIcon_Tray
            // 
            this.notifyIcon_Tray.BalloonTipText = "KeyLogger is now running in the background ...";
            this.notifyIcon_Tray.ContextMenuStrip = this.contextMenuStrip_Tray;
            this.notifyIcon_Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_Tray.Icon")));
            this.notifyIcon_Tray.Text = "KeyLogger";
            this.notifyIcon_Tray.Visible = true;
            this.notifyIcon_Tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_Tray_MouseDoubleClick);
            // 
            // contextMenuStrip_Tray
            // 
            this.contextMenuStrip_Tray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Show,
            this.toolStripSeparator1,
            this.toolStripMenuItem_Keyboard,
            this.toolStripMenuItem_Mouse,
            this.toolStripMenuItem_Controller,
            this.toolStripSeparator2,
            this.toolStripMenuItem_Quit});
            this.contextMenuStrip_Tray.Name = "contextMenuStrip_Tray";
            this.contextMenuStrip_Tray.Size = new System.Drawing.Size(128, 126);
            // 
            // toolStripMenuItem_Show
            // 
            this.toolStripMenuItem_Show.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem_Show.Name = "toolStripMenuItem_Show";
            this.toolStripMenuItem_Show.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItem_Show.Text = "Show";
            this.toolStripMenuItem_Show.Click += new System.EventHandler(this.toolStripMenuItem_Show_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
            // 
            // toolStripMenuItem_Keyboard
            // 
            this.toolStripMenuItem_Keyboard.Name = "toolStripMenuItem_Keyboard";
            this.toolStripMenuItem_Keyboard.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItem_Keyboard.Text = "Keyboard";
            this.toolStripMenuItem_Keyboard.Click += new System.EventHandler(this.toolStripMenuItem_Keyboard_Click);
            // 
            // toolStripMenuItem_Mouse
            // 
            this.toolStripMenuItem_Mouse.Name = "toolStripMenuItem_Mouse";
            this.toolStripMenuItem_Mouse.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItem_Mouse.Text = "Mouse";
            this.toolStripMenuItem_Mouse.Click += new System.EventHandler(this.toolStripMenuItem_Mouse_Click);
            // 
            // toolStripMenuItem_Controller
            // 
            this.toolStripMenuItem_Controller.Name = "toolStripMenuItem_Controller";
            this.toolStripMenuItem_Controller.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItem_Controller.Text = "Controller";
            this.toolStripMenuItem_Controller.Click += new System.EventHandler(this.toolStripMenuItem_Controller_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(124, 6);
            // 
            // toolStripMenuItem_Quit
            // 
            this.toolStripMenuItem_Quit.Name = "toolStripMenuItem_Quit";
            this.toolStripMenuItem_Quit.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItem_Quit.Text = "Quit";
            this.toolStripMenuItem_Quit.Click += new System.EventHandler(this.toolStripMenuItem_Quit_Click);
            // 
            // StartFormMetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 255);
            this.Controls.Add(this.metroTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartFormMetro";
            this.Resizable = false;
            this.Text = "KeyLogger.Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartFormMetro_FormClosed);
            this.Resize += new System.EventHandler(this.StartFormMetro_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.metroTabControl.ResumeLayout(false);
            this.metroTabPage_Main.ResumeLayout(false);
            this.metroTabPage_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Network)).EndInit();
            this.metroTabPage_Devices.ResumeLayout(false);
            this.metroTabPage_Devices.PerformLayout();
            this.metroTabPage_Settings.ResumeLayout(false);
            this.metroTabPage_Settings.PerformLayout();
            this.contextMenuStrip_Tray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender;
        private MetroFramework.Controls.MetroTabControl metroTabControl;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Main;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Devices;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Settings;
        private MetroFramework.Controls.MetroButton metroButton_Discover;
        private MetroFramework.Controls.MetroButton metroButton_Connect;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner_Connect;
        private MetroFramework.Controls.MetroToggle metroToggle_Controller;
        private MetroFramework.Controls.MetroToggle metroToggle_Mouse;
        private MetroFramework.Controls.MetroToggle metroToggle_Keyboard;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton metroButton_PortChange;
        private MetroFramework.Controls.MetroTextBox metroTextBox_Port;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox metroComboBox_Adapter;
        private MetroFramework.Controls.MetroComboBox metroComboBox_IP;
        private MetroFramework.Controls.MetroButton metroButton_AddIP;
        private System.Windows.Forms.Timer timer_AutoConnect;
        private MetroFramework.Controls.MetroToggle metroToggle_AutoConnect;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.NotifyIcon notifyIcon_Tray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Tray;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Show;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Keyboard;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Mouse;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Controller;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Quit;
        private System.Windows.Forms.PictureBox pictureBox_Network;
        private MetroFramework.Controls.MetroLabel metroLabel_Network;
    }
}
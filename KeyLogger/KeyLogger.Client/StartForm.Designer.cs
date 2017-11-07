namespace KeyLogger.Client
{
    partial class StartForm
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
                //this.catchmanager.NetworkClient.NetworkDiscoveryEvent -= NetworkClient_NetworkDiscoveryEvent;
                //this.catchmanager.NetworkClient.NetworkEvent -= NetworkClient_NetworkEvent;

                //this.catchmanager.Dispose();

                this.notifyIcon_Tray.Dispose();
                
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Discover = new System.Windows.Forms.Button();
            this.checkBox_Keyboard = new System.Windows.Forms.CheckBox();
            this.checkBox_Mouse = new System.Windows.Forms.CheckBox();
            this.checkBox_Controller = new System.Windows.Forms.CheckBox();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.notifyIcon_Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_Tray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Keyboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Mouse = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Controller = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_IPAdresses = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer_AutoConnect = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_AutoConnect = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip_Tray.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(11, 28);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(195, 20);
            this.textBox_IP.TabIndex = 0;
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(11, 94);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 1;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Discover
            // 
            this.button_Discover.Location = new System.Drawing.Point(213, 28);
            this.button_Discover.Name = "button_Discover";
            this.button_Discover.Size = new System.Drawing.Size(75, 20);
            this.button_Discover.TabIndex = 2;
            this.button_Discover.Text = "Discover";
            this.button_Discover.UseVisualStyleBackColor = true;
            this.button_Discover.Click += new System.EventHandler(this.button_Discover_Click);
            // 
            // checkBox_Keyboard
            // 
            this.checkBox_Keyboard.AutoSize = true;
            this.checkBox_Keyboard.Location = new System.Drawing.Point(12, 19);
            this.checkBox_Keyboard.Name = "checkBox_Keyboard";
            this.checkBox_Keyboard.Size = new System.Drawing.Size(71, 17);
            this.checkBox_Keyboard.TabIndex = 3;
            this.checkBox_Keyboard.Text = "Keyboard";
            this.checkBox_Keyboard.UseVisualStyleBackColor = true;
            this.checkBox_Keyboard.CheckedChanged += new System.EventHandler(this.checkBox_Keyboard_CheckedChanged);
            // 
            // checkBox_Mouse
            // 
            this.checkBox_Mouse.AutoSize = true;
            this.checkBox_Mouse.Location = new System.Drawing.Point(98, 19);
            this.checkBox_Mouse.Name = "checkBox_Mouse";
            this.checkBox_Mouse.Size = new System.Drawing.Size(58, 17);
            this.checkBox_Mouse.TabIndex = 4;
            this.checkBox_Mouse.Text = "Mouse";
            this.checkBox_Mouse.UseVisualStyleBackColor = true;
            this.checkBox_Mouse.CheckedChanged += new System.EventHandler(this.checkBox_Mouse_CheckedChanged);
            // 
            // checkBox_Controller
            // 
            this.checkBox_Controller.AutoSize = true;
            this.checkBox_Controller.Location = new System.Drawing.Point(184, 19);
            this.checkBox_Controller.Name = "checkBox_Controller";
            this.checkBox_Controller.Size = new System.Drawing.Size(70, 17);
            this.checkBox_Controller.TabIndex = 5;
            this.checkBox_Controller.Text = "Controller";
            this.checkBox_Controller.UseVisualStyleBackColor = true;
            this.checkBox_Controller.CheckedChanged += new System.EventHandler(this.checkBox_Controller_CheckedChanged);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Enabled = false;
            this.button_Disconnect.Location = new System.Drawing.Point(92, 94);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(75, 23);
            this.button_Disconnect.TabIndex = 6;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // notifyIcon_Tray
            // 
            this.notifyIcon_Tray.BalloonTipText = "KeyLogger is now running in the background ...";
            this.notifyIcon_Tray.ContextMenuStrip = this.contextMenuStrip_Tray;
            this.notifyIcon_Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_Tray.Icon")));
            this.notifyIcon_Tray.Text = "KeyLogger.Client";
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
            this.contextMenuStrip_Tray.Size = new System.Drawing.Size(122, 126);
            // 
            // toolStripMenuItem_Show
            // 
            this.toolStripMenuItem_Show.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem_Show.Name = "toolStripMenuItem_Show";
            this.toolStripMenuItem_Show.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem_Show.Text = "Show";
            this.toolStripMenuItem_Show.Click += new System.EventHandler(this.toolStripMenuItem_Show_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(118, 6);
            // 
            // toolStripMenuItem_Keyboard
            // 
            this.toolStripMenuItem_Keyboard.Name = "toolStripMenuItem_Keyboard";
            this.toolStripMenuItem_Keyboard.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem_Keyboard.Text = "Keyboard";
            this.toolStripMenuItem_Keyboard.Click += new System.EventHandler(this.toolStripMenuItem_Keyboard_Click);
            // 
            // toolStripMenuItem_Mouse
            // 
            this.toolStripMenuItem_Mouse.Name = "toolStripMenuItem_Mouse";
            this.toolStripMenuItem_Mouse.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem_Mouse.Text = "Mouse";
            this.toolStripMenuItem_Mouse.Click += new System.EventHandler(this.toolStripMenuItem_Mouse_Click);
            // 
            // toolStripMenuItem_Controller
            // 
            this.toolStripMenuItem_Controller.Name = "toolStripMenuItem_Controller";
            this.toolStripMenuItem_Controller.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem_Controller.Text = "Controller";
            this.toolStripMenuItem_Controller.Click += new System.EventHandler(this.toolStripMenuItem_Controller_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(118, 6);
            // 
            // toolStripMenuItem_Quit
            // 
            this.toolStripMenuItem_Quit.Name = "toolStripMenuItem_Quit";
            this.toolStripMenuItem_Quit.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem_Quit.Text = "Quit";
            this.toolStripMenuItem_Quit.Click += new System.EventHandler(this.toolStripMenuItem_Quit_Click);
            // 
            // comboBox_IPAdresses
            // 
            this.comboBox_IPAdresses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_IPAdresses.FormattingEnabled = true;
            this.comboBox_IPAdresses.Location = new System.Drawing.Point(11, 67);
            this.comboBox_IPAdresses.Name = "comboBox_IPAdresses";
            this.comboBox_IPAdresses.Size = new System.Drawing.Size(195, 21);
            this.comboBox_IPAdresses.TabIndex = 7;
            this.comboBox_IPAdresses.SelectedIndexChanged += new System.EventHandler(this.comboBox_IPAdresses_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Network Interface";
            // 
            // timer_AutoConnect
            // 
            this.timer_AutoConnect.Interval = 30000;
            this.timer_AutoConnect.Tick += new System.EventHandler(this.timer_AutoConnect_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "IP-Address";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_Mouse);
            this.groupBox1.Controls.Add(this.checkBox_Keyboard);
            this.groupBox1.Controls.Add(this.checkBox_Controller);
            this.groupBox1.Location = new System.Drawing.Point(12, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 52);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devices";
            // 
            // checkBox_AutoConnect
            // 
            this.checkBox_AutoConnect.AutoSize = true;
            this.checkBox_AutoConnect.Checked = true;
            this.checkBox_AutoConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AutoConnect.Location = new System.Drawing.Point(173, 98);
            this.checkBox_AutoConnect.Name = "checkBox_AutoConnect";
            this.checkBox_AutoConnect.Size = new System.Drawing.Size(91, 17);
            this.checkBox_AutoConnect.TabIndex = 11;
            this.checkBox_AutoConnect.Text = "Auto Connect";
            this.checkBox_AutoConnect.UseVisualStyleBackColor = true;
            this.checkBox_AutoConnect.CheckedChanged += new System.EventHandler(this.checkBox_AutoConnect_CheckedChanged);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 200);
            this.Controls.Add(this.checkBox_AutoConnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Discover);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_IPAdresses);
            this.Controls.Add(this.button_Disconnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.Text = "KeyLogger.Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartForm_FormClosed);
            this.Resize += new System.EventHandler(this.StartForm_Resize);
            this.contextMenuStrip_Tray.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Discover;
        private System.Windows.Forms.CheckBox checkBox_Keyboard;
        private System.Windows.Forms.CheckBox checkBox_Mouse;
        private System.Windows.Forms.CheckBox checkBox_Controller;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.NotifyIcon notifyIcon_Tray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Tray;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Quit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Show;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Keyboard;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Mouse;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Controller;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ComboBox comboBox_IPAdresses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer_AutoConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_AutoConnect;
    }
}


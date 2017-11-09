namespace KeyLogger.Display
{
    partial class Overview
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overview));
            this.dataGridView_Clients = new System.Windows.Forms.DataGridView();
            this.PC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keyboard = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Mouse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Controller = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Disconnect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroTabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage_Main = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage_Settings = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton_ChangePort = new MetroFramework.Controls.MetroButton();
            this.metroTextBox_Port = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.metroTabControl.SuspendLayout();
            this.metroTabPage_Main.SuspendLayout();
            this.metroTabPage_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Clients
            // 
            this.dataGridView_Clients.AllowUserToAddRows = false;
            this.dataGridView_Clients.AllowUserToDeleteRows = false;
            this.dataGridView_Clients.AllowUserToResizeColumns = false;
            this.dataGridView_Clients.AllowUserToResizeRows = false;
            this.metroStyleExtender.SetApplyMetroTheme(this.dataGridView_Clients, true);
            this.dataGridView_Clients.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_Clients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Clients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PC,
            this.IP,
            this.Keyboard,
            this.Mouse,
            this.Controller,
            this.Disconnect});
            this.dataGridView_Clients.Location = new System.Drawing.Point(3, 13);
            this.dataGridView_Clients.Name = "dataGridView_Clients";
            this.dataGridView_Clients.ReadOnly = true;
            this.dataGridView_Clients.RowHeadersVisible = false;
            this.dataGridView_Clients.Size = new System.Drawing.Size(503, 195);
            this.dataGridView_Clients.TabIndex = 0;
            this.dataGridView_Clients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Clients_CellContentClick);
            // 
            // PC
            // 
            this.PC.HeaderText = "PC";
            this.PC.Name = "PC";
            this.PC.ReadOnly = true;
            this.PC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IP
            // 
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Keyboard
            // 
            this.Keyboard.HeaderText = "Keyboard";
            this.Keyboard.Name = "Keyboard";
            this.Keyboard.ReadOnly = true;
            this.Keyboard.Width = 75;
            // 
            // Mouse
            // 
            this.Mouse.HeaderText = "Mouse";
            this.Mouse.Name = "Mouse";
            this.Mouse.ReadOnly = true;
            this.Mouse.Width = 75;
            // 
            // Controller
            // 
            this.Controller.HeaderText = "Controller";
            this.Controller.Name = "Controller";
            this.Controller.ReadOnly = true;
            this.Controller.Width = 75;
            // 
            // Disconnect
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Disconnect.DefaultCellStyle = dataGridViewCellStyle1;
            this.Disconnect.HeaderText = "Action";
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.ReadOnly = true;
            this.Disconnect.Text = "Disconnect";
            this.Disconnect.UseColumnTextForButtonValue = true;
            this.Disconnect.Width = 75;
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // metroTabControl
            // 
            this.metroTabControl.Controls.Add(this.metroTabPage_Main);
            this.metroTabControl.Controls.Add(this.metroTabPage_Settings);
            this.metroTabControl.Location = new System.Drawing.Point(23, 63);
            this.metroTabControl.Name = "metroTabControl";
            this.metroTabControl.SelectedIndex = 0;
            this.metroTabControl.Size = new System.Drawing.Size(518, 256);
            this.metroTabControl.TabIndex = 0;
            this.metroTabControl.UseSelectable = true;
            // 
            // metroTabPage_Main
            // 
            this.metroTabPage_Main.Controls.Add(this.dataGridView_Clients);
            this.metroTabPage_Main.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Main.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Main.HorizontalScrollbarSize = 10;
            this.metroTabPage_Main.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Main.Name = "metroTabPage_Main";
            this.metroTabPage_Main.Size = new System.Drawing.Size(510, 214);
            this.metroTabPage_Main.TabIndex = 0;
            this.metroTabPage_Main.Text = "Main";
            this.metroTabPage_Main.VerticalScrollbarBarColor = true;
            this.metroTabPage_Main.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Main.VerticalScrollbarSize = 10;
            // 
            // metroTabPage_Settings
            // 
            this.metroTabPage_Settings.Controls.Add(this.metroLabel2);
            this.metroTabPage_Settings.Controls.Add(this.metroButton_ChangePort);
            this.metroTabPage_Settings.Controls.Add(this.metroTextBox_Port);
            this.metroTabPage_Settings.Controls.Add(this.metroLabel1);
            this.metroTabPage_Settings.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Settings.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Settings.HorizontalScrollbarSize = 10;
            this.metroTabPage_Settings.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Settings.Name = "metroTabPage_Settings";
            this.metroTabPage_Settings.Size = new System.Drawing.Size(510, 214);
            this.metroTabPage_Settings.TabIndex = 1;
            this.metroTabPage_Settings.Text = "Settings";
            this.metroTabPage_Settings.VerticalScrollbarBarColor = true;
            this.metroTabPage_Settings.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Settings.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(4, 67);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(470, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Changing the network port will close all connections and restart the application." +
    "";
            // 
            // metroButton_ChangePort
            // 
            this.metroButton_ChangePort.Location = new System.Drawing.Point(86, 37);
            this.metroButton_ChangePort.Name = "metroButton_ChangePort";
            this.metroButton_ChangePort.Size = new System.Drawing.Size(75, 23);
            this.metroButton_ChangePort.TabIndex = 4;
            this.metroButton_ChangePort.Text = "Change";
            this.metroButton_ChangePort.UseSelectable = true;
            this.metroButton_ChangePort.Click += new System.EventHandler(this.metroButton_ChangePort_Click);
            // 
            // metroTextBox_Port
            // 
            this.metroTextBox_Port.Lines = new string[0];
            this.metroTextBox_Port.Location = new System.Drawing.Point(4, 37);
            this.metroTextBox_Port.MaxLength = 32767;
            this.metroTextBox_Port.Name = "metroTextBox_Port";
            this.metroTextBox_Port.PasswordChar = '\0';
            this.metroTextBox_Port.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_Port.SelectedText = "";
            this.metroTextBox_Port.Size = new System.Drawing.Size(75, 23);
            this.metroTextBox_Port.TabIndex = 3;
            this.metroTextBox_Port.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(4, 15);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(87, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Network Port";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start Capture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Start_Capture);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(458, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Replay";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Start_Replay);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(332, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Stop Capture";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Stop_Capture);
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 333);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.metroTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Overview";
            this.Resizable = false;
            this.Text = "KeyLogger.Display";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Overview_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.metroTabControl.ResumeLayout(false);
            this.metroTabPage_Main.ResumeLayout(false);
            this.metroTabPage_Settings.ResumeLayout(false);
            this.metroTabPage_Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Clients;
        private System.Windows.Forms.DataGridViewTextBoxColumn PC;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Keyboard;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Mouse;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Controller;
        private System.Windows.Forms.DataGridViewButtonColumn Disconnect;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender;
        private MetroFramework.Controls.MetroTabControl metroTabControl;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Main;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Settings;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton_ChangePort;
        private MetroFramework.Controls.MetroTextBox metroTextBox_Port;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}


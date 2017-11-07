namespace KeyLogger.Client
{
    partial class InputMessageForm
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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroButton_OK = new MetroFramework.Controls.MetroButton();
            this.metroTextBox_Input = new MetroFramework.Controls.MetroTextBox();
            this.metroButton_Cancel = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // metroButton_OK
            // 
            this.metroButton_OK.Location = new System.Drawing.Point(111, 93);
            this.metroButton_OK.Name = "metroButton_OK";
            this.metroButton_OK.Size = new System.Drawing.Size(75, 23);
            this.metroButton_OK.TabIndex = 0;
            this.metroButton_OK.Text = "OK";
            this.metroButton_OK.UseSelectable = true;
            this.metroButton_OK.Click += new System.EventHandler(this.metroButton_OK_Click);
            // 
            // metroTextBox_Input
            // 
            this.metroTextBox_Input.Lines = new string[0];
            this.metroTextBox_Input.Location = new System.Drawing.Point(24, 64);
            this.metroTextBox_Input.MaxLength = 32767;
            this.metroTextBox_Input.Name = "metroTextBox_Input";
            this.metroTextBox_Input.PasswordChar = '\0';
            this.metroTextBox_Input.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_Input.SelectedText = "";
            this.metroTextBox_Input.Size = new System.Drawing.Size(245, 23);
            this.metroTextBox_Input.TabIndex = 1;
            this.metroTextBox_Input.UseSelectable = true;
            // 
            // metroButton_Cancel
            // 
            this.metroButton_Cancel.Location = new System.Drawing.Point(193, 93);
            this.metroButton_Cancel.Name = "metroButton_Cancel";
            this.metroButton_Cancel.Size = new System.Drawing.Size(75, 23);
            this.metroButton_Cancel.TabIndex = 2;
            this.metroButton_Cancel.Text = "Cancel";
            this.metroButton_Cancel.UseSelectable = true;
            this.metroButton_Cancel.Click += new System.EventHandler(this.metroButton_Cancel_Click);
            // 
            // InputMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 133);
            this.Controls.Add(this.metroButton_Cancel);
            this.Controls.Add(this.metroTextBox_Input);
            this.Controls.Add(this.metroButton_OK);
            this.MaximizeBox = false;
            this.Name = "InputMessageForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Input";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Controls.MetroButton metroButton_OK;
        private MetroFramework.Controls.MetroButton metroButton_Cancel;
        public MetroFramework.Controls.MetroTextBox metroTextBox_Input;
    }
}
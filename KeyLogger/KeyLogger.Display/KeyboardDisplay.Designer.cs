namespace KeyLogger.Display
{
    partial class KeyboardDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardDisplay));
            this.pictureBox_Keyboard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Keyboard)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Keyboard
            // 
            this.pictureBox_Keyboard.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Keyboard.Image")));
            this.pictureBox_Keyboard.Location = new System.Drawing.Point(20, 63);
            this.pictureBox_Keyboard.Name = "pictureBox_Keyboard";
            this.pictureBox_Keyboard.Size = new System.Drawing.Size(1130, 333);
            this.pictureBox_Keyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Keyboard.TabIndex = 0;
            this.pictureBox_Keyboard.TabStop = false;
            this.pictureBox_Keyboard.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Keyboard_Paint);
            // 
            // KeyboardDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 421);
            this.Controls.Add(this.pictureBox_Keyboard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "KeyboardDisplay";
            this.Resizable = false;
            this.Text = "KeyboardDisplay";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KeyboardDisplay_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Keyboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Keyboard;

    }
}
namespace KeyLogger.Display
{
    partial class ControllerDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerDisplay));
            this.pictureBox_Controller = new System.Windows.Forms.PictureBox();
            this.vProgressBar_Right = new KeyLogger.Display.VProgressBar();
            this.vProgressBar_Left = new KeyLogger.Display.VProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Controller)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Controller
            // 
            this.pictureBox_Controller.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Controller.Image")));
            this.pictureBox_Controller.Location = new System.Drawing.Point(23, 63);
            this.pictureBox_Controller.Name = "pictureBox_Controller";
            this.pictureBox_Controller.Size = new System.Drawing.Size(581, 415);
            this.pictureBox_Controller.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Controller.TabIndex = 0;
            this.pictureBox_Controller.TabStop = false;
            this.pictureBox_Controller.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Controller_Paint);
            // 
            // vProgressBar_Right
            // 
            this.vProgressBar_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.vProgressBar_Right.Location = new System.Drawing.Point(569, 74);
            this.vProgressBar_Right.Maximum = 255;
            this.vProgressBar_Right.Name = "vProgressBar_Right";
            this.vProgressBar_Right.Size = new System.Drawing.Size(23, 113);
            this.vProgressBar_Right.TabIndex = 2;
            // 
            // vProgressBar_Left
            // 
            this.vProgressBar_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.vProgressBar_Left.Location = new System.Drawing.Point(38, 74);
            this.vProgressBar_Left.Maximum = 255;
            this.vProgressBar_Left.Name = "vProgressBar_Left";
            this.vProgressBar_Left.Size = new System.Drawing.Size(23, 113);
            this.vProgressBar_Left.TabIndex = 1;
            // 
            // ControllerDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 501);
            this.Controls.Add(this.vProgressBar_Right);
            this.Controls.Add(this.vProgressBar_Left);
            this.Controls.Add(this.pictureBox_Controller);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControllerDisplay";
            this.Resizable = false;
            this.Text = "ControllerDisplay";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControllerDisplay_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Controller)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Controller;
        private VProgressBar vProgressBar_Left;
        private VProgressBar vProgressBar_Right;
    }
}
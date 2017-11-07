namespace KeyLogger.Display
{
    partial class MouseDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouseDisplay));
            this.pictureBox_Mouse = new System.Windows.Forms.PictureBox();
            this.pictureBox_Cursor = new System.Windows.Forms.PictureBox();
            this.timer_DisplayCursor = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Mouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Cursor)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Mouse
            // 
            this.pictureBox_Mouse.Image = global::KeyLogger.Display.Properties.Resources.Mouse;
            this.pictureBox_Mouse.Location = new System.Drawing.Point(35, 186);
            this.pictureBox_Mouse.Name = "pictureBox_Mouse";
            this.pictureBox_Mouse.Size = new System.Drawing.Size(171, 316);
            this.pictureBox_Mouse.TabIndex = 0;
            this.pictureBox_Mouse.TabStop = false;
            this.pictureBox_Mouse.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Mouse_Paint);
            // 
            // pictureBox_Cursor
            // 
            this.pictureBox_Cursor.Location = new System.Drawing.Point(36, 63);
            this.pictureBox_Cursor.Name = "pictureBox_Cursor";
            this.pictureBox_Cursor.Size = new System.Drawing.Size(170, 117);
            this.pictureBox_Cursor.TabIndex = 1;
            this.pictureBox_Cursor.TabStop = false;
            this.pictureBox_Cursor.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Cursor_Paint);
            // 
            // timer_DisplayCursor
            // 
            this.timer_DisplayCursor.Enabled = true;
            this.timer_DisplayCursor.Interval = 50;
            this.timer_DisplayCursor.Tick += new System.EventHandler(this.timer_DisplayCursor_Tick);
            // 
            // MouseDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 522);
            this.Controls.Add(this.pictureBox_Cursor);
            this.Controls.Add(this.pictureBox_Mouse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MouseDisplay";
            this.Resizable = false;
            this.Text = "MouseDisplay";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MouseDisplay_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Mouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Cursor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Mouse;
        private System.Windows.Forms.PictureBox pictureBox_Cursor;
        private System.Windows.Forms.Timer timer_DisplayCursor;
    }
}
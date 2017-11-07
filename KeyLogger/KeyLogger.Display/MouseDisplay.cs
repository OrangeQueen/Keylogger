using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Serialization;
using KeyLogger.Display.Keymap;
using KeyLogger.Display.Properties;
using KeyLogger.Messages;
using KeyLogger.Messages.Events;
using KeyLogger.Network.Status;
using MetroFramework.Forms;

namespace KeyLogger.Display
{
    public partial class MouseDisplay : MetroForm
    {
        private readonly Mouse _mousemapping;
        private readonly NetworkStatusUpdater _networkstatusupdater;

        private MouseInputMessage _message;

        private int _mousex;
        private int _mousey;

        public MouseDisplay(NetworkStatusUpdater nsupdater)
        {
            InitializeComponent();

            var serializer = new XmlSerializer(typeof (Mouse));

            _mousemapping =
                (Mouse) serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(Resources.MouseMapping)));

            _mousex = 0;
            _mousey = 0;

            _networkstatusupdater = nsupdater;
        }

        public void RedrawController(MouseInputMessage message)
        {
            int mx = 0, my = 0;

            if (_message != null)
            {
                mx = _message.X;
                my = _message.Y;
            }

            _message = message;

            //var invalidaterect = new Rectangle();

            Region invalidregion;

            switch (_message.MouseEvent)
            {
                case MouseEvent.MouseWheel:
                    var gp = new GraphicsPath();
                    gp.AddPolygon(_mousemapping.ButtonList.First(s => s.Button == MouseButtons.None).ListPoint);
                    invalidregion = new Region(gp);

                    pictureBox_Mouse.Invalidate(invalidregion);
                    break;
                case MouseEvent.MouseDown:
                case MouseEvent.MouseUp:
                    _message.X = mx;
                    _message.Y = my;

                    gp = new GraphicsPath();
                    gp.AddPolygon(_mousemapping.ButtonList.First(s => s.Button == _message.MouseButton).ListPoint);
                    invalidregion = new Region(gp);

                    pictureBox_Mouse.Invalidate(invalidregion);
                    break;
            }


            //if (_message.X != 0 && _message.Y != 0)
            //    this.pictureBox_Mouse.Invalidate(invalidregion);

            //if (this._message.X != 0 ||this._message.Y != 0)
            //if (Math.Abs(this._mousex - this._message.X) > 5 || Math.Abs(this._mousey - this._message.Y) > 5)
            //    this.pictureBox_Cursor.Invalidate();
        }

        private void pictureBox_Mouse_Paint(object sender, PaintEventArgs e)
        {
            if (_message == null)
            {
                return;
            }


            if (_message.MouseEvent == MouseEvent.MouseDown)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                //Rectangle invalidaterect = _mousemapping.ButtonList.First(s => s.Button == this._message.MouseButton).ListPoint;

                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(128, 255, 0, 0)),
                    _mousemapping.ButtonList.First(s => s.Button == _message.MouseButton).ListPoint);

                //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), invalidaterect);
            }

            if (_message.MouseEvent == MouseEvent.MouseWheel)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //Rectangle invalidaterect = _mousemapping.ButtonList.First(s => s.Button == MouseButtons.None).Mapping;

                //if (this._message.Delta > 0)
                //{
                //    invalidaterect.Height /= 2;
                //}
                //else
                //{
                //    invalidaterect.Y += (invalidaterect.Height / 2);
                //    invalidaterect.Height /= 2;
                //}

                GraphicsPath gp;

                if (_message.Delta > 0)
                {
                    gp = new GraphicsPath();
                    gp.AddPolygon(_mousemapping.ButtonList.First(s => s.Button == MouseButtons.Middle).ListPoint);

                    var test = new Region(gp);

                    RectangleF rf = gp.GetBounds();

                    rf.Height /= 2;

                    test.Intersect(rf);

                    e.Graphics.FillRegion(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), test);
                }
                else
                {
                    gp = new GraphicsPath();
                    gp.AddPolygon(_mousemapping.ButtonList.First(s => s.Button == MouseButtons.Middle).ListPoint);

                    var test = new Region(gp);

                    RectangleF rf = gp.GetBounds();

                    rf.Height /= 2;
                    rf.Y += rf.Height;

                    test.Intersect(rf);

                    e.Graphics.FillRegion(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), test);
                }

                //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), invalidaterect);

                //e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), _mousemapping.ButtonList.First(s => s.Button == MouseButtons.Middle).ListPoint);


                Thread.Sleep(50);

                _message = null;

                Thread.Sleep(50);

                pictureBox_Mouse.Invalidate(new Region(gp));
            }
        }

        private void pictureBox_Cursor_Paint(object sender, PaintEventArgs e)
        {
            if (_message == null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                var penn = new Pen(Color.Black, 5) {StartCap = LineCap.RoundAnchor, EndCap = LineCap.ArrowAnchor};

                e.Graphics.DrawLine(penn, 85, 58, 86, 59);
                return;
            }


            var movevector = new Vector((_message.X - _mousex), (_message.Y - _mousey));


            double length = Math.Log(movevector.Length*1d, 1.12);

            if (double.IsNaN(length))
                length = 0;

            length = Math.Min(length, 70);

            movevector.Normalize();

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var pen = new Pen(Color.Black, 5) {StartCap = LineCap.RoundAnchor, EndCap = LineCap.ArrowAnchor};

            if (!double.IsNaN(movevector.X) && !double.IsNaN(movevector.Y))
                e.Graphics.DrawLine(pen, 85, 58, (int) (movevector.X*length) + 85, (int) (movevector.Y*length) + 58);
            else
                e.Graphics.DrawLine(pen, 85, 58, 86, 59);

            _mousex = _message.X;
            _mousey = _message.Y;

            //if(Math.Abs(this._mousex - this._message.X) > 3)
            //    this._mousex = this._message.X - (int)(movevector.X * 3d);
            //if (Math.Abs(this._mousey - this._message.Y) > 3)
            //    this._mousey = this._message.Y - (int)(movevector.Y * 3d); ;
        }

        private void timer_DisplayCursor_Tick(object sender, EventArgs e)
        {
            pictureBox_Cursor.Invalidate();
        }

        private void MouseDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            _networkstatusupdater.Disconnect();
        }
    }
}
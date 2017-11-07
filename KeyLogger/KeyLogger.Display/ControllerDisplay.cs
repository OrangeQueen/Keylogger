using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KeyLogger.Messages;
using KeyLogger.Network.Status;
using MetroFramework.Forms;

namespace KeyLogger.Display
{
    public partial class ControllerDisplay : MetroForm
    {
        private readonly NetworkStatusUpdater _networkstatusupdater;

        private ControllerInputMessage _message;

        public ControllerDisplay(NetworkStatusUpdater nsupdater)
        {
            InitializeComponent();

            _networkstatusupdater = nsupdater;
        }

        public void RedrawController(ControllerInputMessage message)
        {
            _message = message;

            pictureBox_Controller.Invalidate();

            vProgressBar_Left.Value = message.LeftTrigger;
            vProgressBar_Right.Value = message.RightTrigger;
        }

        private void pictureBox_Controller_Paint(object sender, PaintEventArgs e)
        {
            if (_message == null)
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (_message.DPadUp)
                e.Graphics.FillEllipse(Brushes.GhostWhite, 197, 145, 22, 22);
            if (_message.DPadDown)
                e.Graphics.FillEllipse(Brushes.GhostWhite, 197, 210, 22, 22);
            if (_message.DPadLeft)
                e.Graphics.FillEllipse(Brushes.GhostWhite, 165, 177, 22, 22);
            if (_message.DPadRight)
                e.Graphics.FillEllipse(Brushes.GhostWhite, 230, 177, 22, 22);
            if (_message.Start)
                e.Graphics.FillEllipse(Brushes.GhostWhite, 344, 88, 22, 22);
            if (_message.Back)
                e.Graphics.FillEllipse(Brushes.GhostWhite, 224, 88, 22, 22);
            if (_message.A)
                e.Graphics.FillEllipse(Brushes.GhostWhite, 450, 126, 22, 22);
            if (_message.B)
                e.Graphics.FillEllipse(Brushes.GhostWhite, 493, 85, 22, 22);
            if (_message.X)
                e.Graphics.FillEllipse(Brushes.GhostWhite, 406, 85, 22, 22);
            if (_message.Y)
                e.Graphics.FillEllipse(Brushes.GhostWhite, 447, 45, 22, 22);
            if (_message.LeftShoulder)
            {
                //e.Graphics.FillEllipse(Brushes.Red, 160, 10, 22, 22);

                e.Graphics.FillPolygon(Brushes.Red, new[]
                {
                    new Point {X = 84, Y = 29},
                    new Point {X = 93, Y = 22},
                    new Point {X = 109, Y = 14},
                    new Point {X = 129, Y = 7},
                    new Point {X = 144, Y = 5},
                    new Point {X = 172, Y = 6},
                    new Point {X = 177, Y = 11},
                    new Point {X = 160, Y = 10},
                    new Point {X = 142, Y = 12},
                    new Point {X = 126, Y = 14},
                    new Point {X = 107, Y = 22},
                    new Point {X = 92, Y = 30},
                    new Point {X = 83, Y = 37}
                });
            }
            if (_message.RightShoulder)
            {
                //e.Graphics.FillEllipse(Brushes.Red, 580, 10, 22, 22);

                e.Graphics.FillPolygon(Brushes.Red, new[]
                {
                    new Point {X = 408, Y = 15},
                    new Point {X = 414, Y = 9},
                    new Point {X = 427, Y = 8},
                    new Point {X = 449, Y = 9},
                    new Point {X = 464, Y = 13},
                    new Point {X = 484, Y = 22},
                    new Point {X = 496, Y = 30},
                    new Point {X = 501, Y = 34},
                    new Point {X = 502, Y = 39},
                    new Point {X = 482, Y = 27},
                    new Point {X = 458, Y = 18},
                    new Point {X = 441, Y = 14},
                    new Point {X = 427, Y = 13},
                    new Point {X = 415, Y = 14}
                });
            }

            double leftscaledx = _message.LeftThumbStick.X*(1d/Int16.MaxValue);
            double leftscaledy = _message.LeftThumbStick.Y*(1d/Int16.MaxValue);

            double rightscaledx = _message.RightThumbStick.X*(1d/Int16.MaxValue);
            double rightscaledy = _message.RightThumbStick.Y*(1d/Int16.MaxValue);

            e.Graphics.FillEllipse(_message.LeftStick ? Brushes.Red : Brushes.GhostWhite,
                123 + (int) (leftscaledx*28), 80 + (int) (leftscaledy*-28), 12, 12);

            e.Graphics.FillEllipse(_message.RightStick ? Brushes.Red : Brushes.GhostWhite,
                371 + (int) (rightscaledx*28), 171 + (int) (rightscaledy*-28), 12, 12);
        }

        private void ControllerDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            _networkstatusupdater.Disconnect();
        }
    }
}
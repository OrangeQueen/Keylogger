using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using KeyLogger.Display.Keymap;
using KeyLogger.Display.Properties;
using KeyLogger.Messages;
using KeyLogger.Messages.Events;
using KeyLogger.Network.Status;
using MetroFramework.Forms;
using System;
using System.Diagnostics;

namespace KeyLogger.Display
{
    public partial class KeyboardDisplay : MetroForm
    {
        private readonly Keyboard _keyboardmapping;
        private readonly NetworkStatusUpdater _networkstatusupdater;

        private KeyboardInputMessage _message;

        public KeyboardDisplay(NetworkStatusUpdater nsupdater)
        {
            InitializeComponent();

            var serializer = new XmlSerializer(typeof (Keyboard));

            _keyboardmapping =
                (Keyboard) serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(Resources.KeyboardMapping)));

            _networkstatusupdater = nsupdater;
        }

        public void RedrawController(KeyboardInputMessage message)
        {
            _message = message;
            switch (_message.KeyboardEvent)
            {
                case KeyboardEvent.KeyDown:
                case KeyboardEvent.KeyUp:
                    Rectangle invalidaterect = _keyboardmapping.KeyList.First(s => s.Key == _message.Key).Mapping;

                    if (invalidaterect.X != 0 && invalidaterect.Y != 0)
                        pictureBox_Keyboard.Invalidate(invalidaterect);
                    break;
            }
        }

        private void pictureBox_Keyboard_Paint(object sender, PaintEventArgs e)
        {
            if (_message == null)
            {
                return;
            }
            if (_message.KeyboardEvent == KeyboardEvent.KeyDown)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle invalidaterect = _keyboardmapping.KeyList.First(s => s.Key == _message.Key).Mapping;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), invalidaterect);
            }
        }

        private void KeyboardDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            _networkstatusupdater.Disconnect();
        }
    }
}
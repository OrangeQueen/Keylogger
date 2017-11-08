using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using KeyLogger.Display.Properties;
using KeyLogger.Messages;
using KeyLogger.Network;
using KeyLogger.Network.Events;
using KeyLogger.Network.Status;
using MetroFramework.Forms;
using MetroMessageBox = MetroFramework.MetroMessageBox;
using System.Diagnostics;
using System.Net;

namespace KeyLogger.Display
{
    public partial class Overview : MetroForm
    {
        private static Dictionary<string, Dictionary<FormType, Form>> _clients;

        private static List<Server> _servers;

        public Overview()
        {
            InitializeComponent();

            _clients = new Dictionary<string, Dictionary<FormType, Form>>();

            //_server = new Server(Properties.Settings.Default.NetworkPort, 100);

            //_server.NetworkEvent += NetworkEvent;

            //_server.DeviceEvent += DeviceEvent;

            //_server.InputEvent += InputEvent;

            if (!NetworkHelper.GetHostIpAdresses().Any())
                MessageBox.Show(Resources.Overview_No_active_network_connection_detected);

            _servers = new List<Server>();

            foreach (string ip in NetworkHelper.GetHostIpAdresses())
            {
                var server = new Server(ip, Settings.Default.NetworkPort, 100);

                server.NetworkEvent += NetworkEvent;
                server.DeviceEvent += DeviceEvent;
                server.InputEvent += InputEvent;

                _servers.Add(server);
            }

            metroTextBox_Port.Text = Settings.Default.NetworkPort.ToString(CultureInfo.InvariantCulture);
        }

        private Form GetForm(string ip, FormType type)
        {
            if (_clients.ContainsKey(ip))
                if (_clients[ip].ContainsKey(type))
                    return _clients[ip][type];

            return null;
        }

        private void InputEvent(object sender, InputEventArgs e)
        {
            BeginInvoke((MethodInvoker) (() =>
            {
                if (e.Message.GetType() == typeof (KeyboardInputMessage))
                {
                    var message = (KeyboardInputMessage) e.Message;

                    var form = (KeyboardDisplay) GetForm(e.Ip.Address.ToString(), FormType.Keyboard);

                    form.RedrawController(message);
                }

                if (e.Message.GetType() == typeof (MouseInputMessage))
                {
                    var message = (MouseInputMessage) e.Message;

                    var form = (MouseDisplay) GetForm(e.Ip.Address.ToString(), FormType.Mouse);

                    form.RedrawController(message);
                }

                if (e.Message.GetType() == typeof (ControllerInputMessage))
                {
                    var message = (ControllerInputMessage) e.Message;

                    var form = (ControllerDisplay) GetForm(e.Ip.Address.ToString(), FormType.Controller);

                    form.RedrawController(message);
                }
            }));
        }

        private void DeviceEvent(object sender, DeviceEventArgs e)
        {
            Invoke((MethodInvoker) (() =>
            {
                foreach (DataGridViewRow dgvrc in dataGridView_Clients.Rows)
                {
                    if (dgvrc.Cells[1].FormattedValue.ToString() == e.Ip.Address.ToString())
                    {
                        if (e.Message.Keyboard != null)
                        {
                            dgvrc.Cells[2].Value = (e.Message.Keyboard ?? false == true) ? true : false;

                            if (e.Message.Keyboard == true)
                            {
                                Dictionary<FormType, Form> formsdict = _clients[e.Ip.Address.ToString()];

                                var nsu = new KeyboardNetworkStatusUpdater(_servers, e.Ip.Address.ToString());

                                var d = new KeyboardDisplay(nsu)
                                {
                                    Text = Resources.Overview_Keyboard + GetPcName(e.Ip.Address.ToString())
                                };

                                d.Show();

                                formsdict.Add(FormType.Keyboard, d);
                            }
                            else
                            {
                                Dictionary<FormType, Form> formsdict = _clients[e.Ip.Address.ToString()];

                                Form form = formsdict[FormType.Keyboard];

                                form.Dispose();

                                formsdict.Remove(FormType.Keyboard);
                            }
                        }
                        if (e.Message.Mouse != null)
                        {
                            dgvrc.Cells[3].Value = (e.Message.Mouse ?? false == true) ? true : false;

                            if (e.Message.Mouse == true)
                            {
                                Dictionary<FormType, Form> formsdict = _clients[e.Ip.Address.ToString()];

                                var nsu = new MouseNetworkStatusUpdater(_servers, e.Ip.Address.ToString());

                                var d = new MouseDisplay(nsu)
                                {
                                    Text = Resources.Overview_Mouse + GetPcName(e.Ip.Address.ToString())
                                };

                                d.Show();

                                formsdict.Add(FormType.Mouse, d);
                            }
                            else
                            {
                                Dictionary<FormType, Form> formsdict = _clients[e.Ip.Address.ToString()];

                                Form form = formsdict[FormType.Mouse];

                                form.Dispose();

                                formsdict.Remove(FormType.Mouse);
                            }
                        }
                        if (e.Message.Controller != null)
                        {
                            dgvrc.Cells[4].Value = (e.Message.Controller ?? false == true) ? true : false;

                            if (e.Message.Controller == true)
                            {
                                Dictionary<FormType, Form> formsdict = _clients[e.Ip.Address.ToString()];

                                var nsu = new ControllerNetworkStatusUpdater(_servers, e.Ip.Address.ToString());

                                var d = new ControllerDisplay(nsu)
                                {
                                    Text = Resources.Overview_Controller + GetPcName(e.Ip.Address.ToString())
                                };

                                d.Show();

                                formsdict.Add(FormType.Controller, d);
                            }
                            else
                            {
                                Dictionary<FormType, Form> formsdict = _clients[e.Ip.Address.ToString()];

                                Form form = formsdict[FormType.Controller];

                                form.Dispose();

                                formsdict.Remove(FormType.Controller);
                            }
                        }

                        break;
                    }
                }
            }));
        }

        private void NetworkEvent(object sender, NetworkEventArgs e)
        {
            Invoke((MethodInvoker) (() =>
            {
                switch (e.NetworkStatus)
                {
                    case NetworkStatus.Connected:
                        // Client Dic
                        _clients.Add(e.Ip.Address.ToString(), new Dictionary<FormType, Form>());

                        //listView_Clients.Items.Add(e.Name).SubItems.Add(e.IP.Address.ToString());

                        var dgvr = new DataGridViewRow();
                        dgvr.Cells.Add(new DataGridViewTextBoxCell {Value = e.Name});
                        dgvr.Cells.Add(new DataGridViewTextBoxCell {Value = e.Ip.Address.ToString()});
                        dgvr.Cells.Add(new DataGridViewCheckBoxCell());
                        dgvr.Cells.Add(new DataGridViewCheckBoxCell());
                        dgvr.Cells.Add(new DataGridViewCheckBoxCell());

                        dataGridView_Clients.Rows.Add(dgvr);

                        break;
                    case NetworkStatus.Disconnected:
                        // Client Dic
                        if (_clients[e.Ip.Address.ToString()].ContainsKey(FormType.Keyboard))
                            _clients[e.Ip.Address.ToString()][FormType.Keyboard].Dispose();

                        if (_clients[e.Ip.Address.ToString()].ContainsKey(FormType.Mouse))
                            _clients[e.Ip.Address.ToString()][FormType.Mouse].Dispose();

                        if (_clients[e.Ip.Address.ToString()].ContainsKey(FormType.Controller))
                            _clients[e.Ip.Address.ToString()][FormType.Controller].Dispose();

                        _clients.Remove(e.Ip.Address.ToString());

                        foreach (DataGridViewRow dgvrc in dataGridView_Clients.Rows)
                        {
                            if (dgvrc.Cells[1].FormattedValue.ToString() == e.Ip.Address.ToString())
                            {
                                dataGridView_Clients.Rows.Remove(dgvrc);
                                break;
                            }
                        }
                        break;
                }
            }));
        }

        private void Overview_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Server server in _servers)
            {
                server.NetworkEvent -= NetworkEvent;
                server.DeviceEvent -= DeviceEvent;
                server.InputEvent -= InputEvent;

                server.Shutdown();

                Thread.Sleep(500);
            }
        }

        private void dataGridView_Clients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView_Clients.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType() ==
                typeof (DataGridViewCheckBoxCell))
            {
                //dataGridView_Clients.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)(dataGridView_Clients.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? false);

                foreach (Server server in _servers)
                {
                    switch (e.ColumnIndex)
                    {
                        case 2:
                            server.Send(
                                new DeviceConnectRequestMessage
                                {
                                    Keyboard =
                                        !(bool)
                                            (dataGridView_Clients.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? false)
                                },
                                dataGridView_Clients.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                            break;
                        case 3:
                            server.Send(
                                new DeviceConnectRequestMessage
                                {
                                    Mouse =
                                        !(bool)
                                            (dataGridView_Clients.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? false)
                                },
                                dataGridView_Clients.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                            break;
                        case 4:
                            server.Send(
                                new DeviceConnectRequestMessage
                                {
                                    Controller =
                                        !(bool)
                                            (dataGridView_Clients.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? false)
                                },
                                dataGridView_Clients.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                            break;
                    }
                }
            }

            if (dataGridView_Clients.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType() == typeof (DataGridViewButtonCell))
            {
                foreach (Server server in _servers)
                {
                    server.DisconnectClient(dataGridView_Clients.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                }
            }
        }

        private string GetPcName(string ip)
        {
            return (from DataGridViewRow dgvrc in dataGridView_Clients.Rows
                where dgvrc.Cells[1].FormattedValue.ToString() == ip
                select dgvrc.Cells[0].FormattedValue.ToString()).FirstOrDefault();
        }

        private void metroButton_ChangePort_Click(object sender, EventArgs e)
        {
            ushort result;

            if (UInt16.TryParse(metroTextBox_Port.Text, out result) && result > 0)
            {
                Settings.Default.NetworkPort = result;
                Settings.Default.Save();

                Application.Restart();
                //return;
            }

            MetroMessageBox.Show(this, "This is not a valid port number!", "Information", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        //TODO
        // add button for this
        private void Stop_Capture(object sender, EventArgs e)
        {
            foreach (Server server in _servers)
                server.StopCapture();
        }

        private void Start_Capture(object sender, EventArgs e)
        {
            foreach (Server server in _servers)
                server.StartCapture();
        }

        private void Start_Replay(object sender, EventArgs e)
        {
            // TODO:
            // open file dialog (google4it)
            // read file from returned path
            // split file by Server.LineSep
            // give list instead of _servers[0].Log
            new Thread(Replay).Start(_servers[0].Log.ToList());
        }

        private void ProcessMessage(byte[] datamsg, IPEndPoint senderEndPoint)
        {
            var im = SerializeHelper.Deserialize<InputMessage>(datamsg);
            InputEvent(this, new InputEventArgs { Message = im, Ip = senderEndPoint });
        }

        public void Replay(object data)
        {
            var log = (List<string>)data;
            foreach (var msg in log)
            {
                string[] parts = msg.Split(Server.sep.ToCharArray());

                Thread.Sleep(int.Parse(parts[0]));
                ProcessMessage(
                    Convert.FromBase64String(parts[1]),
                    new IPEndPoint(0,0)
                );
            }
        }
    }
}
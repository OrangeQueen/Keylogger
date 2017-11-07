using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using KeyLogger.Catcher;
using KeyLogger.Catcher.Hooks;
using KeyLogger.Client.Properties;
using KeyLogger.Network;
using KeyLogger.Network.Events;
using MetroFramework.Forms;
using MetroMessageBox = MetroFramework.MetroMessageBox;

namespace KeyLogger.Client
{
    public partial class StartFormMetro : MetroForm
    {
        public CatchManager Catchmanager;

        private bool _acondiscovery;
        private bool _actryconnect;

        public StartFormMetro()
        {
            InitializeComponent();


            foreach (string ip in NetworkHelper.GetHostAdapters())
            {
                // Hinzufügen der gefundenen Adapter
                metroComboBox_Adapter.Items.Add(ip);
            }
            // Auswahl des ersten Adapters
            if (metroComboBox_Adapter.Items.Count > 0)
                metroComboBox_Adapter.SelectedIndex = 0;

            // Wenn es einen aktiven HostAdapter gibt 
            if (NetworkHelper.GetHostAdapters().Any())
            {
                Catchmanager = new CatchManager();

                Catchmanager.NetworkClient.NetworkDiscoveryEvent += NetworkClient_NetworkDiscoveryEvent;
                Catchmanager.NetworkClient.NetworkEvent += NetworkClient_NetworkEvent;
                Catchmanager.NetworkClient.DeviceRequestEvent += NetworkClient_DeviceRequestEvent;
            }
            else
            {
                MessageBox.Show(Resources.StartFormMetro_StartFormMetro_No_active_network_detected);
                Close();
            }

            // Die zuletzt verwendete IP Adresse hinzufügen
            if (!String.IsNullOrEmpty(Settings.Default.LastUsedServerIP))
            {
                metroComboBox_IP.Items.Add(Settings.Default.LastUsedServerIP);
                metroComboBox_IP.SelectedIndex = 0;
            }

            // Port
            metroTextBox_Port.Text = Settings.Default.NetworkPort.ToString(CultureInfo.InvariantCulture);

            // AutoStart Timer
            timer_AutoConnect.Enabled = true;

            // CHECKBOX ENABLED
            //this.metroToggle_AutoConnect.Checked = true;

            // INSTANT CONNECT
            AutoConnect();
        }

        private void AutoConnect()
        {
            // AUTO CONNECT
            if (metroComboBox_IP.Items.Count == 0)
            {
                _acondiscovery = true;
                Catchmanager.NetworkClient.DiscoveryRequest(Settings.Default.NetworkPort);
            }
            else if (NetworkHelper.ValidIPv4(metroComboBox_IP.SelectedItem.ToString()))
            {
                metroProgressSpinner_Connect.Visible = true;

                metroButton_Connect.Enabled = false;
                metroButton_Discover.Enabled = false;
                metroButton_PortChange.Enabled = false;
                metroComboBox_Adapter.Enabled = false;
                metroComboBox_IP.Enabled = false;
                metroButton_AddIP.Enabled = false;
                metroTextBox_Port.Enabled = false;

                metroLabel_Network.Text = Resources.StartFormMetro_MetroLabel_Network_Trying;

                _actryconnect = true;

                Catchmanager.NetworkClient.Connect(metroComboBox_IP.SelectedItem.ToString(),
                    Settings.Default.NetworkPort, Dns.GetHostName());
            }
        }

        private void timer_AutoConnect_Tick(object sender, EventArgs e)
        {
            if (Catchmanager.NetworkStatus == NetworkStatus.Disconnected)
            {
                AutoConnect();
            }
            else
            {
                metroToggle_AutoConnect.Checked = false;
                timer_AutoConnect.Enabled = false;
            }
        }

        private void metroButton_PortChange_Click(object sender, EventArgs e)
        {
            ushort result;

            if (UInt16.TryParse(metroTextBox_Port.Text, out result) && result > 0)
            {
                Settings.Default.NetworkPort = result;
                Settings.Default.Save();

                return;
            }

            MetroMessageBox.Show(this, "This is not a valid port number!", "Information", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void metroToggle_AutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle_AutoConnect.Checked)
            {
                timer_AutoConnect.Stop();
                timer_AutoConnect.Start();
                timer_AutoConnect.Enabled = true;
                AutoConnect();
            }
            else
            {
                timer_AutoConnect.Enabled = false;
                timer_AutoConnect.Stop();
            }
        }

        private void metroComboBox_Adapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Catchmanager != null)
            {
                Catchmanager.NetworkClient.NetworkDiscoveryEvent -= NetworkClient_NetworkDiscoveryEvent;
                Catchmanager.NetworkClient.NetworkEvent -= NetworkClient_NetworkEvent;
                Catchmanager.NetworkClient.DeviceRequestEvent -= NetworkClient_DeviceRequestEvent;

                Catchmanager.ChangeNetworkAdapter(NetworkHelper.GetHostIpAdresses()[metroComboBox_Adapter.SelectedIndex]);

                Catchmanager.NetworkClient.NetworkDiscoveryEvent += NetworkClient_NetworkDiscoveryEvent;
                Catchmanager.NetworkClient.NetworkEvent += NetworkClient_NetworkEvent;
                Catchmanager.NetworkClient.DeviceRequestEvent += NetworkClient_DeviceRequestEvent;
            }
        }

        private void metroToggle_Keyboard_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle_Keyboard.Checked)
            {
                var hook = new KeyboardHook();
                hook.SetKeyDown(true);
                hook.SetKeyUp(true);

                Catchmanager.AddHook(hook);
            }
            else
            {
                Catchmanager.RemoveHook(typeof (KeyboardHook));
            }

            toolStripMenuItem_Keyboard.Checked = !toolStripMenuItem_Keyboard.Checked;
        }

        private void metroToggle_Mouse_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle_Mouse.Checked)
            {
                var hook = new MouseHook();
                hook.SetOnMouseUp(true);
                hook.SetOnMouseDown(true);
                hook.SetMouseWheel(true);
                hook.SetOnMouseMove(true);

                Catchmanager.AddHook(hook);
            }
            else
            {
                Catchmanager.RemoveHook(typeof (MouseHook));
            }

            toolStripMenuItem_Mouse.Checked = !toolStripMenuItem_Mouse.Checked;
        }

        private void metroToggle_Controller_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle_Controller.Checked)
            {
                var hook = new ControllerHook();

                Catchmanager.AddHook(hook);
            }
            else
            {
                Catchmanager.RemoveHook(typeof (ControllerHook));
            }

            toolStripMenuItem_Controller.Checked = !toolStripMenuItem_Controller.Checked;
        }

        private void metroComboBox_IP_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void metroButton_AddIP_Click(object sender, EventArgs e)
        {
            var imf = new InputMessageForm();

            //imf.ShowDialog();

            if (imf.ShowDialog() == DialogResult.OK)
            {
                if (NetworkHelper.ValidIPv4(imf.metroTextBox_Input.Text))
                {
                    if (!metroComboBox_IP.Items.Contains(imf.metroTextBox_Input.Text))
                    {
                        metroComboBox_IP.Items.Add(imf.metroTextBox_Input.Text);
                    }

                    metroComboBox_IP.SelectedIndex = metroComboBox_IP.Items.IndexOf(imf.metroTextBox_Input.Text);
                    metroComboBox_IP.Focus();
                }
                else
                {
                    MetroMessageBox.Show(this, "This is not a valid IP address!", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

            imf.Dispose();
        }

        private void metroButton_Discover_Click(object sender, EventArgs e)
        {
            Catchmanager.NetworkClient.DiscoveryRequest(Settings.Default.NetworkPort);
        }

        private void metroButton_Connect_Click(object sender, EventArgs e)
        {
            if (metroButton_Connect.Text == Resources.StartFormMetro_MetroButton_Connect_Connect)
                if (metroComboBox_IP.SelectedItem != null &&
                    NetworkHelper.ValidIPv4(metroComboBox_IP.SelectedItem.ToString()))
                {
                    metroProgressSpinner_Connect.Visible = true;

                    metroLabel_Network.Text = Resources.StartFormMetro_MetroLabel_Network_Trying;

                    metroButton_Connect.Enabled = false;
                    metroButton_Discover.Enabled = false;
                    metroButton_PortChange.Enabled = false;
                    metroComboBox_Adapter.Enabled = false;
                    metroComboBox_IP.Enabled = false;
                    metroButton_AddIP.Enabled = false;
                    metroTextBox_Port.Enabled = false;

                    Catchmanager.NetworkClient.Connect(metroComboBox_IP.SelectedItem.ToString(),
                        Settings.Default.NetworkPort, Dns.GetHostName());
                }
                else
                {
                    MetroMessageBox.Show(this, "No valid IP selected!", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

            if (metroButton_Connect.Text == Resources.StartFormMetro_MetroButton_Connect_Disconnect)
            {
                Catchmanager.NetworkClient.Disconnect();
            }
        }

        private void StartFormMetro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Catchmanager.NetworkClient.NetworkDiscoveryEvent -= NetworkClient_NetworkDiscoveryEvent;
            Catchmanager.NetworkClient.NetworkEvent -= NetworkClient_NetworkEvent;
            Catchmanager.NetworkClient.DeviceRequestEvent -= NetworkClient_DeviceRequestEvent;

            foreach (IInputHook hook in Catchmanager.InputHooks.ToList())
            {
                Catchmanager.RemoveHook(hook.GetType());
            }

            Catchmanager.NetworkClient.Disconnect();

            Thread.Sleep(500);
        }

        private void StartFormMetro_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                notifyIcon_Tray.Visible = true;
                notifyIcon_Tray.ShowBalloonTip(500);
                Hide();
            }
            else if (FormWindowState.Normal == WindowState)
            {
                notifyIcon_Tray.Visible = false;
            }
        }

        private void notifyIcon_Tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon_Tray.Visible = false;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void toolStripMenuItem_Show_Click(object sender, EventArgs e)
        {
            notifyIcon_Tray.Visible = false;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void toolStripMenuItem_Keyboard_Click(object sender, EventArgs e)
        {
            metroToggle_Keyboard.Checked = !metroToggle_Keyboard.Checked;
        }

        private void toolStripMenuItem_Mouse_Click(object sender, EventArgs e)
        {
            metroToggle_Mouse.Checked = !metroToggle_Mouse.Checked;
        }

        private void toolStripMenuItem_Controller_Click(object sender, EventArgs e)
        {
            metroToggle_Controller.Checked = !metroToggle_Controller.Checked;
        }

        private void toolStripMenuItem_Quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region ControllEventHandlers

        #endregion

        #region NetworkEventHandlers

        private void NetworkClient_DeviceRequestEvent(object sender, DeviceRequestEventArgs e)
        {
            if (e.Message.Controller != null)
            {
                metroToggle_Controller.Checked = e.Message.Controller ?? false;
            }
            if (e.Message.Keyboard != null)
            {
                metroToggle_Keyboard.Checked = e.Message.Keyboard ?? false;
            }
            if (e.Message.Mouse != null)
            {
                metroToggle_Mouse.Checked = e.Message.Mouse ?? false;
            }
        }

        private void NetworkClient_NetworkEvent(object sender, NetworkEventArgs e)
        {
            Invoke((MethodInvoker) (() =>
            {
                switch (e.NetworkStatus)
                {
                    case NetworkStatus.Connected:
                        // AUTOCONNECT
                        _actryconnect = false;

                        // If connected DISABLE controlls
                        metroButton_Connect.Text = Resources.StartFormMetro_MetroButton_Connect_Disconnect;
                        metroButton_Connect.Enabled = true;
                        metroButton_Discover.Enabled = false;
                        metroButton_PortChange.Enabled = false;
                        metroComboBox_Adapter.Enabled = false;
                        metroComboBox_IP.Enabled = false;
                        metroButton_AddIP.Enabled = false;
                        metroTextBox_Port.Enabled = false;
                        metroProgressSpinner_Connect.Visible = false;
                        metroToggle_AutoConnect.Enabled = false;
                        metroToggle_AutoConnect.Checked = false;

                        metroLabel_Network.Text = Resources.StartFormMetro_MetroLabel_Network_Connected;
                        pictureBox_Network.Image = Resources.network_cn;
                        // 

                        // SAVE LAST USED IP ADDRESS
                        Settings.Default.LastUsedServerIP = metroComboBox_IP.SelectedItem.ToString();
                        Settings.Default.Save();

                        break;
                    case NetworkStatus.Disconnected:
                        // AUTO CONNECT 
                        // If Connect Button Disabled
                        if (metroButton_Connect.Enabled == false && !_actryconnect)
                        {
                            MetroMessageBox.Show(this, "Connection failed!", "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }

                        if (!_actryconnect)
                            metroToggle_AutoConnect.Checked = false;

                        if (_actryconnect)
                        {
                            _actryconnect = false;
                            metroComboBox_IP.Items.Clear();
                        }

                        // If disconnected DISABLE controlls
                        metroButton_Connect.Text = Resources.StartFormMetro_MetroButton_Connect_Connect;
                        metroButton_Connect.Enabled = true;
                        metroButton_Discover.Enabled = true;
                        metroButton_PortChange.Enabled = true;
                        metroComboBox_Adapter.Enabled = true;
                        metroComboBox_IP.Enabled = true;
                        metroButton_AddIP.Enabled = true;
                        metroTextBox_Port.Enabled = true;
                        metroProgressSpinner_Connect.Visible = false;
                        metroToggle_AutoConnect.Enabled = true;

                        metroLabel_Network.Text = Resources.StartFormMetro_MetroLabel_Network_Disconnected;
                        pictureBox_Network.Image = Resources.network_dc;
                        // 

                        break;
                }
            }));
        }

        private void NetworkClient_NetworkDiscoveryEvent(object sender, NetworkDiscoveryResponseEventArgs e)
        {
            Invoke((MethodInvoker) (() =>
            {
                // Wenn die gefundene IP Adresse noch nicht enthalten ist -> füge sie hinzu
                if (!metroComboBox_IP.Items.Contains(e.EndPoint.Address.ToString()))
                {
                    metroComboBox_IP.Items.Add(e.EndPoint.Address.ToString());

                    // Wenn noch keine IP Adresse vorhanden war wähle diese aus.
                    if (metroComboBox_IP.Items.Count == 1)
                    {
                        metroComboBox_IP.SelectedIndex = 0;
                    }
                }

                metroComboBox_IP.SelectedIndex = metroComboBox_IP.Items.IndexOf(e.EndPoint.Address.ToString());
                metroComboBox_IP.Focus();

                // AUTOCONNECT
                if (_acondiscovery)
                {
                    _acondiscovery = false;
                    AutoConnect();
                }
            }));
        }

        #endregion
    }
}
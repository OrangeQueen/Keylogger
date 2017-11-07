using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using KeyLogger.Catcher;
using KeyLogger.Catcher.Hooks;
using KeyLogger.Client.Properties;
using KeyLogger.Network;
using KeyLogger.Network.Events;

namespace KeyLogger.Client
{
    public partial class StartForm : Form
    {
        public CatchManager Catchmanager;
        private bool _connectfromstored;
        private bool _connectondiscovery;

        public StartForm()
        {
            InitializeComponent();

            foreach (string ip in NetworkHelper.GetHostAdapters())
            {
                comboBox_IPAdresses.Items.Add(ip);

                comboBox_IPAdresses.SelectedIndex = 0;
            }

            if (NetworkHelper.GetHostAdapters().Any())
            {
                Catchmanager = new CatchManager();

                Catchmanager.NetworkClient.NetworkDiscoveryEvent += NetworkClient_NetworkDiscoveryEvent;
                Catchmanager.NetworkClient.NetworkEvent += NetworkClient_NetworkEvent;
                Catchmanager.NetworkClient.DeviceRequestEvent += NetworkClient_DeviceRequestEvent;
            }
            else
            {
                MessageBox.Show(Resources.StartForm_StartForm_No_active_network_detected);
                Close();
            }

            textBox_IP.Text = Settings.Default.LastUsedServerIP;

            timer_AutoConnect.Enabled = true;


            // INSTANT CONNECT
            AutoConnect();
        }

        private void NetworkClient_DeviceRequestEvent(object sender, DeviceRequestEventArgs e)
        {
            if (e.Message.Controller != null)
            {
                checkBox_Controller.Checked = e.Message.Controller ?? false;
            }
            if (e.Message.Keyboard != null)
            {
                checkBox_Keyboard.Checked = e.Message.Keyboard ?? false;
            }
            if (e.Message.Mouse != null)
            {
                checkBox_Mouse.Checked = e.Message.Mouse ?? false;
            }
        }

        private void NetworkClient_NetworkEvent(object sender, NetworkEventArgs e)
        {
            Invoke((MethodInvoker) (() =>
            {
                switch (e.NetworkStatus)
                {
                    case NetworkStatus.Connected:
                        _connectfromstored = false;

                        button_Connect.Enabled = false;
                        //toolStripMenuItem_Connect.Enabled = false;
                        button_Disconnect.Enabled = true;
                        //toolStripMenuItem_Disconnect.Enabled = true;
                        comboBox_IPAdresses.Enabled = false;

                        button_Connect.Text = Resources.StartForm_Button_Connect_Connect;

                        Settings.Default.LastUsedServerIP = textBox_IP.Text;
                        Settings.Default.Save();

                        break;
                    case NetworkStatus.Disconnected:
                        if (!_connectfromstored)
                            checkBox_AutoConnect.Checked = false;

                        if (_connectfromstored)
                        {
                            _connectfromstored = false;
                            textBox_IP.Text = "";
                        }
                        else if (button_Connect.Text != Resources.StartForm_Button_Connect_Connect)
                            MessageBox.Show(Resources.StartForm_NetworkClient_NetworkEvent_Connection_failed);


                        if (button_Connect.Text != Resources.StartForm_Button_Connect_Connect)
                        {
                            button_Connect.Enabled = true;
                            button_Connect.Text = Resources.StartForm_Button_Connect_Connect;
                        }

                        button_Connect.Enabled = true;
                        //toolStripMenuItem_Connect.Enabled = true;
                        button_Disconnect.Enabled = false;
                        //toolStripMenuItem_Disconnect.Enabled = false;
                        comboBox_IPAdresses.Enabled = true;

                        comboBox_IPAdresses.Enabled = true;
                        textBox_IP.Enabled = true;
                        button_Discover.Enabled = true;

                        break;
                }
            }));
        }

        private void NetworkClient_NetworkDiscoveryEvent(object sender, NetworkDiscoveryResponseEventArgs e)
        {
            Invoke((MethodInvoker) (() => textBox_IP.Text = e.EndPoint.Address.ToString()));

            if (_connectondiscovery)
            {
                _connectondiscovery = false;

                AutoConnect();
            }
        }

        private void button_Discover_Click(object sender, EventArgs e)
        {
            Catchmanager.NetworkClient.DiscoveryRequest(Settings.Default.NetworkPort);
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            if (NetworkHelper.ValidIPv4(textBox_IP.Text))
            {
                comboBox_IPAdresses.Enabled = false;
                textBox_IP.Enabled = false;
                button_Discover.Enabled = false;
                button_Connect.Enabled = false;
                button_Connect.Text = Resources.StartForm_Button_Connect_Connecting;
                Catchmanager.NetworkClient.Connect(textBox_IP.Text, Settings.Default.NetworkPort, Dns.GetHostName());
            }
            else
            {
                MessageBox.Show(Resources.StartForm_button_Connect_Click_Not_a_valid_IP_Adress);
            }
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            Catchmanager.NetworkClient.Disconnect();
        }

        private void checkBox_Keyboard_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Keyboard.Checked)
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

        private void checkBox_Mouse_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Mouse.Checked)
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

        private void checkBox_Controller_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Controller.Checked)
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

        private void StartForm_Resize(object sender, EventArgs e)
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

        //private void toolStripMenuItem_Connect_Click(object sender, EventArgs e)
        //{
        //    if (NetworkHelper.ValidIPv4(this.textBox_IP.Text))
        //    {
        //        catchmanager.NetworkClient.Connect(this.textBox_IP.Text, Properties.Settings.Default.NetworkPort, System.Net.Dns.GetHostName());
        //    }
        //    else
        //    { 
        //        toolStripMenuItem_Show.PerformClick();
        //        MessageBox.Show("Not a valid IP Adress");
        //    }
        //}

        //private void toolStripMenuItem_Disconnect_Click(object sender, EventArgs e)
        //{
        //    catchmanager.NetworkClient.Disconnect();
        //}

        private void toolStripMenuItem_Quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem_Keyboard_Click(object sender, EventArgs e)
        {
            checkBox_Keyboard.Checked = !checkBox_Keyboard.Checked;
        }

        private void toolStripMenuItem_Mouse_Click(object sender, EventArgs e)
        {
            checkBox_Mouse.Checked = !checkBox_Mouse.Checked;
        }

        private void toolStripMenuItem_Controller_Click(object sender, EventArgs e)
        {
            checkBox_Controller.Checked = !checkBox_Controller.Checked;
        }


        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Catchmanager.NetworkClient.NetworkDiscoveryEvent -= NetworkClient_NetworkDiscoveryEvent;
            Catchmanager.NetworkClient.NetworkEvent -= NetworkClient_NetworkEvent;
            Catchmanager.NetworkClient.DeviceRequestEvent -= NetworkClient_DeviceRequestEvent;

            foreach (IInputHook hook in Catchmanager.InputHooks.ToList())
            {
                Catchmanager.RemoveHook(hook.GetType());

                //this.catchmanager.InputHooks.Single(s => s.GetType() == hook.GetType()).Dispose();

                //this.catchmanager.InputHooks.Remove(this.catchmanager.InputHooks.First(s => s.GetType() == hook.GetType()));
            }

            Catchmanager.NetworkClient.Disconnect();

            Thread.Sleep(500);
        }

        private void comboBox_IPAdresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Catchmanager != null)
            {
                Catchmanager.NetworkClient.NetworkDiscoveryEvent -= NetworkClient_NetworkDiscoveryEvent;
                Catchmanager.NetworkClient.NetworkEvent -= NetworkClient_NetworkEvent;
                Catchmanager.NetworkClient.DeviceRequestEvent -= NetworkClient_DeviceRequestEvent;

                Catchmanager.ChangeNetworkAdapter(NetworkHelper.GetHostIpAdresses()[comboBox_IPAdresses.SelectedIndex]);

                Catchmanager.NetworkClient.NetworkDiscoveryEvent += NetworkClient_NetworkDiscoveryEvent;
                Catchmanager.NetworkClient.NetworkEvent += NetworkClient_NetworkEvent;
                Catchmanager.NetworkClient.DeviceRequestEvent += NetworkClient_DeviceRequestEvent;
            }
        }

        // AUTO CONNECT

        private void AutoConnect()
        {
            // AUTO CONNECT
            if (String.IsNullOrEmpty(textBox_IP.Text))
            {
                _connectondiscovery = true;
                Catchmanager.NetworkClient.DiscoveryRequest(Settings.Default.NetworkPort);
            }
            else if (NetworkHelper.ValidIPv4(textBox_IP.Text))
            {
                _connectfromstored = true;
                button_Connect.Enabled = false;
                button_Connect.Text = Resources.StartForm_Button_Connect_Connecting;
                Catchmanager.NetworkClient.Connect(textBox_IP.Text, Settings.Default.NetworkPort, Dns.GetHostName());
                comboBox_IPAdresses.Enabled = false;
                textBox_IP.Enabled = false;
                button_Discover.Enabled = false;
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
                checkBox_AutoConnect.Checked = false;
                timer_AutoConnect.Enabled = false;
            }
        }

        private void checkBox_AutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AutoConnect.Checked)
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
                //connectfromstored = false;
                //connectondiscovery = false;
            }
        }
    }
}
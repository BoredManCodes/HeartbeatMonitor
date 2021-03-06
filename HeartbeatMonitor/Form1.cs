using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net.Http;

namespace HeartbeatMonitor
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            logTimer.Start();
        }
        private static readonly HttpClient client = new HttpClient();
        private void intervalInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void logTimer_Tick(object sender, EventArgs e)
        {
            logDisplay.Text = File.ReadAllText("log.txt");
            logDisplay.SelectionStart = logDisplay.Text.Length;
            logDisplay.ScrollToCaret();
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            heartbeatTimer.Stop();
            try
            {
                heartbeatTimer.Interval = int.Parse(intervalInput.Text) * 1000;
                heartbeatTimer.Start();
                File.WriteAllText("config.ini", addressInput.Text + ",");
                File.AppendAllText("config.ini", intervalInput.Text);
                File.AppendAllText("log.txt", "Updated config.ini" + Environment.NewLine);
            } catch (Exception ex) when (ex is System.FormatException || ex is System.ArgumentOutOfRangeException)
            {
                intervalInput.Text = "That isn't valid";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            ShowInTaskbar = false;
            e.Cancel = true;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            ShowInTaskbar = true;
        }
        private void quit(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Config", new EventHandler(NotifyIcon_DoubleClick));
            cm.MenuItems.Add("Quit", new EventHandler(quit));
            notifyIcon1.ContextMenu = cm;
        }

        private void Form1_FormShown(object sender, EventArgs e)
        {
            File.WriteAllText("log.txt", "Sucessfully intialised" + Environment.NewLine);
            Boolean configExists = File.Exists("config.ini");
            if (configExists)
            {
                try
                {
                    String config = File.ReadAllText("config.ini");
                    String[] configValues = config.Split(',');
                    File.AppendAllText("log.txt", "Loaded config.ini" + Environment.NewLine);
                    addressInput.Text = configValues[0];
                    intervalInput.Text = configValues[1];
                    bool startup = File.Exists(".startup");
                    if (startup)
                    {
                        startupCheck.Checked = true;
                    } else
                    {
                        startupCheck.Checked = false;
                    }
                    heartbeatTimer.Interval = int.Parse(configValues[1]) * 1000;
                    heartbeatTimer.Start();
                    this.Hide();
                    ShowInTaskbar = false;
                    SetStartup();
                }
                catch (Exception ex) when (ex is System.IndexOutOfRangeException || ex is System.FormatException || ex is System.ArgumentOutOfRangeException)
                {
                    File.AppendAllText("log.txt", "Config found but was unreadable." + Environment.NewLine + "Please configure the address and interval" + Environment.NewLine);
                    this.Show();
                    ShowInTaskbar = true;
                }
            }
            else
            {
                File.AppendAllText("log.txt", "Couldn't find a config" + Environment.NewLine + "Please configure the address and interval" + Environment.NewLine);
                this.Show();
                ShowInTaskbar = true;
            }

        
        }

        private async void heartbeatTimer_Tick(object sender, EventArgs e)
        {
            File.AppendAllText("log.txt", "Sending heartbeat at " + DateTime.Now.ToString("h:mm:ss tt") + Environment.NewLine);
            String config = File.ReadAllText("config.ini");
            String[] configValues = config.Split(',');
            var responseString = await client.GetStringAsync(configValues[0]);
            if (responseString.Contains("true"))
            {
                File.AppendAllText("log.txt", "Heartbeat confirmed received at " + DateTime.Now.ToString("h:mm:ss tt") + Environment.NewLine);
            } else if (responseString.Contains("false"))
            {
                File.AppendAllText("log.txt", "Heartbeat server refused heartbeat at " + DateTime.Now.ToString("h:mm:ss tt") + Environment.NewLine);
            }
        }
        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (startupCheck.Checked)
                rk.SetValue("Heartbeat Monitor", Application.ExecutablePath);
            else
                rk.DeleteValue("Heartbeat Monitor", false);

        }

        private void startupChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (startupCheck.Checked)
            {
                File.WriteAllText(".startup", "exists");
            } else
            {
                File.Delete(".startup");
            }
        }
    }

}

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

        private void logTimer_Tick(object sender, EventArgs e)
        {
            logDisplay.Text = File.ReadAllText("log.txt");
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText("config.ini", addressInput.Text + ",");
            File.AppendAllText("config.ini", intervalInput.Text);
            File.AppendAllText("log.txt", "Updated config.ini" + Environment.NewLine);
            heartbeatTimer.Stop();
            heartbeatTimer.Interval = int.Parse(intervalInput.Text) * 1000;
            heartbeatTimer.Start();
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
                    heartbeatTimer.Interval = int.Parse(configValues[1]) * 1000;
                    heartbeatTimer.Start();
                    this.Hide();
                    ShowInTaskbar = false;
                }
                catch (System.IndexOutOfRangeException)
                {
                    File.AppendAllText("log.txt", "Config found but was unreadable." + Environment.NewLine + "Please configure the address and interval");
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

        private void heartbeatTimer_Tick(object sender, EventArgs e)
        {
            File.AppendAllText("log.txt", "Sent heartbeat at " + DateTime.Now.ToString("h:mm:ss tt") + Environment.NewLine);
        }
    }

}


namespace HeartbeatMonitor
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.addressInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.intervalInput = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.logTimer = new System.Windows.Forms.Timer(this.components);
            this.logDisplay = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.heartbeatTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // addressInput
            // 
            this.addressInput.Location = new System.Drawing.Point(116, 6);
            this.addressInput.Name = "addressInput";
            this.addressInput.Size = new System.Drawing.Size(100, 20);
            this.addressInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Heartbeat Address:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Interval in Seconds:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // intervalInput
            // 
            this.intervalInput.Location = new System.Drawing.Point(116, 35);
            this.intervalInput.Name = "intervalInput";
            this.intervalInput.Size = new System.Drawing.Size(100, 20);
            this.intervalInput.TabIndex = 2;
            this.intervalInput.Text = "300";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(116, 61);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save Config";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log Output:";
            // 
            // logTimer
            // 
            this.logTimer.Interval = 1000;
            this.logTimer.Tick += new System.EventHandler(this.logTimer_Tick);
            // 
            // logDisplay
            // 
            this.logDisplay.Location = new System.Drawing.Point(13, 102);
            this.logDisplay.Multiline = true;
            this.logDisplay.Name = "logDisplay";
            this.logDisplay.ReadOnly = true;
            this.logDisplay.Size = new System.Drawing.Size(201, 221);
            this.logDisplay.TabIndex = 7;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "HeartbeatMonitor";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.NotifyIcon_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // heartbeatTimer
            // 
            this.heartbeatTimer.Tick += new System.EventHandler(this.heartbeatTimer_Tick);
            // 
            // Configuration
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 335);
            this.Controls.Add(this.logDisplay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.intervalInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addressInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Configuration";
            this.Text = "Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_FormShown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addressInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox intervalInput;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer logTimer;
        private System.Windows.Forms.TextBox logDisplay;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer heartbeatTimer;
    }
}


namespace Robot_Client
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.IPBox = new System.Windows.Forms.TextBox();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SSHInfo = new System.Windows.Forms.TextBox();
            this.TraveledDistance = new System.Windows.Forms.TextBox();
            this.Speed = new System.Windows.Forms.TextBox();
            this.PWM = new System.Windows.Forms.TextBox();
            this.SensorReading = new System.Windows.Forms.TextBox();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.WASDKeys = new System.Windows.Forms.Panel();
            this.Right = new System.Windows.Forms.Button();
            this.Reverse = new System.Windows.Forms.Button();
            this.Left = new System.Windows.Forms.Button();
            this.Forward = new System.Windows.Forms.Button();
            this.ManualControl = new System.Windows.Forms.Button();
            this.CarPosition = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.AxisY = new System.Windows.Forms.TextBox();
            this.AxisX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.WASDKeys.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection to RaspberryPi using SSH";
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(408, 167);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(100, 20);
            this.IPBox.TabIndex = 1;
            this.IPBox.Text = "192.168.1.7";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(408, 218);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(100, 20);
            this.UsernameBox.TabIndex = 2;
            this.UsernameBox.Text = "pi";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(408, 274);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '•';
            this.PasswordBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordBox.TabIndex = 3;
            this.PasswordBox.Text = "raspberry";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(267, 382);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(433, 382);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 5;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Passsword";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.TraveledDistance);
            this.panel1.Controls.Add(this.Speed);
            this.panel1.Controls.Add(this.PWM);
            this.panel1.Controls.Add(this.SensorReading);
            this.panel1.Controls.Add(this.DisconnectButton);
            this.panel1.Controls.Add(this.WASDKeys);
            this.panel1.Controls.Add(this.ManualControl);
            this.panel1.Controls.Add(this.CarPosition);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.AxisY);
            this.panel1.Controls.Add(this.AxisX);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.StartButton);
            this.panel1.Controls.Add(this.StopButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 743);
            this.panel1.TabIndex = 9;
            this.panel1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.SSHInfo);
            this.groupBox1.Location = new System.Drawing.Point(7, 600);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 134);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RPi output";
            // 
            // SSHInfo
            // 
            this.SSHInfo.Location = new System.Drawing.Point(5, 19);
            this.SSHInfo.Multiline = true;
            this.SSHInfo.Name = "SSHInfo";
            this.SSHInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SSHInfo.Size = new System.Drawing.Size(820, 109);
            this.SSHInfo.TabIndex = 0;
            // 
            // TraveledDistance
            // 
            this.TraveledDistance.BackColor = System.Drawing.SystemColors.Control;
            this.TraveledDistance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TraveledDistance.Location = new System.Drawing.Point(619, 210);
            this.TraveledDistance.Name = "TraveledDistance";
            this.TraveledDistance.Size = new System.Drawing.Size(224, 13);
            this.TraveledDistance.TabIndex = 19;
            this.TraveledDistance.TabStop = false;
            this.TraveledDistance.Text = "Traveled distance: 0sm";
            // 
            // Speed
            // 
            this.Speed.BackColor = System.Drawing.SystemColors.Control;
            this.Speed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Speed.Location = new System.Drawing.Point(619, 184);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(224, 13);
            this.Speed.TabIndex = 18;
            this.Speed.TabStop = false;
            this.Speed.Text = "Speed: 0sm/s";
            // 
            // PWM
            // 
            this.PWM.BackColor = System.Drawing.SystemColors.Control;
            this.PWM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PWM.Location = new System.Drawing.Point(619, 158);
            this.PWM.Name = "PWM";
            this.PWM.Size = new System.Drawing.Size(224, 13);
            this.PWM.TabIndex = 17;
            this.PWM.TabStop = false;
            this.PWM.Text = "PWM: 0%";
            // 
            // SensorReading
            // 
            this.SensorReading.BackColor = System.Drawing.SystemColors.Control;
            this.SensorReading.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SensorReading.Location = new System.Drawing.Point(619, 132);
            this.SensorReading.Name = "SensorReading";
            this.SensorReading.Size = new System.Drawing.Size(224, 13);
            this.SensorReading.TabIndex = 16;
            this.SensorReading.TabStop = false;
            this.SensorReading.Text = "Distance forward: 0sm";
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(694, 271);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButton.TabIndex = 14;
            this.DisconnectButton.Text = "Dsiconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            // 
            // WASDKeys
            // 
            this.WASDKeys.Controls.Add(this.Right);
            this.WASDKeys.Controls.Add(this.Reverse);
            this.WASDKeys.Controls.Add(this.Left);
            this.WASDKeys.Controls.Add(this.Forward);
            this.WASDKeys.Location = new System.Drawing.Point(658, 384);
            this.WASDKeys.Name = "WASDKeys";
            this.WASDKeys.Size = new System.Drawing.Size(141, 107);
            this.WASDKeys.TabIndex = 13;
            this.WASDKeys.Visible = false;
            // 
            // Right
            // 
            this.Right.Enabled = false;
            this.Right.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Right.Location = new System.Drawing.Point(95, 56);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(38, 38);
            this.Right.TabIndex = 3;
            this.Right.Text = "D";
            this.Right.UseVisualStyleBackColor = true;
            // 
            // Reverse
            // 
            this.Reverse.Enabled = false;
            this.Reverse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Reverse.Location = new System.Drawing.Point(52, 56);
            this.Reverse.Name = "Reverse";
            this.Reverse.Size = new System.Drawing.Size(38, 38);
            this.Reverse.TabIndex = 2;
            this.Reverse.Text = "S";
            this.Reverse.UseVisualStyleBackColor = true;
            // 
            // Left
            // 
            this.Left.Enabled = false;
            this.Left.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Left.Location = new System.Drawing.Point(8, 56);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(38, 38);
            this.Left.TabIndex = 1;
            this.Left.Text = "A";
            this.Left.UseVisualStyleBackColor = true;
            // 
            // Forward
            // 
            this.Forward.BackColor = System.Drawing.SystemColors.Control;
            this.Forward.Enabled = false;
            this.Forward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Forward.Location = new System.Drawing.Point(52, 12);
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(38, 38);
            this.Forward.TabIndex = 0;
            this.Forward.Text = "W";
            this.Forward.UseVisualStyleBackColor = false;
            // 
            // ManualControl
            // 
            this.ManualControl.Location = new System.Drawing.Point(680, 513);
            this.ManualControl.Name = "ManualControl";
            this.ManualControl.Size = new System.Drawing.Size(97, 39);
            this.ManualControl.TabIndex = 12;
            this.ManualControl.Text = "Manual control";
            this.ManualControl.UseVisualStyleBackColor = true;
            this.ManualControl.Click += new System.EventHandler(this.ManualControl_Click);
            this.ManualControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ManualControl_MouseClick);
            // 
            // CarPosition
            // 
            this.CarPosition.BackColor = System.Drawing.Color.White;
            this.CarPosition.Location = new System.Drawing.Point(3, 3);
            this.CarPosition.Name = "CarPosition";
            this.CarPosition.Size = new System.Drawing.Size(610, 588);
            this.CarPosition.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(677, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "goal COORDINATES";
            // 
            // AxisY
            // 
            this.AxisY.Location = new System.Drawing.Point(702, 85);
            this.AxisY.Name = "AxisY";
            this.AxisY.Size = new System.Drawing.Size(100, 20);
            this.AxisY.TabIndex = 2;
            // 
            // AxisX
            // 
            this.AxisX.Location = new System.Drawing.Point(702, 50);
            this.AxisX.Name = "AxisX";
            this.AxisX.Size = new System.Drawing.Size(100, 20);
            this.AxisX.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(660, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Axis Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(660, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Axis X";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(743, 558);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 2;
            this.StartButton.TabStop = false;
            this.StartButton.Text = "Go";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(642, 558);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 0;
            this.StopButton.Text = "Close";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 743);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.WASDKeys.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox AxisY;
        private System.Windows.Forms.TextBox AxisX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel CarPosition;
        private System.Windows.Forms.Button ManualControl;
        private System.Windows.Forms.Panel WASDKeys;
        private System.Windows.Forms.Button Right;
        private System.Windows.Forms.Button Reverse;
        private System.Windows.Forms.Button Left;
        private System.Windows.Forms.Button Forward;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.TextBox SSHInfo;
        private System.Windows.Forms.TextBox SensorReading;
        private System.Windows.Forms.TextBox TraveledDistance;
        private System.Windows.Forms.TextBox Speed;
        private System.Windows.Forms.TextBox PWM;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}


namespace GPS_Out
{
    partial class frmStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbLon = new System.Windows.Forms.Label();
            this.lbLat = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.lbQuality = new System.Windows.Forms.Label();
            this.lbAge = new System.Windows.Forms.Label();
            this.lbElev = new System.Windows.Forms.Label();
            this.lbSats = new System.Windows.Forms.Label();
            this.lbHDOP = new System.Windows.Forms.Label();
            this.lbYawRate = new System.Windows.Forms.Label();
            this.lbPitch = new System.Windows.Forms.Label();
            this.lbRoll = new System.Windows.Forms.Label();
            this.lbYaw = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnConnect1 = new System.Windows.Forms.Button();
            this.cboPort1 = new System.Windows.Forms.ComboBox();
            this.lbBaud = new System.Windows.Forms.Label();
            this.cboBaud1 = new System.Windows.Forms.ComboBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.PortIndicator1 = new System.Windows.Forms.Label();
            this.btnRescan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tmrGGA = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboGGA = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cboVTG = new System.Windows.Forms.ComboBox();
            this.tmrVTG = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quality";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "HDOP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(344, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sats";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(344, 57);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Elev";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(344, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 24);
            this.label8.TabIndex = 7;
            this.label8.Text = "Age";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 129);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 24);
            this.label12.TabIndex = 11;
            this.label12.Text = "Yaw";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(344, 129);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 24);
            this.label13.TabIndex = 12;
            this.label13.Text = "Roll";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(344, 153);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 24);
            this.label14.TabIndex = 13;
            this.label14.Text = "Pitch";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 153);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 24);
            this.label15.TabIndex = 14;
            this.label15.Text = "Yaw Rate";
            // 
            // lbLon
            // 
            this.lbLon.AutoSize = true;
            this.lbLon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLon.Location = new System.Drawing.Point(106, 9);
            this.lbLon.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbLon.Name = "lbLon";
            this.lbLon.Size = new System.Drawing.Size(126, 24);
            this.lbLon.TabIndex = 15;
            this.lbLon.Text = "1234567890.";
            // 
            // lbLat
            // 
            this.lbLat.AutoSize = true;
            this.lbLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLat.Location = new System.Drawing.Point(106, 33);
            this.lbLat.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbLat.Name = "lbLat";
            this.lbLat.Size = new System.Drawing.Size(126, 24);
            this.lbLat.TabIndex = 16;
            this.lbLat.Text = "1234567890.";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeed.Location = new System.Drawing.Point(106, 57);
            this.lbSpeed.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(126, 24);
            this.lbSpeed.TabIndex = 17;
            this.lbSpeed.Text = "1234567890.";
            // 
            // lbQuality
            // 
            this.lbQuality.AutoSize = true;
            this.lbQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuality.Location = new System.Drawing.Point(106, 81);
            this.lbQuality.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbQuality.Name = "lbQuality";
            this.lbQuality.Size = new System.Drawing.Size(126, 24);
            this.lbQuality.TabIndex = 18;
            this.lbQuality.Text = "1234567890.";
            // 
            // lbAge
            // 
            this.lbAge.AutoSize = true;
            this.lbAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAge.Location = new System.Drawing.Point(445, 81);
            this.lbAge.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(126, 24);
            this.lbAge.TabIndex = 22;
            this.lbAge.Text = "1234567890.";
            // 
            // lbElev
            // 
            this.lbElev.AutoSize = true;
            this.lbElev.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbElev.Location = new System.Drawing.Point(445, 57);
            this.lbElev.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbElev.Name = "lbElev";
            this.lbElev.Size = new System.Drawing.Size(126, 24);
            this.lbElev.TabIndex = 21;
            this.lbElev.Text = "1234567890.";
            // 
            // lbSats
            // 
            this.lbSats.AutoSize = true;
            this.lbSats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSats.Location = new System.Drawing.Point(445, 33);
            this.lbSats.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbSats.Name = "lbSats";
            this.lbSats.Size = new System.Drawing.Size(126, 24);
            this.lbSats.TabIndex = 20;
            this.lbSats.Text = "1234567890.";
            // 
            // lbHDOP
            // 
            this.lbHDOP.AutoSize = true;
            this.lbHDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHDOP.Location = new System.Drawing.Point(445, 9);
            this.lbHDOP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbHDOP.Name = "lbHDOP";
            this.lbHDOP.Size = new System.Drawing.Size(126, 24);
            this.lbHDOP.TabIndex = 19;
            this.lbHDOP.Text = "1234567890.";
            // 
            // lbYawRate
            // 
            this.lbYawRate.AutoSize = true;
            this.lbYawRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYawRate.Location = new System.Drawing.Point(116, 153);
            this.lbYawRate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbYawRate.Name = "lbYawRate";
            this.lbYawRate.Size = new System.Drawing.Size(126, 24);
            this.lbYawRate.TabIndex = 29;
            this.lbYawRate.Text = "1234567890.";
            // 
            // lbPitch
            // 
            this.lbPitch.AutoSize = true;
            this.lbPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPitch.Location = new System.Drawing.Point(445, 153);
            this.lbPitch.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbPitch.Name = "lbPitch";
            this.lbPitch.Size = new System.Drawing.Size(126, 24);
            this.lbPitch.TabIndex = 28;
            this.lbPitch.Text = "1234567890.";
            // 
            // lbRoll
            // 
            this.lbRoll.AutoSize = true;
            this.lbRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRoll.Location = new System.Drawing.Point(445, 129);
            this.lbRoll.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbRoll.Name = "lbRoll";
            this.lbRoll.Size = new System.Drawing.Size(126, 24);
            this.lbRoll.TabIndex = 27;
            this.lbRoll.Text = "1234567890.";
            // 
            // lbYaw
            // 
            this.lbYaw.AutoSize = true;
            this.lbYaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYaw.Location = new System.Drawing.Point(116, 129);
            this.lbYaw.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbYaw.Name = "lbYaw";
            this.lbYaw.Size = new System.Drawing.Size(126, 24);
            this.lbYaw.TabIndex = 26;
            this.lbYaw.Text = "1234567890.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 39);
            this.button1.TabIndex = 30;
            this.button1.Text = "GGA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(249, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 39);
            this.button2.TabIndex = 31;
            this.button2.Text = "VTG";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnConnect1
            // 
            this.btnConnect1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnConnect1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConnect1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect1.Location = new System.Drawing.Point(16, 47);
            this.btnConnect1.Name = "btnConnect1";
            this.btnConnect1.Size = new System.Drawing.Size(127, 37);
            this.btnConnect1.TabIndex = 128;
            this.btnConnect1.Text = "Connect";
            this.btnConnect1.UseVisualStyleBackColor = false;
            this.btnConnect1.Click += new System.EventHandler(this.btnConnect1_Click);
            // 
            // cboPort1
            // 
            this.cboPort1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboPort1.FormattingEnabled = true;
            this.cboPort1.Location = new System.Drawing.Point(149, 47);
            this.cboPort1.Name = "cboPort1";
            this.cboPort1.Size = new System.Drawing.Size(127, 37);
            this.cboPort1.TabIndex = 127;
            this.cboPort1.SelectedIndexChanged += new System.EventHandler(this.cboPort1_SelectedIndexChanged);
            // 
            // lbBaud
            // 
            this.lbBaud.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBaud.Location = new System.Drawing.Point(282, 20);
            this.lbBaud.Name = "lbBaud";
            this.lbBaud.Size = new System.Drawing.Size(127, 23);
            this.lbBaud.TabIndex = 131;
            this.lbBaud.Text = "Baud";
            this.lbBaud.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboBaud1
            // 
            this.cboBaud1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboBaud1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaud1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboBaud1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboBaud1.FormattingEnabled = true;
            this.cboBaud1.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cboBaud1.Location = new System.Drawing.Point(282, 47);
            this.cboBaud1.Name = "cboBaud1";
            this.cboBaud1.Size = new System.Drawing.Size(127, 37);
            this.cboBaud1.TabIndex = 130;
            this.cboBaud1.SelectedIndexChanged += new System.EventHandler(this.cboBaud1_SelectedIndexChanged);
            // 
            // lbPort
            // 
            this.lbPort.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPort.Location = new System.Drawing.Point(149, 20);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(127, 23);
            this.lbPort.TabIndex = 126;
            this.lbPort.Text = "Port";
            this.lbPort.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PortIndicator1
            // 
            this.PortIndicator1.BackColor = System.Drawing.SystemColors.Control;
            this.PortIndicator1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortIndicator1.Image = global::GPS_Out.Properties.Resources.Off;
            this.PortIndicator1.Location = new System.Drawing.Point(424, 48);
            this.PortIndicator1.Name = "PortIndicator1";
            this.PortIndicator1.Size = new System.Drawing.Size(41, 37);
            this.PortIndicator1.TabIndex = 129;
            this.PortIndicator1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRescan
            // 
            this.btnRescan.BackColor = System.Drawing.Color.Transparent;
            this.btnRescan.FlatAppearance.BorderSize = 0;
            this.btnRescan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRescan.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRescan.Image = global::GPS_Out.Properties.Resources.Update;
            this.btnRescan.Location = new System.Drawing.Point(471, 28);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(72, 72);
            this.btnRescan.TabIndex = 151;
            this.btnRescan.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRescan.UseVisualStyleBackColor = false;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PortIndicator1);
            this.groupBox1.Controls.Add(this.btnRescan);
            this.groupBox1.Controls.Add(this.lbPort);
            this.groupBox1.Controls.Add(this.btnConnect1);
            this.groupBox1.Controls.Add(this.cboBaud1);
            this.groupBox1.Controls.Add(this.cboPort1);
            this.groupBox1.Controls.Add(this.lbBaud);
            this.groupBox1.Location = new System.Drawing.Point(12, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 116);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // tmrGGA
            // 
            this.tmrGGA.Interval = 5000;
            this.tmrGGA.Tick += new System.EventHandler(this.tmrGGA_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 36);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 24);
            this.label9.TabIndex = 153;
            this.label9.Text = "GGA";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.cboVTG);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cboGGA);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 322);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 131);
            this.groupBox2.TabIndex = 154;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transfer Rate";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(135, 79);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 24);
            this.label10.TabIndex = 154;
            this.label10.Text = "VTG";
            // 
            // cboGGA
            // 
            this.cboGGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGGA.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboGGA.FormattingEnabled = true;
            this.cboGGA.Items.AddRange(new object[] {
            "1",
            "5",
            "10"});
            this.cboGGA.Location = new System.Drawing.Point(195, 28);
            this.cboGGA.Name = "cboGGA";
            this.cboGGA.Size = new System.Drawing.Size(60, 37);
            this.cboGGA.TabIndex = 155;
            this.cboGGA.SelectedIndexChanged += new System.EventHandler(this.cboGGA_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(264, 36);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 24);
            this.label11.TabIndex = 156;
            this.label11.Text = "Hz";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(264, 79);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 24);
            this.label16.TabIndex = 158;
            this.label16.Text = "Hz";
            // 
            // cboVTG
            // 
            this.cboVTG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVTG.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboVTG.FormattingEnabled = true;
            this.cboVTG.Items.AddRange(new object[] {
            "1",
            "5",
            "10"});
            this.cboVTG.Location = new System.Drawing.Point(195, 71);
            this.cboVTG.Name = "cboVTG";
            this.cboVTG.Size = new System.Drawing.Size(60, 37);
            this.cboVTG.TabIndex = 157;
            this.cboVTG.SelectedIndexChanged += new System.EventHandler(this.cboVTG_SelectedIndexChanged);
            // 
            // tmrVTG
            // 
            this.tmrVTG.Tick += new System.EventHandler(this.tmrVTG_Tick);
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 467);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbYawRate);
            this.Controls.Add(this.lbPitch);
            this.Controls.Add(this.lbRoll);
            this.Controls.Add(this.lbYaw);
            this.Controls.Add(this.lbAge);
            this.Controls.Add(this.lbElev);
            this.Controls.Add(this.lbSats);
            this.Controls.Add(this.lbHDOP);
            this.Controls.Add(this.lbQuality);
            this.Controls.Add(this.lbSpeed);
            this.Controls.Add(this.lbLat);
            this.Controls.Add(this.lbLon);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "frmStart";
            this.Text = "GPS_Out";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStart_FormClosed);
            this.Load += new System.EventHandler(this.frmStart_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbLon;
        private System.Windows.Forms.Label lbLat;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label lbQuality;
        private System.Windows.Forms.Label lbAge;
        private System.Windows.Forms.Label lbElev;
        private System.Windows.Forms.Label lbSats;
        private System.Windows.Forms.Label lbHDOP;
        private System.Windows.Forms.Label lbYawRate;
        private System.Windows.Forms.Label lbPitch;
        private System.Windows.Forms.Label lbRoll;
        private System.Windows.Forms.Label lbYaw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnConnect1;
        private System.Windows.Forms.ComboBox cboPort1;
        private System.Windows.Forms.Label lbBaud;
        private System.Windows.Forms.ComboBox cboBaud1;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label PortIndicator1;
        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer tmrGGA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboVTG;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboGGA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer tmrVTG;
    }
}


namespace SoundSimulatorGUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtComPort = new System.Windows.Forms.TextBox();
            this.txtFreq1 = new System.Windows.Forms.TextBox();
            this.txtAmp1 = new System.Windows.Forms.TextBox();
            this.txtFreq2 = new System.Windows.Forms.TextBox();
            this.txtAmp2 = new System.Windows.Forms.TextBox();
            this.txtFreq3 = new System.Windows.Forms.TextBox();
            this.txtAmp3 = new System.Windows.Forms.TextBox();
            this.txtNoise = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBaudRate = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtComPort
            // 
            this.txtComPort.Location = new System.Drawing.Point(100, 10);
            this.txtComPort.Name = "txtComPort";
            this.txtComPort.Size = new System.Drawing.Size(100, 20);
            this.txtComPort.TabIndex = 0;
            this.txtComPort.Text = "COM5";
            // 
            // txtFreq1
            // 
            this.txtFreq1.Location = new System.Drawing.Point(102, 95);
            this.txtFreq1.Name = "txtFreq1";
            this.txtFreq1.Size = new System.Drawing.Size(100, 20);
            this.txtFreq1.TabIndex = 1;
            this.txtFreq1.Text = "440";
            // 
            // txtAmp1
            // 
            this.txtAmp1.Location = new System.Drawing.Point(202, 95);
            this.txtAmp1.Name = "txtAmp1";
            this.txtAmp1.Size = new System.Drawing.Size(100, 20);
            this.txtAmp1.TabIndex = 2;
            this.txtAmp1.Text = "1,0";
            // 
            // txtFreq2
            // 
            this.txtFreq2.Location = new System.Drawing.Point(102, 125);
            this.txtFreq2.Name = "txtFreq2";
            this.txtFreq2.Size = new System.Drawing.Size(100, 20);
            this.txtFreq2.TabIndex = 3;
            this.txtFreq2.Text = "880";
            // 
            // txtAmp2
            // 
            this.txtAmp2.Location = new System.Drawing.Point(202, 125);
            this.txtAmp2.Name = "txtAmp2";
            this.txtAmp2.Size = new System.Drawing.Size(100, 20);
            this.txtAmp2.TabIndex = 4;
            this.txtAmp2.Text = "0,5";
            // 
            // txtFreq3
            // 
            this.txtFreq3.Location = new System.Drawing.Point(102, 155);
            this.txtFreq3.Name = "txtFreq3";
            this.txtFreq3.Size = new System.Drawing.Size(100, 20);
            this.txtFreq3.TabIndex = 5;
            this.txtFreq3.Text = "1760";
            // 
            // txtAmp3
            // 
            this.txtAmp3.Location = new System.Drawing.Point(202, 155);
            this.txtAmp3.Name = "txtAmp3";
            this.txtAmp3.Size = new System.Drawing.Size(100, 20);
            this.txtAmp3.TabIndex = 6;
            this.txtAmp3.Text = "0,3";
            // 
            // txtNoise
            // 
            this.txtNoise.Location = new System.Drawing.Point(102, 185);
            this.txtNoise.Name = "txtNoise";
            this.txtNoise.Size = new System.Drawing.Size(100, 20);
            this.txtNoise.TabIndex = 7;
            this.txtNoise.Text = "0,1";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(102, 215);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(202, 215);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 255);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(300, 23);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Neaktivní";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Sine 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Sine 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sine 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Noise";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Frequency";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Amplitude";
            // 
            // comboBaudRate
            // 
            this.comboBaudRate.FormattingEnabled = true;
            this.comboBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400"});
            this.comboBaudRate.Location = new System.Drawing.Point(102, 37);
            this.comboBaudRate.Name = "comboBaudRate";
            this.comboBaudRate.Size = new System.Drawing.Size(121, 21);
            this.comboBaudRate.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "COM port";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Baud Rate";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(350, 287);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBaudRate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComPort);
            this.Controls.Add(this.txtFreq1);
            this.Controls.Add(this.txtAmp1);
            this.Controls.Add(this.txtFreq2);
            this.Controls.Add(this.txtAmp2);
            this.Controls.Add(this.txtFreq3);
            this.Controls.Add(this.txtAmp3);
            this.Controls.Add(this.txtNoise);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblStatus);
            this.Name = "Form1";
            this.Text = "Zvukový signál – simulátor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtComPort;
        private System.Windows.Forms.TextBox txtFreq1;
        private System.Windows.Forms.TextBox txtAmp1;
        private System.Windows.Forms.TextBox txtFreq2;
        private System.Windows.Forms.TextBox txtAmp2;
        private System.Windows.Forms.TextBox txtFreq3;
        private System.Windows.Forms.TextBox txtAmp3;
        private System.Windows.Forms.TextBox txtNoise;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBaudRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
    }
}

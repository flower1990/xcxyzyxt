namespace ComputerExam.StepWizard
{
    partial class frmSetServiceAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetServiceAddress));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFtpTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFtp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnServiceTest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picExam = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.cbAnonymous = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 274);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Location = new System.Drawing.Point(12, 239);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 30);
            this.panel2.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(300, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAnonymous);
            this.groupBox2.Controls.Add(this.btnFtpTest);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtUserName);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtFtp);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 132);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "题库地址";
            // 
            // btnFtpTest
            // 
            this.btnFtpTest.BackColor = System.Drawing.Color.Transparent;
            this.btnFtpTest.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFtpTest.BackgroundImage")));
            this.btnFtpTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFtpTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFtpTest.FlatAppearance.BorderSize = 0;
            this.btnFtpTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFtpTest.Location = new System.Drawing.Point(255, 80);
            this.btnFtpTest.Name = "btnFtpTest";
            this.btnFtpTest.Size = new System.Drawing.Size(83, 23);
            this.btnFtpTest.TabIndex = 4;
            this.btnFtpTest.UseVisualStyleBackColor = false;
            this.btnFtpTest.Click += new System.EventHandler(this.btnFtpTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "服 务 器：";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(99, 55);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(150, 21);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.Text = "liuh";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(98, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(150, 21);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "liuh";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(302, 28);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(36, 21);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "21";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(27, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "密    码：";
            // 
            // txtFtp
            // 
            this.txtFtp.Location = new System.Drawing.Point(99, 28);
            this.txtFtp.Name = "txtFtp";
            this.txtFtp.Size = new System.Drawing.Size(150, 21);
            this.txtFtp.TabIndex = 0;
            this.txtFtp.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(255, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "端口：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(27, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "用 户 名：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnServiceTest);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务地址";
            // 
            // btnServiceTest
            // 
            this.btnServiceTest.BackColor = System.Drawing.Color.Transparent;
            this.btnServiceTest.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnServiceTest.BackgroundImage")));
            this.btnServiceTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnServiceTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServiceTest.FlatAppearance.BorderSize = 0;
            this.btnServiceTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceTest.Location = new System.Drawing.Point(255, 25);
            this.btnServiceTest.Name = "btnServiceTest";
            this.btnServiceTest.Size = new System.Drawing.Size(83, 23);
            this.btnServiceTest.TabIndex = 1;
            this.btnServiceTest.UseVisualStyleBackColor = false;
            this.btnServiceTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(27, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "服 务 器：";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(98, 27);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(151, 21);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "127.0.0.1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.picExam);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.picClose);
            this.panel3.Location = new System.Drawing.Point(0, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 22);
            this.panel3.TabIndex = 0;
            // 
            // picExam
            // 
            this.picExam.Location = new System.Drawing.Point(5, 3);
            this.picExam.Name = "picExam";
            this.picExam.Size = new System.Drawing.Size(16, 16);
            this.picExam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picExam.TabIndex = 27;
            this.picExam.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "设置服务地址";
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Location = new System.Drawing.Point(391, 1);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(16, 16);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picClose.TabIndex = 20;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // cbAnonymous
            // 
            this.cbAnonymous.AutoSize = true;
            this.cbAnonymous.Location = new System.Drawing.Point(257, 57);
            this.cbAnonymous.Name = "cbAnonymous";
            this.cbAnonymous.Size = new System.Drawing.Size(48, 16);
            this.cbAnonymous.TabIndex = 8;
            this.cbAnonymous.Text = "匿名";
            this.cbAnonymous.UseVisualStyleBackColor = true;
            // 
            // frmSetServiceAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(410, 274);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetServiceAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSetServiceAddress";
            this.Load += new System.EventHandler(this.frmSetServiceAddress_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picExam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnServiceTest;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFtp;
        private System.Windows.Forms.Button btnFtpTest;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbAnonymous;

    }
}
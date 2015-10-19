namespace ComputerExam.BusicWork
{
    partial class frmExercise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExercise));
            this.btnZuJuan = new System.Windows.Forms.Button();
            this.lbTaoJuan = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSubject = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpPaperInfo = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPaperType = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDownDB = new System.Windows.Forms.Button();
            this.btnAddDb = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoExam = new System.Windows.Forms.RadioButton();
            this.rdoExercise = new System.Windows.Forms.RadioButton();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.grpPaperInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnZuJuan
            // 
            this.btnZuJuan.Location = new System.Drawing.Point(416, 26);
            this.btnZuJuan.Name = "btnZuJuan";
            this.btnZuJuan.Size = new System.Drawing.Size(75, 23);
            this.btnZuJuan.TabIndex = 10;
            this.btnZuJuan.Text = "开始组卷";
            this.btnZuJuan.UseVisualStyleBackColor = true;
            this.btnZuJuan.Click += new System.EventHandler(this.btnZuJuan_Click);
            // 
            // lbTaoJuan
            // 
            this.lbTaoJuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTaoJuan.FormattingEnabled = true;
            this.lbTaoJuan.ItemHeight = 12;
            this.lbTaoJuan.Location = new System.Drawing.Point(3, 17);
            this.lbTaoJuan.Name = "lbTaoJuan";
            this.lbTaoJuan.Size = new System.Drawing.Size(795, 136);
            this.lbTaoJuan.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "练习科目：";
            // 
            // cboSubject
            // 
            this.cboSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubject.FormattingEnabled = true;
            this.cboSubject.Location = new System.Drawing.Point(110, 27);
            this.cboSubject.Name = "cboSubject";
            this.cboSubject.Size = new System.Drawing.Size(300, 20);
            this.cboSubject.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.grpPaperInfo);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 540);
            this.panel1.TabIndex = 11;
            // 
            // grpPaperInfo
            // 
            this.grpPaperInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPaperInfo.Controls.Add(this.lbTaoJuan);
            this.grpPaperInfo.Location = new System.Drawing.Point(12, 372);
            this.grpPaperInfo.Name = "grpPaperInfo";
            this.grpPaperInfo.Size = new System.Drawing.Size(801, 156);
            this.grpPaperInfo.TabIndex = 13;
            this.grpPaperInfo.TabStop = false;
            this.grpPaperInfo.Text = "固定套卷";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblPaperType);
            this.groupBox2.Location = new System.Drawing.Point(12, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(801, 111);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "多多了解";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(341, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "模拟练习：不作时间限制，可随时查看答案，并可进行多次评分";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "正式考试：完全模拟正式考试，只能评分一次";
            // 
            // lblPaperType
            // 
            this.lblPaperType.AutoSize = true;
            this.lblPaperType.Location = new System.Drawing.Point(39, 81);
            this.lblPaperType.Name = "lblPaperType";
            this.lblPaperType.Size = new System.Drawing.Size(197, 12);
            this.lblPaperType.TabIndex = 14;
            this.lblPaperType.Text = "固定套卷：按固定模式组成一套试卷";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnZuJuan);
            this.groupBox3.Controls.Add(this.cboSubject);
            this.groupBox3.Location = new System.Drawing.Point(12, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(801, 75);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择科目";
            // 
            // btnDownDB
            // 
            this.btnDownDB.Location = new System.Drawing.Point(122, 26);
            this.btnDownDB.Name = "btnDownDB";
            this.btnDownDB.Size = new System.Drawing.Size(75, 23);
            this.btnDownDB.TabIndex = 10;
            this.btnDownDB.Text = "题库下载";
            this.btnDownDB.UseVisualStyleBackColor = true;
            this.btnDownDB.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnAddDb
            // 
            this.btnAddDb.Location = new System.Drawing.Point(41, 26);
            this.btnAddDb.Name = "btnAddDb";
            this.btnAddDb.Size = new System.Drawing.Size(75, 23);
            this.btnAddDb.TabIndex = 10;
            this.btnAddDb.Text = "题库维护";
            this.btnAddDb.UseVisualStyleBackColor = true;
            this.btnAddDb.Click += new System.EventHandler(this.btnAddDb_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdoExam);
            this.groupBox1.Controls.Add(this.rdoExercise);
            this.groupBox1.Location = new System.Drawing.Point(12, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 75);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "学习模式";
            // 
            // rdoExam
            // 
            this.rdoExam.AutoSize = true;
            this.rdoExam.Location = new System.Drawing.Point(118, 29);
            this.rdoExam.Name = "rdoExam";
            this.rdoExam.Size = new System.Drawing.Size(71, 16);
            this.rdoExam.TabIndex = 0;
            this.rdoExam.TabStop = true;
            this.rdoExam.Text = "正式考试";
            this.rdoExam.UseVisualStyleBackColor = true;
            // 
            // rdoExercise
            // 
            this.rdoExercise.AutoSize = true;
            this.rdoExercise.Checked = true;
            this.rdoExercise.Location = new System.Drawing.Point(41, 29);
            this.rdoExercise.Name = "rdoExercise";
            this.rdoExercise.Size = new System.Drawing.Size(71, 16);
            this.rdoExercise.TabIndex = 0;
            this.rdoExercise.TabStop = true;
            this.rdoExercise.Text = "模拟练习";
            this.rdoExercise.UseVisualStyleBackColor = true;
            // 
            // ofdOpen
            // 
            this.ofdOpen.FileName = "openFileDialog1";
            this.ofdOpen.Filter = "所有文件|*.*";
            this.ofdOpen.Title = "添加题库";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnAddDb);
            this.groupBox4.Controls.Add(this.btnDownDB);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(801, 75);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "题库维护";
            // 
            // frmExercise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(825, 540);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExercise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "课前练习";
            this.Load += new System.EventHandler(this.frmExercise_Load);
            this.panel1.ResumeLayout(false);
            this.grpPaperInfo.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnZuJuan;
        private System.Windows.Forms.ListBox lbTaoJuan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSubject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoExam;
        private System.Windows.Forms.RadioButton rdoExercise;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddDb;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
        private System.Windows.Forms.Label lblPaperType;
        private System.Windows.Forms.GroupBox grpPaperInfo;
        private System.Windows.Forms.Button btnDownDB;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}
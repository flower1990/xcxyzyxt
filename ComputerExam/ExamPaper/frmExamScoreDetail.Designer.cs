namespace ComputerExam.ExamPaper
{
    partial class frmExamScoreDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamScoreDetail));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblExamScore = new System.Windows.Forms.Label();
            this.lblExamSubject = new System.Windows.Forms.Label();
            this.lblPaperScore = new System.Windows.Forms.Label();
            this.lblTicketNumber = new System.Windows.Forms.Label();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblExamTime = new System.Windows.Forms.Label();
            this.lblUseTime = new System.Windows.Forms.Label();
            this.lblExamComputer = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 500);
            this.panel1.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(584, 41);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 27);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出系统";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblExamComputer);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblUseTime);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblExamTime);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblStudentName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblTicketNumber);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblPaperScore);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblExamScore);
            this.panel2.Controls.Add(this.lblExamSubject);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(40, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 351);
            this.panel2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "考试科目与考生信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "-----------------------------------------------------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "考试科目：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "试卷分值：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "考生姓名：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "准考证号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "考试时长：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "实际用时：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "考试用机：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(386, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "本场考试得分：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(386, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(215, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "-----------------------------------";
            // 
            // lblExamScore
            // 
            this.lblExamScore.AutoSize = true;
            this.lblExamScore.Font = new System.Drawing.Font("宋体", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblExamScore.Location = new System.Drawing.Point(387, 87);
            this.lblExamScore.Name = "lblExamScore";
            this.lblExamScore.Size = new System.Drawing.Size(125, 133);
            this.lblExamScore.TabIndex = 11;
            this.lblExamScore.Text = "0";
            // 
            // lblExamSubject
            // 
            this.lblExamSubject.AutoSize = true;
            this.lblExamSubject.Location = new System.Drawing.Point(109, 87);
            this.lblExamSubject.Name = "lblExamSubject";
            this.lblExamSubject.Size = new System.Drawing.Size(11, 12);
            this.lblExamSubject.TabIndex = 11;
            this.lblExamSubject.Text = "0";
            // 
            // lblPaperScore
            // 
            this.lblPaperScore.AutoSize = true;
            this.lblPaperScore.Location = new System.Drawing.Point(109, 117);
            this.lblPaperScore.Name = "lblPaperScore";
            this.lblPaperScore.Size = new System.Drawing.Size(11, 12);
            this.lblPaperScore.TabIndex = 11;
            this.lblPaperScore.Text = "0";
            // 
            // lblTicketNumber
            // 
            this.lblTicketNumber.AutoSize = true;
            this.lblTicketNumber.Location = new System.Drawing.Point(109, 177);
            this.lblTicketNumber.Name = "lblTicketNumber";
            this.lblTicketNumber.Size = new System.Drawing.Size(11, 12);
            this.lblTicketNumber.TabIndex = 11;
            this.lblTicketNumber.Text = "0";
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Location = new System.Drawing.Point(109, 147);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(11, 12);
            this.lblStudentName.TabIndex = 11;
            this.lblStudentName.Text = "0";
            // 
            // lblExamTime
            // 
            this.lblExamTime.AutoSize = true;
            this.lblExamTime.Location = new System.Drawing.Point(109, 207);
            this.lblExamTime.Name = "lblExamTime";
            this.lblExamTime.Size = new System.Drawing.Size(11, 12);
            this.lblExamTime.TabIndex = 11;
            this.lblExamTime.Text = "0";
            // 
            // lblUseTime
            // 
            this.lblUseTime.AutoSize = true;
            this.lblUseTime.Location = new System.Drawing.Point(109, 237);
            this.lblUseTime.Name = "lblUseTime";
            this.lblUseTime.Size = new System.Drawing.Size(11, 12);
            this.lblUseTime.TabIndex = 11;
            this.lblUseTime.Text = "0";
            // 
            // lblExamComputer
            // 
            this.lblExamComputer.AutoSize = true;
            this.lblExamComputer.Location = new System.Drawing.Point(109, 267);
            this.lblExamComputer.Name = "lblExamComputer";
            this.lblExamComputer.Size = new System.Drawing.Size(11, 12);
            this.lblExamComputer.TabIndex = 11;
            this.lblExamComputer.Text = "0";
            // 
            // frmExamScoreDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmExamScoreDetail";
            this.Text = "frmExamScoreDetail";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblExamScore;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblExamComputer;
        private System.Windows.Forms.Label lblUseTime;
        private System.Windows.Forms.Label lblExamTime;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblTicketNumber;
        private System.Windows.Forms.Label lblPaperScore;
        private System.Windows.Forms.Label lblExamSubject;
    }
}
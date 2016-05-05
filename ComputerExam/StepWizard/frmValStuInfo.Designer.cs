namespace ComputerExam.StepWizard
{
    partial class frmValStuInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValStuInfo));
            this.pnlBackground = new ComputerExam.Common.BackgroundPanel();
            this.btnExitSystem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLastStep = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblExamMode = new System.Windows.Forms.Label();
            this.lblStuName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblExamSubject = new System.Windows.Forms.Label();
            this.lblTicketNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBackground.BackColor = System.Drawing.Color.Transparent;
            this.pnlBackground.BackgroundImage = global::ComputerExam.Properties.Resources.bg_exam;
            this.pnlBackground.Controls.Add(this.btnExitSystem);
            this.pnlBackground.Controls.Add(this.label1);
            this.pnlBackground.Controls.Add(this.btnLastStep);
            this.pnlBackground.Controls.Add(this.pictureBox1);
            this.pnlBackground.Controls.Add(this.btnNextStep);
            this.pnlBackground.Controls.Add(this.lblError);
            this.pnlBackground.Controls.Add(this.label9);
            this.pnlBackground.Controls.Add(this.lblExamMode);
            this.pnlBackground.Controls.Add(this.lblStuName);
            this.pnlBackground.Controls.Add(this.label3);
            this.pnlBackground.Controls.Add(this.label7);
            this.pnlBackground.Controls.Add(this.lblExamSubject);
            this.pnlBackground.Controls.Add(this.lblTicketNumber);
            this.pnlBackground.Controls.Add(this.label5);
            this.pnlBackground.Location = new System.Drawing.Point(12, 6);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(700, 400);
            this.pnlBackground.TabIndex = 1;
            // 
            // btnExitSystem
            // 
            this.btnExitSystem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExitSystem.BackgroundImage")));
            this.btnExitSystem.FlatAppearance.BorderSize = 0;
            this.btnExitSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitSystem.Location = new System.Drawing.Point(589, 293);
            this.btnExitSystem.Name = "btnExitSystem";
            this.btnExitSystem.Size = new System.Drawing.Size(79, 27);
            this.btnExitSystem.TabIndex = 10;
            this.btnExitSystem.Text = "退出系统";
            this.btnExitSystem.UseVisualStyleBackColor = true;
            this.btnExitSystem.Click += new System.EventHandler(this.btnExitSystem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(259, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "第三步：验证考生信息";
            // 
            // btnLastStep
            // 
            this.btnLastStep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLastStep.BackgroundImage")));
            this.btnLastStep.FlatAppearance.BorderSize = 0;
            this.btnLastStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastStep.Location = new System.Drawing.Point(419, 293);
            this.btnLastStep.Name = "btnLastStep";
            this.btnLastStep.Size = new System.Drawing.Size(79, 27);
            this.btnLastStep.TabIndex = 11;
            this.btnLastStep.Text = "上一步";
            this.btnLastStep.UseVisualStyleBackColor = true;
            this.btnLastStep.Click += new System.EventHandler(this.btnLastStep_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(261, 146);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnNextStep
            // 
            this.btnNextStep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNextStep.BackgroundImage")));
            this.btnNextStep.FlatAppearance.BorderSize = 0;
            this.btnNextStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextStep.Location = new System.Drawing.Point(504, 293);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(79, 27);
            this.btnNextStep.TabIndex = 12;
            this.btnNextStep.Text = "下一步";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(120, 364);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(53, 12);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "错误消息";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(377, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "考生姓名：";
            // 
            // lblExamMode
            // 
            this.lblExamMode.AutoSize = true;
            this.lblExamMode.Location = new System.Drawing.Point(448, 158);
            this.lblExamMode.Name = "lblExamMode";
            this.lblExamMode.Size = new System.Drawing.Size(53, 12);
            this.lblExamMode.TabIndex = 5;
            this.lblExamMode.Text = "朔日科技";
            // 
            // lblStuName
            // 
            this.lblStuName.AutoSize = true;
            this.lblStuName.Location = new System.Drawing.Point(448, 230);
            this.lblStuName.Name = "lblStuName";
            this.lblStuName.Size = new System.Drawing.Size(53, 12);
            this.lblStuName.TabIndex = 5;
            this.lblStuName.Text = "朔日科技";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "考试模式：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(377, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "准考证号：";
            // 
            // lblExamSubject
            // 
            this.lblExamSubject.AutoSize = true;
            this.lblExamSubject.Location = new System.Drawing.Point(448, 182);
            this.lblExamSubject.Name = "lblExamSubject";
            this.lblExamSubject.Size = new System.Drawing.Size(53, 12);
            this.lblExamSubject.TabIndex = 5;
            this.lblExamSubject.Text = "朔日科技";
            // 
            // lblTicketNumber
            // 
            this.lblTicketNumber.AutoSize = true;
            this.lblTicketNumber.Location = new System.Drawing.Point(448, 206);
            this.lblTicketNumber.Name = "lblTicketNumber";
            this.lblTicketNumber.Size = new System.Drawing.Size(53, 12);
            this.lblTicketNumber.TabIndex = 5;
            this.lblTicketNumber.Text = "朔日科技";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "考试科目：";
            // 
            // frmValStuInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(724, 412);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBackground);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmValStuInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试登陆向导";
            this.Load += new System.EventHandler(this.frmValStuInfo_Load);
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblExamMode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblStuName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTicketNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblExamSubject;
        private System.Windows.Forms.Button btnExitSystem;
        private System.Windows.Forms.Button btnLastStep;
        private System.Windows.Forms.Button btnNextStep;
        private Common.BackgroundPanel pnlBackground;
    }
}
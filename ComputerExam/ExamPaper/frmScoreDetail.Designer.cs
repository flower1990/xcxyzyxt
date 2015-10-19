namespace ComputerExam.ExamPaper
{
    partial class frmScoreDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScoreDetail));
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlExerciseMode = new System.Windows.Forms.Panel();
            this.txtScore = new System.Windows.Forms.RichTextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlExerciseMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(584, 39);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(79, 27);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "继续考试";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.pnlExerciseMode);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.lblSubject);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 500);
            this.panel1.TabIndex = 1;
            // 
            // pnlExerciseMode
            // 
            this.pnlExerciseMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExerciseMode.Controls.Add(this.txtScore);
            this.pnlExerciseMode.Location = new System.Drawing.Point(40, 113);
            this.pnlExerciseMode.Name = "pnlExerciseMode";
            this.pnlExerciseMode.Size = new System.Drawing.Size(623, 351);
            this.pnlExerciseMode.TabIndex = 10;
            // 
            // txtScore
            // 
            this.txtScore.BackColor = System.Drawing.Color.White;
            this.txtScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScore.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtScore.Location = new System.Drawing.Point(0, 0);
            this.txtScore.Name = "txtScore";
            this.txtScore.ReadOnly = true;
            this.txtScore.Size = new System.Drawing.Size(621, 349);
            this.txtScore.TabIndex = 9;
            this.txtScore.Text = "";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.BackColor = System.Drawing.Color.Transparent;
            this.lblSubject.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.lblSubject.Location = new System.Drawing.Point(139, 86);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(109, 12);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "考试科目：计算机";
            // 
            // frmScoreDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmScoreDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmScoreDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlExerciseMode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlExerciseMode;
        public System.Windows.Forms.RichTextBox txtScore;
        public System.Windows.Forms.Label lblSubject;

    }
}
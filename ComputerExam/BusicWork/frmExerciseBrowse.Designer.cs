namespace ComputerExam.BusicWork
{
    partial class frmExerciseBrowse
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.TiKuNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.试卷名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaperScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnScoreDetail = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.dgvResult);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 433);
            this.panel1.TabIndex = 13;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TiKuNo,
            this.SubjectName,
            this.试卷名称,
            this.PaperScore,
            this.ScoreDetail,
            this.CreateTime});
            this.dgvResult.Location = new System.Drawing.Point(12, 78);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(765, 343);
            this.dgvResult.TabIndex = 14;
            // 
            // TiKuNo
            // 
            this.TiKuNo.DataPropertyName = "TiKuNo";
            this.TiKuNo.HeaderText = "序号";
            this.TiKuNo.Name = "TiKuNo";
            this.TiKuNo.ReadOnly = true;
            // 
            // SubjectName
            // 
            this.SubjectName.DataPropertyName = "SubjectName";
            this.SubjectName.HeaderText = "科目名称";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            // 
            // 试卷名称
            // 
            this.试卷名称.DataPropertyName = "PresetPaperID";
            this.试卷名称.HeaderText = "试卷名称";
            this.试卷名称.Name = "试卷名称";
            this.试卷名称.ReadOnly = true;
            // 
            // PaperScore
            // 
            this.PaperScore.DataPropertyName = "PaperScore";
            this.PaperScore.HeaderText = "本次得分";
            this.PaperScore.Name = "PaperScore";
            this.PaperScore.ReadOnly = true;
            // 
            // ScoreDetail
            // 
            this.ScoreDetail.DataPropertyName = "ScoreDetail";
            this.ScoreDetail.HeaderText = "ScoreDetail";
            this.ScoreDetail.Name = "ScoreDetail";
            this.ScoreDetail.ReadOnly = true;
            this.ScoreDetail.Visible = false;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "提交时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnScoreDetail);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.dtpEnd);
            this.panel2.Controls.Add(this.dtpStart);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 60);
            this.panel2.TabIndex = 11;
            // 
            // btnScoreDetail
            // 
            this.btnScoreDetail.Location = new System.Drawing.Point(442, 11);
            this.btnScoreDetail.Name = "btnScoreDetail";
            this.btnScoreDetail.Size = new System.Drawing.Size(75, 23);
            this.btnScoreDetail.TabIndex = 13;
            this.btnScoreDetail.Text = "评分明细";
            this.btnScoreDetail.UseVisualStyleBackColor = true;
            this.btnScoreDetail.Click += new System.EventHandler(this.btnScoreDetail_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(361, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(245, 12);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(110, 21);
            this.dtpEnd.TabIndex = 7;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(106, 12);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(110, 21);
            this.dtpStart.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "到";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "从";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "提交时间：";
            // 
            // frmExerciseBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 433);
            this.Controls.Add(this.panel1);
            this.Name = "frmExerciseBrowse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExerciseBrowse";
            this.Load += new System.EventHandler(this.frmExerciseBrowse_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnScoreDetail;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiKuNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn 试卷名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaperScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
    }
}
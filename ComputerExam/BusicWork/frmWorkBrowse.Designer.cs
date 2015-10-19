namespace ComputerExam.BusicWork
{
    partial class frmWorkBrowse
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSubject = new System.Windows.Forms.ComboBox();
            this.btnScoreDetail = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.JobScoreNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamineeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HWID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HWName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManagerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreSubmitted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamEndDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HWSubmitTimeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreSubmitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HWPublicUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecialtyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stat = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Size = new System.Drawing.Size(888, 386);
            this.panel1.TabIndex = 12;
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
            this.JobScoreNo,
            this.ExamNumber,
            this.ExamineeName,
            this.ClassName,
            this.SubjectName,
            this.NodeName,
            this.HWID,
            this.HWName,
            this.ManagerName,
            this.TotalScore,
            this.ScoreSubmitted,
            this.ExamEndDateTime,
            this.HWSubmitTimeType,
            this.ScoreSubmitTime,
            this.HWPublicUserID,
            this.CityID,
            this.SpecialtyID,
            this.Stat});
            this.dgvResult.Location = new System.Drawing.Point(12, 78);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(864, 296);
            this.dgvResult.TabIndex = 13;
            this.dgvResult.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvResult_CellFormatting);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cboSubject);
            this.panel2.Controls.Add(this.btnScoreDetail);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(864, 60);
            this.panel2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "科目名称：";
            // 
            // cboSubject
            // 
            this.cboSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubject.FormattingEnabled = true;
            this.cboSubject.Location = new System.Drawing.Point(86, 12);
            this.cboSubject.Name = "cboSubject";
            this.cboSubject.Size = new System.Drawing.Size(200, 20);
            this.cboSubject.TabIndex = 25;
            // 
            // btnScoreDetail
            // 
            this.btnScoreDetail.Location = new System.Drawing.Point(373, 10);
            this.btnScoreDetail.Name = "btnScoreDetail";
            this.btnScoreDetail.Size = new System.Drawing.Size(75, 23);
            this.btnScoreDetail.TabIndex = 13;
            this.btnScoreDetail.Text = "成绩明细";
            this.btnScoreDetail.UseVisualStyleBackColor = true;
            this.btnScoreDetail.Visible = false;
            this.btnScoreDetail.Click += new System.EventHandler(this.btnScoreDetail_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(292, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // JobScoreNo
            // 
            this.JobScoreNo.DataPropertyName = "JobScoreNo";
            this.JobScoreNo.HeaderText = "序号";
            this.JobScoreNo.Name = "JobScoreNo";
            this.JobScoreNo.ReadOnly = true;
            // 
            // ExamNumber
            // 
            this.ExamNumber.DataPropertyName = "ExamNumber";
            this.ExamNumber.HeaderText = "ExamNumber";
            this.ExamNumber.Name = "ExamNumber";
            this.ExamNumber.ReadOnly = true;
            this.ExamNumber.Visible = false;
            // 
            // ExamineeName
            // 
            this.ExamineeName.DataPropertyName = "ExamineeName";
            this.ExamineeName.HeaderText = "姓名";
            this.ExamineeName.Name = "ExamineeName";
            this.ExamineeName.ReadOnly = true;
            // 
            // ClassName
            // 
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.HeaderText = "班级";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            // 
            // SubjectName
            // 
            this.SubjectName.DataPropertyName = "SubjectName";
            this.SubjectName.HeaderText = "科目名称";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            // 
            // NodeName
            // 
            this.NodeName.DataPropertyName = "NodeName";
            this.NodeName.HeaderText = "章节";
            this.NodeName.Name = "NodeName";
            this.NodeName.ReadOnly = true;
            // 
            // HWID
            // 
            this.HWID.DataPropertyName = "HWID";
            this.HWID.HeaderText = "HWID";
            this.HWID.Name = "HWID";
            this.HWID.ReadOnly = true;
            this.HWID.Visible = false;
            // 
            // HWName
            // 
            this.HWName.DataPropertyName = "HWName";
            this.HWName.HeaderText = "作业名称";
            this.HWName.Name = "HWName";
            this.HWName.ReadOnly = true;
            this.HWName.Width = 200;
            // 
            // ManagerName
            // 
            this.ManagerName.DataPropertyName = "ManagerName";
            this.ManagerName.HeaderText = "ManagerName";
            this.ManagerName.Name = "ManagerName";
            this.ManagerName.ReadOnly = true;
            this.ManagerName.Visible = false;
            // 
            // TotalScore
            // 
            this.TotalScore.DataPropertyName = "TotalScore";
            this.TotalScore.HeaderText = "作业成绩";
            this.TotalScore.Name = "TotalScore";
            this.TotalScore.ReadOnly = true;
            // 
            // ScoreSubmitted
            // 
            this.ScoreSubmitted.HeaderText = "ScoreSubmitted";
            this.ScoreSubmitted.Name = "ScoreSubmitted";
            this.ScoreSubmitted.ReadOnly = true;
            this.ScoreSubmitted.Visible = false;
            // 
            // ExamEndDateTime
            // 
            this.ExamEndDateTime.HeaderText = "ExamEndDateTime";
            this.ExamEndDateTime.Name = "ExamEndDateTime";
            this.ExamEndDateTime.ReadOnly = true;
            this.ExamEndDateTime.Visible = false;
            // 
            // HWSubmitTimeType
            // 
            this.HWSubmitTimeType.HeaderText = "HWSubmitTimeType";
            this.HWSubmitTimeType.Name = "HWSubmitTimeType";
            this.HWSubmitTimeType.ReadOnly = true;
            this.HWSubmitTimeType.Visible = false;
            // 
            // ScoreSubmitTime
            // 
            this.ScoreSubmitTime.DataPropertyName = "ScoreSubmitTime";
            this.ScoreSubmitTime.HeaderText = "提交时间";
            this.ScoreSubmitTime.Name = "ScoreSubmitTime";
            this.ScoreSubmitTime.ReadOnly = true;
            // 
            // HWPublicUserID
            // 
            this.HWPublicUserID.DataPropertyName = "HWPublicUserID";
            this.HWPublicUserID.HeaderText = "HWPublicUserID";
            this.HWPublicUserID.Name = "HWPublicUserID";
            this.HWPublicUserID.ReadOnly = true;
            this.HWPublicUserID.Visible = false;
            // 
            // CityID
            // 
            this.CityID.HeaderText = "CityID";
            this.CityID.Name = "CityID";
            this.CityID.ReadOnly = true;
            this.CityID.Visible = false;
            // 
            // SpecialtyID
            // 
            this.SpecialtyID.HeaderText = "SpecialtyID";
            this.SpecialtyID.Name = "SpecialtyID";
            this.SpecialtyID.ReadOnly = true;
            this.SpecialtyID.Visible = false;
            // 
            // Stat
            // 
            this.Stat.DataPropertyName = "Stat";
            this.Stat.HeaderText = "提交状态";
            this.Stat.Name = "Stat";
            this.Stat.ReadOnly = true;
            // 
            // frmWorkBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 386);
            this.Controls.Add(this.panel1);
            this.Name = "frmWorkBrowse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成绩浏览";
            this.Load += new System.EventHandler(this.frmBrowse_Load);
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
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnScoreDetail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobScoreNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HWID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HWName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreSubmitted;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamEndDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn HWSubmitTimeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreSubmitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn HWPublicUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecialtyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stat;
    }
}
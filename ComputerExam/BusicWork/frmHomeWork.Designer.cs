namespace ComputerExam.BusicWork
{
    partial class frmHomeWork
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSubject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboJobState = new System.Windows.Forms.ComboBox();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbBar = new System.Windows.Forms.ToolStripProgressBar();
            this.JobNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.学生姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowAnalysis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAllocReSubmitScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllocReSubmitScoreCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HWSubmitTimeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HWName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HWFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HWFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsEnable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAllowExercise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManagerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCalculateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecialtyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublicUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamStartDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamEndDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSingleGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobDownLoadState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.作业上交状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(848, 424);
            this.panel1.TabIndex = 13;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToOrderColumns = true;
            this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JobNo,
            this.学生姓名,
            this.ShowScore,
            this.ShowAnalysis,
            this.ExamMode,
            this.CreateTime,
            this.IsAllocReSubmitScore,
            this.AllocReSubmitScoreCount,
            this.HWSubmitTimeType,
            this.SubjectName,
            this.NodeName,
            this.HWName,
            this.HWFileName,
            this.HWFilePath,
            this.IsEnable,
            this.IsAllowExercise,
            this.ManagerName,
            this.IsCalculateTime,
            this.ClassName,
            this.SpecialtyID,
            this.CityID,
            this.PublicUserID,
            this.ExamStartDateTime,
            this.ExamEndDateTime,
            this.IsPay,
            this.IsSingleGrade,
            this.JobDownLoadState,
            this.作业上交状态});
            this.dgvResult.Location = new System.Drawing.Point(12, 78);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(824, 321);
            this.dgvResult.TabIndex = 12;
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
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboJobState);
            this.panel2.Controls.Add(this.btnDownLoad);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(824, 60);
            this.panel2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "科目名称：";
            // 
            // cboSubject
            // 
            this.cboSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubject.FormattingEnabled = true;
            this.cboSubject.Location = new System.Drawing.Point(283, 15);
            this.cboSubject.Name = "cboSubject";
            this.cboSubject.Size = new System.Drawing.Size(200, 20);
            this.cboSubject.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "作业类型：";
            // 
            // cboJobState
            // 
            this.cboJobState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJobState.FormattingEnabled = true;
            this.cboJobState.Location = new System.Drawing.Point(86, 15);
            this.cboJobState.Name = "cboJobState";
            this.cboJobState.Size = new System.Drawing.Size(120, 20);
            this.cboJobState.TabIndex = 20;
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Location = new System.Drawing.Point(570, 13);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(75, 23);
            this.btnDownLoad.TabIndex = 14;
            this.btnDownLoad.Text = "下载";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(489, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMessage,
            this.tsbBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 402);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(848, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsbMessage
            // 
            this.tsbMessage.Name = "tsbMessage";
            this.tsbMessage.Size = new System.Drawing.Size(116, 17);
            this.tsbMessage.Text = "当前作业下载进度：";
            // 
            // tsbBar
            // 
            this.tsbBar.Name = "tsbBar";
            this.tsbBar.Size = new System.Drawing.Size(150, 16);
            // 
            // JobNo
            // 
            this.JobNo.DataPropertyName = "JobNo";
            this.JobNo.HeaderText = "序号";
            this.JobNo.Name = "JobNo";
            this.JobNo.ReadOnly = true;
            // 
            // 学生姓名
            // 
            this.学生姓名.DataPropertyName = "ExamineeName";
            this.学生姓名.HeaderText = "学生姓名";
            this.学生姓名.Name = "学生姓名";
            this.学生姓名.ReadOnly = true;
            // 
            // ShowScore
            // 
            this.ShowScore.DataPropertyName = "ShowScore";
            this.ShowScore.HeaderText = "ShowScore";
            this.ShowScore.Name = "ShowScore";
            this.ShowScore.ReadOnly = true;
            this.ShowScore.Visible = false;
            // 
            // ShowAnalysis
            // 
            this.ShowAnalysis.DataPropertyName = "ShowAnalysis";
            this.ShowAnalysis.HeaderText = "ShowAnalysis";
            this.ShowAnalysis.Name = "ShowAnalysis";
            this.ShowAnalysis.ReadOnly = true;
            this.ShowAnalysis.Visible = false;
            // 
            // ExamMode
            // 
            this.ExamMode.DataPropertyName = "ExamMode";
            this.ExamMode.HeaderText = "ExamMode";
            this.ExamMode.Name = "ExamMode";
            this.ExamMode.ReadOnly = true;
            this.ExamMode.Visible = false;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "CreateTime";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            this.CreateTime.Visible = false;
            // 
            // IsAllocReSubmitScore
            // 
            this.IsAllocReSubmitScore.DataPropertyName = "IsAllocReSubmitScore";
            this.IsAllocReSubmitScore.HeaderText = "IsAllocReSubmitScore";
            this.IsAllocReSubmitScore.Name = "IsAllocReSubmitScore";
            this.IsAllocReSubmitScore.ReadOnly = true;
            this.IsAllocReSubmitScore.Visible = false;
            // 
            // AllocReSubmitScoreCount
            // 
            this.AllocReSubmitScoreCount.DataPropertyName = "AllocReSubmitScoreCount";
            this.AllocReSubmitScoreCount.HeaderText = "AllocReSubmitScoreCount";
            this.AllocReSubmitScoreCount.Name = "AllocReSubmitScoreCount";
            this.AllocReSubmitScoreCount.ReadOnly = true;
            this.AllocReSubmitScoreCount.Visible = false;
            // 
            // HWSubmitTimeType
            // 
            this.HWSubmitTimeType.DataPropertyName = "HWSubmitTimeType";
            this.HWSubmitTimeType.HeaderText = "HWSubmitTimeType";
            this.HWSubmitTimeType.Name = "HWSubmitTimeType";
            this.HWSubmitTimeType.ReadOnly = true;
            this.HWSubmitTimeType.Visible = false;
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
            this.NodeName.HeaderText = "章节名称";
            this.NodeName.Name = "NodeName";
            this.NodeName.ReadOnly = true;
            // 
            // HWName
            // 
            this.HWName.DataPropertyName = "HWName";
            this.HWName.HeaderText = "作业名称";
            this.HWName.Name = "HWName";
            this.HWName.ReadOnly = true;
            // 
            // HWFileName
            // 
            this.HWFileName.DataPropertyName = "HWFileName";
            this.HWFileName.HeaderText = "HWFileName";
            this.HWFileName.Name = "HWFileName";
            this.HWFileName.ReadOnly = true;
            this.HWFileName.Visible = false;
            // 
            // HWFilePath
            // 
            this.HWFilePath.DataPropertyName = "HWFilePath";
            this.HWFilePath.HeaderText = "HWFilePath";
            this.HWFilePath.Name = "HWFilePath";
            this.HWFilePath.ReadOnly = true;
            this.HWFilePath.Visible = false;
            // 
            // IsEnable
            // 
            this.IsEnable.DataPropertyName = "IsEnable";
            this.IsEnable.HeaderText = "IsEnable";
            this.IsEnable.Name = "IsEnable";
            this.IsEnable.ReadOnly = true;
            this.IsEnable.Visible = false;
            // 
            // IsAllowExercise
            // 
            this.IsAllowExercise.DataPropertyName = "IsAllowExercise";
            this.IsAllowExercise.HeaderText = "IsAllowExercise";
            this.IsAllowExercise.Name = "IsAllowExercise";
            this.IsAllowExercise.ReadOnly = true;
            this.IsAllowExercise.Visible = false;
            // 
            // ManagerName
            // 
            this.ManagerName.DataPropertyName = "ManagerName";
            this.ManagerName.HeaderText = "ManagerName";
            this.ManagerName.Name = "ManagerName";
            this.ManagerName.ReadOnly = true;
            this.ManagerName.Visible = false;
            // 
            // IsCalculateTime
            // 
            this.IsCalculateTime.DataPropertyName = "IsCalculateTime";
            this.IsCalculateTime.HeaderText = "IsCalculateTime";
            this.IsCalculateTime.Name = "IsCalculateTime";
            this.IsCalculateTime.ReadOnly = true;
            this.IsCalculateTime.Visible = false;
            // 
            // ClassName
            // 
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.HeaderText = "ClassName";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            this.ClassName.Visible = false;
            // 
            // SpecialtyID
            // 
            this.SpecialtyID.DataPropertyName = "SpecialtyID";
            this.SpecialtyID.HeaderText = "SpecialtyID";
            this.SpecialtyID.Name = "SpecialtyID";
            this.SpecialtyID.ReadOnly = true;
            this.SpecialtyID.Visible = false;
            // 
            // CityID
            // 
            this.CityID.DataPropertyName = "CityID";
            this.CityID.HeaderText = "CityID";
            this.CityID.Name = "CityID";
            this.CityID.ReadOnly = true;
            this.CityID.Visible = false;
            // 
            // PublicUserID
            // 
            this.PublicUserID.DataPropertyName = "PublicUserID";
            this.PublicUserID.HeaderText = "PublicUserID";
            this.PublicUserID.Name = "PublicUserID";
            this.PublicUserID.ReadOnly = true;
            this.PublicUserID.Visible = false;
            // 
            // ExamStartDateTime
            // 
            this.ExamStartDateTime.DataPropertyName = "ExamStartDateTime";
            dataGridViewCellStyle1.Format = "D";
            dataGridViewCellStyle1.NullValue = null;
            this.ExamStartDateTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.ExamStartDateTime.HeaderText = "开始时间";
            this.ExamStartDateTime.Name = "ExamStartDateTime";
            this.ExamStartDateTime.ReadOnly = true;
            this.ExamStartDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExamEndDateTime
            // 
            this.ExamEndDateTime.DataPropertyName = "ExamEndDateTime";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.ExamEndDateTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExamEndDateTime.HeaderText = "结束时间";
            this.ExamEndDateTime.Name = "ExamEndDateTime";
            this.ExamEndDateTime.ReadOnly = true;
            this.ExamEndDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IsPay
            // 
            this.IsPay.DataPropertyName = "IsPay";
            this.IsPay.HeaderText = "IsPay";
            this.IsPay.Name = "IsPay";
            this.IsPay.ReadOnly = true;
            this.IsPay.Visible = false;
            // 
            // IsSingleGrade
            // 
            this.IsSingleGrade.DataPropertyName = "IsSingleGrade";
            this.IsSingleGrade.HeaderText = "IsSingleGrade";
            this.IsSingleGrade.Name = "IsSingleGrade";
            this.IsSingleGrade.ReadOnly = true;
            this.IsSingleGrade.Visible = false;
            // 
            // JobDownLoadState
            // 
            this.JobDownLoadState.DataPropertyName = "JobDownLoadState";
            this.JobDownLoadState.HeaderText = "作业下载状态";
            this.JobDownLoadState.Name = "JobDownLoadState";
            this.JobDownLoadState.ReadOnly = true;
            // 
            // 作业上交状态
            // 
            this.作业上交状态.DataPropertyName = "JobSubmitState";
            this.作业上交状态.HeaderText = "作业上交状态";
            this.作业上交状态.Name = "作业上交状态";
            this.作业上交状态.ReadOnly = true;
            this.作业上交状态.Visible = false;
            // 
            // frmHomeWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 424);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "frmHomeWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "我的作业";
            this.Load += new System.EventHandler(this.frmHomeWork_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsbMessage;
        private System.Windows.Forms.ToolStripProgressBar tsbBar;
        private System.Windows.Forms.ComboBox cboJobState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn 学生姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShowScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShowAnalysis;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsAllocReSubmitScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllocReSubmitScoreCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn HWSubmitTimeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HWName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HWFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HWFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsAllowExercise;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCalculateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecialtyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublicUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamStartDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamEndDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSingleGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobDownLoadState;
        private System.Windows.Forms.DataGridViewTextBoxColumn 作业上交状态;
    }
}
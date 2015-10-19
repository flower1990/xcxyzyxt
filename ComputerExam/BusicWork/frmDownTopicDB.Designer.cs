namespace ComputerExam.BusicWork
{
    partial class frmDownTopicDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownTopicDB));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblDown = new System.Windows.Forms.Label();
            this.proDown = new System.Windows.Forms.ProgressBar();
            this.btnDown = new System.Windows.Forms.Button();
            this.dgvDownTopicDB = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicDBName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicDBVersion1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicDBCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsEnable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequireEnvFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvFileUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDownTopicDB)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 80);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "对考试题库进行下载操作";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(88, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "考试题库下载";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 98);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(604, 210);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblDown);
            this.tabPage3.Controls.Add(this.proDown);
            this.tabPage3.Controls.Add(this.btnDown);
            this.tabPage3.Controls.Add(this.dgvDownTopicDB);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(596, 184);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "考试题库下载";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblDown
            // 
            this.lblDown.AutoSize = true;
            this.lblDown.Location = new System.Drawing.Point(297, 160);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(17, 12);
            this.lblDown.TabIndex = 8;
            this.lblDown.Text = "0%";
            // 
            // proDown
            // 
            this.proDown.Location = new System.Drawing.Point(87, 155);
            this.proDown.Name = "proDown";
            this.proDown.Size = new System.Drawing.Size(204, 23);
            this.proDown.TabIndex = 7;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(6, 155);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "下载题库";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // dgvDownTopicDB
            // 
            this.dgvDownTopicDB.AllowUserToAddRows = false;
            this.dgvDownTopicDB.AllowUserToDeleteRows = false;
            this.dgvDownTopicDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDownTopicDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TopicDBName,
            this.TopicDBVersion1,
            this.TopicDBCode1,
            this.CreateTime,
            this.PathUrl,
            this.IsEnable,
            this.UserID,
            this.UserName,
            this.TotalSize,
            this.RequireEnvFile,
            this.EnvFileName,
            this.EnvFileUrl});
            this.dgvDownTopicDB.Location = new System.Drawing.Point(3, 3);
            this.dgvDownTopicDB.Name = "dgvDownTopicDB";
            this.dgvDownTopicDB.ReadOnly = true;
            this.dgvDownTopicDB.RowTemplate.Height = 23;
            this.dgvDownTopicDB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDownTopicDB.Size = new System.Drawing.Size(590, 146);
            this.dgvDownTopicDB.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(541, 314);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // TopicDBName
            // 
            this.TopicDBName.DataPropertyName = "TopicDBName";
            this.TopicDBName.HeaderText = "题库名称";
            this.TopicDBName.Name = "TopicDBName";
            this.TopicDBName.ReadOnly = true;
            // 
            // TopicDBVersion1
            // 
            this.TopicDBVersion1.DataPropertyName = "TopicDBVersion";
            this.TopicDBVersion1.HeaderText = "题库版本";
            this.TopicDBVersion1.Name = "TopicDBVersion1";
            this.TopicDBVersion1.ReadOnly = true;
            // 
            // TopicDBCode1
            // 
            this.TopicDBCode1.DataPropertyName = "TopicDBCode";
            this.TopicDBCode1.HeaderText = "题库编码";
            this.TopicDBCode1.Name = "TopicDBCode1";
            this.TopicDBCode1.ReadOnly = true;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.CreateTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.CreateTime.HeaderText = "发布时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            // 
            // PathUrl
            // 
            this.PathUrl.DataPropertyName = "PathUrl";
            this.PathUrl.HeaderText = "PathUrl";
            this.PathUrl.Name = "PathUrl";
            this.PathUrl.ReadOnly = true;
            this.PathUrl.Visible = false;
            // 
            // IsEnable
            // 
            this.IsEnable.DataPropertyName = "IsEnable";
            this.IsEnable.HeaderText = "IsEnable";
            this.IsEnable.Name = "IsEnable";
            this.IsEnable.ReadOnly = true;
            this.IsEnable.Visible = false;
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Visible = false;
            // 
            // TotalSize
            // 
            this.TotalSize.DataPropertyName = "TotalSize";
            this.TotalSize.HeaderText = "文件大小";
            this.TotalSize.Name = "TotalSize";
            this.TotalSize.ReadOnly = true;
            // 
            // RequireEnvFile
            // 
            this.RequireEnvFile.DataPropertyName = "RequireEnvFile";
            this.RequireEnvFile.HeaderText = "RequireEnvFile";
            this.RequireEnvFile.Name = "RequireEnvFile";
            this.RequireEnvFile.ReadOnly = true;
            this.RequireEnvFile.Visible = false;
            // 
            // EnvFileName
            // 
            this.EnvFileName.DataPropertyName = "EnvFileName";
            this.EnvFileName.HeaderText = "EnvFileName";
            this.EnvFileName.Name = "EnvFileName";
            this.EnvFileName.ReadOnly = true;
            this.EnvFileName.Visible = false;
            // 
            // EnvFileUrl
            // 
            this.EnvFileUrl.DataPropertyName = "EnvFileUrl";
            this.EnvFileUrl.HeaderText = "EnvFileUrl";
            this.EnvFileUrl.Name = "EnvFileUrl";
            this.EnvFileUrl.ReadOnly = true;
            this.EnvFileUrl.Visible = false;
            // 
            // frmDownTopicDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(628, 349);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDownTopicDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试题库下载";
            this.Load += new System.EventHandler(this.frmDownTopicDB_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDownTopicDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblDown;
        private System.Windows.Forms.ProgressBar proDown;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.DataGridView dgvDownTopicDB;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicDBName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicDBVersion1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicDBCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequireEnvFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnvFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnvFileUrl;
    }
}
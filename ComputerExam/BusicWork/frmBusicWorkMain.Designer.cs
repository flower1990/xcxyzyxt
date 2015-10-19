namespace ComputerExam.BusicWork
{
    partial class frmBusicWorkMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusicWorkMain));
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbHomeWork = new System.Windows.Forms.ToolStripButton();
            this.tsbDownWork = new System.Windows.Forms.ToolStripButton();
            this.tsbWorkBrowse = new System.Windows.Forms.ToolStripButton();
            this.tsbMyJobStatistics = new System.Windows.Forms.ToolStripButton();
            this.tsbExercise = new System.Windows.Forms.ToolStripButton();
            this.tsbUseManual = new System.Windows.Forms.ToolStripButton();
            this.tsbExerciseBrowse = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Location = new System.Drawing.Point(0, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 482);
            this.panel2.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHomeWork,
            this.tsbDownWork,
            this.tsbWorkBrowse,
            this.tsbMyJobStatistics,
            this.tsbExercise,
            this.tsbUseManual,
            this.tsbExerciseBrowse,
            this.tsbExit});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(194, 476);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbHomeWork
            // 
            this.tsbHomeWork.AutoSize = false;
            this.tsbHomeWork.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbHomeWork.BackgroundImage")));
            this.tsbHomeWork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsbHomeWork.Checked = true;
            this.tsbHomeWork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbHomeWork.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tsbHomeWork.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbHomeWork.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbHomeWork.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHomeWork.Name = "tsbHomeWork";
            this.tsbHomeWork.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsbHomeWork.Size = new System.Drawing.Size(192, 49);
            this.tsbHomeWork.Text = "我的作业";
            this.tsbHomeWork.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsbHomeWork.Click += new System.EventHandler(this.tsbHomeWork_Click);
            this.tsbHomeWork.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsbHomeWork_MouseDown);
            // 
            // tsbDownWork
            // 
            this.tsbDownWork.AutoSize = false;
            this.tsbDownWork.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbDownWork.BackgroundImage")));
            this.tsbDownWork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsbDownWork.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tsbDownWork.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbDownWork.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDownWork.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDownWork.Name = "tsbDownWork";
            this.tsbDownWork.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsbDownWork.Size = new System.Drawing.Size(192, 49);
            this.tsbDownWork.Text = "   已下载作业";
            this.tsbDownWork.Click += new System.EventHandler(this.tsbDownWork_Click);
            this.tsbDownWork.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsbHomeWork_MouseDown);
            // 
            // tsbWorkBrowse
            // 
            this.tsbWorkBrowse.AutoSize = false;
            this.tsbWorkBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbWorkBrowse.BackgroundImage")));
            this.tsbWorkBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsbWorkBrowse.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tsbWorkBrowse.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbWorkBrowse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbWorkBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWorkBrowse.Name = "tsbWorkBrowse";
            this.tsbWorkBrowse.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsbWorkBrowse.Size = new System.Drawing.Size(192, 49);
            this.tsbWorkBrowse.Text = "      作业成绩浏览";
            this.tsbWorkBrowse.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsbWorkBrowse.Click += new System.EventHandler(this.tsbBrowse_Click);
            this.tsbWorkBrowse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsbHomeWork_MouseDown);
            // 
            // tsbMyJobStatistics
            // 
            this.tsbMyJobStatistics.AutoSize = false;
            this.tsbMyJobStatistics.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbMyJobStatistics.BackgroundImage")));
            this.tsbMyJobStatistics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsbMyJobStatistics.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tsbMyJobStatistics.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbMyJobStatistics.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMyJobStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMyJobStatistics.Name = "tsbMyJobStatistics";
            this.tsbMyJobStatistics.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsbMyJobStatistics.Size = new System.Drawing.Size(192, 49);
            this.tsbMyJobStatistics.Text = "       完成情况统计";
            this.tsbMyJobStatistics.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsbMyJobStatistics.Click += new System.EventHandler(this.tsbMyJobStatistics_Click);
            this.tsbMyJobStatistics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsbHomeWork_MouseDown);
            // 
            // tsbExercise
            // 
            this.tsbExercise.AutoSize = false;
            this.tsbExercise.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbExercise.BackgroundImage")));
            this.tsbExercise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsbExercise.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tsbExercise.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbExercise.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbExercise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExercise.Name = "tsbExercise";
            this.tsbExercise.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsbExercise.Size = new System.Drawing.Size(192, 49);
            this.tsbExercise.Text = "强化练习";
            this.tsbExercise.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsbExercise.Click += new System.EventHandler(this.tsbExercise_Click);
            this.tsbExercise.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsbHomeWork_MouseDown);
            // 
            // tsbUseManual
            // 
            this.tsbUseManual.AutoSize = false;
            this.tsbUseManual.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbUseManual.BackgroundImage")));
            this.tsbUseManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsbUseManual.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tsbUseManual.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbUseManual.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbUseManual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUseManual.Name = "tsbUseManual";
            this.tsbUseManual.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsbUseManual.Size = new System.Drawing.Size(192, 49);
            this.tsbUseManual.Text = "使用手册";
            this.tsbUseManual.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsbUseManual.Click += new System.EventHandler(this.tsbUseManual_Click);
            this.tsbUseManual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsbHomeWork_MouseDown);
            // 
            // tsbExerciseBrowse
            // 
            this.tsbExerciseBrowse.AutoSize = false;
            this.tsbExerciseBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbExerciseBrowse.BackgroundImage")));
            this.tsbExerciseBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsbExerciseBrowse.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tsbExerciseBrowse.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbExerciseBrowse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbExerciseBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExerciseBrowse.Name = "tsbExerciseBrowse";
            this.tsbExerciseBrowse.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsbExerciseBrowse.Size = new System.Drawing.Size(192, 49);
            this.tsbExerciseBrowse.Text = "       练习成绩浏览";
            this.tsbExerciseBrowse.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsbExerciseBrowse.Visible = false;
            this.tsbExerciseBrowse.Click += new System.EventHandler(this.tsbExerciseBrowse_Click);
            this.tsbExerciseBrowse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsbHomeWork_MouseDown);
            // 
            // tsbExit
            // 
            this.tsbExit.AutoSize = false;
            this.tsbExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbExit.BackgroundImage")));
            this.tsbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsbExit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tsbExit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsbExit.Size = new System.Drawing.Size(192, 49);
            this.tsbExit.Text = "退出系统";
            this.tsbExit.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            this.tsbExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsbHomeWork_MouseDown);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlContainer.Location = new System.Drawing.Point(206, 128);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(609, 482);
            this.pnlContainer.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 122);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(682, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "天津商业大学数字化作业中心 作业客户端";
            // 
            // frmBusicWorkMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(167)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(815, 610);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBusicWorkMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "天津商业大学数字化作业中心 作业客户端 v5.0.B0924";
            this.Load += new System.EventHandler(this.frmBusicWorkMain_Load);
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbHomeWork;
        private System.Windows.Forms.ToolStripButton tsbDownWork;
        private System.Windows.Forms.ToolStripButton tsbWorkBrowse;
        private System.Windows.Forms.ToolStripButton tsbExercise;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripButton tsbExerciseBrowse;
        private System.Windows.Forms.ToolStripButton tsbMyJobStatistics;
        private System.Windows.Forms.ToolStripButton tsbUseManual;
    }
}
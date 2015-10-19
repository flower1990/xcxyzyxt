namespace ComputerExam.StepWizard
{
    partial class frmLoadPaper
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadPaper));
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.backgroundPanel1 = new ComputerExam.Common.BackgroundPanel();
            this.tmrShowForm = new System.Windows.Forms.Timer(this.components);
            this.tmrInitTopic = new System.Windows.Forms.Timer(this.components);
            this.backgroundPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(116, 364);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(155, 12);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "正在初始化试题，请稍后...";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(207, 188);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(286, 24);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "正在进行考前准备工作..";
            // 
            // backgroundPanel1
            // 
            this.backgroundPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backgroundPanel1.BackColor = System.Drawing.Color.Transparent;
            this.backgroundPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backgroundPanel1.BackgroundImage")));
            this.backgroundPanel1.Controls.Add(this.lblMessage);
            this.backgroundPanel1.Controls.Add(this.lblTitle);
            this.backgroundPanel1.Location = new System.Drawing.Point(12, 6);
            this.backgroundPanel1.Name = "backgroundPanel1";
            this.backgroundPanel1.Size = new System.Drawing.Size(700, 400);
            this.backgroundPanel1.TabIndex = 6;
            // 
            // tmrShowForm
            // 
            this.tmrShowForm.Tick += new System.EventHandler(this.tmrShowForm_Tick);
            // 
            // tmrInitTopic
            // 
            this.tmrInitTopic.Tick += new System.EventHandler(this.tmrInitTopic_Tick);
            // 
            // frmLoadPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(724, 412);
            this.ControlBox = false;
            this.Controls.Add(this.backgroundPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoadPaper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试登陆向导";
            this.Load += new System.EventHandler(this.frmExamInfo_Load);
            this.backgroundPanel1.ResumeLayout(false);
            this.backgroundPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblTitle;
        private Common.BackgroundPanel backgroundPanel1;
        private System.Windows.Forms.Timer tmrShowForm;
        private System.Windows.Forms.Timer tmrInitTopic;
    }
}
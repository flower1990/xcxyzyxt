namespace ComputerExam.StepWizard
{
    partial class frmExamInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamInfo));
            this.tmrCreatePaper = new System.Windows.Forms.Timer(this.components);
            this.tmrLoadPaper = new System.Windows.Forms.Timer(this.components);
            this.tmrInitPaper = new System.Windows.Forms.Timer(this.components);
            this.tmrMessage = new System.Windows.Forms.Timer(this.components);
            this.backgroundPanel1 = new ComputerExam.Common.BackgroundPanel();
            this.txtMessage = new ComputerExam.CustomControl.CustomRichTextBox();
            this.btnExitSystem = new System.Windows.Forms.Button();
            this.btnReturnLogin = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.tmrNewJob = new System.Windows.Forms.Timer(this.components);
            this.tmrLastJob = new System.Windows.Forms.Timer(this.components);
            this.backgroundPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrCreatePaper
            // 
            this.tmrCreatePaper.Tick += new System.EventHandler(this.tmrCreatePaper_Tick);
            // 
            // tmrLoadPaper
            // 
            this.tmrLoadPaper.Tick += new System.EventHandler(this.tmrLoadPaper_Tick);
            // 
            // tmrInitPaper
            // 
            this.tmrInitPaper.Tick += new System.EventHandler(this.tmrInitPaper_Tick);
            // 
            // tmrMessage
            // 
            this.tmrMessage.Interval = 2000;
            this.tmrMessage.Tick += new System.EventHandler(this.tmrMessage_Tick);
            // 
            // backgroundPanel1
            // 
            this.backgroundPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backgroundPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backgroundPanel1.BackgroundImage")));
            this.backgroundPanel1.Controls.Add(this.txtMessage);
            this.backgroundPanel1.Controls.Add(this.btnExitSystem);
            this.backgroundPanel1.Controls.Add(this.btnReturnLogin);
            this.backgroundPanel1.Controls.Add(this.btnNextStep);
            this.backgroundPanel1.Location = new System.Drawing.Point(12, 6);
            this.backgroundPanel1.Name = "backgroundPanel1";
            this.backgroundPanel1.Size = new System.Drawing.Size(700, 400);
            this.backgroundPanel1.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtMessage.Location = new System.Drawing.Point(28, 93);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(560, 230);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.Text = "";
            // 
            // btnExitSystem
            // 
            this.btnExitSystem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExitSystem.BackgroundImage")));
            this.btnExitSystem.FlatAppearance.BorderSize = 0;
            this.btnExitSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitSystem.Location = new System.Drawing.Point(598, 357);
            this.btnExitSystem.Name = "btnExitSystem";
            this.btnExitSystem.Size = new System.Drawing.Size(79, 27);
            this.btnExitSystem.TabIndex = 2;
            this.btnExitSystem.Text = "退出系统";
            this.btnExitSystem.UseVisualStyleBackColor = true;
            this.btnExitSystem.Click += new System.EventHandler(this.btnExitSystem_Click);
            // 
            // btnReturnLogin
            // 
            this.btnReturnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReturnLogin.BackgroundImage")));
            this.btnReturnLogin.FlatAppearance.BorderSize = 0;
            this.btnReturnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnLogin.Location = new System.Drawing.Point(428, 357);
            this.btnReturnLogin.Name = "btnReturnLogin";
            this.btnReturnLogin.Size = new System.Drawing.Size(79, 27);
            this.btnReturnLogin.TabIndex = 2;
            this.btnReturnLogin.Text = "返回主窗体";
            this.btnReturnLogin.UseVisualStyleBackColor = true;
            this.btnReturnLogin.Click += new System.EventHandler(this.btnReturnLogin_Click);
            // 
            // btnNextStep
            // 
            this.btnNextStep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNextStep.BackgroundImage")));
            this.btnNextStep.FlatAppearance.BorderSize = 0;
            this.btnNextStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextStep.Location = new System.Drawing.Point(513, 357);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(79, 27);
            this.btnNextStep.TabIndex = 2;
            this.btnNextStep.Text = "下一步";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // tmrNewJob
            // 
            this.tmrNewJob.Tick += new System.EventHandler(this.tmrNewJob_Tick);
            // 
            // tmrLastJob
            // 
            this.tmrLastJob.Tick += new System.EventHandler(this.tmrLastJob_Tick);
            // 
            // frmExamInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(724, 412);
            this.ControlBox = false;
            this.Controls.Add(this.backgroundPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExamInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试登陆向导";
            this.Load += new System.EventHandler(this.frmExamInfo_Load);
            this.backgroundPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReturnLogin;
        private System.Windows.Forms.Button btnExitSystem;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Timer tmrCreatePaper;
        private System.Windows.Forms.Timer tmrLoadPaper;
        private System.Windows.Forms.Timer tmrInitPaper;
        private System.Windows.Forms.Timer tmrMessage;
        private Common.BackgroundPanel backgroundPanel1;
        private CustomControl.CustomRichTextBox txtMessage;
        private System.Windows.Forms.Timer tmrNewJob;
        private System.Windows.Forms.Timer tmrLastJob;
    }
}
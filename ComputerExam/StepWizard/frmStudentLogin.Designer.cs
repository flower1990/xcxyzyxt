namespace ComputerExam.StepWizard
{
    partial class frmStudentLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentLogin));
            this.backgroundPanel1 = new ComputerExam.Common.BackgroundPanel();
            this.btnExitSystem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLastStep = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTicketNumber = new System.Windows.Forms.TextBox();
            this.backgroundPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundPanel1
            // 
            this.backgroundPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backgroundPanel1.BackColor = System.Drawing.Color.Transparent;
            this.backgroundPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backgroundPanel1.BackgroundImage")));
            this.backgroundPanel1.Controls.Add(this.btnExitSystem);
            this.backgroundPanel1.Controls.Add(this.label1);
            this.backgroundPanel1.Controls.Add(this.btnLastStep);
            this.backgroundPanel1.Controls.Add(this.pictureBox1);
            this.backgroundPanel1.Controls.Add(this.btnNextStep);
            this.backgroundPanel1.Controls.Add(this.lblError);
            this.backgroundPanel1.Controls.Add(this.label2);
            this.backgroundPanel1.Controls.Add(this.txtTicketNumber);
            this.backgroundPanel1.Location = new System.Drawing.Point(12, 6);
            this.backgroundPanel1.Name = "backgroundPanel1";
            this.backgroundPanel1.Size = new System.Drawing.Size(700, 400);
            this.backgroundPanel1.TabIndex = 1;
            // 
            // btnExitSystem
            // 
            this.btnExitSystem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExitSystem.BackgroundImage")));
            this.btnExitSystem.FlatAppearance.BorderSize = 0;
            this.btnExitSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitSystem.Location = new System.Drawing.Point(588, 292);
            this.btnExitSystem.Name = "btnExitSystem";
            this.btnExitSystem.Size = new System.Drawing.Size(79, 27);
            this.btnExitSystem.TabIndex = 8;
            this.btnExitSystem.Text = "退出系统";
            this.btnExitSystem.UseVisualStyleBackColor = true;
            this.btnExitSystem.Click += new System.EventHandler(this.btnExitSystem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(262, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "第二步：考生登录";
            // 
            // btnLastStep
            // 
            this.btnLastStep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLastStep.BackgroundImage")));
            this.btnLastStep.FlatAppearance.BorderSize = 0;
            this.btnLastStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastStep.Location = new System.Drawing.Point(418, 292);
            this.btnLastStep.Name = "btnLastStep";
            this.btnLastStep.Size = new System.Drawing.Size(79, 27);
            this.btnLastStep.TabIndex = 9;
            this.btnLastStep.Text = "上一步";
            this.btnLastStep.UseVisualStyleBackColor = true;
            this.btnLastStep.Click += new System.EventHandler(this.btnLastStep_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(264, 155);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnNextStep
            // 
            this.btnNextStep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNextStep.BackgroundImage")));
            this.btnNextStep.FlatAppearance.BorderSize = 0;
            this.btnNextStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextStep.Location = new System.Drawing.Point(503, 292);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(79, 27);
            this.btnNextStep.TabIndex = 9;
            this.btnNextStep.Text = "下一步";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(119, 364);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(53, 12);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "错误消息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "准考证号：";
            // 
            // txtTicketNumber
            // 
            this.txtTicketNumber.Location = new System.Drawing.Point(451, 190);
            this.txtTicketNumber.Name = "txtTicketNumber";
            this.txtTicketNumber.Size = new System.Drawing.Size(200, 21);
            this.txtTicketNumber.TabIndex = 5;
            this.txtTicketNumber.Text = "1";
            // 
            // frmStudentLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(724, 412);
            this.ControlBox = false;
            this.Controls.Add(this.backgroundPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudentLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试登陆向导";
            this.Load += new System.EventHandler(this.frmExamineeLogin_Load);
            this.backgroundPanel1.ResumeLayout(false);
            this.backgroundPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTicketNumber;
        private System.Windows.Forms.Button btnExitSystem;
        private System.Windows.Forms.Button btnLastStep;
        private System.Windows.Forms.Button btnNextStep;
        private Common.BackgroundPanel backgroundPanel1;
    }
}
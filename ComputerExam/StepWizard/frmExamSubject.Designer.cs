namespace ComputerExam.StepWizard
{
    partial class frmExamSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamSubject));
            this.tmrCheckEnvironment = new System.Windows.Forms.Timer(this.components);
            this.backgroundPanel1 = new ComputerExam.Common.BackgroundPanel();
            this.txtTestResult = new ComputerExam.CustomControl.CustomRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExitSystem = new System.Windows.Forms.Button();
            this.cboSubject = new System.Windows.Forms.ComboBox();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTestEnvir = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.backgroundPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrCheckEnvironment
            // 
            this.tmrCheckEnvironment.Interval = 1000;
            this.tmrCheckEnvironment.Tick += new System.EventHandler(this.tmrCheckEnvironment_Tick);
            // 
            // backgroundPanel1
            // 
            this.backgroundPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backgroundPanel1.BackColor = System.Drawing.Color.Transparent;
            this.backgroundPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backgroundPanel1.BackgroundImage")));
            this.backgroundPanel1.Controls.Add(this.txtTestResult);
            this.backgroundPanel1.Controls.Add(this.label1);
            this.backgroundPanel1.Controls.Add(this.btnExitSystem);
            this.backgroundPanel1.Controls.Add(this.cboSubject);
            this.backgroundPanel1.Controls.Add(this.btnNextStep);
            this.backgroundPanel1.Controls.Add(this.pictureBox1);
            this.backgroundPanel1.Controls.Add(this.btnTestEnvir);
            this.backgroundPanel1.Controls.Add(this.lblError);
            this.backgroundPanel1.Location = new System.Drawing.Point(12, 6);
            this.backgroundPanel1.Name = "backgroundPanel1";
            this.backgroundPanel1.Size = new System.Drawing.Size(700, 400);
            this.backgroundPanel1.TabIndex = 1;
            // 
            // txtTestResult
            // 
            this.txtTestResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTestResult.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtTestResult.Location = new System.Drawing.Point(398, 154);
            this.txtTestResult.Name = "txtTestResult";
            this.txtTestResult.Size = new System.Drawing.Size(270, 120);
            this.txtTestResult.TabIndex = 11;
            this.txtTestResult.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(260, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "第一步：选择考试科目";
            // 
            // btnExitSystem
            // 
            this.btnExitSystem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExitSystem.BackgroundImage")));
            this.btnExitSystem.FlatAppearance.BorderSize = 0;
            this.btnExitSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitSystem.Location = new System.Drawing.Point(586, 291);
            this.btnExitSystem.Name = "btnExitSystem";
            this.btnExitSystem.Size = new System.Drawing.Size(79, 27);
            this.btnExitSystem.TabIndex = 6;
            this.btnExitSystem.Text = "退出系统";
            this.btnExitSystem.UseVisualStyleBackColor = true;
            this.btnExitSystem.Click += new System.EventHandler(this.btnExitSystem_Click);
            // 
            // cboSubject
            // 
            this.cboSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubject.FormattingEnabled = true;
            this.cboSubject.Location = new System.Drawing.Point(398, 127);
            this.cboSubject.Name = "cboSubject";
            this.cboSubject.Size = new System.Drawing.Size(270, 20);
            this.cboSubject.TabIndex = 3;
            // 
            // btnNextStep
            // 
            this.btnNextStep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNextStep.BackgroundImage")));
            this.btnNextStep.FlatAppearance.BorderSize = 0;
            this.btnNextStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextStep.Location = new System.Drawing.Point(501, 291);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(79, 27);
            this.btnNextStep.TabIndex = 7;
            this.btnNextStep.Text = "下一步";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(262, 155);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnTestEnvir
            // 
            this.btnTestEnvir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTestEnvir.BackgroundImage")));
            this.btnTestEnvir.FlatAppearance.BorderSize = 0;
            this.btnTestEnvir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestEnvir.Location = new System.Drawing.Point(395, 291);
            this.btnTestEnvir.Name = "btnTestEnvir";
            this.btnTestEnvir.Size = new System.Drawing.Size(100, 27);
            this.btnTestEnvir.TabIndex = 8;
            this.btnTestEnvir.Text = "检测答题环境";
            this.btnTestEnvir.UseVisualStyleBackColor = true;
            this.btnTestEnvir.Click += new System.EventHandler(this.btnTestEnvir_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(114, 363);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(401, 12);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "请选择一门考试科目，单机【检测答题环境】对所需的答题环境进行检测。";
            // 
            // frmExamSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(724, 412);
            this.ControlBox = false;
            this.Controls.Add(this.backgroundPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExamSubject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试登陆向导";
            this.Load += new System.EventHandler(this.frmExamSubject_Load);
            this.backgroundPanel1.ResumeLayout(false);
            this.backgroundPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboSubject;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnExitSystem;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Button btnTestEnvir;
        private Common.BackgroundPanel backgroundPanel1;
        private CustomControl.CustomRichTextBox txtTestResult;
        private System.Windows.Forms.Timer tmrCheckEnvironment;
    }
}
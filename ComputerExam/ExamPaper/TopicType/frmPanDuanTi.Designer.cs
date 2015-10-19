namespace ComputerExam.ExamPaper
{
    partial class frmPanDuanTi
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
            this.pnlPanDuan = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rdoError = new System.Windows.Forms.RadioButton();
            this.rdoRight = new System.Windows.Forms.RadioButton();
            this.pnlPanDuan.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPanDuan
            // 
            this.pnlPanDuan.Controls.Add(this.label5);
            this.pnlPanDuan.Controls.Add(this.label8);
            this.pnlPanDuan.Controls.Add(this.rdoError);
            this.pnlPanDuan.Controls.Add(this.rdoRight);
            this.pnlPanDuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPanDuan.Location = new System.Drawing.Point(0, 0);
            this.pnlPanDuan.Name = "pnlPanDuan";
            this.pnlPanDuan.Size = new System.Drawing.Size(519, 23);
            this.pnlPanDuan.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "（答题快捷键：正确使用 R 键，错误使用 W 键）";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "请选择：";
            // 
            // rdoError
            // 
            this.rdoError.AutoSize = true;
            this.rdoError.Location = new System.Drawing.Point(117, 6);
            this.rdoError.Name = "rdoError";
            this.rdoError.Size = new System.Drawing.Size(47, 16);
            this.rdoError.TabIndex = 19;
            this.rdoError.TabStop = true;
            this.rdoError.Text = "错误";
            this.rdoError.UseVisualStyleBackColor = true;
            this.rdoError.CheckedChanged += new System.EventHandler(this.rdoError_CheckedChanged);
            // 
            // rdoRight
            // 
            this.rdoRight.AutoSize = true;
            this.rdoRight.Location = new System.Drawing.Point(64, 6);
            this.rdoRight.Name = "rdoRight";
            this.rdoRight.Size = new System.Drawing.Size(47, 16);
            this.rdoRight.TabIndex = 18;
            this.rdoRight.TabStop = true;
            this.rdoRight.Text = "正确";
            this.rdoRight.UseVisualStyleBackColor = true;
            this.rdoRight.CheckedChanged += new System.EventHandler(this.rdoRight_CheckedChanged);
            // 
            // frmPanDuanTi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(519, 23);
            this.Controls.Add(this.pnlPanDuan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPanDuanTi";
            this.Text = "判断题";
            this.Load += new System.EventHandler(this.frmPanDuanTi_Load);
            this.pnlPanDuan.ResumeLayout(false);
            this.pnlPanDuan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.RadioButton rdoError;
        public System.Windows.Forms.RadioButton rdoRight;
        public System.Windows.Forms.Panel pnlPanDuan;
    }
}
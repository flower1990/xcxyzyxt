namespace ComputerExam.ExamPaper
{
    partial class frmTyping
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
            this.pnlTyping = new System.Windows.Forms.Panel();
            this.txtTyping = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTypingTime = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlTyping.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTyping
            // 
            this.pnlTyping.Controls.Add(this.txtTyping);
            this.pnlTyping.Controls.Add(this.panel1);
            this.pnlTyping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTyping.Location = new System.Drawing.Point(0, 0);
            this.pnlTyping.Name = "pnlTyping";
            this.pnlTyping.Size = new System.Drawing.Size(753, 395);
            this.pnlTyping.TabIndex = 2;
            // 
            // txtTyping
            // 
            this.txtTyping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTyping.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTyping.Location = new System.Drawing.Point(3, 32);
            this.txtTyping.Name = "txtTyping";
            this.txtTyping.Size = new System.Drawing.Size(747, 360);
            this.txtTyping.TabIndex = 30;
            this.txtTyping.Text = "";
            this.txtTyping.TextChanged += new System.EventHandler(this.txtTyping_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblTypingTime);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 23);
            this.panel1.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(371, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "红色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "请在编辑框中录入以上文字,体面文字展现为";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(248, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "蓝色";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(283, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "表示录入正确，";
            // 
            // lblTypingTime
            // 
            this.lblTypingTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTypingTime.AutoSize = true;
            this.lblTypingTime.Location = new System.Drawing.Point(606, 5);
            this.lblTypingTime.Name = "lblTypingTime";
            this.lblTypingTime.Size = new System.Drawing.Size(131, 12);
            this.lblTypingTime.TabIndex = 1;
            this.lblTypingTime.Text = "可用时间：18 分 88 秒";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(406, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "表示录入错误";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmTyping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(753, 395);
            this.Controls.Add(this.pnlTyping);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTyping";
            this.Text = "打字题";
            this.Load += new System.EventHandler(this.frmTyping_Load);
            this.pnlTyping.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.RichTextBox txtTyping;
        public System.Windows.Forms.Label lblTypingTime;
        public System.Windows.Forms.Panel pnlTyping;
        private System.Windows.Forms.Timer timer1;
    }
}
namespace ComputerExam.Common
{
    partial class FrmProcessing
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panImage = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panImage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbMessage, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 300);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panImage
            // 
            this.panImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panImage.Location = new System.Drawing.Point(150, 153);
            this.panImage.Name = "panImage";
            this.panImage.Padding = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.panImage.Size = new System.Drawing.Size(300, 94);
            this.panImage.TabIndex = 2;
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbMessage.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessage.ForeColor = System.Drawing.Color.White;
            this.lbMessage.Location = new System.Drawing.Point(150, 52);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(300, 98);
            this.lbMessage.TabIndex = 1;
            this.lbMessage.Text = "正在处理中，请稍候...";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // FrmProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProcessing";
            this.Opacity = 0.85D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmProcessing";
            this.Load += new System.EventHandler(this.FrmProcessing_Load);
            this.Shown += new System.EventHandler(this.FrmProcessing_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Panel panImage;
    }
}
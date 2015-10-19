using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputerExam.CustomControl
{
    /// <summary>
    /// 自定义控件：完全用户只读的RichTextBox：用来显示缩略图
    /// </summary>
    public class CustomRichTextBox : RichTextBox
    {
        private const int WM_SETFOCUS = 0x7;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        /// <summary>
        /// 构造函数：设置指针样式
        /// </summary>
        public CustomRichTextBox()    // 构造函数：设置指针样式
        {
            this.Cursor = Cursors.Arrow;    //设置鼠标样式   
        }

        /// <summary>
        /// 屏蔽控件所有鼠标消息的发送
        /// </summary>
        /// <param name="m">消息</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETFOCUS || 
                m.Msg == WM_KEYDOWN || 
                m.Msg == WM_KEYUP || 
                m.Msg == WM_LBUTTONDOWN || 
                m.Msg == WM_LBUTTONUP || 
                m.Msg == WM_LBUTTONDBLCLK || 
                m.Msg == WM_RBUTTONDOWN || 
                m.Msg == WM_RBUTTONUP || 
                m.Msg == WM_RBUTTONDBLCLK)
            {
                return;
            }
            base.WndProc(ref m);
        }
    }
}

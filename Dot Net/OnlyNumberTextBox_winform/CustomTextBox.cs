using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public class CustomTextBox : TextBox
    {
        private const int WM_CHAR  = 0x0102;  // 字符消息
        private const int WM_PASTE = 0x0302;  // 上下文菜单"粘贴"消息

        public CustomTextBox() { }

        /// <summary>
        /// 捕获Mouse的Paste消息
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE)  // 选择上下文菜单的"粘贴"操作
            {
                this.ClearSelection();
                SendKeys.Send(Clipboard.GetText());  // 模拟键盘输入
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        /// <summary>
        /// 捕获Ctrl+V快捷键操作
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys)Shortcut.CtrlV)  // 快捷键 Ctrl+V 粘贴操作
            {
                this.ClearSelection();

                string text = Clipboard.GetText();
                for (int k = 0; k < text.Length; k++) // can not use SendKeys.Send
                {
                    // 通过消息模拟键盘输入, SendKeys.Send()静态方法不行
                    SendCharKey(text[k]);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 屏蔽非数字键
        /// </summary>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (this.ReadOnly)
            {
                return;
            }
            
            // 特殊键, 不处理
            if ((int)e.KeyChar <= 31)
            {
                return;
            }

            // 非数字键, 放弃该输入
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 通过消息模拟键盘录入
        /// </summary>
        private void SendCharKey(char c)
        {
            Message msg = new Message();

            msg.HWnd = this.Handle;
            msg.Msg = WM_CHAR;
            msg.WParam = (IntPtr)c;
            msg.LParam = IntPtr.Zero;

            base.WndProc(ref msg);
        }

        /// <summary>
        /// 清除当前TextBox的选择
        /// </summary>
        private void ClearSelection()
        {
            if (this.SelectionLength == 0)
            {
                return;
            }

            int selLength = this.SelectedText.Length;
            this.SelectionStart += this.SelectedText.Length;  // 光标在选择之后
            this.SelectionLength = 0;

            for (int k = 1; k <= selLength; k++)
            {
                this.DeleteText(Keys.Back);
            }
        }

        /// <summary>
        /// 删除当前字符, 并计算SelectionStart值
        /// </summary>
        private void DeleteText(Keys key)
        {
            int selStart = this.SelectionStart;

            if (key == Keys.Delete)  // 转换Delete操作为BackSpace操作
            {
                selStart += 1;
                if (selStart > base.Text.Length)
                {
                    return;
                }
            }

            if (selStart == 0 || selStart > base.Text.Length)  // 不需要删除
            {
                return;
            }

            if (selStart == 1 && base.Text.Length == 1)
            {
                base.Text = "";
                base.SelectionStart = 0;
            }
            else  // selStart > 0
            {
                base.Text = base.Text.Substring(0, selStart - 1) + 
                    base.Text.Substring(selStart, base.Text.Length - selStart);
                base.SelectionStart = selStart - 1;
            }

        }
    }
}

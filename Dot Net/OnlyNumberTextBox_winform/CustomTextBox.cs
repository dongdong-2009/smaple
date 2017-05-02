using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public class CustomTextBox : TextBox
    {
        private const int WM_CHAR  = 0x0102;  // �ַ���Ϣ
        private const int WM_PASTE = 0x0302;  // �����Ĳ˵�"ճ��"��Ϣ

        public CustomTextBox() { }

        /// <summary>
        /// ����Mouse��Paste��Ϣ
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE)  // ѡ�������Ĳ˵���"ճ��"����
            {
                this.ClearSelection();
                SendKeys.Send(Clipboard.GetText());  // ģ���������
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        /// <summary>
        /// ����Ctrl+V��ݼ�����
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys)Shortcut.CtrlV)  // ��ݼ� Ctrl+V ճ������
            {
                this.ClearSelection();

                string text = Clipboard.GetText();
                for (int k = 0; k < text.Length; k++) // can not use SendKeys.Send
                {
                    // ͨ����Ϣģ���������, SendKeys.Send()��̬��������
                    SendCharKey(text[k]);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// ���η����ּ�
        /// </summary>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (this.ReadOnly)
            {
                return;
            }
            
            // �����, ������
            if ((int)e.KeyChar <= 31)
            {
                return;
            }

            // �����ּ�, ����������
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// ͨ����Ϣģ�����¼��
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
        /// �����ǰTextBox��ѡ��
        /// </summary>
        private void ClearSelection()
        {
            if (this.SelectionLength == 0)
            {
                return;
            }

            int selLength = this.SelectedText.Length;
            this.SelectionStart += this.SelectedText.Length;  // �����ѡ��֮��
            this.SelectionLength = 0;

            for (int k = 1; k <= selLength; k++)
            {
                this.DeleteText(Keys.Back);
            }
        }

        /// <summary>
        /// ɾ����ǰ�ַ�, ������SelectionStartֵ
        /// </summary>
        private void DeleteText(Keys key)
        {
            int selStart = this.SelectionStart;

            if (key == Keys.Delete)  // ת��Delete����ΪBackSpace����
            {
                selStart += 1;
                if (selStart > base.Text.Length)
                {
                    return;
                }
            }

            if (selStart == 0 || selStart > base.Text.Length)  // ����Ҫɾ��
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

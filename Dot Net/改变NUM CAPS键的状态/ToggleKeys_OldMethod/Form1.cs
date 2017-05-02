using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ToggleKeys_OldMethod
{
    public partial class Form1 : Form
    {
        #region DLL Imports 

        /// <summary>
        /// This function retrieves the status of the specified virtual key.
        /// The status specifies whether the key is up, down.
        /// </summary>
        /// <param name="keyCode">Specifies a key code for the button to me checked</param>
        /// <returns>Return value will be 0 if off and 1 if on</returns>
        [DllImport("user32.dll")]
        internal static extern short GetKeyState(int keyCode);

        /// <summary>
        /// This function is useful to simulate Key presses to the window with focus.
        /// </summary>
        /// <param name="bVk">Specifies a virtual-key code. The code must be a value in the range 1 to 254.</param>
        /// <param name="bScan">Specifies a hardware scan code for the key.</param>
        /// <param name="dwFlags"> Specifies various aspects of function operation. This parameter can be one or more of the following values.
        ///                         <code>KEYEVENTF_EXTENDEDKEY</code> or <code>KEYEVENTF_KEYUP</code>
        ///                         If specified, the key is being released. If not specified, the key is being depressed.</param>
        /// <param name="dwExtraInfo">Specifies an additional value associated with the key stroke</param>
        [DllImport("user32.dll")]        
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);        

        #endregion

        #region Constructor and Form Events 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // update the day and date
            labelDayDate.Text = System.DateTime.Today.DayOfWeek + ", " + System.DateTime.Today.Day + "-" + System.DateTime.Today.Month + "-" + System.DateTime.Today.Year;

            // read the current status of the specified keys
            UpdateKeys();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // only 3 keys are tested, u can add more
            // but
            // for a long list of keys SWITCH is recommended

            if (e.KeyData == Keys.Insert)
            {
                UpdateInsert();
            }
            else if (e.KeyData == Keys.NumLock)
            {
                UpdateNUMLock();
            }
            else if (e.KeyData == Keys.CapsLock)
            {
                UpdateCAPSLock();
            }            
        }

        private void lblINS_DoubleClick(object sender, EventArgs e)
        {
            PressKeyboardButton(Keys.Insert);
            UpdateInsert();
        }

        private void lblNUM_DoubleClick(object sender, EventArgs e)
        {
            PressKeyboardButton(Keys.NumLock);
            UpdateNUMLock();
        }

        private void lblCAPS_DoubleClick(object sender, EventArgs e)
        {
            PressKeyboardButton(Keys.CapsLock);
            UpdateCAPSLock();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            UpdateKeys();
        }
        
        #endregion

        #region Utility Methods 

        /// <summary>
        /// It checks the desired keys and update their status on the Form
        /// </summary>
        private void UpdateKeys()
        {
            UpdateInsert();
            UpdateNUMLock();
            UpdateCAPSLock();
        }

        /// <summary>
        /// Updates the Form according to the status of INSERT key 
        /// </summary>
        private void UpdateInsert()
        {
            bool NumLock = (GetKeyState((int)Keys.Insert)) != 0;

            if (NumLock)
            {
                lblINS.Text = "INS";
            }
            else
            {
                lblINS.Text = "OVR";
            }

            this.Refresh();
        }

        /// <summary>
        /// Updates the Form according to the status of NUM Lock key 
        /// </summary>
        private void UpdateNUMLock()
        {
            bool NumLock = (GetKeyState((int)Keys.NumLock)) != 0;

            if (NumLock)
            {
                lblNUM.Text = "NUM";
            }
            else
            {
                lblNUM.Text = String.Empty;
            }

            this.Refresh();
        }

        /// <summary>
        /// Updates the Form according to the status of CAPS Lock key 
        /// </summary>
        private void UpdateCAPSLock()
        {
            bool CapsLock = (GetKeyState((int)Keys.CapsLock)) != 0;

            if (CapsLock)
            {
                lblCAPS.Text = "CAPS";
            }
            else
            {
                lblCAPS.Text = String.Empty;
            }

            this.Refresh();
        }

        /// <summary>
        /// Simulate the Key Press Event
        /// </summary>
        /// <param name="keyCode">The code of the Key to be simulated</param>
        private void PressKeyboardButton(Keys keyCode)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    // This is your form.
    public partial class Form1 : Form
    {
        // This nested class must be ComVisible for the JavaScript to be able to call it.
        [ComVisible(true)]
        public class ScriptManager
        {
            // Variable to store the form of type Form1.
            private Form1 mForm;

            // Constructor.
            public ScriptManager(Form1 form)
            {
                // Save the form so it can be referenced later.
                mForm = form;
            }

            // This method can be called from JavaScript.
            public void MethodToCallFromScript()
            {
                // Call a method on the form.
                mForm.DoSomething();
            }

            // This method can also be called from JavaScript.
            public void AnotherMethod(string message)
            {
                MessageBox.Show(message);
            }
        }

        // This method will be called by the other method (MethodToCallFromScript) that gets called by JavaScript.
        public void DoSomething()
        {
            // Indicate success.
            MessageBox.Show("It worked!");
        }
        // Constructor.
        public Form1()
        {
            InitializeComponent();
            //webBrowser1 = new WebBrowser();
            //webBrowser1.Navigate("about:blank");
            // Set the WebBrowser to use an instance of the ScriptManager to handle method calls to C#.
            webBrowser1.ObjectForScripting = new ScriptManager(this);

            // Create the webpage.
//            webBrowser1.DocumentText = @"<html>
//                            <head>
//            	                <title>Testaa</title>
//                            </head>
//                            <body>
//            12313453
//            	            <input type=""button"" value=""Go!"" onclick=""window.external.MethodToCallFromScript();"" />
//                                <br />
//                                <input type=""button"" value=""Go Again!"" onclick=""window.external.AnotherMethod('Hello');"" />
//                            </body>
//                            </html>";
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Create the webpage.
            webBrowser1.Document.Write( @"<html>
                            <head>
            	                <title>Testaa</title>
                            </head>
                            <body>
            12313453
            	            <input type=""button"" value=""Go!"" onclick=""window.external.MethodToCallFromScript();"" />
                                <br />
                                <input type=""button"" value=""Go Again!"" onclick=""window.external.AnotherMethod('Hello');"" />
                            </body>
                            </html>");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsApplication1 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main() {

            System.Threading.Thread.CurrentThread.Name = "Main App";
            Application.Run(new Form1());
        }
    }
}
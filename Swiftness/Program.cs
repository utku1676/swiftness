using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace cpg.Swiftness
{
    static class Program
    {
        public static Forms.frmMain mainForm;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new Forms.frmMain();
            Application.Run(mainForm);
        }
    }
}

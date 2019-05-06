using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleOrder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form mainForm = new MainForm();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            //mainForm.WindowState = FormWindowState.Maximized;
            Application.Run(mainForm);
        }
    }
}

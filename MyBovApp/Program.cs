using MyBovApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;
using System.Globalization;
using System.Data;

namespace MyBovApp
{
    static class Program
    {
        public static Order order;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            order = new Order();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
        }
    }
}

using Management_Sytem.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Sytem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new Notification());
            //Application.Run(new Payment());
            //Application.Run(new Customer());
            //Application.Run(new Customer_Account());
            //Application.Run(new Partial_Payment_Tracker());
            //Application.Run(new Meter());
            //Application.Run(new Meter_Reading());
            //Application.Run(new Traiff_Plan());
            //Application.Run(new Bill());
            //Application.Run(new RegisterForm());
             //Application.Run(new CustomerDashboard());
        }
    }
}
    
﻿using System;
using System.Threading;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var message = String.Format("Sorry, something went wrong.\r\n{0}\r\nPlease contact support.",
                ((Exception)e.ExceptionObject).Message);
            Console.WriteLine("ERROR {0}: {1}", DateTimeOffset.Now, e.ExceptionObject);
            MessageBox.Show(message, "Unexpected Error");
        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var message = String.Format("Sorry, something went wrong.\r\n{0}\r\nPlease contact support.",
                e.Exception.Message);
            Console.WriteLine("ERROR {0}: {1}",DateTimeOffset.Now, e.Exception);
            MessageBox.Show(message, "Unexpected Error");
        }
    }
}

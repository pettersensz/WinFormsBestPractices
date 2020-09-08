using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.Objects;
using PluralsightWinFormsDemoApp.Presenters;

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
            var mainForm = new MainForm();
            var subscriptionManager = new SubscriptionManager("subscriptions.xml");
            var podcastLoader = new PodcastLoader();
            var podcastPlayer = new PodcastPlayer();
            var displayService = new MessageBoxDisplayService();
            var settingsService = new SettingsService();
            var systemInformationService = new SystemInformationService();
            var subscriptionService = new NewSubscriptionService();
            var presenter = new MainFormPresenter(mainForm, 
                subscriptionManager, 
                podcastLoader, 
                podcastPlayer,
                displayService,
                settingsService,
                systemInformationService,
                subscriptionService);
            Application.Run(mainForm);
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

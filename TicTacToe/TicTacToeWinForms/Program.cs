namespace TicTacToeWinForms
{
    using System;
    using System.Security.Principal;
    using System.Threading;
    using System.Windows.Forms;
    using Pdc;
    using UI;
    using Serilog;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.LiterateConsole()
                .CreateLogger();

            Application.ThreadException += Application_ThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = new Tmc.StartApplicatie();

            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
            host.BeforeRunning += delegate
            {
                if (SplashScreenForm.SplashScreen != null) {
                    AppDomain.CurrentDomain.AssemblyLoad -= CurrentDomain_AssemblyLoad;
                    SplashScreenForm.SplashScreen.Invoke(new MethodInvoker(SplashScreenForm.SplashScreen.Dispose));
                    SplashScreenForm.SplashScreen = null;
                }
            };

            host.Initializing += delegate
            {
                SplashScreenForm.ShowSplashScreen();
            };

            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
            host.Start();

            Log.CloseAndFlush();
        }

        private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            SplashScreenForm.MessageMethod($"Loading {args.LoadedAssembly.ManifestModule.Name}");
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var identity = WindowsIdentity.GetCurrent() as IIdentity;
            var ceh = new SerilogErrorHandler();
            ceh.Execute(SharedSettings.GetEmailAdres(), new Exception($"Identity: {identity.Name}\r\nexception type: {e.GetType()}\r\nMessage: {e.Exception.Message}", e.Exception));
            ceh = null;
        }
    }
}

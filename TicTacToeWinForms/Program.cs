using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeWinForms.Pdc;
using TicTacToeWinForms.UI;

namespace TicTacToeWinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = new TicTacToeWinForms.Tmc.StartApplicatie();
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
            host.BeforeRunning += delegate
            {
                if (SplashScreenForm.SplashScreen != null) {
                    AppDomain.CurrentDomain.AssemblyLoad -= CurrentDomain_AssemblyLoad;
                    SplashScreenForm.SplashScreen.BeginInvoke(new MethodInvoker(SplashScreenForm.SplashScreen.Dispose));
                    SplashScreenForm.SplashScreen = null;
                }
            };

            host.Initializing += delegate
            {
                SplashScreenForm.ShowSplashScreen();
            };

            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
            host.Start();
            //Application.Run(new UI.MainWindow());
        }

        private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            throw new NotImplementedException();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var identity = WindowsIdentity.GetCurrent() as IIdentity;

            var ceh = new CustomErrorHandler();
            ceh.Execute(SharedSettings.GetEmailAdres(),
                new Exception(string.Format("Identity: {0}\r\nexception type: {1}\r\nMessage: {2}",
                    identity.Name,
                    e.GetType(),
                    e.Exception.Message), e.Exception));
            ceh = null;
        }
    }
}

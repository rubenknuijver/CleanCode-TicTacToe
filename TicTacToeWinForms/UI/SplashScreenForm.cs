namespace TicTacToeWinForms.UI
{
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Deployment.Application;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    public sealed class SplashScreenForm :Form
    {
        public readonly string VersionText = "Tic-Tac-Toe"; // Application.ProductVersion;

        static List<string> _requestedFileList = new List<string>();
        static List<string> _parameterList = new List<string>();
        Bitmap _bitmap;

        public static SplashScreenForm SplashScreen { get; set; }
        public Label SplashMessages { get; set; }

        public SplashScreenForm()
        {
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Program));

            #region Correct version nummer
            if (SharedSettings.IsBeta)
                VersionText = string.Format("{0} Béta", VersionText);

            if (ApplicationDeployment.IsNetworkDeployed) {
                var ad = ApplicationDeployment.CurrentDeployment;
                VersionText = string.Format("{0} versie {1}", VersionText, ad.CurrentVersion);
            }
            else
                VersionText = string.Format("{0} versie {1}", VersionText, Application.ProductVersion);


#if DEBUG
            VersionText = string.Format("{0} (debug)", VersionText);
#endif
            #endregion

            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;

            // Stream must be kept open for the lifetime of the bitmap
            _bitmap = Resources.Superbad;
            ClientSize = _bitmap.Size;

            using (var font = new Font("Sans Serif", 10, FontStyle.Bold)) {
                using (var g = Graphics.FromImage(_bitmap)) {
                    using (var format = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center }) {
                        g.DrawString(VersionText, font, Brushes.DarkSlateGray, 200, 152, format);
                    }
                }
            }
            BackgroundImage = _bitmap;

            //this.ClientSize = new Size(400, 300);
            BackColor = Color.FromArgb(0xFB, 0xFC, 0xFD);
            TransparencyKey = Color.FromArgb(0xFB, 0xFC, 0xFD);

            SplashMessages = new Label()
            {
                Font = new Font("Sans Serif", 10, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Text = "Bezig met laden...",
                BackColor = Color.FromArgb(0xEF, 0xEF, 0xFF),
                //BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(4, 200),
                Size = new Size(392, 30)
            };
            Controls.Add(SplashMessages);

            //var xPos = 15;
            //var pictureBSNRB = new PictureBox()
            //{
            //    Image = Resources.BSNRB_kleur, //((System.Drawing.Image)(resources.GetObject("BSNRB_kleur"))),
            //    Location = new Point(xPos, 240),
            //    Name = "pictureBSNRB",
            //    Size = new Size(50, 50),
            //    SizeMode = PictureBoxSizeMode.StretchImage,
            //    TabIndex = 0,
            //    TabStop = false,
            //    BackColor = Color.FromArgb(0xF8, 0xF8, 0xF8),
            //};
            //Controls.Add(pictureBSNRB);
        }


        public void SetText()
        {
            //List<string> list = Properties.Resources.OneLiners.Replace(Environment.NewLine, "~").Split('~').ToList();
            //foreach (var item in list)
            //{
            //    SplashMessages.Text = "Building: " + item;
            //    Application.DoEvents();
            //    System.Threading.Thread.Sleep(50);
            //}
            //Dispose();
        }

        protected override void OnShown(EventArgs e)
        {
            //SplashScreen.SetText();
            base.OnShown(e);
        }

        public static void ShowSplashScreen()
        {
            ThreadPool.QueueUserWorkItem(state => {
                SplashScreen = new SplashScreenForm();
                SplashScreen.TopMost = true;
                SplashScreen.ShowDialog();
            });
        }

        public static void MessageMethod(string text)
        {
            if ((SplashScreen != null) && (!SplashScreen.IsDisposed)) {
                SplashScreen.WriteMsg(text);
            }
        }

        private void WriteMsg(string message)
        {
            #region Body
            if (SplashMessages.InvokeRequired) {
                var writeMsgDlg = new WriteMsgDlg(WriteMsg);
                SplashMessages.Invoke(writeMsgDlg, new object[] { message });
            }
            else {
                SplashMessages.Text = message;
            }
            #endregion
        }
        delegate void WriteMsgDlg(string message);

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (_bitmap != null) {
                    _bitmap.Dispose();
                    _bitmap = null;
                }
            }
            base.Dispose(disposing);
        }

        public static string[] GetParameterList()
        {
            return _parameterList.ToArray();
        }

        public static string[] GetRequestedFileList()
        {
            return _requestedFileList.ToArray();
        }

        public static void SetCommandLineArgs(string[] args)
        {
            _requestedFileList.Clear();
            _parameterList.Clear();

            foreach (var arg in args) {
                if (arg.Length == 0) continue;
                if (arg[0] == '-' || arg[0] == '/') {
                    var markerLength = 1;

                    if (arg.Length >= 2 && arg[0] == '-' && arg[1] == '-') {
                        markerLength = 2;
                    }

                    _parameterList.Add(arg.Substring(markerLength));
                }
                else {
                    _requestedFileList.Add(arg);
                }
            }
        }
    }
}

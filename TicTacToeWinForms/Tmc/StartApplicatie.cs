namespace TicTacToeWinForms.Tmc
{
    using Pdc;
    using System;
    //using System.Threading;
    using System.Windows.Forms;
    using UI;

    public class StartApplicatie
    {

        private Timer _gameTimer;
        private MainWindow _mainWindow;
        private DateTime _startTime;

        public string VersionText { get; private set; }

        public event Action BeforeRunning;
        public event Action Initializing;

        /// <summary>
        /// Triggers the Initializing event.
        /// </summary>
        public virtual void OnInitializing()
        {
            Initializing?.Invoke();
        }


        /// <summary>
        /// Triggers the BeforeRunning event.
        /// </summary>
        public virtual void OnBeforeRunning()
        {
            BeforeRunning?.Invoke();
        }

        public void Start()
        {
            OnInitializing();

            try {
                using (_mainWindow = new MainWindow()) {

                    InitForm(_mainWindow);

                    System.Threading.Thread.Sleep(5000);
                    OnBeforeRunning();

                    _startTime = DateTime.Now;
                    _mainWindow.ShowDialog();
                }
            }
            catch (Exception ex) {
                var ceh = new CustomErrorHandler();
                ceh.Execute(SharedSettings.GetEmailAdres(), ex);
                ceh = null;
            }
        }

        private void InitForm(MainWindow form)
        {
            form.SuspendLayout();
            form.Text = VersionText;
            form.FormClosing += ApplicationClosing;

            _gameTimer = new Timer();
            _gameTimer.Tick += UpdateTimer_Tick;
            _gameTimer.Interval = 1000; // every second;
            _gameTimer.Start();

            form.ResumeLayout();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {

            _mainWindow.SetStatusTime(DateTime.Now - _startTime);
        }

        private void ApplicationClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            
        }
    }
}
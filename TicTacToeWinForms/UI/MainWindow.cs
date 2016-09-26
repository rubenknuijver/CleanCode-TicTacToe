using System;
using GameLibrary;

namespace TicTacToeWinForms.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    public partial class MainWindow : Form
    {
        public event CancelEventHandler RequestingStart;

        public event CancelEventHandler RequestingStop;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Setup(Action tasks)
        {
            this.SuspendLayout();
            tasks?.Invoke();
            this.ResumeLayout();
        }

        public void SetupGameBindings(Game game)
        {
            this.playerList.DataSource = game.Players;
            this.gameRounds.DataBindings.Add("Value", game, "MaxRounds", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void SetStatusText(string text)
        {
            this.toolStripStatusLabel1.Text = text;
        }

        public void SetStatusTime(TimeSpan time)
        {
            if (time < TimeSpan.FromSeconds(1)) {
                return;
            }

            if (this.InvokeRequired) {
                Action<TimeSpan> method = SetStatusTime;
                this.Invoke(method, time);
            }

            this.toolStripStatusLabel2.Text = time.ToString(@"hh\:mm\:ss");
        }

        public void RegisterStartGameAction(Action action)
        {
            this.RequestingStart += (sender, args) => {
                action?.Invoke();
            };
        }

        public void RegisterStopGameAction(Action action)
        {
            this.RequestingStop += (sender, args) => {
                action?.Invoke();
            };
        }

        public void RegisterClearBoardAction(Action action)
        {
            this.buttonResetBoard.Click += (sender, args) => {
                action?.Invoke();
            };
        }
        public void RegisterClosingAction(Action action)
        {
            this.FormClosing += (sender, eventArgs) => {
                action?.Invoke();
            };
        }

        public void RegisterPlayerConfigurationAction(Action action)
        {
            this.btnConfigPlayers.Click += (sender, args) => {
                action?.Invoke();
            };
        }

        public List<T> FindControlBy<T>(Predicate<T> findBy, bool searchDescendants)
            where T : Control
        {
            return FindControlBy<T>(this, findBy, searchDescendants);
        }

        internal List<T> FindControlBy<T>(Control controlToSearch, Predicate<T> findBy, bool searchDescendants)
            where T : Control
        {
            var result = new List<T>();
            foreach (Control c in controlToSearch.Controls) {
                if (c is T && findBy(c as T)) {
                    result.Add(c as T);
                }
                if (searchDescendants) {
                    result.AddRange(FindControlBy<T>(c, findBy, true));
                }
            }
            return result;
        }

        private void StarPlaying()
        {
            var cancelEventArgs = new CancelEventArgs();
            this.RequestingStart?.Invoke(this, cancelEventArgs);
            if (!cancelEventArgs.Cancel) {
                this.buttonStartStop.Text = "Stop";
                this.panelSettings.Enabled = false;
                this.panelGrid.Enabled = true;
            }
        }

        private void StopPlaying()
        {
            var cancelEventArgs = new CancelEventArgs();
            this.RequestingStop?.Invoke(this, cancelEventArgs);
            if (!cancelEventArgs.Cancel) {
                this.buttonStartStop.Text = "Start";
                this.panelSettings.Enabled = true;
                this.panelGrid.Enabled = false;
            }
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (this.panelSettings.Enabled) {
                this.StarPlaying();
            }
            else {
                this.StopPlaying();
            }
        }
    }
}

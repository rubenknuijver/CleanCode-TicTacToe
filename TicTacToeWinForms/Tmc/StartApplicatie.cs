namespace TicTacToeWinForms.Tmc
{
    using GameLibrary;
    using GameLibrary.Board;
    using GameLibrary.Events;
    using GameLibrary.Players;
    using Pdc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using UI;
    using UI.Controls;

    public class StartApplicatie
    {

        private Timer _gameTimer;
        private MainWindow _mainWindow;
        private DateTime _startTime;

        private Game _game = null;
        private BoardAgent _gameBoardAgent = null;

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

        /// <summary>
        /// Start your game Engines
        /// </summary>
        public void Start()
        {
            OnInitializing();

            //try {
            var board = new GameBoard(3, 3);
            _game = new Game(new InMemoryBus(), board, 2, 3);
            _game.Rules.Add(new GameLibrary.Utils.TicTacToe_WinningMoveRule());
            _game.Rules.Add(new GameLibrary.Utils.TicTacToe_CanStillTakeTurnsRule());
            _game.Bus.RegisterHandler(new GenericEventHandler<RoundWinnerEvent>(e => {
                if (MessageBox.Show($"And the winner is.. {e.Round.Winner.Name}", "Game Winner", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    
                }
            }));

            _game.Bus.RegisterHandler(new GenericEventHandler<RoundCompletedEvent>(e => {
                if(e.Round.Winner == null) {
                    MessageBox.Show($"It's a draw...");
                }                
            }));

            board.Initialize();

            using (_mainWindow = new MainWindow()) {

                InitForm(_mainWindow);

                System.Threading.Thread.Sleep(1000);
                OnBeforeRunning();

                _startTime = DateTime.Now;
                _mainWindow.ShowDialog();
            }
            /*  }
              catch (Exception ex) {
                  var ceh = new CustomErrorHandler();
                  ceh.Execute(SharedSettings.GetEmailAdres(), ex);
                  ceh = null;
              }
              */
        }

        private void InitForm(MainWindow form)
        {
            form.Setup(() => {
                form.Text = VersionText;

                form.RegisterClosingAction(ApplicationClosing);
                form.RegisterPlayerConfigurationAction(PlayerConfiguration);
                form.SetupGameBindings(_game);
                    
                var v = form.FindControlBy<Control>(f => f.Tag != null, true);
                Array.ForEach(v.Select(s => s.Tag).ToArray(), (a) => System.Diagnostics.Debug.WriteLine(a));

                _gameBoardAgent = new BoardAgent(_game, form.panelGrid);
                _gameBoardAgent.Prepare();

                form.RegisterStartGameAction(() => {
                    if (_game.PrepareGameRound()) {
                        _gameBoardAgent.Prepare();
                    }
                    if (!_game.CurrentGameRound.HasStarted) {
                        _game.CurrentGameRound.Start();
                    }
                });

                form.RegisterStopGameAction(() => {

                });

                form.RegisterClearBoardAction(() => {
                    _game.Board.Clear();
                    _gameBoardAgent.Prepare();
                });
            });

            _gameTimer = new Timer();
            _gameTimer.Tick += UpdateTimer_Tick;
            _gameTimer.Interval = 10; // every 10th second;
            _gameTimer.Start();
        }


        private void PlayerConfiguration()
        {
            var playerConfiguration = new PlayerConfiguration(_game);
            if (playerConfiguration.Show()) {
                _gameBoardAgent.Prepare();
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            _mainWindow.SetStatusTime(DateTime.Now - _startTime);
            _gameBoardAgent.Pulse();
        }

        private void ApplicationClosing()
        {
            MessageBox.Show("Farewell.. and Goodbye!");
        }
    }
}
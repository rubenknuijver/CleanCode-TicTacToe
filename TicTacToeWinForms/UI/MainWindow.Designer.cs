using TicTacToeWinForms.UI.Controls;

namespace TicTacToeWinForms.UI
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.btnConfigPlayers = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gameRounds = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.buttonResetBoard = new System.Windows.Forms.Button();
            this.playerList = new TicTacToeWinForms.UI.Controls.GamePlayerListBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameRounds)).BeginInit();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(509, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "ready.";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(49, 17);
            this.toolStripStatusLabel2.Text = "00:00:00";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(51, 17);
            this.toolStripStatusLabel3.Tag = "CurrentRoundDisplay";
            this.toolStripStatusLabel3.Text = "Round 0";
            // 
            // panelGrid
            // 
            this.panelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrid.BackColor = System.Drawing.Color.Snow;
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrid.Location = new System.Drawing.Point(12, 12);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(404, 404);
            this.panelGrid.TabIndex = 1;
            this.panelGrid.Tag = "GameBoard";
            // 
            // btnConfigPlayers
            // 
            this.btnConfigPlayers.Location = new System.Drawing.Point(0, 0);
            this.btnConfigPlayers.Name = "btnConfigPlayers";
            this.btnConfigPlayers.Size = new System.Drawing.Size(190, 30);
            this.btnConfigPlayers.TabIndex = 0;
            this.btnConfigPlayers.Text = "Players";
            this.btnConfigPlayers.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // gameRounds
            // 
            this.gameRounds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameRounds.Location = new System.Drawing.Point(3, 49);
            this.gameRounds.Name = "gameRounds";
            this.gameRounds.Size = new System.Drawing.Size(184, 20);
            this.gameRounds.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rounds";
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartStop.Location = new System.Drawing.Point(422, 214);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(190, 30);
            this.buttonStartStop.TabIndex = 2;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.btnConfigPlayers);
            this.panelSettings.Controls.Add(this.gameRounds);
            this.panelSettings.Controls.Add(this.label1);
            this.panelSettings.Location = new System.Drawing.Point(422, 12);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(190, 78);
            this.panelSettings.TabIndex = 4;
            this.panelSettings.Tag = "PlayerConfiguration";
            // 
            // buttonResetBoard
            // 
            this.buttonResetBoard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetBoard.Location = new System.Drawing.Point(422, 178);
            this.buttonResetBoard.Name = "buttonResetBoard";
            this.buttonResetBoard.Size = new System.Drawing.Size(190, 30);
            this.buttonResetBoard.TabIndex = 5;
            this.buttonResetBoard.Tag = "ResetBoard";
            this.buttonResetBoard.Text = "Reset Board";
            this.buttonResetBoard.UseVisualStyleBackColor = true;
            // 
            // playerList
            // 
            this.playerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerList.BackColor = System.Drawing.Color.LemonChiffon;
            this.playerList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.playerList.Enabled = false;
            this.playerList.FormattingEnabled = true;
            this.playerList.ItemHeight = 20;
            this.playerList.Location = new System.Drawing.Point(422, 250);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(190, 164);
            this.playerList.TabIndex = 3;
            this.playerList.Tag = "GamePlayers";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.buttonResetBoard);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.playerList);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameRounds)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        public System.Windows.Forms.Button btnConfigPlayers;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Panel panelGrid;
        public GamePlayerListBox playerList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Panel panelSettings;
        public System.Windows.Forms.NumericUpDown gameRounds;
        private System.Windows.Forms.Button buttonResetBoard;
    }
}
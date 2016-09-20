using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeWinForms.UI
{
    public partial class MainWindow : Form, IStatusPresentor
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetStatusText(string text)
        {
            toolStripStatusLabel1.Text = text;
        }

        public void SetStatusTime(TimeSpan time)
        {
            if(time < TimeSpan.FromSeconds(1)) {
                return;
            }

            if (this.InvokeRequired) {
                Action<TimeSpan> method = SetStatusTime;
                this.Invoke(method, time);
            }
            toolStripStatusLabel2.Text = time.ToString(@"hh\:mm\:ss");
        }
    }
}

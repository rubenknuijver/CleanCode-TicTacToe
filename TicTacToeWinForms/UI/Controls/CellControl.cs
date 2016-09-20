namespace TicTacToeWinForms.UI.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class CellControl : UserControl
    {
        public CellControl()
        {
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Cursor = Cursors.Hand;
            this.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}

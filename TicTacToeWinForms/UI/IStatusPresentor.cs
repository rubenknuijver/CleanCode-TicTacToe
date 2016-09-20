using System;

namespace TicTacToeWinForms.UI
{
    public interface IStatusPresentor : IPresentor
    {
        void SetStatusText(string text);
        void SetStatusTime(TimeSpan time);
    }

    public interface IPresentor
    {
    }
}
using Serilog;
using System;

namespace TicTacToeWinForms.Pdc
{
    public class SerilogErrorHandler
    {
        public void Execute(string emailAddress, Exception exception)
        {
            Log.Error(exception, "Something went wrong");
        }
    }
}
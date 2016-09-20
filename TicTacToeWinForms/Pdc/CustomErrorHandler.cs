using System;

namespace TicTacToeWinForms.Pdc
{
    public class CustomErrorHandler
    {
        public CustomErrorHandler()
        {
        }

        public void Execute(string emailAddress, Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}
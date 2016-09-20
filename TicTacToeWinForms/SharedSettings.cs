namespace TicTacToeWinForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SharedSettings
    {
        public static bool IsBeta { get; internal set; }

        internal static string GetEmailAdres()
        {
            return "r.knuijver@tasper.nl";
        }
    }
}

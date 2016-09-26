namespace TicTacToeWinForms.Pdc
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class BusinessObjectBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }

}

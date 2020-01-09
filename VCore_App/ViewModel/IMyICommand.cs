using System;

namespace VCore_App.ViewModel
{
    public interface IMyICommand
    {
        event EventHandler CanExecuteChanged;

        void RaiseCanExecuteChanged();
    }
}
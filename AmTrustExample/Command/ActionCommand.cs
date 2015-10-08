#region Using Statements
using System;
using System.Windows.Input;

#endregion

namespace AmTrustExample.Command
{
    public class ActionCommand : ICommand
    {
        public Predicate<object> CanExecuteDelegate { get; set; }
        private readonly Action<object> _codeToExecute;

        public ActionCommand(Action<object> codeToExecute)
        {
            _codeToExecute = codeToExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
                return CanExecuteDelegate(parameter);
            return true; // if there is no can execute default to true
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (_codeToExecute != null) _codeToExecute(null);
        }
    }
}
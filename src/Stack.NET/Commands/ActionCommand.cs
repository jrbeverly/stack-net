using System;
using System.Windows.Input;

namespace Stack.NET.Commands
{
    /// <summary>A basic implementation of ICommand that wraps a method that takes no parameters or a method that takes one parameter.</summary>
    /// <seealso
    ///     cref="https://msdn.microsoft.com/en-us/library/microsoft.expression.interactivity.core.actioncommand(v=expression.40).aspx" />
    public sealed class ActionCommand : ICommand
    {
        private readonly Action _action;

        /// <summary>Initializes a new instance of the ActionCommand class.</summary>
        /// <param name="action">An action.</param>
        public ActionCommand(Action action)
        {
            _action = action;
        }

        /// <inheritdoc />
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc />
        public void Execute(object parameter)
        {
            _action();
        }

        /// <inheritdoc />
        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
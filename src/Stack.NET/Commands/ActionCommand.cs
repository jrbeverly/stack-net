using System;
using System.Windows.Input;

namespace Stack.NET.Commands
{
    /// <summary>
    ///     A basic implementation of ICommand that wraps a method that takes no parameters or a method that takes one
    ///     parameter.
    /// </summary>
    /// <seealso
    ///     cref="https://msdn.microsoft.com/en-us/library/microsoft.expression.interactivity.core.actioncommand(v=expression.40).aspx" />
    public sealed class ActionCommand : ICommand
    {
        private readonly Action _action;

        /// <summary>
        ///     Initializes a new instance of the ActionCommand class.
        /// </summary>
        /// <param name="action">An action.</param>
        public ActionCommand(Action action)
        {
            _action = action;
        }

        /// <summary>
        ///     Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        ///     Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">
        ///     Data used by the command. If the command does not require data to be passed, then this object
        ///     can be set to null.
        /// </param>
        public void Execute(object parameter)
        {
            _action();
        }

        /// <summary>
        ///     Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">
        ///     Data used by the command. If the command does not require data to be passed, this object can be
        ///     set to null.
        /// </param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
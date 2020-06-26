using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hello_World.Infrastructure.Commands
{
#pragma warning disable SA1402 // File may only contain a single class

    public abstract class AsyncCommandBase : ICommand
    {
        /// <summary>Occurs when changes occur that affect whether or not the command should execute. </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract Task ExecuteAsync();

        public abstract bool CanExecuteTask();

        [DebuggerStepThrough]
        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            this.Execute();
        }

        /// <summary>Triggers the CanExecuteChanged event</summary>
        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>Defines the method that determines whether the command can execute in its current state.</summary>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        protected bool CanExecute()
        {
            return this.CanExecuteTask();
        }

        /// <summary>Defines the method to be called when the command is invoked. </summary>
        protected async void Execute()
        {
            if (this.CanExecuteTask() == false)
            {
                return;
            }

            this.RaiseCanExecuteChanged();

            try
            {
                await this.ExecuteAsync();
            }
            finally
            {
                this.RaiseCanExecuteChanged();
            }
        }
    }

    public abstract class AsyncCommandBase<T> : ICommand
    {
        /// <summary>Occurs when changes occur that affect whether or not the command should execute. </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public abstract Task ExecuteAsync(T parameter);

        public abstract bool CanExecuteTask(T parameter);

        bool ICommand.CanExecute(object parameter)
        {
            if (typeof(T).IsValueType && parameter == null)
            {
                return false;
            }

            return this.CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            if (typeof(T).IsValueType && parameter == null)
            {
                return;
            }

            this.Execute((T)parameter);
        }

        /// <summary>Gets a value indicating whether the command can execute in its current state. </summary>
        /// <param name="parameter">The parameter for the command.</param>
        /// <returns>A value indicating whether the command can execute in its current state.</returns>
        protected bool CanExecute(T parameter)
        {
            return this.CanExecuteTask(parameter);
        }

        /// <summary>Defines the method to be called when the command is invoked. </summary>
        /// <param name="parameter">The parameter for the command.</param>
        protected async void Execute(T parameter)
        {
            if (this.CanExecuteTask(parameter) == false)
            {
                return;
            }

            this.RaiseCanExecuteChanged();

            try
            {
                await this.ExecuteAsync(parameter);
            }
            finally
            {
                this.RaiseCanExecuteChanged();
            }
        }

        /// <summary>Triggers the CanExecuteChanged event</summary>
        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
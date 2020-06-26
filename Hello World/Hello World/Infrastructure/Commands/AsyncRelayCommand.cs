using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hello_World.Infrastructure.Commands
{
#pragma warning disable SA1402 // File may only contain a single class

    /// <summary>Provides an async implementation of the <see cref="ICommand"/> interface. 
    /// The command is inactive when the command's task is running. </summary>
    public class AsyncRelayCommand : AsyncCommandBase
    {
        private readonly Func<Task> execute;

        private readonly Func<bool> canExecute;

        /// <summary>Initializes a new instance of the <see cref="AsyncRelayCommand"/> class. </summary>
        /// <param name="execute">The function to execute. </param>
        public AsyncRelayCommand(Func<Task> execute)
            : this(execute, () => true)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AsyncRelayCommand"/> class. </summary>
        /// <param name="execute">The function. </param>
        /// <param name="canExecute">The predicate to check whether the function can be executed. </param>
        public AsyncRelayCommand(Func<Task> execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public override Task ExecuteAsync()
        {
            return this.execute();
        }

        public override bool CanExecuteTask()
        {
            return this.canExecute();
        }
    }

    /// <summary>Provides an implementation of the <see cref="ICommand"/> interface. </summary>
    /// <typeparam name="TParameter">The type of the command parameter. </typeparam>
    public class AsyncRelayCommand<TParameter> : AsyncCommandBase<TParameter>
    {
        private readonly Func<TParameter, Task> execute;

        private readonly Predicate<TParameter> canExecute;

        /// <summary>Initializes a new instance of the <see cref="AsyncRelayCommand{TParameter}"/> class. </summary>
        /// <param name="execute">The function. </param>
        public AsyncRelayCommand(Func<TParameter, Task> execute)
            : this(execute, param => true)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AsyncRelayCommand{TParameter}"/> class. </summary>
        /// <param name="execute">The function. </param>
        /// <param name="canExecute">The predicate to check whether the function can be executed. </param>
        public AsyncRelayCommand(Func<TParameter, Task> execute, Predicate<TParameter> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public override Task ExecuteAsync(TParameter parameter)
        {
            return this.execute(parameter);
        }

        public override bool CanExecuteTask(TParameter parameter)
        {
            return this.canExecute(parameter);
        }
    }
}
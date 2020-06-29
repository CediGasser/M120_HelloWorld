//-----------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="MyToolkit">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/MyToolkit/MyToolkit/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Hello_World.Infrastructure.Commands
{
#pragma warning disable SA1402 // File may only contain a single class

    /// <summary>Provides an implementation of the <see cref="ICommand"/> interface. </summary>
    public class RelayCommand : CommandBase
    {
        private readonly Action execute;

        private readonly Func<bool> canExecute;

        /// <summary>Initializes a new instance of the <see cref="RelayCommand"/> class. </summary>
        /// <param name="execute">The action to execute. </param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RelayCommand"/> class. </summary>
        /// <param name="execute">The action to execute. </param>
        /// <param name="canExecute">The predicate to check whether the function can be executed. </param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>Defines the method that determines whether the command can execute in its current state.</summary>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public override bool CanExecute()
        {
            return this.canExecute == null || this.canExecute();
        }

        /// <summary>Defines the method to be called when the command is invoked. </summary>
        public override void Execute()
        {
            this.execute();
        }
    }

    /// <summary>Provides an implementation of the <see cref="ICommand"/> interface. </summary>
    /// <typeparam name="T">The type of the command parameter. </typeparam>
    public class RelayCommand<T> : CommandBase<T>
    {
        private readonly Action<T> execute;

        private readonly Predicate<T> canExecute;

        /// <summary>Initializes a new instance of the <see cref="RelayCommand{T}"/> class. </summary>
        /// <param name="execute">The action to execute. </param>
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RelayCommand{T}"/> class. </summary>
        /// <param name="execute">The action to execute. </param>
        /// <param name="canExecute">The predicate to check whether the function can be executed. </param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <inheritdoc />
        [DebuggerStepThrough]
        public override bool CanExecute(T parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <inheritdoc />
        public override void Execute(T parameter)
        {
            this.execute(parameter);
        }
    }
}
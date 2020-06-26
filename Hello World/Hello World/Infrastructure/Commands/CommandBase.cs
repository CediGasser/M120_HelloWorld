//-----------------------------------------------------------------------
// <copyright file="CommandBase.cs" company="MyToolkit">
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

    /// <summary>Provides a base implementation of the <see cref="ICommand"/> interface. </summary>
    public abstract class CommandBase : ICommand
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

        /// <summary>Tries to execute the command by checking the <see cref="CanExecute"/> property 
        /// and executes the command only when it can be executed. </summary>
        /// <returns>True if command has been executed; false otherwise. </returns>
        public bool TryExecute()
        {
            if (!this.CanExecute())
            {
                return false;
            }

            this.Execute();
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            this.Execute();
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute();
        }

        /// <summary>Defines the method that determines whether the command can execute in its current state.</summary>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public abstract bool CanExecute();

        /// <summary>Defines the method to be called when the command is invoked. </summary>
        public abstract void Execute();
    }

    /// <summary>Provides an implementation of the <see cref="ICommand"/> interface. </summary>
    /// <typeparam name="T">The type of the command parameter. </typeparam>
    public abstract class CommandBase<T> : ICommand
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

        /// <summary>Tries to execute the command by calling the <see cref="CanExecute"/> method 
        /// and executes the command only when it can be executed. </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns>True if command has been executed; false otherwise. </returns>
        public bool TryExecute(T parameter)
        {
            if (!this.CanExecute(parameter))
            {
                return false;
            }

            this.Execute(parameter);
            return true;
        }

        [DebuggerStepThrough]
        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            this.Execute((T)parameter);
        }

        /// <summary>Gets a value indicating whether the command can execute in its current state. </summary>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        /// <param name="parameter">Data used by the command.</param>
        [DebuggerStepThrough]
        public abstract bool CanExecute(T parameter);

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        public abstract void Execute(T parameter);
    }
}
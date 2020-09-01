using System;
using System.Windows;
using Hello_World.Infrastructure.ViewModels;

namespace Hello_World.GamePage
{
    public interface IWindowDisplayer
    {
        public void ShowWindow<T>(Func<T> windowCreationFunction, IViewModel dataContext) where T : Window
        {
        }

        public void ShowDialogWindow<T>(Func<T> windowCreationFunction, IViewModel dataContext) where T : Window
        {
        }
    }
}
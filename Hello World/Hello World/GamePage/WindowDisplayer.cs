using System;
using System.Windows;
using Hello_World.Infrastructure.ViewModels;

namespace Hello_World.GamePage
{
    public class WindowDisplayer : IWindowDisplayer
    {
        public void ShowWindow<T>(Func<T> windowCreationFunction, IViewModel dataContext) where T : Window
        {
            T window = windowCreationFunction.Invoke();
            window.DataContext = dataContext;
            window.Show();
        }


        public void ShowDialogWindow<T>(Func<T> windowCreationFunction, IViewModel dataContext) where T : Window
        {
            T window = windowCreationFunction.Invoke();

            window.DataContext = dataContext;
            window.ShowDialog();
        }
    }
}
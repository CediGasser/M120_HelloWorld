using System.Windows;
using Hello_World.Core;

namespace Hello_World.Infrastructure
{
    internal class ErrorMessageDisplayer : IErrorMessageDisplayer
    {
        public void Show(string errorTitle, string errorMessage)
        {
            MessageBox.Show(errorMessage, errorTitle);
        }
    }
}
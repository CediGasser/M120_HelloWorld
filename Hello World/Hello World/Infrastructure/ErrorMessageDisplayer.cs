using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Hello_World.Core;

namespace Hello_World.Infrastructure
{
    class ErrorMessageDisplayer:IErrorMessageDisplayer
    {
        public void Show(string errorTitle, string errorMessage)
        {
            MessageBox.Show(errorMessage, errorTitle);
        }
    }
}

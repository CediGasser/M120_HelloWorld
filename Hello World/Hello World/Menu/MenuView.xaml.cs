using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hello_World.Menu
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : Window
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void MenuView_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                ((MenuViewModel)e.OldValue).CloseRequested -= this.OnCloseRequested;
            }

            ((MenuViewModel)e.NewValue).CloseRequested += this.OnCloseRequested;
        }

        private void OnCloseRequested(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}

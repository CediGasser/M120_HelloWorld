#nullable enable
using System;
using System.ComponentModel;
using System.Windows;

namespace Hello_World.Menu
{
    /// <summary>
    ///     Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : Window
    {
        public MenuView()
        {
            this.InitializeComponent();
        }

        private void MenuView_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null) ((MenuViewModel) e.OldValue).CloseRequested -= this.OnCloseRequested;

            ((MenuViewModel) e.NewValue).CloseRequested += this.OnCloseRequested;
        }

        private void OnCloseRequested(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuView_OnClosing(object sender, CancelEventArgs e)
        {
            ((MenuViewModel) this.DataContext).IsWindowClosed = true;
        }
    }
}
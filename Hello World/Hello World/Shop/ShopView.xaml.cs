#nullable enable
using System;
using System.ComponentModel;
using System.Windows;

namespace Hello_World.Shop
{
    /// <summary>
    ///     Interaction logic for ShopView.xaml
    /// </summary>
    public partial class ShopView : Window
    {
        public ShopView()
        {
            this.InitializeComponent();
        }

        private void ShopView_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                ((ShopViewModel) e.OldValue).CloseRequested -= this.OnCloseRequested;
                ((ShopViewModel) e.OldValue).BringToFrontRequested -= this.OnBringToFrontRequested;
            }

            ((ShopViewModel) e.NewValue).CloseRequested += this.OnCloseRequested;
            ((ShopViewModel) e.NewValue).BringToFrontRequested += this.OnBringToFrontRequested;
        }

        private void OnBringToFrontRequested(object? sender, EventArgs e)
        {
            this.Activate();
        }

        private void OnCloseRequested(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void ShopView_OnClosing(object sender, CancelEventArgs e)
        {
            ((ShopViewModel) this.DataContext).IsWindowClosed = true;
        }
    }
}
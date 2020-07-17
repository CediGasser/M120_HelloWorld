using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hello_World.Menu;

namespace Hello_World.Shop
{
    /// <summary>
    /// Interaction logic for ShopView.xaml
    /// </summary>
    public partial class ShopView : Window
    {
        public ShopView()
        {
            InitializeComponent();
        }

        private void ShopView_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                ((ShopViewModel)e.OldValue).CloseRequested -= this.OnCloseRequested;
                ((ShopViewModel)e.OldValue).BringToFrontRequested -= this.OnBringToFrontRequested;
            }

            ((ShopViewModel)e.NewValue).CloseRequested += this.OnCloseRequested;
            ((ShopViewModel)e.NewValue).BringToFrontRequested += this.OnBringToFrontRequested;
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

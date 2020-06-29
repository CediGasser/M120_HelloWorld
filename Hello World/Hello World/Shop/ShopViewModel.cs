using System;
using System.Collections.Generic;
using System.Text;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.ViewModels;

namespace Hello_World.Shop
{
    class ShopViewModel : ViewModelBase
    {
        private Game game;

        public readonly List<ListViewModel> ListViewModels = new List<ListViewModel>();

        public ShopViewModel(Game game)
        {
            this.game = game;
            LoadListView();
        }

        private void LoadListView()
        {
            foreach (IHelloWorldProducer helloWorldProducer in this.HelloWorldProducers)
            {
                ListViewModels.Add(new ListViewModel(helloWorldProducer));
            }
        }

        public List<IHelloWorldProducer> HelloWorldProducers => game.HelloWorldProducers;
    }
}

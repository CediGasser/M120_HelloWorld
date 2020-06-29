using System;
using System.Collections.Generic;
using System.Text;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;

namespace Hello_World.Shop
{
    class ListViewModel
    {
        private readonly IHelloWorldProducer helloWorldProducer;

        public ListViewModel(IHelloWorldProducer helloWorldProducer)
        {
            this.helloWorldProducer = helloWorldProducer;

            OnBuyButtonClickCommand = new RelayCommand(OnBuyButtonClick);
        }

        private void OnBuyButtonClick()
        {
            helloWorldProducer.AddToCount();
        }

        public RelayCommand OnBuyButtonClickCommand { get; }


    }
}

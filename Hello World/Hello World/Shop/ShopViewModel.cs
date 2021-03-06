﻿using System;
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

        public ShopViewModel(Game game)
        {
            this.game = game;
            OnBuyButtonClickCommand = new RelayCommand<Device>(helloWorldProducer=>OnBuyButtonClick(helloWorldProducer));
        }

        public int Karma
        {
            get => game.Karma;
            set => game.Karma = value;
        }

        public RelayCommand<Device> OnBuyButtonClickCommand { get; set; }
        
        public List<Device> HelloWorldProducers => game.HelloWorldProducers;

        private void OnBuyButtonClick(Device helloWorldProducer)
        {
            if(this.Karma >= helloWorldProducer.Prize)
            {
                this.Karma -= helloWorldProducer.Prize;
                helloWorldProducer.AddToCount();
            }
        }
    }
}

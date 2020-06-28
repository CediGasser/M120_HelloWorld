using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.ViewModels;

namespace Hello_World.GamePage
{
    class GameViewModel : ViewModelBase
    {
        private readonly Game game;
        
        public RelayCommand DoThis { get; set; }

        public GameViewModel(Game game)
        {
            this.game = game;
            this.DoThis = new RelayCommand(DoSomething);
        }

        public int Karma
        {
            get => game.Karma;
            set => game.Karma = value;
        }

        //public int Karma { get; set; } = 53;

        private void DoSomething()
        {
            this.Karma = 100;
        }

    }
}

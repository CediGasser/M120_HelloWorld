using System;
using System.Collections.Generic;
using System.Text;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;

namespace Hello_World.GamePage
{
    class GameViewModel : FodyNotifyPropertyChangedBase
    {
        private readonly Game game;

        public RelayCommand DoThis { get; set; }

        public GameViewModel(Game game)
        {
            this.game = game;
            this.DoThis = new RelayCommand(DoSomething);
        }

        public int Karma => game.Karma;

        private void DoSomething()
        {
            game.Karma = 100;
        }
    }
}

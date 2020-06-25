using System;
using System.Collections.Generic;
using System.Text;
using Hello_World.Core;

namespace Hello_World.MainMenuPage
{
    class MainMenuViewModel : FodyNotifyPropertyChangedBase
    {
        private readonly Game game;

        public MainMenuViewModel(Game game)
        {
            this.game = game;
        }

        public int Karma => game.Karma;
    }
}

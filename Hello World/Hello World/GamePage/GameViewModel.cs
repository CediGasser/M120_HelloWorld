using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Hello_World.Core;
using Hello_World.Infrastructure.Commands;
using Hello_World.Infrastructure.Timer;
using Hello_World.Infrastructure.ViewModels;

namespace Hello_World.GamePage
{
    class GameViewModel : ViewModelBase
    {
        private readonly Game game;

        private readonly OneSecondTimer oneSecondTimer;

        private int clicksPerSecond;

        public int HelloWorldPerSecond { get; set; }

        public RelayCommand DoThis { get; set; }

        public GameViewModel(Game game)
        {
            this.game = game;
            this.DoThis = new RelayCommand(DoSomething);
            this.oneSecondTimer = new OneSecondTimer();
            this.oneSecondTimer.Setup();
            this.oneSecondTimer.dispatcherTimer.Tick += OnTimerEnd;
        }

        public int Karma
        {
            get => game.Karma;
            set => game.Karma = value;
        }
        
        private void DoSomething()
        {
            this.Karma += 1;
            this.clicksPerSecond += 1 ;
        }

        private void OnTimerEnd(object sender, EventArgs e)
        {
            this.HelloWorldPerSecond = this.clicksPerSecond;
            this.clicksPerSecond = 0;
        }

    }
}

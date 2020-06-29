using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hello_World.Core
{
    public class Game : FodyNotifyPropertyChangedBase
    {
        public Game()
        {
            Karma = 0;
        }

        public int Karma { get; set; }
    }
}

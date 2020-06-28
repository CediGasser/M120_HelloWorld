using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hello_World.Core
{
    public class Game : FodyNotifyPropertyChangedBase
    {
        public Game(int karma)
        {
            Karma = karma;
        }

        public int Karma { get; set; }
    }
}

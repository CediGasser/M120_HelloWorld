using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_World.Infrastructure.Timer
{
    class OneSecondTimer
    {
        public System.Windows.Threading.DispatcherTimer dispatcherTimer;

        public void Setup()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
    }
}

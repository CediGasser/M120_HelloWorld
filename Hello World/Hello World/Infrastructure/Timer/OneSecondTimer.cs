using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_World.Infrastructure.Timer
{
    class OneSecondTimer
    {
        public readonly System.Windows.Threading.DispatcherTimer DispatcherTimer;

        public OneSecondTimer()
        {
            DispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            DispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            DispatcherTimer.Start();
        }
    }
}

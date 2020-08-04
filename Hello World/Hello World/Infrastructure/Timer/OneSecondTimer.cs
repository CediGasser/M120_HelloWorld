using System;
using System.Windows.Threading;

namespace Hello_World.Infrastructure.Timer
{
    internal class OneSecondTimer
    {
        public readonly DispatcherTimer DispatcherTimer;

        public OneSecondTimer()
        {
            this.DispatcherTimer = new DispatcherTimer();
            this.DispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            this.DispatcherTimer.Start();
        }
    }
}
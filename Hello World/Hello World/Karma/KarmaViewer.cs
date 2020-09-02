using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hello_World.Core;

namespace Hello_World.Karma
{
    public static class KarmaViewer
    {
        private static readonly List<string> KarmaNameBinding = new List<string>()
        {
            "Karma",
            "Kilo Karma",
            "Mega Karma",
            "Giga Karma",
        };

        public static string ShowAbleKarma(Core.Karma karma)
        {
            long numberToShow = karma.Value.Last();
            int index = karma.Value.IndexOf(numberToShow);
            return $"{numberToShow} {KarmaNameBinding[index]}";
        }
    }


}

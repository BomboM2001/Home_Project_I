using System;
using System.Collections.Generic;
using System.Text;

namespace homeproject
{
    class Leaderboard
    {
        public string name;
        public int time;
        public string IDmap;
        public string AllData
        {
            get { return $"{name},{time},{IDmap}"; }
        }
        public Leaderboard(string name, int time, string IDmap)
        {
            this.name = name;
            this.time = time;
            this.IDmap = IDmap;
        }
    }
}

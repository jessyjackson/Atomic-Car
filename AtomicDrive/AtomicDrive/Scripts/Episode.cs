using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicDrive
{
    internal class Episode
    {
        public string State { get; set; }
        public Action Action { get; set; }
        public int Reward { get; set; }
        public Episode(string s,Action a)
        {
            State = s;
            Action = a;
        }
    }
}

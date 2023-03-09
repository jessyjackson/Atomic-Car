using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicDrive
{
    internal class Step
    {
        public string State { get; set; }
        public Action Action { get; set; }
        public int Reward { get; set; }
        public (int,int) Position { get; set; }
        public Step(string s,Action a)
        {
            State = s;
            Action = a;
        }
    }
}

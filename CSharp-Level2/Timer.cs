using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Level2
{
    public class Timer
    {
        public string Name { get; set; }
        public TimeSpan TimeSpan { get; set; }

        //public delegate void 
        public Timer(string name, TimeSpan timeSpan) 
        {
            this.Name = name;
            this.TimeSpan = timeSpan;
        }
    }
}

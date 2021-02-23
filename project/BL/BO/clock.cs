using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class clock
    {
       public volatile bool cancel;
        #region singelton
        static readonly clock instance = new clock();
        static clock() { }// static ctor to ensure instance init is done just before first usage
        clock() { stopWatch = new Stopwatch();cancel = true; } // default => private
        public static clock Instance { get => instance; }// The public Instance property to use
        #endregion
       public Stopwatch stopWatch { get; set; }
       public TimeSpan startTime { get; set; }
       public int rate { get; set; }
       public  Action<TimeSpan> ClockObserver { get; set; }
       public TimeSpan Time { get;set; }
    }
}

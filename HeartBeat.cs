using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceWithTopshelf
{
    public class HeartBeat
    {
        private readonly Timer _timer;
        public HeartBeat()
        {
            _timer = new Timer(2000) { AutoReset = true };
            _timer.Elapsed += TimeElapsed;
        }

        private void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"c:\temp\HeartBeat.txt", lines);
        }

        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }
    }
}

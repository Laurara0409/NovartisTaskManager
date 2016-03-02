using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovartisTaskManager.BusinessClass
{
    class Timer
    {
        private bool running; //0 timer stops,1 timer continue
        private int sec;
        private int min;
        private int hr;
        public Timer()
        {
            bool unning = true;
            sec = 0;
            int min = 0;
            int hr = 0;
        }
        public string getTimeCost()
        {
            string timecost = null;
            if (running == true)
            {
                sec++;
                if (sec == 60)
                {
                    sec = 0;
                    min += 1;
                }
                if (min == 60)
                {
                    hr += 1;
                    min = 0;
                }

            }
            timecost = hr + ":" + min + ":" + sec;
            return timecost;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediabazaar_s2_cb06_1.Schedule
{
    class WorkDay
    {
        public int sShift { private set; get; }
        public int sBreak { private set; get; }
        public int eShift { private set; get; }
        public int eBreak { private set; get; }

        public WorkDay(string inpShift, string inpBreak) //format start_hh' 'end_hh
        {
            string[] inp = inpShift.Split(' ');
            sShift = Convert.ToInt32(inp[0]);
            eShift = Convert.ToInt32(inp[1]);
            inp = inpBreak.Split(' ');
            sBreak = Convert.ToInt32(inp[0]);
            eBreak = Convert.ToInt32(inp[1]);
        }
        public bool InShift(int hour)
        {
            if (sShift <= hour && eShift >= hour) return GetBreak(hour);
            return false;
        }
        private bool GetBreak(int hour)
        {
            if (sBreak <= hour && eBreak >= hour) return false;
            return true;
        }
        public void ChngDay(string inpShift, string inpBreak)
        {
            string[] inp = inpShift.Split(' ');
            sShift = Convert.ToInt32(inp[0]);
            eShift = Convert.ToInt32(inp[1]);
            inp = inpBreak.Split(' ');
            sBreak = Convert.ToInt32(inp[0]);
            eBreak = Convert.ToInt32(inp[1]);
        }
        public int GetWorkedHours()
        {
            int otp = eShift - sShift+1;
            int brk = 0;
            if (eShift == 0)
                otp = 0;    
            if (eBreak != 0)
                brk = eBreak - sBreak + 1;
            return otp - brk;
        }

    }
}

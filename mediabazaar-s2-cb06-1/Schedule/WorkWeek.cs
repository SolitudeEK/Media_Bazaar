using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediabazaar_s2_cb06_1.Schedule
{
    class WorkWeek
    {
        private List<WorkDay> workDays = new List<WorkDay>();
        private int id;
        public WorkWeek(int id)
        {
            workDays=WorkWeekDB.GetDays(id);
        }
        public WorkWeek(int id, DateTime date)
        {
            workDays = WorkWeekDB.GetWorkedDays(id,date);
        }
        public WorkWeek()
        {

        }
        public static List<WorkDay> GetFirstWeek()
        {
            return new List<WorkDay> { new WorkDay("9 15", "13 13"), new WorkDay("9 15", "13 13"), new WorkDay("9 15", "13 13"), new WorkDay("9 15", "13 13"), new WorkDay("9 15", "13 13") };
        }
        public static List<WorkDay> GetSecondWeek()
        {
            return new List<WorkDay> { new WorkDay("13 20", "17 17"), new WorkDay("13 20", "17 17"), new WorkDay("13 20", "17 17"), new WorkDay("13 20", "17 17"), new WorkDay("13 20", "17 17") };
        }
        public List<WorkDay> GetWeek()
        {
            return workDays;
        }
        public bool ChngWeek(int day, string toChng)
        {
            string[] chng = toChng.Split('-');
            if (WorkWeekDB.ChngeDay(id, chng, day))
            {
                workDays[day].ChngDay(chng[0], chng[1]);
                return true;
            }
            return false;
        }
        public bool AddWeek(string inpt, int id, DateTime start)
        {
            List<string> inp = inpt.Split('v').ToList();
            return WorkWeekDB.AddWeek(inp.ToArray(), id, start);
        }
        public bool GetWanted(int id)
        {
            workDays = WorkWeekDB.GetWanted(id);
            if (workDays!=null)
                return true;
            return false;
        }
        public bool AddWanted(bool isNew, string[] slot)
        {
            return WorkWeekDB.AddWanted(id, slot, isNew);
        }
        public int GetWorkedHours()
        {
            int otp = 0;
            foreach (WorkDay day in workDays)
                otp += day.GetWorkedHours();
            return otp;
        }
    }
}

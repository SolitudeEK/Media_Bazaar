using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediabazaar_s2_cb06_1.Schedule
{
    public class GeneratorSchedule
    {
        private int MaxHour, MiniShop, NumPpl;
        private string departmentName;
        private Dictionary<int, WorkDay[]> WantedWS;
        private List<int> emFreeIds = new List<int>();
        private Dictionary<int, string> ToCreates = new Dictionary<int, string>();
        private int[] ids;
        private int[,] slots = new int[5, 13];
        public GeneratorSchedule(int MaxHour, int MiniShop,int NumPpl, string name)
        {
            this.MaxHour = MaxHour;
            this.MiniShop = MiniShop;
            this.NumPpl = NumPpl;
            departmentName = name;
        }
        public string GenerateShedule()
        {
            if (!Checker())
                return ("Data not correct");
            ids = GeneratorScheduleDB.GetIds(departmentName, NumPpl);
            if (ids == null)
                return ("Connection problem!");
            WantedWS = GeneratorScheduleDB.GetWanteds(ids);
            CreateFreeTimes();
            if (StartGen())
            {
                SetSchedules();
                return "Schedule is created!";
            }
            return "With this input does not possible to ctreate schedule!";

        } 
        private bool Checker()
        {
            if (!(MaxHour > 0 && MiniShop > 0 && NumPpl > 0)) //Check correct input;
                return false;
            if (NumPpl * MaxHour*5 < MiniShop * 65) //Check does generate theroreticaly possible 
                return false;
            if (GeneratorScheduleDB.CheckPpl(departmentName) < NumPpl) //Check if we got sufficent people
                return false;
            return true;
        }
        private void CreateFreeTimes()
        {
            foreach(int id in ids)
            {
                if (!WantedWS.ContainsKey(id))
                    emFreeIds.Add(id);
            }
        }
        private int ReadySchedl()
        {
            int otp = 0;
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    if (slots[i, j] < MiniShop) otp++;
                }
            }
            return otp;
        }
        private void GetWandted()
        {
            foreach (var WW in WantedWS)
            {
                WorkDay[] wd = WW.Value;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        if (j + 8 >= wd[i].sShift && j + 8 <= wd[i].eShift)
                            slots[i, j]++;
                    }
                }
            }
        }
        private void GetCombined()
        {
            int start;
            string toCreate = "";
            int workPossible = MaxHour;
            bool isWork = true;
            foreach (int index in emFreeIds)
            {
                start = 0;
                toCreate = "";               
                for (int i = 0; i < 5; i++)
                {
                    workPossible = MaxHour;
                    isWork = false;
                    for (int j = 0; j < 13; j++)
                    {
                        if (slots[i, j] < MiniShop)
                        {
                            isWork = true;
                            start = j;
                            while (j < 13 && slots[i, j] < MiniShop && workPossible > j - start)
                            {
                                slots[i, j]++;
                                j++;
                            }
                            j--;
                            toCreate += start + 8 + " " + (j + 8) + "v0 0v";
                            start = 0;
                            j = 13;
                        }
                    }
                    if (!isWork) toCreate += "0 0v0 0v";
                }
                ToCreates.Add(index, toCreate);
            }
        }
        private void ReAssignWanted()
        {
            emFreeIds=ids.ToList();
            ToCreates.Clear();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 13; j++)
                    slots[i,j] = 0;
            }
            GetCombined();
        }
        private bool StartGen()
        {
            GetWandted();
            GetCombined();
            if(ReadySchedl()!=0)
            {
                ReAssignWanted();
                if(ReadySchedl() != 0)
                    return false;
            }
            return true;

        }
        private void SetSchedules()
        {
            foreach(var wwC in ToCreates)
            {
                WorkWeek ww = new WorkWeek();
                ww.AddWeek(wwC.Value, wwC.Key, DateTime.Now);
            }
        }
    }
}

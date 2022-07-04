using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using mediabazaar_s2_cb06_1.Employee;
using mediabazaar_s2_cb06_1.Schedule;
namespace mediabazaar_s2_cb06_1.Scanner
{
    class QRInfo
    {
        public static Image GetImage(int id, int size)
        {
            Image img = EmployeeManagerDB.GetImage(id);
            if (img != null)
                return (Image)(new Bitmap(img, new Size(200, 200)));
            return (Image)(new Bitmap((Properties.Resources.Asset_11_2_77x), new Size(200, 200)));
        }
        public static bool SetTime(int id)
        {
            return WorkWeekDB.SetQRTime(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediabazaar_s2_cb06_1.MailBox
{
    public class Mail
    {
        private int recipient, sender;
        public int id { private set; get; }
        private string message;
        private DateTime sendedTime;

        public Mail(int sender, int recipient, string message, DateTime time, int id)
        {
            this.sender = sender;
            this.recipient = recipient;
            this.message = message;
            sendedTime = time;
            this.id = id;
        }

        public List<string> GetInfo()
        {
            List<string> otp = new List<string>();
            otp.Add(sender + "");               //0
            otp.Add(recipient + "");            //1
            otp.Add(sendedTime.ToString("g"));  //2
            otp.Add(message);                   //3
            otp.Add(id+"");                     //4
            return otp;
        }
    }
}

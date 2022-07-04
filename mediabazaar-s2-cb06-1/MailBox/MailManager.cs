using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mediabazaar_s2_cb06_1.Employee;

namespace mediabazaar_s2_cb06_1.MailBox
{
    public class MailManager
    {
        public List<Mail> mails = new List<Mail>();
        private int holderId;
        public MailManager(Person person)
        {
            holderId = person.GetId();
            mails=MailDB.GetMails(holderId);
        }
        public bool DeleteMail(int id)
        {
            foreach( Mail mail in mails)
            {
                if (mail.id == id)
                {
                    mails.Remove(mail);
                    return MailDB.DeleteMail(id);
                }
            }
            return false;
        }
        
        public bool SendMail( int recipentId, string mail)
        {
            return MailDB.SendMail(recipentId, mail, holderId);
        }
        public List<Mail> GetMails()
        {
            return mails;
        }
        public static void SendMail(string mail, string role,int senderId)
        {
            List<int> ids = MailDB.GetIds(role);
            foreach(int id in ids)
            {
                MailDB.SendMail(id, mail, senderId);
            }
        }
    }
}

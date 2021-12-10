using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class Staff
    {
        public string Id;
        public string Name;
        public string Password;
        public string BankId;


        public Staff(string Name, string Password, string BankId)
        {
            this.Name = Name;
            this.Password = Password;
            // set Id
            DateTime currentDate;
            currentDate = DateTime.Now;
            for (int i = 0; i < 3; i++) Id += Name[i];
            Id += currentDate;
            this.BankId = BankId;

        }
    }
}

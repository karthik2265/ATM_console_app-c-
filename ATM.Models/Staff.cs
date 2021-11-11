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
        private DateTime currentDate;
        public StaffAcessLevel AccessLevel;


        public Staff(string Name, string Password, StaffAcessLevel AccessLevel = StaffAcessLevel.StaffMember)
        {
            this.Name = Name;
            this.Password = Password;
            // set Id
            currentDate = DateTime.Now;
            for (int i = 0; i < 3; i++) Id += Name[i];
            Id += currentDate;
            // set acessLevel
            this.AccessLevel = AccessLevel;

        }
    }
}

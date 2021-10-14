using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class Bank
    {
        public Dictionary<string, Customer> Customers;
        public string Name;
        public string Id;

        // to set Id 
        private readonly DateTime currentDate;

        public Bank(int id, string name)
        {
            this.Name = name;
            this.Customers = new Dictionary<string, Customer>();
            // set accountId
            currentDate = DateTime.Now;
            string date = currentDate.ToShortDateString();
            Id = "";
            for (int i = 0; i < 3; i++) Id += this.Name;
            Id += date;
        }
    }
}

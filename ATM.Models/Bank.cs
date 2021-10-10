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
        public int Id;

        public Bank(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Customers = new Dictionary<string, Customer>();
        }
    }
}

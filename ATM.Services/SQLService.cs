using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ATM.Models;
using System.Data;
using ATM.Models.enums;

namespace ATM.Services
{
    public class SQLService
    {
        private SqlConnection connection;
        public SQLService(SqlConnection cnn)
        {
            this.connection = cnn;
        }

        public bool AddCustomer(Customer customer)
        {
            // (id, name, password, balance, status, bankId)
            string query = $"INSERT INTO Customers VALUES('{customer.Id}', '{customer.Name}', '{customer.Password}', {customer.Balance}, '{customer.Status}', '{customer.BankId}')";
            SqlCommand command = new(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public Customer CustomerLogIn(string name, string password)
        {
            string query = "SELECT * FROM Customers";
            SqlCommand command = new(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while( reader.Read())
            {
                var customerData = (IDataReader)reader;
                string customerName = Convert.ToString(customerData[1]);
                string customerPassword = Convert.ToString(customerData[2]);
                if (customerName == name && customerPassword == password)
                {
                    string id = Convert.ToString(customerData[0]);
                    double balance = Convert.ToDouble(customerData[3]);
                    AccountStatus status = (AccountStatus) Enum.Parse(typeof(AccountStatus), Convert.ToString(customerData[4]));
                    string bankId = Convert.ToString(customerData[5]);
                    Customer c = new(id, name, password, balance, status, bankId);
                    reader.Close();
                    return c;
                }
            }
            reader.Close();
            return null;
        } 

        public bool UpdateCustomerField(Customer customer, string columnName, string value)
        {
            string query = $"UPDATE Customers SET {columnName} = {value} WHERE id = '{customer.Id}'";
            SqlCommand command = new(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<Bank> GetBanks()
        {
            var res = new List<Bank>();
            string query = "SELECT * FROM Banks";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var bankData = (IDataReader) reader;
                var currencyString = Convert.ToString(bankData[6]);
                Currency currency = (Currency)Enum.Parse(typeof(Currency), currencyString);
                Bank b = new Bank(Convert.ToString(bankData[0]), Convert.ToString(bankData[1]), Convert.ToDouble(bankData[2]), Convert.ToDouble(bankData[3]), Convert.ToDouble(bankData[4]), Convert.ToDouble(bankData[5]), currency, Convert.ToDouble(bankData[7]));
                res.Add(b);
            }

            reader.Close();
            return res;
        }

        public bool AddTransaction(Transaction transaction)
        {
            string id = Convert.ToString(transaction.Id);
            string senderAccId = Convert.ToString(transaction.SenderAccountId);
            string recieverAccId = Convert.ToString(transaction.RecieverAccountId);
            string bankId = Convert.ToString(transaction.BankId);
            string amount = Convert.ToString(transaction.Amount);
            string transactionType = Convert.ToString(transaction.Type);
            string date = transaction.On.ToString("yyyy-MM-dd HH:mm:ss.fff"); ;

            string query = $"INSERT INTO Transactions VALUES('{id}', '{senderAccId}', '{recieverAccId}', '{bankId}', {amount}, '{transactionType}', '{date}')";
            SqlCommand command = new(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

    }
}

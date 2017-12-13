using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDbExample.Persistence
{
    public class CustomersRepository
    {
        public static List<DTO.Customer> GetCustomers()
        {
            ACMEEntities db = new ACMEEntities();
            var dbCustomers = db.Customers.ToList();

            var dtoCustomers = new List<DTO.Customer>();

            foreach (var dbCustomer in dbCustomers)
            {
                var dtoCustomer = new DTO.Customer();

                dtoCustomer.CustomerId = dbCustomer.CustomerId;
                dtoCustomer.Name = dbCustomer.Name;
                dtoCustomer.Address = dbCustomer.Address;
                dtoCustomer.City = dbCustomer.City;
                dtoCustomer.State = dbCustomer.State;
                dtoCustomer.PostalCode = dbCustomer.PostalCode;
                dtoCustomer.Notes = dbCustomer.Notes;

                dtoCustomers.Add(dtoCustomer);
            }

            //return dbCustomers;
            return dtoCustomers;
        }
    }
}

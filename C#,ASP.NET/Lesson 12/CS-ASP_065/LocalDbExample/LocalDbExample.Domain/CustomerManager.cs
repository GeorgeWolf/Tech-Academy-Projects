using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalDbExample;

namespace LocalDbExample.Domain
{
    public class CustomerManager
    {
        public static List<DTO.Customer> GetCustomers()
        {
            var customers = Persistence.CustomersRepository.GetCustomers();
            return customers;
        }

        public static void AddCustomer(DTO.Customer customer)
        {
            try
            {
                Persistence.CustomersRepository.AddCustomer(customer);
            }
            catch (Exception)
            {
                // Log it
                throw;
            }
        }
    }
}

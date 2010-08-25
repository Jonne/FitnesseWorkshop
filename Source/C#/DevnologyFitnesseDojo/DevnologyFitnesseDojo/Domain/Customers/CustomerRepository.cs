using System;
using System.Collections.Generic;
using System.Linq;

namespace DevnologyFitnesseDojo.Domain.Customers
{
    public class CustomerRepository
    {
        private static readonly List<Customer> customers = new List<Customer>();

        public static void Add(Customer customer)
        {
            if (customers.Contains(customer))
            {
                throw new ArgumentException("Customer " + customer + " already known.");
            }

            customers.Add(customer);
        }

        public static Customer FindByName(string customerName)
        {
            return customers.SingleOrDefault(customer => customer.Name == customerName);
        }
    }
}

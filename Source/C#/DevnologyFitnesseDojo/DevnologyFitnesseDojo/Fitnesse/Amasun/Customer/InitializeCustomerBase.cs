using System;
using DevnologyFitnesseDojo.Domain.Customers;

namespace DevnologyFitnesseDojo.Fitnesse.Amasun.Customer
{
    public class IntializeCustomerBase
    {
        private string name;

        public void Execute()
        {
            CustomerRepository.Add(new Domain.Customers.Customer { Name = name });
        }

        public void SetName(String name)
        {
            this.name = name;
        }
    }
}
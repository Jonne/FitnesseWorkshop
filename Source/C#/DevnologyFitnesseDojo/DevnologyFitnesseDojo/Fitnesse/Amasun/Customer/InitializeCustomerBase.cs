using System;
using DevnologyFitnesseDojo.Domain;

namespace DevnologyFitnesseDojo.Fitnesse.Amasun.Customer
{
    public class IntializeCustomerBase
    {
        private String name;

        public void Execute()
        {
            Customers.Add(new Domain.Customer { Name = name });
        }

        public void SetName(String name)
        {
            this.name = name;
        }
    }
}
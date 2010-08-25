using System;
using DevnologyFitnesseDojo.Domain;

namespace DevnologyFitnesseDojo.Fitnesse.Amasun.Customer
{
    public class IntializeCustomerBase
    {
        private string name;
        private int money;

        public void Execute()
        {
            Customers.Add(new Domain.Customer { Name = name, Money = money });
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public void SetMoney(int money)
        {
            this.money = money;
        }
    }
}
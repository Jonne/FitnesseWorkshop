using System;

namespace DevnologyFitnesseDojo.Domain
{
    public class Customer
    {
        public string Name { get; set; }

        public int Money { get; set; }

        public override bool Equals(object o)
        {
            var customer = o as Customer;

            if (customer != null)
            {
                return Name == customer.Name;
            }

            return false;
        }
    }
}

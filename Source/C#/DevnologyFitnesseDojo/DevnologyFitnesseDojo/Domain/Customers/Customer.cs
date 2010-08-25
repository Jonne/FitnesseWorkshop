namespace DevnologyFitnesseDojo.Domain.Customers
{
    public class Customer
    {
        public string Name { get; set; }

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
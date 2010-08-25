
using System.Collections.Generic;

namespace DevnologyFitnesseDojo.Domain
{
    public class Order
    {
        private readonly Customer customer;
        private readonly Dictionary<Book, int> contents = new Dictionary<Book, int>();

        public Order(Customer customer)
        {
            this.customer = customer;
        }

        public void AddBook(int amount, Book book)
        {
            int currentAmount = 0;
            if (contents.ContainsKey(book))
            {
                currentAmount = contents[book];    
            }
            
            currentAmount += amount;

            contents[book] = currentAmount;
        }

        public IEnumerable<Book> Books
        {
            get { return contents.Keys; }
        }

        public int GetAmount(Book book)
        {
            return contents[book];
        }

        public Customer Customer
        {
            get
            {
                return customer;
            }
        }

        public bool ContainsBook(Book book)
        {
            return contents.ContainsKey(book);
        }

        public int TotalPrice
        {
            get
            {
                int totalPrice = 0;
                foreach (var content in contents)
                {
                    totalPrice += (int)content.Key.Price*content.Value;
                }
                return totalPrice;
            }
        }
    }
}

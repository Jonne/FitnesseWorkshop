using System.Collections.Generic;
using DevnologyFitnesseDojo.Domain.Books;
using DevnologyFitnesseDojo.Domain.Customers;

namespace DevnologyFitnesseDojo.Domain.Orders
{
    public class Order
    {
        private readonly Dictionary<Book, int> contents = new Dictionary<Book, int>();
        private readonly Customer customer;
        private int discount;

        public Order(Customer customer)
        {
            this.customer = customer;
        }

        public IEnumerable<Book> Books
        {
            get { return contents.Keys; }
        }

        public Customer Customer
        {
            get { return customer; }
        }

        public int Subtotal
        {
            get
            {
                int totalPrice = 0;
                foreach (var content in contents)
                {
                    totalPrice += (int) content.Key.Price*content.Value;
                }
                return totalPrice;
            }
        }

        public int Discount
        {
            get { return discount; }
        }

        public int Total
        {
            get { return Subtotal - Discount; }
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

        public int GetAmount(Book book)
        {
            return contents[book];
        }

        public bool ContainsBook(Book book)
        {
            return contents.ContainsKey(book);
        }

        public void ApplyDiscount(int discount)
        {
            this.discount = discount;
        }
    }
}
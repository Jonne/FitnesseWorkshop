using System;
using DevnologyFitnesseDojo.Domain;

namespace DevnologyFitnesseDojo.Fitnesse.Amasun.Book
{
    public class BuyBookScenarioForCustomer
    {
        private readonly int beforeMoney;
        private readonly BookService bookService = new BookService();
        private readonly Domain.Customer customer;
        private readonly Order order;

        public BuyBookScenarioForCustomer(string customerName)
        {
            customer = Customers.FindByName(customerName);

            beforeMoney = customer.Money;

            order = new Order(customer);
        }

        public bool CustomerBuysBooksWithTitle(int amount, String title)
        {
            Domain.Book book = Inventory.Instance.FindByTitle(title);

            order.AddBook(amount, book);

            return true;
        }

        public bool PlaceOrder()
        {
            bookService.BuyBooks(order);

            return true;
        }

        public int CustomerPayed()
        {
            return beforeMoney - customer.Money;
        }
    }
}
using System;
using DevnologyFitnesseDojo.Domain;

namespace DevnologyFitnesseDojo.Fitnesse.Amasun.Book
{
    public class BuyBookScenarioForCustomer
    {
        private BookService bookService = new BookService();

        private int beforeMoney;
        private Domain.Customer customer;
        private Order order;

        public BuyBookScenarioForCustomer(string customerName)
        {
            customer = Customers.FindByName(customerName);
            
            beforeMoney = customer.Money;

            order = new Order(customer);
        }

        public bool customerBuysBooksWithTitle(int amount, String title)
        {
            Domain.Book book = Inventory.Instance.FindByTitle(title);

            order.AddBook(amount, book);

            return true;
        }

        public bool placeOrder()
        {
            bookService.BuyBooks(order);

            return true;
        }

        public int customerPayed()
        {
            return beforeMoney - customer.Money;

        }
    }
}
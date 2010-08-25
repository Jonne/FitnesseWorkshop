using System;
using DevnologyFitnesseDojo.Domain.Books;
using DevnologyFitnesseDojo.Domain.Customers;
using DevnologyFitnesseDojo.Domain.Orders;

namespace DevnologyFitnesseDojo.Fitnesse.Amasun.Book
{
    public class BuyBookScenarioForCustomer
    {
        private readonly BookService bookService = new BookService();
        private readonly Domain.Customers.Customer customer;
        private readonly Order order;

        public BuyBookScenarioForCustomer(string customerName)
        {
            customer = CustomerRepository.FindByName(customerName);

            order = new Order(customer);
        }

        public bool CustomerBuysBooksWithTitle(int amount, String title)
        {
            Domain.Books.Book book = Inventory.FindByTitle(title);

            order.AddBook(amount, book);

            return true;
        }

        public bool PlaceOrder()
        {
            bookService.BuyBooks(order);

            return true;
        }

        public int AppliedDiscount()
        {
            return order.Discount;
        }

        public int ChargedSubtotal()
        {
            return order.Subtotal;
        }

        public int ChargedTotal()
        {
            return order.Total;
        }
    }
}
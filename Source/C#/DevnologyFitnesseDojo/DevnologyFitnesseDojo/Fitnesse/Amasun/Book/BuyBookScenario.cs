using System;
using DevnologyFitnesseDojo.Domain.Books;
using DevnologyFitnesseDojo.Domain.Customers;
using DevnologyFitnesseDojo.Domain.Orders;

namespace DevnologyFitnesseDojo.Fitnesse.Amasun.Book
{
    public class BuyBookScenario
    {
        private readonly BookService bookService = new BookService();

        public bool CustomerBuysBooksWithTitle(string customerName, int amount, String title)
        {
            Domain.Books.Book book = Inventory.FindByTitle(title);

            Domain.Customers.Customer customer = CustomerRepository.FindByName(customerName);

            var order = new Order(customer);

            order.AddBook(amount, book);

            bookService.BuyBooks(order);

            return true;
        }
    }
}
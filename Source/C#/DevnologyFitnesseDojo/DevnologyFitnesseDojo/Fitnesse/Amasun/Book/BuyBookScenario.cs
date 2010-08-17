using System;
using DevnologyFitnesseDojo.Domain;

namespace DevnologyFitnesseDojo.Fitnesse.Amasun.Book
{
    public class BuyBookScenario
    {
        private readonly BookService bookService = new BookService();


        public bool CustomerBuysBooksWithTitle(string customerName, int amount, String title)
        {
            Domain.Customer customer = Customers.FindByName(customerName);
            Domain.Book book = Inventory.Instance.FindByTitle(title);

            bookService.BuyBook(customer, amount, book);

            return true;
        }
    }
}
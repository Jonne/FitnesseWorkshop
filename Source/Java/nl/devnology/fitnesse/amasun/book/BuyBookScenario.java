package nl.devnology.fitnesse.amasun.book;

import nl.devnology.domain.book.Book;
import nl.devnology.domain.book.BookService;
import nl.devnology.domain.book.Inventory;
import nl.devnology.domain.customer.Customer;
import nl.devnology.domain.customer.Customers;

/**
 * @author Erik Pragt
 */
public class BuyBookScenario {
    private BookService bookService = new BookService();


    public boolean customerBuysBooksWithTitle(String customerName, Integer amount, String title) {
        Customer customer = Customers.findByName(customerName);
        Book book = Inventory.get().findByTitle(title);

        bookService.buyBooks(customer, amount, book);

        return true;
    }

    public Integer customerPays(String customerName) {
        return 0;
    }    
}

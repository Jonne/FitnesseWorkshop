package nl.devnology.domain.book;

import nl.devnology.domain.customer.Customer;

/**
 * @author Erik Pragt
 */
public class BookService {
    

    public void buyBooks(Customer customer, Integer amount, Book book) {
        Inventory.get().deductInventory(book, amount);
    }
}

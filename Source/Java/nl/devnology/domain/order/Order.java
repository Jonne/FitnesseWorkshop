package nl.devnology.domain.order;

import java.util.HashMap;
import java.util.Map;
import java.util.Set;

import nl.devnology.domain.book.Book;
import nl.devnology.domain.customer.Customer;

/**
 * @author Erik Pragt
 */
public class Order {
    private Customer customer;

    private Map<Book, Integer> contents = new HashMap<Book, Integer>();

    public Order(Customer customer) {
        this.customer = customer;
    }

    public void addBook(Integer amount, Book book) {
        Integer currentAmount = contents.get(book);

        if(currentAmount == null) {
            currentAmount = 0;
        }

        currentAmount += amount;

        contents.put(book, currentAmount);
    }

    public Set<Book> getBooks() {
        return contents.keySet();
    }

    public Integer getAmount(Book book) {
        return contents.get(book);
    }

    public Customer getCustomer() {
        return customer;
    }

    public boolean containsBook(Book book) {
        return contents.keySet().contains(book);
    }

    public Integer getTotalPrice() {
        Integer totalPrice = 0;

        for (Map.Entry<Book, Integer> entry : contents.entrySet()) {
            totalPrice += (entry.getKey().getPrice() * entry.getValue());
        }
        return totalPrice;
    }
}

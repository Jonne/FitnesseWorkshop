package nl.devnology.fitnesse.amasun.book;

import nl.devnology.domain.book.Book;
import nl.devnology.domain.book.BookService;
import nl.devnology.domain.book.Inventory;
import nl.devnology.domain.customer.Customer;
import nl.devnology.domain.customer.Customers;
import nl.devnology.domain.order.Order;

/**
 * @author Erik Pragt
 */
public class BuyBookScenarioForCustomer {
    private BookService bookService = new BookService();

    private Integer beforeMoney;
    private Customer customer;
    private Order order;

    public BuyBookScenarioForCustomer(String customerName) {
        customer = Customers.findByName(customerName);


        beforeMoney = customer.getMoney();

        order = new Order(customer);
    }

    public boolean customerBuysBooksWithTitle(Integer amount, String title) {
        Book book = Inventory.get().findByTitle(title);

        order.addBook(amount, book);

        return true;
    }

    public boolean placeOrder() {
        bookService.buyBooks(order);

        return true;
    }

    public Integer customerPayed() {
        return beforeMoney - customer.getMoney();

    }
}

package nl.devnology.fitnesse.amasun.book;

import nl.devnology.domain.book.Book;
import nl.devnology.domain.book.Inventory;

/**
 * @author Erik Pragt
 */
public class InitializeBookInventory {
    private String author;
    private String title;
    private String isbn;
    private Integer price;
    private Integer amount;

    public void execute() {
        Book book = new Book(author, title, isbn, price);

        Inventory inventory = Inventory.get();

        inventory.addBook(book, amount);
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setIsbn(String isbn) {
        this.isbn = isbn;
    }

    public void setPrice(Integer price) {
        this.price = price;
    }

    public void setAmount(int amount) {
        this.amount = amount;
    }
}

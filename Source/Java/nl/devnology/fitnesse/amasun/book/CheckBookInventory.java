package nl.devnology.fitnesse.amasun.book;

import nl.devnology.domain.book.Book;
import nl.devnology.domain.book.Inventory;

/**
 * @author Erik Pragt
 */
public class CheckBookInventory {
    private String author;
    private String title;
    private String isbn;
    private Integer price;


    public Integer amount() {
        Book book = new Book(author, title, isbn, price);

        return Inventory.get().countBooks(book);
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public void setIsbn(String isbn) {
        this.isbn = isbn;
    }

    public void setPrice(Integer price) {
        this.price = price;
    }
}

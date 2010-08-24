package nl.devnology.domain.book;

import java.util.HashMap;
import java.util.Map;

/**
 * @author Erik Pragt
 */
public class Inventory {
    private static Inventory inventory = new Inventory();

    private static Map<Book, Integer> books = new HashMap<Book, Integer>();

    public static Inventory get() {
        return inventory;
    }


    public void addBook(Book book, Integer amount) {
        Integer currentAmount = books.get(book);

        if(currentAmount == null) {
            currentAmount = amount;
        } else {
            currentAmount += amount;
        }

        books.put(book, currentAmount);
    }

    public Book findByTitle(String title) {
        for(Map.Entry<Book, Integer> entry: books.entrySet()) {
            Book book = entry.getKey();
            if(book.getTitle().equals(title)) {
                return book;
            }
        }

        return null;
    }

    public Integer countBooks(Book book) {
        return books.get(book);
    }

    public void deductInventory(Book book, Integer amount) {
        Integer stock = books.get(book);

        if(stock - amount < 0) {
            throw new IllegalArgumentException("Not enough books in stock: current stock is " + stock + ", trying to deduct " + amount);
        }

        stock -= amount;

        books.put(book, stock);
    }
}

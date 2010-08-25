package nl.devnology.fitnesse.amasun.book;

import nl.devnology.domain.book.Book;
import nl.devnology.domain.book.BookService;
import nl.devnology.domain.book.DiscountType;
import nl.devnology.domain.book.Inventory;
import nl.devnology.domain.book.PromoPackage;

/**
 * @author Erik Pragt
 */
public class CreatePromoPackage {
    private BookService bookService = new BookService();

    private Inventory inventory;
    private Book book1;
    private Book book2;
    private Integer discountAmount;
    private DiscountType discountType;

    public CreatePromoPackage() {
        inventory = Inventory.get();
    }

    public void setBook1Isbn(String book1isbn) {
        book1 = inventory.findByIsbn(book1isbn);
    }

    public void setBook2Isbn(String book2isbn) {
        book2 = inventory.findByIsbn(book2isbn);
    }

    public void setDiscountAmount(Integer discount) {
        discountAmount = discount;
    }

    public void setDiscountType(String type) {
        discountType = DiscountType.valueOf(type);
    }

    public void execute() {
        inventory.addPromoPackage(new PromoPackage(book1, book2, discountAmount, discountType));

    }
}

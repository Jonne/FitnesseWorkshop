package nl.devnology.domain.book;

import nl.devnology.domain.order.Order;

/**
 * @author Erik Pragt
 */
public class PromoPackage {
    private Book book1;
    private Book book2;
    private Integer discountAmount;
    private DiscountType discountType;

    public PromoPackage(Book book1, Book book2, Integer discountAmount, DiscountType discountType) {
        this.book1 = book1;
        this.book2 = book2;
        this.discountAmount = discountAmount;
        this.discountType = discountType;
    }

    public Integer caclulateDiscount() {
        if(discountType == DiscountType.AMOUNT) {
            return discountAmount;
        } else {
            return (int) ((book1.getPrice() + book2.getPrice()) * (discountAmount / 100d));
        }
    }

    public boolean isEligible(Order order) {
        return order.containsBook(book1) && order.containsBook(book2);
    }
}

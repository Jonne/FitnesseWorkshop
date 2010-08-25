package nl.devnology.domain.book;

import nl.devnology.domain.customer.Customer;
import nl.devnology.domain.order.Order;

/**
 * @author Erik Pragt
 */
public class BookService {
    private Inventory inventory = Inventory.get();

    public void buyBooks(Order order) {
        Integer totalPriceBeforeDiscount = order.getTotalPrice();

        Integer totalPriceAfterDiscount = totalPriceBeforeDiscount - calculateDiscount(order);

        Customer customer = order.getCustomer();

        if (customer.getMoney() >= totalPriceAfterDiscount) {
            customer.deductMoney(totalPriceAfterDiscount);
        }

        // Then deduct the inventory
        for (Book book : order.getBooks()) {
            Integer amount = order.getAmount(book);

            Inventory.get().deductInventory(book, amount);
        }
    }

    private Integer calculateDiscount(Order order) {
        if (!inventory.isPromoOrder(order)) {
            return 0;
        }

        PromoPackage promoPackage = inventory.getPromoPackage(order);

        return promoPackage.caclulateDiscount();
    }
}

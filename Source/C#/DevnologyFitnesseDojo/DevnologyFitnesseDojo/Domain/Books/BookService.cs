using DevnologyFitnesseDojo.Domain.Orders;

namespace DevnologyFitnesseDojo.Domain.Books
{
    public class BookService
    {
        public void BuyBooks(Order order)
        {
            int discount = CalculateDiscount(order);

            order.ApplyDiscount(discount);

            // Then deduct the inventory
            foreach (Book book in order.Books)
            {
                int amount = order.GetAmount(book);

                Inventory.DeductInventory(book, amount);
            }
        }

        private int CalculateDiscount(Order order)
        {
            if (!Inventory.IsPromoOrder(order))
            {
                return 0;
            }

            PromoPackage promoPackage = Inventory.GetPromoPackage(order);

            return promoPackage.CaclulateDiscount();
        }
    }
}


namespace DevnologyFitnesseDojo.Domain
{
    public class BookService
    {
        private readonly Inventory inventory = Inventory.Instance;

        public void BuyBooks(Order order)
        {
            int totalPriceBeforeDiscount = order.TotalPrice;

            int totalPriceAfterDiscount = totalPriceBeforeDiscount - CalculateDiscount(order);

            Customer customer = order.Customer;

            if (customer.Money >= totalPriceAfterDiscount)
            {
                customer.Money = totalPriceAfterDiscount;
            }

            // Then deduct the inventory
            foreach (Book book in order.Books)
            {
                int amount = order.GetAmount(book);

                inventory.DeductInventory(book, amount);
            }
        }

        private int CalculateDiscount(Order order)
        {
            if (!inventory.IsPromoOrder(order))
            {
                return 0;
            }

            PromoPackage promoPackage = inventory.GetPromoPackage(order);

            return promoPackage.caclulateDiscount();
        }
    }
}

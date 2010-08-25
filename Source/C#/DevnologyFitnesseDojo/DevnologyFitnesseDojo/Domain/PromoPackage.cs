namespace DevnologyFitnesseDojo.Domain
{
    public class PromoPackage
    {
        private readonly Book book1;
        private readonly Book book2;
        private readonly int discountAmount;
        private readonly DiscountType discountType;

        public PromoPackage(Book book1, Book book2, int discountAmount, DiscountType discountType)
        {
            this.book1 = book1;
            this.book2 = book2;
            this.discountAmount = discountAmount;
            this.discountType = discountType;
        }

        public int caclulateDiscount()
        {
            if (discountType == DiscountType.AMOUNT)
            {
                return discountAmount;
            }

            return (int) ((book1.Price + book2.Price)*(discountAmount/100m));
        }

        public bool IsEligible(Order order)
        {
            return order.ContainsBook(book1) && order.ContainsBook(book2);
        }
    }
}
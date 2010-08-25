using System;
using DevnologyFitnesseDojo.Domain;

namespace DevnologyFitnesseDojo.Fitnesse.Amasun.Book
{
    public class CreatePromoPackage
    {
        private BookService bookService = new BookService();

        private Inventory inventory;
        private Domain.Book book1;
        private Domain.Book book2;
        private int discountAmount;
        private DiscountType discountType;

        public CreatePromoPackage()
        {
            inventory = Inventory.Instance;
        }

        public void setBook1Isbn(string book1isbn)
        {
            book1 = inventory.FindByIsbn(book1isbn);
        }

        public void setBook2Isbn(string book2isbn)
        {
            book2 = inventory.FindByIsbn(book2isbn);
        }

        public void setDiscountAmount(int discount)
        {
            discountAmount = discount;
        }

        public void setDiscountType(String type)
        {
            discountType = (DiscountType)Enum.Parse(typeof(DiscountType), type);
        }

        public void execute()
        {
            inventory.AddPromoPackage(new PromoPackage(book1, book2, discountAmount, discountType));
        }
    }
}

using System;
using DevnologyFitnesseDojo.Domain;
using DevnologyFitnesseDojo.Domain.Books;

namespace DevnologyFitnesseDojo.Fitnesse.Amasun.Book
{
    public class CreatePromoPackage
    {

        private Domain.Books.Book book1;
        private Domain.Books.Book book2;
        private int discountAmount;
        private DiscountType discountType;

        public void SetBook1Isbn(string book1isbn)
        {
            book1 = Inventory.FindByIsbn(book1isbn);
        }

        public void SetBook2Isbn(string book2isbn)
        {
            book2 = Inventory.FindByIsbn(book2isbn);
        }

        public void SetDiscountAmount(int discount)
        {
            discountAmount = discount;
        }

        public void SetDiscountType(String type)
        {
            discountType = (DiscountType)Enum.Parse(typeof(DiscountType), type);
        }

        public void Execute()
        {
            Inventory.AddPromoPackage(new PromoPackage(book1, book2, discountAmount, discountType));
        }
    }
}

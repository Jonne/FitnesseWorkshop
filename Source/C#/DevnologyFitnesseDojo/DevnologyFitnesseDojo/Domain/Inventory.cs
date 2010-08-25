using System;
using System.Collections.Generic;
using System.Linq;

namespace DevnologyFitnesseDojo.Domain
{
    public class Inventory
    {
        private static readonly Inventory inventory = new Inventory();

        private readonly Dictionary<Book, int> books = new Dictionary<Book, int>();
        private readonly IList<PromoPackage> promoPackages = new List<PromoPackage>();

        public static Inventory Instance
        {
            get { return inventory; }
        }

        public void AddBook(Book book, int amount)
        {
            if (!books.ContainsKey(book))
            {
                books.Add(book, 0);
            }

            int currentAmount = books[book];

            currentAmount += amount;

            books[book] = currentAmount;
        }

        public Book FindByTitle(string title)
        {
            return books.Keys.SingleOrDefault(book => book.Title == title);
        }

        public Book FindByIsbn(string isbn)
        {
            return books.Keys.SingleOrDefault(book => book.Isbn == isbn);
        }

        public int CountBooks(Book book)
        {
            if (!books.ContainsKey(book))
            {
                return 0;
            }

            return books[book];
        }

        public void DeductInventory(Book book, int amount)
        {
            int stock = books[book];

            if (stock - amount < 0)
            {
                throw new ArgumentException("Not enough books in stock: current stock is " + stock + ", trying to deduct " +
                    amount);
            }

            stock -= amount;

            books[book] = stock;
        }

        public void AddPromoPackage(PromoPackage promoPackage)
        {
            promoPackages.Add(promoPackage);
        }


        public PromoPackage GetPromoPackage(Order order)
        {
            foreach (PromoPackage promoPackage in promoPackages)
            {
                if (promoPackage.IsEligible(order))
                {
                    return promoPackage;
                }
            }
            return null;
        }

        public bool IsPromoOrder(Order order)
        {
            foreach (PromoPackage promoPackage in promoPackages)
            {
                if (promoPackage.IsEligible(order))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
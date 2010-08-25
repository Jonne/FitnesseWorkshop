using System;
using System.Collections.Generic;
using System.Linq;
using DevnologyFitnesseDojo.Domain.Orders;

namespace DevnologyFitnesseDojo.Domain.Books
{
    public class Inventory
    {
        private static readonly Dictionary<Book, int> books = new Dictionary<Book, int>();
        private static readonly IList<PromoPackage> promoPackages = new List<PromoPackage>();

        public static void AddBook(Book book, int amount)
        {
            if (!books.ContainsKey(book))
            {
                books.Add(book, 0);
            }

            int currentAmount = books[book];

            currentAmount += amount;

            books[book] = currentAmount;
        }

        public static Book FindByTitle(string title)
        {
            return books.Keys.SingleOrDefault(book => book.Title == title);
        }

        public static Book FindByIsbn(string isbn)
        {
            return books.Keys.SingleOrDefault(book => book.Isbn == isbn);
        }

        /// <summary>
        /// Gets the number of books in the inventory.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static int CountBooks(Book book)
        {
            if (!books.ContainsKey(book))
            {
                return 0;
            }

            return books[book];
        }

        /// <summary>
        /// Deducts the amount given for the specified book in the inventory.
        /// </summary>
        /// <param name="book"></param>
        /// <param name="amount"></param>
        public static void DeductInventory(Book book, int amount)
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

        public static void AddPromoPackage(PromoPackage promoPackage)
        {
            promoPackages.Add(promoPackage);
        }

        public static PromoPackage GetPromoPackage(Order order)
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

        public static bool IsPromoOrder(Order order)
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
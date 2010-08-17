using System;
using System.Collections.Generic;
using System.Linq;

namespace DevnologyFitnesseDojo.Domain
{
    public class Inventory
    {
        private static readonly Inventory inventory = new Inventory();
        
        public static Inventory Instance
        {
            get { return inventory; }
        }

        private readonly Dictionary<Book, int> books = new Dictionary<Book,int>();

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

        public Book FindByTitle(String title)
        {
            return books.Keys.SingleOrDefault(book => book.Title == title);
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
                throw new ArgumentException("Not enough books in stock: current stock is " + stock + ", trying to deduct " + amount);
            }

            stock -= amount;

            books[book] = stock;
        }
    }
}

using DevnologyFitnesseDojo.Domain;
using DevnologyFitnesseDojo.Domain.Books;

namespace DevnologyFitnesseDojo.Fitnesse.Amasun.Book
{
    public class InitializeBookInventory
    {
        private int amount;
        private string author;
        private string isbn;
        private decimal price;
        private string title;

        public void Execute()
        {
            var book = new Domain.Books.Book { Author = author, Title = title, Isbn = isbn, Price = price };

            Inventory.AddBook(book, amount);
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetIsbn(string isbn)
        {
            this.isbn = isbn;
        }

        public void SetPrice(decimal price)
        {
            this.price = price;
        }

        public void SetAmount(int amount)
        {
            this.amount = amount;
        }
    }
}
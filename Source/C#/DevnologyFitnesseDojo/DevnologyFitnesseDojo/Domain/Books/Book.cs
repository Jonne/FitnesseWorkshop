
namespace DevnologyFitnesseDojo.Domain.Books
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public decimal Price { get; set; }

        public override bool Equals(object o)
        {
            var book = o as Book;

            if (book != null)
            {
                return Title == book.Title && Author == book.Author;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() + Author.GetHashCode();
        }
    }
}

using DevnologyFitnesseDojo.Domain;

namespace DevnologyFitnesseDojo.Fitnesse.Amasun.Book
{
    public class CheckBookInventory
    {
        private string author;
        private string title;

        public int Amount()
        {
            var book = new Domain.Book { Author = author, Title = title };

            return Inventory.Instance.CountBooks(book);
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }
    }
}
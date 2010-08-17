
namespace DevnologyFitnesseDojo.Domain
{
    public class BookService
    {
        public void BuyBook(Customer customer, int amount, Book book)
        {
            Inventory.Instance.DeductInventory(book, amount);
        }
    }
}

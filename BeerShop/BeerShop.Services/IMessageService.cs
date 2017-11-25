namespace BeerShop.Services
{
    public interface IMessageService
    {
        void Create(string name, string email, string phone, string subject, string content);
    }
}

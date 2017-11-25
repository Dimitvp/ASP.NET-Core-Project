namespace BeerShop.Services.Administration
{
    using Models.Messages;
    using System.Collections.Generic;

    public interface IAdminMessageService
    {
        IEnumerable<MessageListingModel> AllListing(int page = 1, int pageSize = 5);

        int Total();

        MessageDetailsModel ById(int id);

        void MarkAsRead(int id);

        void Delete(int id);
    }
}

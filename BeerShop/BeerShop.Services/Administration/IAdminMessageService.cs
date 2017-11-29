namespace BeerShop.Services.Administration
{
    using Models.Messages;
    using System.Collections.Generic;

    public interface IAdminMessageService
    {
        IEnumerable<MessageListingServiceModel> AllListing(int page = ServiceConstants.DefaultPage, int pageSize = ServiceConstants.DefaultPageSize);

        int Total();

        MessageDetailsServiceModel ById(int id);

        void MarkAsRead(int id);

        bool Delete(int id);
    }
}

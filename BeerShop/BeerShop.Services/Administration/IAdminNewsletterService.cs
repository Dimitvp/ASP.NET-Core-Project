namespace BeerShop.Services.Administration
{
    using Models.Newsletter;
    using System.Collections.Generic;

    using static ServiceConstants;

    public interface IAdminNewsletterService
    {
        IEnumerable<EmailListingServiceModel> All(int page = DefaultPage, int pageSize = DefaultPageSize);

        bool Delete(int id);

        EmailListingServiceModel ById(int id);

        byte[] Emails();

        int Total();
    }
}

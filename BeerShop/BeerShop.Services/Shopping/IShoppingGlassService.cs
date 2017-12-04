﻿namespace BeerShop.Services.Shopping
{
    using Models.Glasses;
    using System.Collections.Generic;

    using static ServiceConstants;

    public interface IShoppingGlassService
    {
        IEnumerable<GlassListingServiceModel> LatestListing();

        IEnumerable<GlassListingServiceModel> All(int page = DefaultPage, int pageSize = DefaultPageSize);

        IEnumerable<GlassListingServiceModel> Search(string searchTerm);

        GlassDetailsServiceModel ById(int id);

        int Total();
    }
}

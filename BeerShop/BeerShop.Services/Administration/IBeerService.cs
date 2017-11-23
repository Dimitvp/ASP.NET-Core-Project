﻿namespace BeerShop.Services.Administration
{
    using Microsoft.AspNetCore.Http;
    using Models.Beers;
    using System.Collections.Generic;

    public interface IBeerService
    {
        IEnumerable<BeerListingModel> AllListing();

        void Create(
            string name, 
            decimal price, 
            int quantity, 
            string description, 
            int styleId, 
            int breweryId,
            IFormFile image);

        BeerEditModel ById(int id);

        void Edit(
            int id, 
            string name, 
            decimal price, 
            int quantity,
            int styleId, 
            int breweryId,
            IFormFile image);

        void Delete(int id);
    }
}

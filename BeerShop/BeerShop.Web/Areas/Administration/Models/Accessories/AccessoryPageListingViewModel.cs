﻿namespace BeerShop.Web.Areas.Administration.Models.Accessories
{
    using Services.Administration.Models.Accessories;
    using System.Collections.Generic;

    public class AccessoryPageListingViewModel
    {
        public IEnumerable<AccessoryListingServiceModel> Accessories { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PreviousPage => this.CurrentPage == 1
            ? 1
            : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages
            ? this.TotalPages
            : this.CurrentPage + 1;
    }
}
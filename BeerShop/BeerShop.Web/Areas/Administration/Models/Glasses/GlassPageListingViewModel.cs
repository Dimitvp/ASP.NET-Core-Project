﻿namespace BeerShop.Web.Areas.Administration.Models.Glasses
{
    using Services.Administration.Models.Glasses;
    using System.Collections.Generic;

    public class GlassPageListingViewModel
    {
        public IEnumerable<GlassListingServiceModel> Glasses { get; set; }

        public string SearchTerm { get; set; }

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
namespace BeerShop.Services.Administration.Models.Logs
{
    using BeerShop.Common.Mapping;
    using BeerShop.Models;
    using BeerShop.Models.Enums;
    using System;

    public class LogListingModel : IMapFrom<Log>
    {
        public string Username { get; set; }

        public LogType LogType { get; set; }

        public string Table { get; set; }

        public DateTime Date { get; set; }
    }
}

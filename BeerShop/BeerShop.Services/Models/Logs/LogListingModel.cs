namespace BeerShop.Services.Models.Logs
{
    using BeerShop.Models.Enums;
    using System;

    public class LogListingModel
    {
        public string Username { get; set; }

        public LogType LogType { get; set; }

        public string Table { get; set; }

        public DateTime Date { get; set; }
    }
}

namespace BeerShop.Models
{
    using BeerShop.Models.Enums;
    using System;

    public class Log
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public LogType LogType { get; set; }

        public DateTime Date { get; set; }

        public string Table { get; set; }
    }
}

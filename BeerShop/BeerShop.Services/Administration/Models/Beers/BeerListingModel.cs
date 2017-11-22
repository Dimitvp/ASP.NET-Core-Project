namespace BeerShop.Services.Administration.Models.Beers
{
    public class BeerListingModel : BeerEditModel
    {
        public int Id { get; set; }

        public string Style { get; set; }

        public string Brewery { get; set; }
    }
}

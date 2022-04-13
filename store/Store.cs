using System;
using System.Collections.Generic;
using System.Linq;

namespace store
{
    public class Store
    {
        private List<string> VideoCategories { get; set; }
        private List<Video> Videos { get; set; }
        private List<Rental> RentalHistory { get; set; }
        private Dictionary<string, int> Price { get; set; }
        private Dictionary<Customer, List<Rental>> ActiveRental { get; set; }
        public List<Video> AvailableVideos { get; internal set; }

        public Store()
        {
            VideoCategories = new List<string> { "NewRelease", "Drama", "Comedy", "Romance", "Horror" };
            SetPrice();
            SetVideos();
        }

        public void CreateRental(Customer customer, List<Video> videos, int days)
        {
            int pricePerDay = videos.Aggregate(0, (result, item) => result + Price[item.Category]);
            Rental rental = new Rental(1, days, pricePerDay, customer, videos);  //TODO: startDate
            ActiveRental[customer].Add(rental);
            RentalHistory.Add(rental);
            AvailableVideos = AvailableVideos.Except(videos).ToList();
        }

        public void ReturnVideo(Rental rental)
        {
            _ = ActiveRental[rental.Renter].Remove(rental);
            AvailableVideos.AddRange(rental.Rents);
        }

        private void SetPrice()
        {
            HashSet<int> prices = Utilites.GenerateDistinctNumbers(1, 10, VideoCategories.Count);
            Price = VideoCategories.Zip(prices, (k, v) => (k, v)).ToDictionary(x => x.k, x => x.v);
        }

        private void SetVideos()
        {
            foreach (string category in VideoCategories)
            {
                for (char letter = 'A'; letter <= 'D'; letter++)
                {
                    Videos.Add(new Video(category + letter, category));
                }
            }
        }
    }
}
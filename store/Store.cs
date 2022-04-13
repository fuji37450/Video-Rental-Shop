using System;
using System.Collections.Generic;

namespace store
{
    public class Store
    {
        private List<Video> Videos { get; set; }
        private List<Rental> RentalHistory { get; set; }
        private Dictionary<string, int> Price { get; set; }
        private Dictionary<Customer, List<Rental>> ActiveRental { get; set; }
        public List<Video> AvailableVideos { get; internal set; }

        public Store()
        {
        }

        public void CreateRental(Customer customer, List<Video> videos, int days)
        {

        }

        public void ReturnVideo(Rental rental)
        {

        }
    }
}
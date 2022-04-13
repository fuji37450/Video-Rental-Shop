﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace store
{
    public class Store
    {
        public List<Video> AvailableVideos { get; internal set; }
        public List<Rental> RentalHistory { get; set; }
        private List<string> VideoCategories { get; set; }
        private List<Video> Videos { get; set; }
        private List<Rental> ActiveRental { get; set; }
        private Dictionary<string, int> Price { get; set; }

        public Store()
        {
            VideoCategories = new List<string> { "NewRelease", "Drama", "Comedy", "Romance", "Horror" };
            RentalHistory = new List<Rental>();
            ActiveRental = new List<Rental>();
            SetPrice();
            SetVideos();
            AvailableVideos = Videos;
        }

        public void CreateRental(Customer customer, List<Video> videos, int days)
        {
            int pricePerDay = videos.Aggregate(0, (result, item) => result + Price[item.Category]);
            Rental rental = new Rental(days, pricePerDay, customer, videos);
            ActiveRental.Add(rental);
            RentalHistory.Add(rental);
            AvailableVideos = AvailableVideos.Except(videos).ToList();
        }

        public void ReturnVideo(Rental rental)
        {
            _ = ActiveRental.Remove(rental);
            AvailableVideos.AddRange(rental.Rents);
        }

        private void SetPrice()
        {
            HashSet<int> prices = Utilites.GenerateDistinctNumbers(1, 10, VideoCategories.Count);
            Price = VideoCategories.Zip(prices, (k, v) => (k, v)).ToDictionary(x => x.k, x => x.v);
        }

        private void SetVideos()
        {
            Videos = new List<Video>();
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
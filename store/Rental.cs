using System;
using System.Collections.Generic;

namespace store
{
    public class Rental
    {
        public int TotalPrice { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public Customer Renter { get; set; }
        public List<Video> Rents { get; set; }

        public Rental(int days, int pricePerDay, Customer customer, List<Video> videos)
        {
            StartDate = Simulator.Today;
            EndDate = StartDate + days;
            TotalPrice = pricePerDay * days;
            Renter = customer;
            Rents = videos;
        }
    }
}

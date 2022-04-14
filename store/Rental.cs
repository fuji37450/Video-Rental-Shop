using System.Collections.Generic;

namespace store
{
    public class Rental
    {
        public int TotalPrice { get; private set; }
        public int StartDate { get; private set; }
        public int EndDate { get; private set; }
        public Customer Renter { get; private set; }
        public List<Video> Rents { get; private set; }

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

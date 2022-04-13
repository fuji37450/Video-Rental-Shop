using System;
using System.Collections.Generic;

namespace store
{
    public class Rental
    {
        private int TotalPrice { get; set; }
        private int StartDate { get; set; }
        private int EndDate { get; set; }
        private Customer Renter { get; set; }
        private List<Video> Rents { get; set; }

        public Rental()
        {
        }
    }
}

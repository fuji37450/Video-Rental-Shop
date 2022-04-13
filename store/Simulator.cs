using System;
using System.Collections.Generic;
using System.Linq;

namespace store
{
    class Simulator
    {
        public static int Today { get; set; }
        private static Store _store;
        private static List<Customer> Customers { get; set; }

        static void Main(string[] args)
        {
            _store = new Store();
            SetCustomers();

            for (Today = 1; Today <= 35; Today++)
            {
                Console.WriteLine($"Day {Today}");
                DaySimulate();
            }
        }

        private void Init()
        {

        }

        private static void DaySimulate()
        {
            CheckRental();
            List<Customer> customers = ChooseCustomer();
            if(_store.AvailableVideos.Count > 0)
            {
                foreach (Customer customer in customers)
                {
                    customer.Rent(ref _store);
                }
            }
        }

        private static void CheckRental()
        {
            //TODO: sort
            foreach (Rental rental in _store.RentalHistory)
            {
                if (rental.EndDate == Today)
                {
                    _store.ReturnVideo(rental);
                }
            }
        }

        private static List<Customer> ChooseCustomer()
        {
            HashSet<int> pickedNum = Utilites.GenerateDistinctNumbers(0, 9, 3);
            List<Customer> picked = (from num in pickedNum
                                  select Customers[num])
                                 .ToList();
            return picked;
        }

        private static void SetCustomers()
        {
            Customers = new List<Customer>();
            for (int i = 1; i <= 3; i++)
            {
                Customers.Add(new Breezy("Breezy" + i.ToString()));
            }

            for (int i = 1; i <= 3; i++)
            {
                Customers.Add(new Hoarder("Hoarder" + i.ToString()));
            }

            for (int i = 1; i <= 4; i++)
            {
                Customers.Add(new Regular("Regular" + i.ToString()));
            }
        }
    }
}

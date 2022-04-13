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
                DaySimulate();
            }
        }

        private static void DaySimulate()
        {
            CheckRental();
            List<Customer> customers = ChooseCustomer();

            if (_store.AvailableVideos.Count > 0)
            {
                foreach (Customer customer in customers)
                {
                    if (customer.CanRent(_store.AvailableVideos.Count))
                    {
                        customer.Rent(ref _store);
                    }
                }
            }
        }

        private static void CheckRental()
        {
            _store.ActiveRental.Where(rental => rental.EndDate == Today)
                               .ToList()
                               .ForEach(_store.ReturnVideo);
        }

        private static List<Customer> ChooseCustomer()
        {
            List<int> pickedNum = Utilites.GenerateDistinctNumbers(0, 9, 3);
            List<Customer> picked = Customers.Where((customer, index) => pickedNum.Contains(index))
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

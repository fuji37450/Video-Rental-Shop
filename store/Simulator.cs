using System;
using System.Collections.Generic;
using System.Linq;

namespace store
{
    class Program
    {
        static void Main()
        {
            Simulator simulator = Simulator.GetInstance();
            simulator.Run();
        }

    }

    public sealed class Simulator
    {
        private static Simulator _instance;
        public static int Today { get; private set; }
        private Store _store;
        private List<Customer> Customers { get; set; }

        private Simulator() { }

        public static Simulator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Simulator();
            }
            return _instance;
        }

        public void Run()
        {
            _store = new Store();
            SetCustomers();

            for (Today = 1; Today <= 35; Today++)
            {
                DaySimulate();
            }

            Report();
        }

        private void DaySimulate()
        {
            CheckRental();
            List<Customer> customers = ChooseCustomer();

            foreach (Customer customer in customers)
            {
                if (customer.CanRent(_store.AvailableVideos.Count))
                {
                    customer.Rent(ref _store);
                }
            }
        }

        private void CheckRental()
        {
            _store.ActiveRental.Where(rental => rental.EndDate == Today)
                               .ToList()
                               .ForEach(_store.ReturnVideo);
        }

        private List<Customer> ChooseCustomer()
        {
            List<int> pickedNum = Utilites.GenerateDistinctNumbers(0, 9, 3);
            List<Customer> picked = Customers.Where((customer, index) => pickedNum.Contains(index))
                                             .ToList();
            return picked;
        }

        private void SetCustomers()
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

        private void Report()
        {
            Console.WriteLine("Videos currently in the store:");
            ReportVideos(_store.AvailableVideos);
            Console.Write("The amount of money the store made during the 35 days: $");
            Console.WriteLine($"{_store.RentalHistory.Aggregate(0, (result, rental) => result + rental.TotalPrice)}");
            Console.WriteLine("Complete rentals:");
            ReportRentals(_store.RentalHistory.Except(_store.ActiveRental).ToList());
            Console.WriteLine("Active rentals:");
            ReportRentals(_store.ActiveRental);
        }

        private void ReportRentals(List<Rental> rentals)
        {
            Console.WriteLine("{0,5}  {1,-8}  {2,8}  {3,4}  {4,10}  {4}",
                              "No.",
                              "Renter",
                              "StartDay",
                              "Days",
                              "TotalPrice",
                              "Movies");
            for (int i = 0; i < rentals.Count; i++)
            {
                Rental rental = rentals[i];
                Console.Write("{0,5}| {1,-8}| {2,8}| {3,4}| {4,10}| ",
                              i + ".",
                              rental.Renter.Name,
                              rental.StartDate,
                              rental.EndDate - rental.StartDate,
                              rental.TotalPrice);
                ReportVideos(rental.Rents);
            }
        }

        private void ReportVideos(List<Video> videos)
        {
            if (videos.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                for (int i = 0; i < videos.Count; i++)
                {
                    Console.Write($"{videos[i].Name}");
                    if (i != videos.Count - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

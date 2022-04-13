using System;
using System.Collections.Generic;
using System.Linq;

namespace store
{
    public abstract class Customer
    {
        public string Name { get; set; }
        protected int Amount { get; set; }
        protected int Days { get; set; }
        protected List<Video> Picked { get; set; }

        public Customer(string name) => Name = name;

        public void Rent(ref Store store)
        {
            UpdateAmountAndDays();

            Picked = PickVideos(ref store);

            if (Picked?.Any() == true)
            {
                store.CreateRental(this, Picked, Days);
            }
        }

        public List<Video> PickVideos(ref Store store)
        {
            List<Video> avaliable = store.AvailableVideos;

            if (avaliable.Count < Amount)
            {
                return null;
            }

            HashSet<int> pickedNum = Utilites.GenerateDistinctNumbers(0, avaliable.Count - 1, Amount);
            List<Video> picked = (from num in pickedNum
                                  select avaliable[num])
                                 .ToList();
            return picked;
        }

        protected abstract void UpdateAmountAndDays();
    }
}

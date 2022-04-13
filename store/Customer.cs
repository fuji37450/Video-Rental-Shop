using System;
using System.Collections.Generic;
using System.Linq;

namespace store
{
    public abstract class Customer
    {
        protected int Amount { get; set; }
        protected int Days { get; set; }
        protected List<Video> Picked { get; set; }
        public string Name { get; set; }

        public Customer(string name) => Name = name;

        public abstract void Rent(ref Store store);

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
    }
}

using System.Collections.Generic;
using System.Linq;

namespace store
{
    public abstract class Customer
    {
        public string Name { get; private set; }
        public int RentedCount { get; set; }
        protected const int MaximumRent = 3;
        protected int Amount { get; set; }
        protected int Days { get; set; }
        protected List<Video> PickedVideo { get; set; }

        public Customer(string name) => Name = name;

        public virtual bool CanRent(int inventory)
        {
            return RentedCount < MaximumRent && inventory > 0;
        }

        public void Rent(ref Store store)
        {
            RandomAmountAndDays(store.AvailableVideos.Count);

            PickedVideo = PickVideos(store.AvailableVideos);
            RentedCount += Amount;

            store.CreateRental(this, PickedVideo, Days);
        }

        public List<Video> PickVideos(List<Video> availableVideos)
        {
            List<int> pickedNum = Utilites.GenerateDistinctNumbers(0, availableVideos.Count - 1, Amount);
            List<Video> picked = availableVideos.Where((video, index) => pickedNum.Contains(index))
                                                .ToList();
            return picked;
        }

        protected virtual void RandomAmountAndDays(int inventory) { }
    }
}

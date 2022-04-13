using System;
namespace store
{
    public class Breezy : Customer
    {
        public Breezy(string name) : base(name){}

        public override void Rent(ref Store store)
        {
            Amount = Utilites.GenerateNumber(1, 2);
            Days = Utilites.GenerateNumber(1, 2);
            Picked = PickVideos(ref store);

            store.CreateRental(this, Picked, Days);
        }
    }
}

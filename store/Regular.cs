using System;
using System.Collections.Generic;
using System.Linq;

namespace store
{
    public class Regular : Customer
    {
        public Regular(string name) : base(name){}

        public override void Rent(ref Store store)
        {
            Amount = Utilites.GenerateNumber(1, 3);
            Days = Utilites.GenerateNumber(3, 5);
            Picked = PickVideos(ref store);

            store.CreateRental(this, Picked, Days);
        }
    }
}

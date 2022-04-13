﻿using System;
using System.Linq;

namespace store
{
    public class Hoarder:Customer
    {
        public Hoarder(string name) : base(name)
        {
            Amount = 3;
            Days = 7;
        }

        public override void Rent(ref Store store)
        {
            Picked = PickVideos(ref store);

            if (Picked?.Any() == true)
            {
                store.CreateRental(this, Picked, Days);
            }
        }
    }
}

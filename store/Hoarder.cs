using System;
using System.Collections.Generic;
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

        public override bool CanRent(int inventory)
        {
            return RentedCount == 0 && inventory >= 3;
        }
    }
}

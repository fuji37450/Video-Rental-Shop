using System;
using System.Collections.Generic;
using System.Linq;

namespace store
{
    public class Breezy : Customer
    {
        public Breezy(string name) : base(name){}

        protected override void RandomAmountAndDays(int inventory)
        {
            Amount = Utilites.GenerateNumber(1, Math.Min(3, inventory));
            Days = Utilites.GenerateNumber(1, 2);
        }
    }
}

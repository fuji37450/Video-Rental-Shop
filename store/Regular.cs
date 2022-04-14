using System;
using System.Collections.Generic;
using System.Linq;

namespace store
{
    public class Regular : Customer
    {
        public Regular(string name) : base(name){}

        protected override void RandomAmountAndDays(int inventory)
        {
            Amount = Utilites.GenerateNumber(1, Math.Min(3 - RentedCount, inventory));
            Days = Utilites.GenerateNumber(3, 5);
        }
    }
}

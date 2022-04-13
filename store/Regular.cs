using System;
using System.Collections.Generic;
using System.Linq;

namespace store
{
    public class Regular : Customer
    {
        public Regular(string name) : base(name){}

        protected override void UpdateAmountAndDays()
        {
            Amount = Utilites.GenerateNumber(1, 3);
            Days = Utilites.GenerateNumber(3, 5);
        }
    }
}

using System;
using System.Linq;

namespace store
{
    public class Breezy : Customer
    {
        public Breezy(string name) : base(name){}

        protected override void UpdateAmountAndDays()
        {
            Amount = Utilites.GenerateNumber(1, 2);
            Days = Utilites.GenerateNumber(1, 2);
        }
    }
}

using System;
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

        protected override void UpdateAmountAndDays()
        {
        }
    }
}

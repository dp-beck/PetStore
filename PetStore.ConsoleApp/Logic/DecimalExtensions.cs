using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public static class DecimalExtensions
    {

        public static decimal DiscountThisPrice(this decimal value)
        {
            return Math.Round(value * 0.9m, 2);
        }
    }
}

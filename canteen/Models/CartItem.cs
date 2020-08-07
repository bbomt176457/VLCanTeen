using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using canteen.Models;

namespace canteen.Models
{
    public class CartItem
    {
        public Food1 Food { set; get; }
        public int Amount { set; get; }
        public int Total
        {
            get
            {
                return Amount * (int)Food.Price;
            }
        }
    }
}
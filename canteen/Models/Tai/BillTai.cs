using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using canteen.Models;

namespace canteen.Models.Tai
{

    public class BillTai
    {
        SEP23Team9Entities1 db = null;
        public BillTai()
        {
            db = new SEP23Team9Entities1();
        }
        public int Insert(Bill bill)
        {
            db.Bills.Add(bill);
            db.SaveChanges();
            return bill.Bill_ID;
        }

    }
}
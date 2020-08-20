using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using canteen.Models;

namespace canteen.Models.Tai
{
    public class BillDetailTai
    {
        SEP23Team9Entities1 db = null;
        public BillDetailTai()
        {
            db = new SEP23Team9Entities1();
        }
        public bool Insert(BillDetail detailTai)
        {
            try
            {
                db.BillDetails.Add(detailTai);
                db.SaveChanges();
                return true;
            }

            catch
            {
                return false;

            }
        }
    }
}
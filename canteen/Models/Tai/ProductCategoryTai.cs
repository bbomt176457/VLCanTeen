using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using canteen.Models;

namespace canteen.Models.Tai
{
    
    public class ProductCategoryTai         
    {
        SEP23Team9Entities1 db = null;
        public ProductCategoryTai()
        {
            db = new SEP23Team9Entities1();
        }
        public List<Category> ListAll(int top)
        {
            return db.Categories.OrderByDescending(x => x.Category_ID).Take(top).ToList();
        }
        public Category ViewDetail(long id)
        {
            return db.Categories.Find(id);
        }


    }
}
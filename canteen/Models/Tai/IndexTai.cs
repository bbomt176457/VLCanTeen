using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Text;
using canteen.Models;
using PagedList;
using PagedList.Mvc;

namespace canteen.Tai
{
    public class IndexTai
    {
        SEP23Team9Entities db = new SEP23Team9Entities();
        public IEnumerable<Food1> ListAllPaging(int page ,int pageSize)
        {
            return db.Food1.OrderByDescending(x=>x.Food_ID).ToPagedList(page,pageSize );
        }
    }
}
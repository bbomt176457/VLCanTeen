using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace canteen.Models
{
    public class FoodItem
    {
        SEP23Team9Entities db = null;
        public FoodItem()
        {
            db = new SEP23Team9Entities();
        }
        public List<Food1> ListNewFood(int top)
        {
            return db.Food1.OrderByDescending(x => x.Food_ID).Take(top).ToList();
        }
        public List<Food1> ListRelatedfood(long foodId)
        {
            var food = db.Food1.Find(foodId);
            return db.Food1.Where(x => x.Food_ID != foodId && x.Category == food.Category).ToList(); 
        }
        public Food1 Viewdetail(long id)
        {
            return db.Food1.Find(id);

        }  
    }
}
using Kantin.DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantin.DATA.DataAccess
{
    public class CategoryDataAccess
    {
        public static bool Add(Category model)
        {
            try
            {
                using (var db = new DataContext())
                {
                    db.Categories.Add(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool Delete(int id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Categories.Find(id);
                    db.Categories.Remove(data);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Update(Category model)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Categories.Find(model.Id);
                    data.Name = model.Name;

                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<Category> CategoryList()
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Categories.ToList();
                    return data;
                }
            }
            catch (Exception)
            {
                return new List<Category>();
            }
        }

        public static Category ReturnCategory(int id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Categories.Find(id);
                    return data;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }


    }
}

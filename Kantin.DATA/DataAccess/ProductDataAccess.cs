using Kantin.DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantin.DATA.DataAccess
{
    public class ProductDataAccess
    {
        public static bool Add(Product model)
        {
            try
            {
                using (var db = new DataContext())
                {
                    db.Products.Add(model);
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
                    var data = db.Products.Find(id);
                    db.Products.Remove(data);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static List<Product> ProductList()
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Products.ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }

        public static bool UpdateProduct(Product model)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Products.Find(model.Id);
                    data.Name = model.Name;
                    data.Price = model.Price;
                    data.Stock = model.Stock;
                    data.Barcode = model.Barcode;
                    if (model.UrunLink!=null)
                    {
                        data.UrunLink = model.UrunLink;
                    }

                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Product Product(int id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Products.Find(id);
                    return data;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Product> CategoryUrun(int id, string search)
        {
            try
            {
                using (var db = new DataContext())
                {
                    if (search != null && id != 0)
                    {
                        var data = db.Products.Where(i => i.CategoryId == id).Where(i => i.Name.Contains(search)).ToList();
                        return data;
                    }
                    else if (search!=null)
                    {
                        var data = db.Products.Where(i => i.Name.Contains(search)).ToList();
                        return data;
                    }
                    else if (id!=0)
                    {
                        var data = db.Products.Where(i => i.CategoryId == id).ToList();
                        return data;
                    }
                    else
                    {
                        var data = db.Products.ToList();
                        return data;
                    }

                }
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }

        }

        public static bool Satis(int id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Products.Find(id);

                    data.Stock--;
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return true;
            }

        }

        public static bool Iade(int id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Products.Find(id);

                    data.Stock++;
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

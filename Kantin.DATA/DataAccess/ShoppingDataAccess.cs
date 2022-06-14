using Kantin.DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantin.DATA.DataAccess
{
    public class ShoppingDataAccess
    {
        public static bool FaturaOlustur(Fatura model)
        {
            try
            {
                using (var db = new DataContext())
                {
                    db.Faturas.Add(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static List<Fatura> TumFaturalar()
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Faturas.ToList();
                    return data;
                }
            }
            catch (Exception)
            {
                return new List<Fatura>();
            }
        }
    
        public static bool FaturaSil(int id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Faturas.Find(id);

                    db.Faturas.Remove(data);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
   
        public static Fatura FaturaGetir(int id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Faturas.Find(id);
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

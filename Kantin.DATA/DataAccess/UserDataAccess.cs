using Kantin.DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantin.DATA.DataAccess
{
    public class UserDataAccess
    {
        public static bool Add(User model)
        {
            try
            {
                using (var db = new DataContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static User Login(string Username, string Password)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Users.Where(i => i.Username == Username && i.Password == Password).FirstOrDefault();
                    return data;
                }
            }
            catch (Exception)
            {

                return new User();
            }



        }

        public static bool Guncelle(User model)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Users.Find(model.Id);
                    data.Name = model.Name;
                    data.Password = model.Password;
                    data.Surname = model.Surname;
                    data.Username = model.Username;
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
    
        public static bool Sil (int id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Users.Find(id);
                    db.Users.Remove(data);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    
        public static User Getir(int id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Users.Find(id);
                    return data;
                }
            }
            catch (Exception)
            {
                return null;
            }


        }

        public static List<User> Users()
        {
            try
            {
                using (var db = new DataContext())
                {
                    var data = db.Users.ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
   
        //public static bool LogOut()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }

}

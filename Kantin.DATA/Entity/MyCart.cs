using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantin.DATA.Entity
{
    public class MyCart
    {
        public int Id { get; set; }
        public static List<Cart> Cart { get; set; }
        public static float Toplam { get; set;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantin.DATA.Entity
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Barcode { get; set; }
        public int Stock { get; set; }
        public string UrunLink { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

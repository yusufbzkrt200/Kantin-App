using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantin.DATA.Entity
{
    [Table("dbo.Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Barcode { get; set; }
        public int Stock { get; set; }
        public string UrunLink { get; set; }
        
        public int CategoryId { get; set; }
    }
}

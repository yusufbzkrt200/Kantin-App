using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantin.DATA.Entity
{
    [Table("dbo.Faturas")]

    public class Fatura
    {
        [Key]
        public int Id { get; set; }
        public float Toplam { get; set; }
        public string Urunler { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string FaturaLink { get; set; }
        public bool Cash { get; set; }
        public bool Iade { get; set; }
    }
}

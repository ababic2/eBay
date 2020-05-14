using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eBay.Models
{
    public class Proizvod
    {
        public int ProizvodId { get; set; }
        public String Naziv { get; set; }
        public String OpisProizvoda { get; set; }
        
        [Column(TypeName = "decimal(5, 2)")] // Tip kakav ce bit u bazi. Mora se staviti preciznost. Inace se prikazuje warning
        public decimal Cijena { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoPets.Models
{
    [Table("Pets")]
    public class Pet
    {
        [Key]
        public int CodigoPet { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Especie { get; set; }
    }
}

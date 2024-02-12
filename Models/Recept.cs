using System.ComponentModel.DataAnnotations;

namespace KoktelosAPIKezdemeny.Models
{
    public class Recept
    {
        [Key]
        public int Ssz { get; set; }
        public int Koktel_Id { get; set;}
        public int Osszetevo_Id { get; set;}
        public int Mennyiseg { get; set; }
    }
}

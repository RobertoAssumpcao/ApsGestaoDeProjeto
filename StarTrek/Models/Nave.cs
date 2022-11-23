using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StarTrek.Models
{
    public class Nave
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Afiliacao { get; set; }
        public string Classe { get; set; }
        [DisplayName("Data de lançamento")]
        public DateTime DataLancamento { get; set; }
        public string Registro { get; set; }
        public string Status { get; set; }
        public string Propulsao { get; set; }
        public string Armamento { get; set; }
        public string Defesa { get; set; }


    }
}
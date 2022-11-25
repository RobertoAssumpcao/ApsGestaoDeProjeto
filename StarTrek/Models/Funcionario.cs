using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StarTrek.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nome da Pessoa")]
        public string NomePessoa { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        [DisplayName("Profissão")]
        public string Profissao { get; set; }
        public string Email { get; set; }
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace ManipulacaoDeDados.Models
{
    public class ContatoModelo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o nome do contato!")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Insira o e-mail do contato!")]
        [EmailAddress(ErrorMessage = "O e-mail inserido não é válido!")]
        public string  email{ get; set;}
        [Required(ErrorMessage = "Insira um telemovel do contato!")]
        [Phone(ErrorMessage = "O telemovel inserido não é válido!")]
        public string telemovel { get; set;}
    }
}

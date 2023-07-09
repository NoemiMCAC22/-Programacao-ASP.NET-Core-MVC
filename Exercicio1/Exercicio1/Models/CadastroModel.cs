using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio1.Models
{
    public class CadastroModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o endereço do Contato")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Digite o número do Telemovel do Contato")]
        [Phone(ErrorMessage = " O Telemóvel inserido não é válido!")]
        public string Telemovel { get; set; }
        


    }
}

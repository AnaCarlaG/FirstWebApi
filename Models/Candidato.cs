using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Candidato
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Apelido { get; set; }
        [Required]
        public string CPF { get; set; }
        public string Bairro { get; set; }
       
        public string Logradouro { get; set; }
        public string Numero { get; set; }
       
        public string Complemento { get; set; }
       
        public string Email { get; set; }
       
        public string Celular { get; set; }
        public string CelularOpcional { get; set; }

        public int IdCidade { get; set; }
        public Cidade cidade { get; set; }
    }
}

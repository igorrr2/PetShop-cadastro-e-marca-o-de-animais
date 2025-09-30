using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{

    public class Animal
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Raca { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Observacoes { get; set; }

        public Animal()
        {
            Nome = string.Empty; Tipo = string.Empty; Raca = string.Empty; Sexo = string.Empty; Observacoes = string.Empty;
            Id = Guid.Empty;
            DataNascimento = DateTime.Now;
        }
    }

}


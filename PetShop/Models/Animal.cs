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
        public string NomeAnimal { get; set; }
        public string NomeTutor { get; set; }
        public string Raca { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Observacoes { get; set; }
        public string NumeroTelefoneTutor { get; set; }

        public Animal()
        {
            NomeAnimal = string.Empty; NomeTutor = string.Empty; Raca = string.Empty; Sexo = string.Empty; Observacoes = NumeroTelefoneTutor = string.Empty;
            Id = Guid.Empty;
            DataNascimento = DateTime.Now;
        }
    }

}


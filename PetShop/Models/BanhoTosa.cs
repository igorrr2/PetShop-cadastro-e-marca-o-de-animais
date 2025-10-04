using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class BanhoTosa
    {
        public Guid Id { get; set; }

        public DateTime DataAgendamento { get; set; }
        
        public string NomeAnimalAgendado { get; set; }

        public string NomeTutorAnimal { get; set; }

        public string ModalidadeAgendamento { get; set; }

        public string Observacoes { get; set; }

        public BanhoTosa() {
            NomeAnimalAgendado = ModalidadeAgendamento = Observacoes = NomeTutorAnimal = string.Empty;
            Id = Guid.Empty;
            DataAgendamento = DateTime.Now;
        }

    }
}

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

        public string IdAgendamentoBancoServidor { get; set; }

        public string UsuarioId { get; set; }

        public Guid AnimalId { get; set; }

        public DateTime DataAgendamento { get; set; }

        public string ModalidadeAgendamento { get; set; }

        public string Observacoes { get; set; }

        public string NomeAnimalAgendado { get; set; }
        public string NomeTutorAnimal { get; set; }

        public BanhoTosa() {
            IdAgendamentoBancoServidor = UsuarioId = ModalidadeAgendamento = Observacoes = string.Empty;
            Id = AnimalId = Guid.Empty;
            DataAgendamento = DateTime.Now;
        }

    }
}

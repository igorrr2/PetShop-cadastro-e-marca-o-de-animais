using PetShop.Data;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop.Telas
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            AnimalRepository.Initialize();
            BanhoTosaRepository.Initialize();

            BanhoTosaRepository.TryGetByAgendamentosDoDia(out List<BanhoTosa> listaBanhoTosa);

            if (listaBanhoTosa.Count > 0)
            {
                var popup = new AgendamentosDoDiaForm(listaBanhoTosa);

                popup.Owner = this;
                popup.TopMost = true;
                popup.StartPosition = FormStartPosition.CenterScreen;
                popup.Show(); 
            }
        }
    }
}

using PetShop.Data;
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
        }

        private void BtnCadastrarAnimal_Click(object sender, EventArgs e)
        {
            //AbrirFormularioNoPanel(new CadastrarAnimalForm());
        }

        private void BtnAgendarConsulta_Click(object sender, EventArgs e)
        {
            //AbrirFormularioNoPanel(new AgendarConsultaForm());
        }

        private void BtnAgendarBanho_Click(object sender, EventArgs e)
        {
            //AbrirFormularioNoPanel(new AgendarBanhoForm());
        }
    }
}

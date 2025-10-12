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

            // Painel principal
            panelConteudo = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(149, 94, 38)
            };
            this.Controls.Add(panelConteudo);

            // Menu lateral
            menuLateral = new MenuForm();
            menuLateral.CadastrarAnimalClicked += (s, e) => AbrirFormularioNoPanel(new CadastrarAnimalForm(Guid.Empty));
            menuLateral.AgendarConsultaClicked += (s, e) => AbrirFormularioNoPanel(new AgendarConsultaForm());
            menuLateral.AgendarBanhoClicked += (s, e) => AbrirFormularioNoPanel(new AgendarBanhoTosaForm(Guid.Empty));
            menuLateral.VisualizarConsultasAgendadasClicked += (s, e) => AbrirFormularioNoPanel(new VisualizarConsultasAgendadas());
            menuLateral.VisualizarBanhoETosasAgendadasClicked += (s, e) => AbrirFormularioNoPanel(new VisualizarBanhoETosasAgendadas());
            menuLateral.VisualizarAnimaisCadastradosClicked += (s, e) => AbrirFormularioNoPanel(new VisualizarAnimaisCadastrados());
            menuLateral.AlterarSenhaClicked += (s, e) => AbrirFormularioNoPanel(new AlterarSenhaForm());
            menuLateral.LogoutClicked += (s, e) =>
            {
                AppSession.Logout(this);
                this.Close();

                LoginForm login = new LoginForm();
                login.StartPosition = FormStartPosition.CenterScreen;
                login.WindowState = FormWindowState.Maximized;
                login.Show();
            };

            this.Controls.Add(menuLateral);

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

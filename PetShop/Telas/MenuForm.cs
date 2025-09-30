using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetShop.Telas
{
    public partial class MenuForm : UserControl
    {
        public event EventHandler CadastrarAnimalClicked;
        public event EventHandler VisualizarAnimaisCadastradosClicked;
        public event EventHandler AgendarConsultaClicked;
        public event EventHandler VisualizarConsultasAgendadasClicked;
        public event EventHandler AgendarBanhoClicked;
        public event EventHandler VisualizarBanhoETosasAgendadasClicked;
        public event EventHandler LogoutClicked;

        public MenuForm()
        {
            InitializeComponent();
            CriarBotoesMenu();
        }

        private void CriarBotoesMenu()
        {
            this.Dock = DockStyle.Left;
            this.Width = 200;
            this.BackColor = Color.LightGray;

            // Botões topo
            Button btnCadastrarAnimal = new Button { Text = "Cadastrar Animal", Dock = DockStyle.Top, Height = 50 };
            btnCadastrarAnimal.Click += (s, e) => CadastrarAnimalClicked?.Invoke(this, EventArgs.Empty);

            Button btnVisualizarAnimaisCadastrados = new Button { Text = "Visualizar Animais Cadastrados", Dock = DockStyle.Top, Height = 50 };
            btnVisualizarAnimaisCadastrados.Click += (s, e) => VisualizarAnimaisCadastradosClicked?.Invoke(this, EventArgs.Empty);

            Button btnAgendarConsulta = new Button { Text = "Agendar Consulta", Dock = DockStyle.Top, Height = 50 };
            btnAgendarConsulta.Click += (s, e) => AgendarConsultaClicked?.Invoke(this, EventArgs.Empty);

            Button btnVisualizarConsultasAgendadas = new Button { Text = "Visualizar Consultas Agendadas", Dock = DockStyle.Top, Height = 50 };
            btnVisualizarConsultasAgendadas.Click += (s, e) => VisualizarConsultasAgendadasClicked?.Invoke(this, EventArgs.Empty);

            Button btnAgendarBanho = new Button { Text = "Agendar Banho e Tosa", Dock = DockStyle.Top, Height = 50 };
            btnAgendarBanho.Click += (s, e) => AgendarBanhoClicked?.Invoke(this, EventArgs.Empty);

            Button btnVisualizarBanhoETosaAgendados = new Button { Text = "Visualizar Banho e Tosa Agendados", Dock = DockStyle.Top, Height = 50 };
            btnVisualizarBanhoETosaAgendados.Click += (s, e) => VisualizarBanhoETosasAgendadasClicked?.Invoke(this, EventArgs.Empty);

            Button btnLogout = new Button { Text = "Logout", Dock = DockStyle.Bottom, Height = 50 };
            btnLogout.Click += (s, e) => LogoutClicked?.Invoke(this, EventArgs.Empty);

            // Adiciona botões **na ordem que quer que apareçam**
            this.Controls.Add(btnVisualizarBanhoETosaAgendados);
            this.Controls.Add(btnAgendarBanho);
            this.Controls.Add(btnVisualizarConsultasAgendadas);
            this.Controls.Add(btnAgendarConsulta);
            this.Controls.Add(btnVisualizarAnimaisCadastrados);
            this.Controls.Add(btnCadastrarAnimal);
            this.Controls.Add(btnLogout);
        }
    }
}

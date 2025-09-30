using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetShop.Telas
{
    public partial class MainForm : Form
    {
        private MenuForm menuLateral;
        private Panel panelConteudo;

        private void InitializeComponent()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            // Painel principal
            panelConteudo = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.WhiteSmoke
            };
            this.Controls.Add(panelConteudo);

            // Menu lateral
            menuLateral = new MenuForm();
            menuLateral.CadastrarAnimalClicked += (s, e) => AbrirFormularioNoPanel(new CadastrarAnimalForm(Guid.Empty));
            menuLateral.AgendarConsultaClicked += (s, e) => AbrirFormularioNoPanel(new AgendarConsultaForm());
            menuLateral.AgendarBanhoClicked += (s, e) => AbrirFormularioNoPanel(new AgendarBanhoTosaForm());
            menuLateral.VisualizarConsultasAgendadasClicked += (s, e) => AbrirFormularioNoPanel(new VisualizarConsultasAgendadas());
            menuLateral.VisualizarBanhoETosasAgendadasClicked += (s, e) => AbrirFormularioNoPanel(new VisualizarBanhoETosasAgendadas());
            menuLateral.VisualizarAnimaisCadastradosClicked += (s, e) => AbrirFormularioNoPanel(new VisualizarAnimaisCadastrados());
            menuLateral.LogoutClicked += (s, e) =>
            {
                AppSession.Logout();
                this.Close();

                LoginForm login = new LoginForm();
                login.StartPosition = FormStartPosition.CenterScreen;
                login.WindowState = FormWindowState.Maximized;
                login.Show();
            };

            this.Controls.Add(menuLateral);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Text = "PetShop - Sistema";
        }

        private void AbrirFormularioNoPanel(Form formFilho)
        {
            panelConteudo.Controls.Clear();
            formFilho.TopLevel = false;
            formFilho.FormBorderStyle = FormBorderStyle.None;
            formFilho.Dock = DockStyle.Fill;
            panelConteudo.Controls.Add(formFilho);
            panelConteudo.Tag = formFilho;
            formFilho.Show();
        }
    }
}

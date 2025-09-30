using PetShop.Mensagens;
using System.Windows.Forms;
using PetShop.MensagemRetorno;
using PetShop.Telas;

namespace PetShop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private static Mensagem Logar(string login, string senha)
        {
            Mensagem mensagem = new Mensagem();
            try
            {
                //chamar login webService
                AppSession.Token = new Guid().ToString();
                AppSession.Usuario = "Igor";
                return mensagem;
            }catch (Exception ex){
                return new Mensagem(ex.Message, ex);
            }
        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                errorProvider.SetError(LoginTextBox, MensagemAlerta.LoginNaoPreenchido);
                LoginTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(SenhaTextBox.Text))
            {
                errorProvider.SetError(SenhaTextBox, MensagemAlerta.SenhaNaoPreenchida);
                SenhaTextBox.Focus();
                return;
            }
            Mensagem mensagem = Logar(LoginTextBox.Text, SenhaTextBox.Text);
            if (!mensagem.Sucesso){
                MessageBox.Show(mensagem.Descricao, MensagemTitulo.ErroTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Login OK → abrir a tela principal
            MainForm mainForm = new MainForm();
            mainForm.Show();

            // Opcional: esconder ou fechar a tela de login
            this.Hide(); // só esconde
                         // this.Close(); // fecha completamente
        }
    }
}
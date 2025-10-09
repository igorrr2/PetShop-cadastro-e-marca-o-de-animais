using PetShop.Mensagens;
using System.Windows.Forms;
using Util.MensagemRetorno;
using PetShop.Telas;
using Util.Criptografia;
using System.Windows.Forms.Design;
using ApiPetShopLibrary.Login;
using PetShopClient;

namespace PetShop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private static async Task<Mensagem> Logar(string login, string senha)
        {
            Mensagem mensagem = new Mensagem();
            LoginResposta resposta;
            try
            {
                Client cliente = new Client();
                (mensagem, resposta) = await cliente.LogarAsync(login, senha);
                if (!mensagem.Sucesso)
                    return mensagem;

                if(resposta == null)
                    return new Mensagem("Não foi encontrado nenhum usuário no banco de dados");

                if(resposta.statusCode != 200)
                    return new Mensagem(resposta.MensagemRetorno);
                
                AppSession.Token = resposta.TokenAutenticacao;
                AppSession.Usuario = resposta.UsuarioNome;

                return mensagem;
            }catch (Exception ex){
                return new Mensagem(ex.Message, ex);
            }
        }

        private async void Loginbutton_Click(object sender, EventArgs e)
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
            Mensagem mensagem = await Logar(LoginTextBox.Text, SenhaTextBox.Text);
            if (!mensagem.Sucesso){
                MessageBox.Show(mensagem.Descricao, MensagemTitulo.ErroTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
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

        private static async Task<Mensagem> Logar(string login, string senha, Form owner)
        {

            Mensagem mensagem = new Mensagem();
            LoginResposta resposta = null;

            using (var loading = new LoadingForm("Efetuando login...", "Aguarde enquanto o login está sendo efetuado"))
            { 
                loading.StartPosition = FormStartPosition.CenterScreen;

                var task = Task.Run(async () =>
                {
                    try
                    {
                        Client cliente = new Client();
                        (mensagem, resposta) = await cliente.LogarAsync(login, senha);
                    }
                    catch (Exception ex)
                    {
                        mensagem = new Mensagem(ex.Message, ex);
                    }
                    finally
                    {
                        
                        if (!loading.IsDisposed)
                            loading.Invoke(new Action(() => loading.Close()));
                    }
                });

                loading.ShowDialog(owner);
                task.Wait();
            }

            if (!mensagem.Sucesso) return mensagem;
            if (resposta == null) return new Mensagem("Não foi encontrado nenhum usuário no banco de dados");
            if (resposta.statusCode != 200) return new Mensagem(resposta.MensagemRetorno);

            AppSession.Token = resposta.TokenAutenticacao;
            AppSession.Usuario = resposta.UsuarioNome;
            AppSession.UsuarioId = resposta.UsuarioId;

            return mensagem;
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
            Mensagem mensagem = await Logar(LoginTextBox.Text, SenhaTextBox.Text, this);
            if (!mensagem.Sucesso)
            {
                MessageBox.Show(mensagem.Descricao, MensagemTitulo.ErroTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Hide(); 
        }
    }
}
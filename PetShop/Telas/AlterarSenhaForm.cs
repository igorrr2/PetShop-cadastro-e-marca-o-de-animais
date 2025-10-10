using ApiPetShopLibrary.Login;
using Microsoft.VisualBasic.Logging;
using PetShop.Data;
using PetShop.Mensagens;
using PetShop.Models;
using PetShopClient;
using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Util.MensagemRetorno;

namespace PetShop.Telas
{
    public partial class AlterarSenhaForm : Form
    {

        public AlterarSenhaForm()
        {
            InitializeComponent();
        }

        public bool ValidarPreenchimentoDosCampos()
        {
            if (string.IsNullOrEmpty(SenhaAtualTextBox.Text))
            {
                errorProvider.SetError(SenhaAtualTextBox, "Senha atual não foi preenchida");
                return false;
            }
            if (string.IsNullOrEmpty(NovaSenhaTextBox.Text))
            {
                errorProvider.SetError(NovaSenhaTextBox, "Nova senha não foi preenchida");
                return false;
            }
            if (string.IsNullOrEmpty(NovaSenhaConfirmacaoTextBox.Text))
            {
                errorProvider.SetError(NovaSenhaConfirmacaoTextBox, "Confirmação de senha não foi preenchida");
                return false;
            }
            return true;
        }

        private void AlterarSenhaForm_Load(object sender, EventArgs e)
        {
            CentralizarPanel();
        }

        private void AlterarSenhaForm_Resize(object sender, EventArgs e)
        {
            CentralizarPanel();
        }

        private void CentralizarPanel()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
            panelCentral.Top = (this.ClientSize.Height - panelCentral.Height) / 2;
        }

        private async void AlterarSenhaButton_ClickAsync(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (!ValidarPreenchimentoDosCampos())
                return;

            if (NovaSenhaTextBox.Text != NovaSenhaConfirmacaoTextBox.Text)
            {
                MessageBox.Show(
                    "As senhas informadas não conferem.",
                    MensagemTitulo.ErroTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Mensagem mensagem = null;
            AlterarSenhaResposta resposta = null;

            // Monta solicitação
            var solicitacao = new AlterarSenhaSolicitacao
            {
                Token = AppSession.Token, // ou como você estiver armazenando o token
                SenhaAtual = SenhaAtualTextBox.Text,
                NovaSenha = NovaSenhaTextBox.Text,
                NovaSenhaConfirmacao = NovaSenhaConfirmacaoTextBox.Text
            };

            string titulo = "Alterando Senha...";
            string texto = "Aguarde enquanto sua senha está sendo atualizada.";

            using (var loading = new LoadingForm(titulo, texto))
            {
                var task = Task.Run(async () =>
                {
                    try
                    {
                        var client = new Client();
                        (mensagem, resposta) = await client.AlterarSenhaAsync(solicitacao);
                    }
                    catch (Exception ex)
                    {
                        mensagem = new Mensagem(ex.Message, ex);
                    }
                    finally
                    {
                        if (loading.IsHandleCreated && !loading.IsDisposed)
                        {
                            loading.Invoke(new Action(() => loading.Close()));
                        }
                    }
                });

                loading.ShowDialog();
                await task;
            }

            if (mensagem != null && !mensagem.Sucesso)
            {
                MessageBox.Show(
                    string.Format("Erro ao processar: {0}", mensagem.Descricao),
                    MensagemTitulo.ErroTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (resposta == null)
            {
                MessageBox.Show(
                    "Não foi retornado objeto de resposta da API.",
                    MensagemTitulo.ErroTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (resposta.statusCode != 200)
            {
                MessageBox.Show(resposta.MensagemRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(
                resposta.MensagemRetorno,
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SenhaAtualTextBox.Clear();
            NovaSenhaTextBox.Clear();
            NovaSenhaConfirmacaoTextBox.Clear();
        }
        private void MostrarSenhaAtualButton_Click(object sender, EventArgs e)
        {
            SenhaAtualTextBox.PasswordChar = SenhaAtualTextBox.PasswordChar == '\0' ? '●' : '\0';
        }

        private void MostrarNovaSenhaButton_Click(object sender, EventArgs e)
        {
            NovaSenhaTextBox.PasswordChar = NovaSenhaTextBox.PasswordChar == '\0' ? '●' : '\0';
        }

        private void MostrarConfirmacaoButton_Click(object sender, EventArgs e)
        {
            NovaSenhaConfirmacaoTextBox.PasswordChar = NovaSenhaConfirmacaoTextBox.PasswordChar == '\0' ? '●' : '\0';
        }
    }
}


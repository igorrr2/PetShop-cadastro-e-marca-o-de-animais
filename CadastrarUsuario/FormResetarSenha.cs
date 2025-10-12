using ApiPetShopLibrary.Login;
using PetShop;
using PetShopClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util.MensagemRetorno;

namespace CadastrarUsuario
{
    public partial class FormResetarSenha : Form
    {
        private readonly Usuario UsuarioExistente;
        private readonly string apiBaseUrl = "https://localhost:5001/api/Usuario";

        public FormResetarSenha(Usuario usuario)
        {
            InitializeComponent();
            this.UsuarioExistente = usuario;
        }

        public static AtualizarUsuarioSolicitacao MontarSolicitacaResetarSenha(string senha, string confirmacaoSenha, string IdUsuarioAtualizar)
        {
            AtualizarUsuarioSolicitacao solicitacao = new AtualizarUsuarioSolicitacao();
            solicitacao.Senha = senha;
            solicitacao.ConfirmacaoSenha = confirmacaoSenha;
            solicitacao.IdUsuarioAtualizar = IdUsuarioAtualizar;
            solicitacao.NomeUsuario = solicitacao.login = string.Empty;
            return solicitacao;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text != txtConfirmacao.Text)
            {
                MessageBox.Show("As senhas não conferem.");
                return;
            }

            try
            {
                Mensagem mensagem = new Mensagem();

                RespostaGenerica resposta = new RespostaGenerica();

                using (var loading = new LoadingForm("Resetando senha do usuário", "Aguarde enquanto o reset da senha está sendo efetuado"))
                {
                    var task = Task.Run(async () =>
                    {
                        try
                        {
                            AtualizarUsuarioSolicitacao solicitacao = MontarSolicitacaResetarSenha(txtSenha.Text, txtConfirmacao.Text, UsuarioExistente.Id);
                            var client = new Client();
                            (mensagem, resposta) = await client.ResetarSenhaAsync(solicitacao);
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
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (resposta == null)
                {
                    MessageBox.Show(
                        "Não foi retornado objeto de resposta da API.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }
}
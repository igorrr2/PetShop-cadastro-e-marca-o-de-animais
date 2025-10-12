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
    public partial class FormUsuario : Form
    {
        private readonly Usuario usuarioExistente;
        private readonly string apiBaseUrl = "https://localhost:5001/api/Usuario";

        public FormUsuario(Usuario usuario = null)
        {
            InitializeComponent();
            usuarioExistente = usuario;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            if (usuarioExistente != null)
            {
                txtNome.Text = usuarioExistente.Nome;
                txtLogin.Text = usuarioExistente.Login;
                
                lblTitulo.Text = "Editar Usuário";
            }
            else
            {
                lblTitulo.Text = "Cadastrar Novo Usuário";
            }
            
            bool mostrarSenha = usuarioExistente == null;
            lblSenha.Visible = txtSenha.Visible = mostrarSenha;

            if (!mostrarSenha)
            {   
                int novoTop = txtSenha.Top;
                btnSalvar.Top = novoTop;
                btnCancelar.Top = novoTop;
                this.Height = this.Height - txtSenha.Height - lblSenha.Height;
            }
        }

        public static CriarUsuarioSolicitacao MontarSolicitacaoCadastrarUsuario(string senha, string NomeUsuario, string login)
        {
            CriarUsuarioSolicitacao solicitacao = new CriarUsuarioSolicitacao();
            solicitacao.Senha = senha;
            solicitacao.login = login;
            solicitacao.NomeUsuario = NomeUsuario;

            return solicitacao;
        }

        public static AtualizarUsuarioSolicitacao MontarSolicitacaoAtualizarUsuario(string idUsuarioAtualizar, string NomeUsuario, string login)
        {
            AtualizarUsuarioSolicitacao solicitacao = new AtualizarUsuarioSolicitacao();
            solicitacao.IdUsuarioAtualizar = idUsuarioAtualizar;
            solicitacao.login = login;
            solicitacao.NomeUsuario = NomeUsuario;
            solicitacao.Senha = solicitacao.ConfirmacaoSenha = string.Empty;
            return solicitacao;
        }
        public bool ValidarCamposCadastroObrigatorio()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                errorProvider.SetError(txtNome, "Nome é obrigatório");
                return false;
            }
            if (string.IsNullOrEmpty(txtLogin.Text))
            {
                errorProvider.SetError(txtLogin, "Login é obrigatório");
                return false;
            }
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                errorProvider.SetError(txtSenha, "Senha é obrigatória");
                return false;
            }

            return true;
        }

        public bool ValidarCamposAtualizacaoObrigatorio()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                errorProvider.SetError(txtNome, "Nome é obrigatório");
                return false;
            }
            if (string.IsNullOrEmpty(txtLogin.Text))
            {
                errorProvider.SetError(txtLogin, "Login é obrigatório");
                return false;
            }
            return true;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            try
            {
                Mensagem mensagem = new Mensagem();
                RespostaGenerica resposta = new RespostaGenerica();
                if (usuarioExistente == null)
                {
                    if (!ValidarCamposCadastroObrigatorio())
                        return;

                    using (var loading = new LoadingForm("Cadastrando usuário", "Aguarde enquanto o usuário está sendo cadastrado"))
                    {
                        var task = Task.Run(async () =>
                        {
                            try
                            {
                                CriarUsuarioSolicitacao solicitacao = MontarSolicitacaoCadastrarUsuario(txtSenha.Text, txtNome.Text, txtLogin.Text);
                                var client = new Client();
                                (mensagem, resposta) = await client.CadastrarUsuarioAsync(solicitacao);
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
                }
                else
                {
                    if (!ValidarCamposAtualizacaoObrigatorio())
                        return;

                    using (var loading = new LoadingForm("Atualizando usuário", "Aguarde enquanto o usuário está sendo Atualizado"))
                    {
                        var task = Task.Run(async () =>
                        {
                            try
                            {
                                AtualizarUsuarioSolicitacao solicitacao = MontarSolicitacaoAtualizarUsuario(usuarioExistente.Id, txtNome.Text, txtLogin.Text);
                                var client = new Client();
                                (mensagem, resposta) = await client.AtualizarUsuarioAsync(solicitacao);
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
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }
}
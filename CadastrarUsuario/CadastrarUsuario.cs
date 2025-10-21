using ApiPetShopLibrary.Login;
using PetShop;
using PetShopClient;
using System.Net.Http.Json;
using System.Windows.Forms;
using Util.MensagemRetorno;

namespace CadastrarUsuario
{
    public partial class CadastrarUsuario : Form
    {

        private List<Usuario> usuarios = new List<Usuario>();
        private readonly string apiBaseUrl = "http://localhost:5036/"; // ajuste para sua rota base

        public CadastrarUsuario()
        {
            InitializeComponent();
            this.Shown += CadastrarUsuario_Shown;
        }

        private async void CadastrarUsuario_Shown(object sender, EventArgs e)
        {
            Mensagem mensagem = new Mensagem();
            UsuariosResposta resposta = new UsuariosResposta();
            (mensagem, resposta) = await CarregarUsuarioAsync();
            if (!mensagem.Sucesso)
            {
                MessageBox.Show(
                    string.Format("Erro ao processar: {0}", mensagem.Descricao),
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            usuarios = resposta.Usuarios;
            AtualizarGrid(resposta.Usuarios);
        }



        private void AtualizarGrid(IEnumerable<Usuario> lista)
        {
            dgvUsuarios.DataSource = lista
                .Select(u => new
                {
                    u.Nome,
                    u.Login,
                    UsuarioLogado = u.Token != Guid.Empty.ToString() ? "Sim" : "Não",
                    Ativo = u.Ativo ? "Sim" : "Não"
                }).ToList();

            if (dgvUsuarios.Columns["UsuarioLogado"] != null)
            {
                dgvUsuarios.Columns["UsuarioLogado"].HeaderText = "Logado";
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtPesquisar.Text.ToLower();
            var filtrados = usuarios.Where(u => u.Nome.ToLower().Contains(filtro)).ToList();
            AtualizarGrid(filtrados);
        }

        public async Task<(Mensagem mensagem, UsuariosResposta resposta)> CarregarUsuarioAsync()
        {
            Client cliente = new Client();
            Mensagem mensagem = new Mensagem();
            UsuariosResposta resposta = new UsuariosResposta();
            using (var loading = new LoadingForm("Obtendo lista de usuárioas...", "Aguarde enquanto a lista de usuários é consultada..."))
            {
                var task = Task.Run(async () =>
                {
                    try
                    {
                        var client = new Client();
                        (mensagem, resposta) = await client.CarregarUsuariosAsync();
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
                return (mensagem, resposta);
            }

            if (resposta == null)
            {
                return (new Mensagem("Não foi retornado objeto de resposta da API."), resposta);
            }

            if (resposta.StatusCode != 200)
            {
                return (new Mensagem("resposta.MensagemRetorno"), resposta);
            }

            return (new Mensagem(), resposta);
        }

        private async void btnCadastrar_ClickAsync(object sender, EventArgs e)
        {
            using (var form = new FormUsuario())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Mensagem mensagem = new Mensagem();
                    UsuariosResposta resposta = new UsuariosResposta();
                    (mensagem, resposta) = await CarregarUsuarioAsync();
                    if (!mensagem.Sucesso)
                    {
                        MessageBox.Show(
                            string.Format("Erro ao processar: {0}", mensagem.Descricao),
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    usuarios = resposta.Usuarios;
                    AtualizarGrid(resposta.Usuarios);
                }
            }
        }

        private async void btnAtualizar_ClickAsync(object sender, EventArgs e)
        {
            Mensagem mensagem;
            UsuariosResposta resposta;
            (mensagem, resposta) = await CarregarUsuarioAsync();
            if (!mensagem.Sucesso)
            {
                MessageBox.Show(
                    string.Format("Erro ao processar: {0}", mensagem.Descricao),
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            usuarios = resposta.Usuarios;
            AtualizarGrid(resposta.Usuarios);
        }

        public static AtualizarUsuarioSolicitacao MontarSolicitacaoApagarUsuario(string idUsuarioAtualizar)
        {
            AtualizarUsuarioSolicitacao solicitacao = new AtualizarUsuarioSolicitacao();
            solicitacao.IdUsuarioAtualizar = idUsuarioAtualizar;
            solicitacao.ConfirmacaoSenha = solicitacao.Senha = solicitacao.login = solicitacao.NomeUsuario = string.Empty;
            return solicitacao;
        }

        private async void dgvUsuarios_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string nomeUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
            var usuario = usuarios.FirstOrDefault(u => u.Nome == nomeUsuario);
            if (usuario == null) return;
            Mensagem mensagem = new Mensagem();
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "Editar")
            {
                using (var form = new FormUsuario(usuario))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        UsuariosResposta resposta = new UsuariosResposta();
                        (mensagem, resposta) = await CarregarUsuarioAsync();
                        if (!mensagem.Sucesso)
                        {
                            MessageBox.Show(
                                string.Format("Erro ao processar: {0}", mensagem.Descricao),
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        usuarios = resposta.Usuarios;
                        AtualizarGrid(resposta.Usuarios);
                    }

                }
            }
            else if (dgvUsuarios.Columns[e.ColumnIndex].Name == "ResetarSenha")
            {
                using (var form = new FormResetarSenha(usuario))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        UsuariosResposta resposta = new UsuariosResposta();
                        (mensagem, resposta) = await CarregarUsuarioAsync();
                        if (!mensagem.Sucesso)
                        {
                            MessageBox.Show(
                                string.Format("Erro ao processar: {0}", mensagem.Descricao),
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        usuarios = resposta.Usuarios;
                        AtualizarGrid(resposta.Usuarios);
                    }
                }
            }
            else if (dgvUsuarios.Columns[e.ColumnIndex].Name == "Excluir")
            {
                var usuarioNome = dgvUsuarios.Rows[e.RowIndex].Cells["Nome"].Value?.ToString() ?? "este usuário";

                var confirm = MessageBox.Show(
                    $"Tem certeza que deseja excluir {usuarioNome}?",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    RespostaGenerica resposta = new RespostaGenerica();
                    using (var loading = new LoadingForm("Atualizando usuário", "Aguarde enquanto o usuário está sendo Atualizado"))
                    {
                        var task = Task.Run(async () =>
                        {
                            try
                            {
                                AtualizarUsuarioSolicitacao solicitacao = MontarSolicitacaoApagarUsuario(usuario.Id);
                                var client = new Client();
                                
                                (mensagem, resposta) = await client.ApagarUsuarioAsync(solicitacao);
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
                    UsuariosResposta usuariosResposta = new UsuariosResposta();
                    (mensagem, usuariosResposta) = await CarregarUsuarioAsync();
                    if (!mensagem.Sucesso)
                    {
                        MessageBox.Show(
                            string.Format("Erro ao processar: {0}", mensagem.Descricao),
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    usuarios = usuariosResposta.Usuarios;
                    AtualizarGrid(usuariosResposta.Usuarios);
                }
            }
        }
    }
}
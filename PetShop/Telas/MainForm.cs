using ApiPetShopLibrary.Animal;
using ApiPetShopLibrary.BanhoTosa;
using PetShop.Data;
using PetShop.Mensagens;
using PetShop.Models;
using PetShopClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util.MensagemRetorno;

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
            Mensagem mensagem = SincronizarDadosServidor();
            if (!mensagem.Sucesso)
            {
                MessageBox.Show(
                    string.Format(MensagemErro.ErroAoProcessarDados, mensagem.Descricao),
                    MensagemTitulo.ErroTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        public static Mensagem SincronizarDadosServidor()
        {
            Mensagem mensagem = new Mensagem();
            AnimalResposta respostaAnimais = null;
            AgendamentoBanhoTosaResposta respostaAgendamentos = null;
            using (var loading = new LoadingForm(
                    "Sincronizando dados com servidor",
                    "Aguarde enquanto os dados são sincronizados com o servidor"))
            {
                loading.StartPosition = FormStartPosition.CenterScreen;

                var task = Task.Run(async () =>
                {
                    try
                    {

                        Client cliente = new Client();
                        AnimalListarSolicitacao solicitacao = new AnimalListarSolicitacao();
                        solicitacao.Token = AppSession.Token;
                        (mensagem, respostaAnimais) = await cliente.ListarAnimaisAsync(solicitacao);

                        if (mensagem.Sucesso && respostaAnimais != null)
                        {
                            mensagem = AtualizarAnimaisBancoLocal(respostaAnimais);
                            if (mensagem.Sucesso)
                            {
                                AgendamentoBanhoTosaListarSolicitacao solicitacaoAgendamento = new AgendamentoBanhoTosaListarSolicitacao();
                                solicitacaoAgendamento.Token = AppSession.Token;
                                (mensagem, respostaAgendamentos) = await cliente.ListarAgendamentosAsync(solicitacaoAgendamento);
                                if (mensagem.Sucesso && respostaAgendamentos != null)
                                    mensagem = AtualizarAgendamentosBancoLocal(respostaAgendamentos);

                            }
                        }

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

                loading.ShowDialog();

                task.Wait();
            }

            if (!mensagem.Sucesso)
            {
                return mensagem;
            }

            if (respostaAnimais == null || respostaAgendamentos == null)
            {
                return new Mensagem("Não foi retornado o objeto resposta");
            }

            if (respostaAnimais.StatusCode != 200)
            {
                return new Mensagem(respostaAnimais.MensagemRetorno);
            }
            if (respostaAgendamentos.StatusCode != 200)
            {
                return new Mensagem(respostaAgendamentos.MensagemRetorno);
            }

            return mensagem;

        }

        public static Mensagem AtualizarAnimaisBancoLocal(AnimalResposta resposta)
        {
            Mensagem mensagem = new Mensagem();

            foreach (AnimalDto animal in resposta.Animais)
            {
                mensagem = AnimalRepository.TryGetByIdAnimalBancoServidor(animal.AnimalId, out Models.Animal registro);
                if (!mensagem.Sucesso)
                    return mensagem;

                if (registro == null)
                {
                    registro = new Models.Animal();
                    registro.NomeAnimal = animal.NomeAnimal;
                    registro.NomeTutor = animal.NomeTutor;
                    registro.Raca = animal.Raca;
                    registro.Sexo = animal.Sexo;
                    registro.DataNascimento = animal.DataNascimento;
                    registro.Observacoes = animal.Observacoes;
                    registro.NumeroTelefoneTutor = animal.NumeroTelefoneTutor;
                    registro.IdAnimalBancoServidor = animal.AnimalId;
                    registro.UsuarioId = AppSession.UsuarioId;

                    mensagem = AnimalRepository.TrySave(registro);
                    if (!mensagem.Sucesso)
                        return mensagem;
                }

            }

            return mensagem;
        }

        public static Mensagem AtualizarAgendamentosBancoLocal(AgendamentoBanhoTosaResposta resposta)
        {
            Mensagem mensagem = new Mensagem();

            foreach (AgendamentoBanhoTosaDto agendamento in resposta.Agendamentos)
            {
                mensagem = BanhoTosaRepository.TryGetByIdAgendamentoBancoServidor(agendamento.AgendamentolId, out Models.BanhoTosa registro);
                if (!mensagem.Sucesso)
                    return mensagem;

                if (registro == null)
                {

                    registro = new Models.BanhoTosa();

                    registro.IdAgendamentoBancoServidor = agendamento.AgendamentolId;
                    registro.DataAgendamento = agendamento.DataAgendamento;
                    registro.ModalidadeAgendamento = agendamento.ModalidadeAgendamento;
                    registro.Observacoes = agendamento.Observacoes;
                    registro.UsuarioId = AppSession.UsuarioId;

                    mensagem = AnimalRepository.TryGetByIdAnimalBancoServidor(agendamento.AnimalId, out Models.Animal animal);
                    if (!mensagem.Sucesso)
                        return mensagem;

                    registro.NomeAnimalAgendado = animal?.NomeAnimal ?? string.Empty;
                    registro.NomeTutorAnimal = animal?.NomeTutor ?? string.Empty;

                    registro.AnimalId = animal != null ? animal.Id: Guid.NewGuid();
                    mensagem = BanhoTosaRepository.TrySave(registro);
                    if (!mensagem.Sucesso)
                        return mensagem;
                }

            }

            return mensagem;
        }
    }
}


using PetShop.Data;
using Util.MensagemRetorno;
using PetShop.Mensagens;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetShopClient;

namespace PetShop.Telas
{
    public partial class AgendarBanhoTosaForm : Form
    {
        private BindingSource BanhoTosaBindingSource = new BindingSource();
        public Guid BanhoTosaId;
        public BanhoTosa BanhoTosaAtual = new BanhoTosa();
        public bool IsPopUp = false;
        public List<Animal> ListaAnimaisCadastrados = new List<Animal>();

        public AgendarBanhoTosaForm(Guid banhoTosaId, bool isPopUp = false)
        {
            InitializeComponent();
            Mensagem mensagem = AnimalRepository.ListAll(out ListaAnimaisCadastrados);
            if (!mensagem.Sucesso)
            {
                MessageBox.Show(string.Format(MensagemErro.ErroAoObterRegistroNoBanco, mensagem.Descricao), MensagemTitulo.ErroAoSalvar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BanhoTosaId = banhoTosaId;
            ConfigurarBinding();
            IsPopUp = isPopUp;
            CancelarButton.Visible = isPopUp;
            if (isPopUp)
            {
                this.Text = "Editar Agendamento";
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.ShowInTaskbar = false;
            }
        }

        private void ConfigurarBinding()
        {
            Mensagem mensagem = new Mensagem();
            if (BanhoTosaId != Guid.Empty)
            {
                mensagem = BanhoTosaRepository.TryGet(BanhoTosaId, out BanhoTosaAtual);
                if (!mensagem.Sucesso)
                {
                    MessageBox.Show(string.Format(MensagemErro.ErroAoObterRegistroNoBanco, mensagem.Descricao), MensagemTitulo.ErroAoSalvar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            BanhoTosaBindingSource.DataSource = BanhoTosaAtual;
            // 1️⃣ Configura DataSource do ComboBox
            NomeAnimalAgendadoCombobox.DataSource = ListaAnimaisCadastrados;
            NomeAnimalAgendadoCombobox.DisplayMember = nameof(Animal.NomeAnimal); // o que aparece
            NomeAnimalAgendadoCombobox.ValueMember = nameof(Animal.NomeAnimal);   // valor usado para seleção
            NomeAnimalAgendadoCombobox.DropDownStyle = ComboBoxStyle.DropDownList;


            mensagem = AnimalRepository.ListAll(out List<Animal> animais);
            if (!mensagem.Sucesso)
            {
                MessageBox.Show(string.Format(MensagemErro.ErroAoObterRegistroNoBanco, mensagem.Descricao), MensagemTitulo.ErroAoSalvar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NomeAnimalAgendadoCombobox.DataSource = animais;
            NomeAnimalAgendadoCombobox.DisplayMember = nameof(Animal.NomeAnimal);
            NomeAnimalAgendadoCombobox.ValueMember = nameof(Animal.Id);

            NomeAnimalAgendadoCombobox.DataBindings.Add(
                 "SelectedValue",
                 BanhoTosaAtual,
                 nameof(BanhoTosaAtual.AnimalId),
                 true,
                 DataSourceUpdateMode.OnPropertyChanged
             );

            if (BanhoTosaAtual.AnimalId != Guid.Empty)
            {
                NomeAnimalAgendadoCombobox.SelectedValue = BanhoTosaAtual.AnimalId;
            }

            var binding = new Binding("SelectedItem", BanhoTosaAtual, nameof(BanhoTosa.ModalidadeAgendamento), true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += (s, e) =>
            {
                if (e.Value == null || !ModalidadeAgendamentoComBox.Items.Contains(e.Value))
                    e.Value = null;
            };
            binding.Parse += (s, e) =>
            {
                e.Value ??= "";
            };
            ModalidadeAgendamentoComBox.DataBindings.Add(binding);

            DataAgendamentoDateTimerPicker.DataBindings.Add("Value", BanhoTosaBindingSource, "DataAgendamento", true, DataSourceUpdateMode.OnPropertyChanged);
            ObservacoesTextBox.DataBindings.Add("Text", BanhoTosaBindingSource, nameof(BanhoTosa.Observacoes), true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void AgendarBanhoTosaForm_Load(object sender, EventArgs e)
        {
            CentralizarPanel();
        }

        private void AgendarBanhoTosaForm_Resize(object sender, EventArgs e)
        {
            CentralizarPanel();
            LabelErro.MaximumSize = new Size(panelCentral.Width - 50, 0);
        }

        private void CentralizarPanel()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
            panelCentral.Top = (this.ClientSize.Height - panelCentral.Height) / 2;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public bool ValidarCamposPreenchidos()
        {
            if (BanhoTosaAtual.AnimalId == Guid.Empty)
            {
                MostrarErro(MensagemAlerta.NomeAnimalAgendadoNaoPreenchido);
                errorProvider.SetError(NomeAnimalAgendadoCombobox, MensagemAlerta.NomeAnimalAgendadoNaoPreenchido);
                return false;
            }
            if (string.IsNullOrEmpty(BanhoTosaAtual.ModalidadeAgendamento))
            {
                MostrarErro(MensagemAlerta.ModalidadeAgendamentoNaoPreenchida);
                errorProvider.SetError(ModalidadeAgendamentoComBox, MensagemAlerta.ModalidadeAgendamentoNaoPreenchida);
                return false;
            }
            if (BanhoTosaAtual.DataAgendamento == DateTime.MinValue)
            {
                MostrarErro(MensagemAlerta.DataAgendamentoNaoPreenchida);
                errorProvider.SetError(DataAgendamentoDateTimerPicker, MensagemAlerta.DataAgendamentoNaoPreenchida);
                return false;
            }

            if (BanhoTosaAtual.DataAgendamento < DateTime.Now)
            {
                MostrarErro(MensagemAlerta.DataAgendamentoMenorQueAtual);
                return false;
            }

            LabelErro.Visible = false;
            return true;
        }

        private void AjustarPosicaoECrescimentoForm()
        {
            // Reposiciona campos baseado na label de erro
            int yInicial = LabelErro.Visible ? LabelErro.Bottom + 10 : 18;

            NomeAnimalAgendadoLabel.Top = yInicial;
            NomeAnimalAgendadoCombobox.Top = NomeAnimalAgendadoLabel.Bottom + 5;

            ModalidadeAgendamentoLabel.Top = NomeAnimalAgendadoCombobox.Bottom + 10;
            ModalidadeAgendamentoComBox.Top = ModalidadeAgendamentoLabel.Bottom + 5;

            DataAgendamentoLabel.Top = ModalidadeAgendamentoComBox.Bottom + 10;
            DataAgendamentoDateTimerPicker.Top = DataAgendamentoLabel.Bottom + 5;

            ObservacaoLabel.Top = DataAgendamentoDateTimerPicker.Bottom + 10;
            ObservacoesTextBox.Top = ObservacaoLabel.Bottom + 5;

            SalvarButton.Top = ObservacoesTextBox.Bottom + 10;
            CancelarButton.Top = ObservacoesTextBox.Bottom + 10;

            // Soma a altura de todos os controles do panelCentral
            int alturaTotal = 0;
            foreach (Control ctrl in panelCentral.Controls)
            {
                if (ctrl.Visible)
                {
                    int ctrlBottom = ctrl.Bottom;
                    if (ctrlBottom > alturaTotal)
                        alturaTotal = ctrlBottom;
                }
            }

            int margemExtra = 25; // espaço abaixo do último controle
            panelCentral.Height = alturaTotal + margemExtra;

            // Define altura do formulário
            this.Height = panelCentral.Top + panelCentral.Height + margemExtra;

            // Centraliza horizontalmente
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
        }


        private void MostrarErro(string mensagem)
        {
            LabelErro.Text = mensagem;
            LabelErro.Visible = true;

            LabelErro.MaximumSize = new Size(panelCentral.Width - 50, 0);
            LabelErro.AutoSize = true;
            AjustarPosicaoECrescimentoForm();

        }

        public void MontarSolicitacaoAgendamentoBanhoTosa(Animal animal, out ApiPetShopLibrary.BanhoTosa.AgendamentoBanhoTosaSolicitacao solicitacao)
        {
            solicitacao = new ApiPetShopLibrary.BanhoTosa.AgendamentoBanhoTosaSolicitacao();
            solicitacao.Agendamento = new ApiPetShopLibrary.BanhoTosa.AgendamentoBanhoTosaDto();
            solicitacao.Token = AppSession.Token;
            solicitacao.Agendamento.AnimalId = animal.IdAnimalBancoServidor;
            solicitacao.Agendamento.DataAgendamento = BanhoTosaAtual.DataAgendamento;
            solicitacao.Agendamento.AgendamentolId = BanhoTosaAtual.IdAgendamentoBancoServidor;
            solicitacao.Agendamento.Observacoes = BanhoTosaAtual.Observacoes;
            solicitacao.Agendamento.ModalidadeAgendamento = BanhoTosaAtual.ModalidadeAgendamento;
            solicitacao.Agendamento.Observacoes = BanhoTosaAtual.Observacoes;
        }

        private async void SalvarButton_Click(object sender, EventArgs e)
        {
            BanhoTosaAtual = BanhoTosaBindingSource.Current as BanhoTosa;
            errorProvider.Clear();
            ApiPetShopLibrary.BanhoTosa.AgendamentoBanhoTosaSolicitacao solicitacao;

            if (!ValidarCamposPreenchidos())
                return;

            if (BanhoTosaAtual != null)
            {
                Mensagem mensagem = null;
                ApiPetShopLibrary.BanhoTosa.AgendamentoBanhoTosaResposta resposta = null;

                mensagem = AnimalRepository.TryGet(BanhoTosaAtual.AnimalId, out Animal animal);
                if (!mensagem.Sucesso)
                {
                    MessageBox.Show(string.Format(MensagemErro.ErroAoObterRegistroNoBanco, mensagem.Descricao), MensagemTitulo.ErroAoSalvar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string mensagemFormularioCarregamento = $"Aguarde enquanto Agendamento de '{BanhoTosaAtual.ModalidadeAgendamento}' para o Animal '{animal.NomeAnimal}' está sendo " +
                                                        (string.IsNullOrEmpty(BanhoTosaAtual.IdAgendamentoBancoServidor) ? "Cadastrado" : "Atualizado");
                string tituloFormularioCarregamento = (string.IsNullOrEmpty(BanhoTosaAtual.IdAgendamentoBancoServidor) ? "Cadastrando" : "Atualizando") + " Agendamento";

                using (var loading = new LoadingForm(tituloFormularioCarregamento, mensagemFormularioCarregamento))
                {
                    loading.StartPosition = FormStartPosition.CenterScreen;

                    var task = Task.Run(async () =>
                    {
                        try
                        {
                            // Monta a solicitação
                            MontarSolicitacaoAgendamentoBanhoTosa(animal, out solicitacao);

                            // Chamada API
                            Client cliente = new Client();
                            if (string.IsNullOrEmpty(BanhoTosaAtual.IdAgendamentoBancoServidor))
                                (mensagem, resposta) = await cliente.CadastrarAgendamentoAsync(solicitacao);
                            else
                                (mensagem, resposta) = await cliente.AtualizarAgendamentoAsync(solicitacao);

                            // Salva local se API retornou OK
                            if (mensagem.Sucesso && resposta != null && resposta.StatusCode == 200)
                            {
                                BanhoTosaAtual.IdAgendamentoBancoServidor = resposta.Id;
                                BanhoTosaAtual.UsuarioId = AppSession.UsuarioId;
                                mensagem = BanhoTosaRepository.TrySave(BanhoTosaAtual);
                            }
                        }
                        catch (Exception ex)
                        {
                            mensagem = new Mensagem(ex.Message, ex);
                        }
                        finally
                        {
                            // Fecha o loading na thread da UI
                            if (!loading.IsDisposed)
                                loading.Invoke(new Action(() => loading.Close()));
                        }
                    });

                    // Modal → bloqueia interação do usuário
                    loading.ShowDialog();

                    // Aguarda a task terminar
                    task.Wait();
                }

                // Loading fechado → podemos mostrar mensagens e atualizar UI
                if (mensagem != null && !mensagem.Sucesso)
                {
                    MessageBox.Show(string.Format(MensagemErro.ErroAoProcessarDados, mensagem.Descricao),
                        MensagemTitulo.ErroTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (resposta == null)
                {
                    MessageBox.Show(string.Format(MensagemErro.ErroAoProcessarDados, "Não foi retornado o objeto resposta"),
                        MensagemTitulo.ErroTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (resposta.StatusCode != 200)
                {
                    MessageBox.Show(resposta.MensagemRetorno, MensagemTitulo.ErroTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!mensagem.Sucesso)
                {
                    MessageBox.Show(string.Format(MensagemErro.ErroAoSalvar, "Agendamento", mensagem.Descricao),
                        MensagemTitulo.ErroAoSalvar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Animal '{animal.NomeAnimal}' agendado com sucesso para '{BanhoTosaAtual.DataAgendamento:dd/MM/yyyy HH:mm}'!");

                // Atualiza interface
                if (IsPopUp)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    BanhoTosaAtual = new BanhoTosa();

                    NomeAnimalAgendadoCombobox.DataBindings.Clear();
                    NomeAnimalAgendadoCombobox.SelectedValue = string.Empty;
                    ModalidadeAgendamentoComBox.DataBindings.Clear();
                    ModalidadeAgendamentoComBox.SelectedIndex = -1;
                    DataAgendamentoDateTimerPicker.DataBindings.Clear();
                    ObservacoesTextBox.DataBindings.Clear();
                    LabelErro.Visible = false;
                    LabelErro.Text = string.Empty;

                    AjustarPosicaoECrescimentoForm();
                    ConfigurarBinding();
                }
            }
        }

    }
}

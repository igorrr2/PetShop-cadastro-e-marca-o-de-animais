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
            ListaAnimaisCadastrados = AnimalRepository.ListAll();
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

            // 2️⃣ Faz binding no SelectedValue para atualizar o objeto BanhoTosaAtual
            NomeAnimalAgendadoCombobox.DataBindings.Add(
                "SelectedValue",                     // sempre SelectedValue
                BanhoTosaAtual,                      // objeto que será atualizado
                nameof(BanhoTosaAtual.NomeAnimalAgendado),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            // 3️⃣ Seleciona o valor atual, se houver
            if (!string.IsNullOrEmpty(BanhoTosaAtual.NomeAnimalAgendado))
            {
                NomeAnimalAgendadoCombobox.SelectedValue = BanhoTosaAtual.NomeAnimalAgendado;
            }

            NomeTutorTextBox.DataBindings.Add("Text", BanhoTosaAtual, nameof(BanhoTosa.NomeTutorAnimal), true, DataSourceUpdateMode.OnPropertyChanged);

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
            if (string.IsNullOrEmpty(BanhoTosaAtual.NomeAnimalAgendado))
            {
                errorProvider.SetError(NomeAnimalAgendadoCombobox, MensagemAlerta.NomeAnimalAgendadoNaoPreenchido);
                return false;
            }
            if (string.IsNullOrEmpty(BanhoTosaAtual.NomeTutorAnimal))
            {
                errorProvider.SetError(NomeTutorTextBox, MensagemAlerta.NomeTutorAnimalNaoPreenchido);
                return false;
            }
            if (string.IsNullOrEmpty(BanhoTosaAtual.ModalidadeAgendamento))
            {
                errorProvider.SetError(ModalidadeAgendamentoComBox, MensagemAlerta.ModalidadeAgendamentoNaoPreenchida);
                return false;
            }
            if (BanhoTosaAtual.DataAgendamento == DateTime.MinValue)
            {
                errorProvider.SetError(DataAgendamentoDateTimerPicker, MensagemAlerta.DataAgendamentoNaoPreenchida);
                return false;
            }

            return true;
        }


        private void SalvarButton_Click(object sender, EventArgs e)
        {
            Mensagem mensagem = new Mensagem();
            BanhoTosaAtual = BanhoTosaBindingSource.Current as BanhoTosa;
            errorProvider.Clear();

            if (!ValidarCamposPreenchidos())
                return;

            if (BanhoTosaAtual != null)
            {
                mensagem = BanhoTosaRepository.TrySave(BanhoTosaAtual);
                if (!mensagem.Sucesso)
                {
                    MessageBox.Show(string.Format(MensagemErro.ErroAoSalvar, "BanhoTosaAgendamentos", mensagem.Descricao), MensagemTitulo.ErroAoSalvar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Aqui você pode salvar no banco, enviar para a API, etc.
                MessageBox.Show(
                $"Animal '{BanhoTosaAtual.NomeAnimalAgendado}' agendado com sucesso para o dia/hora '{BanhoTosaAtual.DataAgendamento:dd/MM/yyyy HH:mm}'!"
                );
                if (IsPopUp)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    BanhoTosaAtual = new BanhoTosa();
                    //BanhoTosaBindingSource.DataSource = BanhoTosaAtual;

                    NomeTutorTextBox.DataBindings.Clear();
                    NomeAnimalAgendadoCombobox.DataBindings.Clear();
                    NomeAnimalAgendadoCombobox.SelectedValue = string.Empty;
                    ModalidadeAgendamentoComBox.DataBindings.Clear();
                    ModalidadeAgendamentoComBox.SelectedIndex = -1;
                    DataAgendamentoDateTimerPicker.DataBindings.Clear();
                    ObservacoesTextBox.DataBindings.Clear();

                    // Reconfigura bindings
                    ConfigurarBinding();
                }
            }
        }
    }
}

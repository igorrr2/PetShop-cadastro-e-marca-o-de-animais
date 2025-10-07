using PetShop.Data;
using PetShop.Mensagens;
using PetShop.Models;
using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Util.MensagemRetorno;

namespace PetShop.Telas
{
    public partial class CadastrarAnimalForm : Form
    {
        private BindingSource animalBindingSource = new BindingSource();
        public Guid AnimalId;
        public Animal AnimalAtual = new Animal();
        public bool IsPopUp = false;
        public CadastrarAnimalForm(Guid animalId, bool isPopUp = false)
        {
            InitializeComponent();
            AnimalId = animalId;
            ConfigurarBinding();
            IsPopUp = isPopUp;
            CancelarButton.Visible = isPopUp;
            if (isPopUp)
            {
                this.Text = "Editar Animal";
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
            if (AnimalId != Guid.Empty)
            {
                mensagem = AnimalRepository.TryGet(AnimalId, out AnimalAtual);
                if (!mensagem.Sucesso)
                {
                    MessageBox.Show(string.Format(MensagemErro.ErroAoObterRegistroNoBanco, mensagem.Descricao), MensagemTitulo.ErroAoSalvar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            animalBindingSource.DataSource = AnimalAtual;

            // Associa cada controle ao BindingSource
            NomeAnimalTextBox.DataBindings.Add("Text", animalBindingSource, nameof(Animal.NomeAnimal), false, DataSourceUpdateMode.OnPropertyChanged);
            NomeTutorTextBox.DataBindings.Add("Text", animalBindingSource, nameof(Animal.NomeTutor), false, DataSourceUpdateMode.OnPropertyChanged);
            RacaTextBox.DataBindings.Add("Text", animalBindingSource, nameof(Animal.Raca), false, DataSourceUpdateMode.OnPropertyChanged);
            NumeroTelefoneTutorTextBox.DataBindings.Add("Text", animalBindingSource, nameof(Animal.NumeroTelefoneTutor), false, DataSourceUpdateMode.OnPropertyChanged);

            var binding = new Binding("SelectedItem", animalBindingSource, nameof(Animal.Sexo), true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += (s, e) =>
            {
                if (e.Value == null || !SexoComboBox.Items.Contains(e.Value))
                    e.Value = null;
            };
            binding.Parse += (s, e) =>
            {
                e.Value ??= "";
            };
            SexoComboBox.DataBindings.Add(binding);

            DataNascimentoDateTimerPicker.DataBindings.Add("Value", animalBindingSource, "DataNascimento", true, DataSourceUpdateMode.OnPropertyChanged);
            ObservacoesTextBox.DataBindings.Add("Text", animalBindingSource, nameof(Animal.Observacoes), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void CadastrarAnimalForm_Load(object sender, EventArgs e)
        {
            CentralizarPanel();
        }

        private void CadastrarAnimalForm_Resize(object sender, EventArgs e)
        {
            CentralizarPanel();
        }

        private void CentralizarPanel()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
            panelCentral.Top = (this.ClientSize.Height - panelCentral.Height) / 2;
        }

        public bool ValidarCamposPreenchidos()
        {
            if (string.IsNullOrEmpty(AnimalAtual.NomeAnimal))
            {
                MostrarErro(MensagemAlerta.NomeAnimalNaoPreenchido);
                errorProvider.SetError(NomeAnimalTextBox, MensagemAlerta.NomeAnimalNaoPreenchido);
                return false;
            }
            if (string.IsNullOrEmpty(AnimalAtual.NomeTutor))
            {
                MostrarErro(MensagemAlerta.TipoAnimalNaoPreenchido);
                errorProvider.SetError(NomeTutorTextBox, MensagemAlerta.TipoAnimalNaoPreenchido);
                return false;
            }
            if (string.IsNullOrEmpty(AnimalAtual.NumeroTelefoneTutor))
            {
                MostrarErro(MensagemAlerta.NumeroTutorNaoPreenchido);
                errorProvider.SetError(NomeTutorTextBox, MensagemAlerta.NumeroTutorNaoPreenchido);
                return false;
            }
            if (string.IsNullOrEmpty(AnimalAtual.Raca))
            {
                MostrarErro(MensagemAlerta.RacaAnimalNaoPreenchida);
                errorProvider.SetError(RacaTextBox, MensagemAlerta.RacaAnimalNaoPreenchida);
                return false;
            }
            if (string.IsNullOrEmpty(AnimalAtual.Sexo))
            {
                MostrarErro(MensagemAlerta.SexoAnimalNaoPreenchido);
                errorProvider.SetError(SexoComboBox, MensagemAlerta.SexoAnimalNaoPreenchido);
                return false;
            }
            if (AnimalAtual.DataNascimento == DateTime.MinValue)
            {
                MostrarErro(MensagemAlerta.DataAgendamentoNaoPreenchida);
                errorProvider.SetError(DataNascimentoDateTimerPicker, MensagemAlerta.DataAgendamentoNaoPreenchida);
                return false;
            }
            return true;
        }

        private void SalvarButton_Click(object sender, EventArgs e)
        {
            Mensagem mensagem = new Mensagem();
            AnimalAtual = animalBindingSource.Current as Animal;
            errorProvider.Clear();

            if (!ValidarCamposPreenchidos())
                return;

            if (AnimalAtual.DataNascimento.Date == DateTime.Today)
            {
                DialogResult resultado = MessageBox.Show(
                    MensagemAlerta.DataNascimentoIgualAtual,
                    MensagemTitulo.InformacaoTitulo,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.No)
                {
                    return;
                }
            }

            if (AnimalAtual != null)
            {
                // Agora você tem todos os dados preenchidos:
                // animalAtual.Nome, animalAtual.Tipo, animalAtual.Raca, etc.
                mensagem = AnimalRepository.TrySave(AnimalAtual);
                if (!mensagem.Sucesso)
                {
                    MessageBox.Show(string.Format(MensagemErro.ErroAoSalvar, "Animal", mensagem.Descricao), MensagemTitulo.ErroAoSalvar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Aqui você pode salvar no banco, enviar para a API, etc.
                MessageBox.Show($"Animal '{AnimalAtual.NomeAnimal}' salvo com sucesso!");
                if (IsPopUp)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    SexoComboBox.SelectedIndex = -1;
                    animalBindingSource.DataSource = new Animal();
                    LabelErro.Visible = false;
                    LabelErro.Text = string.Empty;
                    AjustarPosicaoECrescimentoForm();
                }
            }
        }

        private void AjustarPosicaoECrescimentoForm()
        {
            // Se tiver LabelErro, usa Bottom + margem; senão, usa valor fixo
            int yInicial = (LabelErro != null && LabelErro.Visible) ? LabelErro.Bottom + 10 : 18;

            // Reposiciona todos os campos
            NomeAnimalLabel.Top = yInicial;
            NomeAnimalTextBox.Top = NomeAnimalLabel.Bottom + 5;

            NomeTutorLabel.Top = NomeAnimalTextBox.Bottom + 10;
            NomeTutorTextBox.Top = NomeTutorLabel.Bottom + 5;

            NumeroTelefoneTutoLabel.Top = NomeTutorTextBox.Bottom + 10;
            NumeroTelefoneTutorTextBox.Top = NumeroTelefoneTutoLabel.Bottom + 5;

            RacaLabel.Top = NumeroTelefoneTutorTextBox.Bottom + 10;
            RacaTextBox.Top = RacaLabel.Bottom + 5;

            SexoLabel.Top = RacaTextBox.Bottom + 10;
            SexoComboBox.Top = SexoLabel.Bottom + 5;

            DataNascimentoLabel.Top = SexoComboBox.Bottom + 10;
            DataNascimentoDateTimerPicker.Top = DataNascimentoLabel.Bottom + 5;

            ObservacaoLabel.Top = DataNascimentoDateTimerPicker.Bottom + 10;
            ObservacoesTextBox.Top = ObservacaoLabel.Bottom + 5;

            SalvarButton.Top = ObservacoesTextBox.Bottom + 10;
            CancelarButton.Top = ObservacoesTextBox.Bottom + 10;

            // Ajusta a altura do panelCentral somando altura do último controle + margem
            int alturaPanel = SalvarButton.Bottom + 20;
            panelCentral.Height = alturaPanel;

            // Ajusta a altura do Form para caber o panelCentral + margem
            this.Height = panelCentral.Top + panelCentral.Height + 20;

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
            this.StartPosition = FormStartPosition.CenterParent;

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

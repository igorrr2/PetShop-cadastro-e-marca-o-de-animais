using PetShop.Data;
using PetShop.MensagemRetorno;
using PetShop.Mensagens;
using PetShop.Models;
using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace PetShop.Telas
{
    public partial class CadastrarAnimalForm : Form
    {
        private BindingSource animalBindingSource = new BindingSource();
        public Guid AnimalId;
        public Animal AnimalAtual = new Animal();
        public CadastrarAnimalForm(Guid animalId)
        {
            InitializeComponent();
            AnimalId = animalId;
            ConfigurarBinding();
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
            NomeTextBox.DataBindings.Add("Text", animalBindingSource, nameof(Animal.Nome), false, DataSourceUpdateMode.OnPropertyChanged);
            TipoTextBox.DataBindings.Add("Text", animalBindingSource, nameof(Animal.Tipo), false, DataSourceUpdateMode.OnPropertyChanged);
            RacaTextBox.DataBindings.Add("Text", animalBindingSource, nameof(Animal.Raca), false, DataSourceUpdateMode.OnPropertyChanged);
            SexoTextBox.DataBindings.Add("Text", animalBindingSource, nameof(Animal.Sexo), false, DataSourceUpdateMode.OnPropertyChanged);
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
            if (string.IsNullOrEmpty(AnimalAtual.Nome))
            {
                errorProvider.SetError(NomeTextBox, MensagemAlerta.NomeAnimalNaoPreenchido);
                return false;
            }
            if (string.IsNullOrEmpty(AnimalAtual.Tipo))
            {
                errorProvider.SetError(TipoTextBox, MensagemAlerta.TipoAnimalNaoPreenchido);
                return false;
            }
            if (string.IsNullOrEmpty(AnimalAtual.Raca))
            {
                errorProvider.SetError(RacaTextBox, MensagemAlerta.RacaAnimalNaoPreenchida);
                return false;
            }
            if (string.IsNullOrEmpty(AnimalAtual.Sexo))
            {
                errorProvider.SetError(SexoTextBox, MensagemAlerta.SexoAnimalNaoPreenchido);
                return false;
            }
            if (AnimalAtual.DataNascimento == DateTime.MinValue)
            {
                errorProvider.SetError(DataNascimentoDateTimerPicker, MensagemAlerta.DataNascimentoNaoPreenchida);
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
                MessageBox.Show($"Animal '{AnimalAtual.Nome}' salvo com sucesso!");

                // Se quiser limpar os campos para novo cadastro:
                animalBindingSource.DataSource = new Animal();
            }
        }
    }
}

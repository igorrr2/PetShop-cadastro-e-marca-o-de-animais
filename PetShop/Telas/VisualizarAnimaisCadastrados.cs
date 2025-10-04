using PetShop.Data;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PetShop.Telas
{
    public partial class VisualizarAnimaisCadastrados : Form
    {
        private List<Animal> animaisOriginais;

        public VisualizarAnimaisCadastrados()
        {
            InitializeComponent();
            ConfigurarColunasDataGridView();
            CarregarDados();
        }

        public void ConfigurarColunasDataGridView()
        {
            // Colunas do DataGridView
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Animal.NomeAnimal),
                HeaderText = "Nome do Animal",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Animal.NomeTutor),
                HeaderText = "Nome do Tutor",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Animal.Raca),
                HeaderText = "Raça",
                Width = 150
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Animal.Sexo),
                HeaderText = "Sexo",
                Width = 80
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Animal.DataNascimento),
                HeaderText = "Data de Nascimento",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Animal.Observacoes),
                HeaderText = "Observações",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Animal.NumeroTelefoneTutor),
                HeaderText = "Número de telefone do Tutor",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Coluna Editar
            var colEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "✏️ Editar",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dataGridView.Columns.Add(colEditar);

            // Coluna Excluir
            var colExcluir = new DataGridViewButtonColumn
            {
                HeaderText = "Excluir",
                Text = "🗑️ Excluir",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dataGridView.Columns.Add(colExcluir);
        }

        private void CarregarDados()
        {
            animaisOriginais = AnimalRepository.ListAll();
            animalBindingSource.DataSource = animaisOriginais.ToList();
        }

        private void Filtro_TextChanged(object sender, EventArgs e)
        {
            string filtroNomeAnimal = txtFiltroNomeAnimal.Text.ToLower();
            string filtroNomeTutor = txtFiltroNomeTutor.Text.ToLower();
            string filtroRaca = txtFiltroRaca.Text.ToLower();

            var filtrados = animaisOriginais.Where(a =>
                a.NomeAnimal.ToLower().Contains(filtroNomeAnimal) &&
                a.NomeTutor.ToLower().Contains(filtroNomeTutor) &&
                a.Raca.ToLower().Contains(filtroRaca)
            ).ToList();

            animalBindingSource.DataSource = filtrados;
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var grid = sender as DataGridView;
            var animalSelecionado = grid.Rows[e.RowIndex].DataBoundItem as Animal;

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string coluna = grid.Columns[e.ColumnIndex].HeaderText;

                if (coluna == "Editar")
                {
                    using (var form = new CadastrarAnimalForm(animalSelecionado.Id, true))
                    {
                        DialogResult result = form.ShowDialog(this);
                        if (result == DialogResult.OK || result == DialogResult.Cancel)
                        {
                            CarregarDados();
                        }
                    }
                }
                else if (coluna == "Excluir")
                {
                    var confirm = MessageBox.Show(
                        $"Tem certeza que deseja excluir o animal '{animalSelecionado.NomeAnimal}'?",
                        "Confirmar exclusão",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        var mensagem = AnimalRepository.TryDelete(animalSelecionado.Id);
                        if (!mensagem.Sucesso)
                            MessageBox.Show($"Erro ao excluir: {mensagem.Descricao}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            CarregarDados();
                    }
                }
            }
        }

        private void NovoAnimalButton_Click(object sender, EventArgs e)
        {
            using (var form = new CadastrarAnimalForm(Guid.Empty, true))
            {
                DialogResult result = form.ShowDialog(this);
                if (result == DialogResult.OK || result == DialogResult.Cancel)
                {
                    CarregarDados();
                }
            }
        }
    }
}

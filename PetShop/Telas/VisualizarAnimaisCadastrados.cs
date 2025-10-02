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
            CarregarDados();
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
    }
}

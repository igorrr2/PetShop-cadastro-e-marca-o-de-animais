using PetShop.Data;
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
    public partial class VisualizarBanhoETosasAgendadas : Form
    {
        private List<BanhoTosa> BanhoTosasOriginais;
        public VisualizarBanhoETosasAgendadas()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            BanhoTosasOriginais = BanhoTosaRepository.ListAll();
            BanhoTosaBindingSource.DataSource = BanhoTosasOriginais.ToList();
        }

        private void Filtro_TextChanged(object sender, EventArgs e)
        {
            string filtroNomeAnimal = txtFiltroNomeAnimal.Text.ToLower();
            string filtroNomeTutor = txtFiltroNomeTutor.Text.ToLower();
            string filtroModalidade = txtFiltroModalidade.Text.ToLower();
            string filtroDataAgendamento = txtFiltroDataAgendamento.Text.ToLower();

            var filtrados = BanhoTosasOriginais.Where(a =>
                a.NomeAnimalAgendado.ToLower().Contains(filtroNomeAnimal) &&
                a.NomeTutorAnimal.ToLower().Contains(filtroNomeTutor) &&
                a.ModalidadeAgendamento.ToLower().Contains(filtroModalidade) &&
                a.DataAgendamento.ToString().ToLower().Contains(filtroDataAgendamento)
            ).ToList();

            BanhoTosaBindingSource.DataSource = filtrados;
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var grid = sender as DataGridView;
            var banhoTosaSelecionada = grid.Rows[e.RowIndex].DataBoundItem as BanhoTosa;

            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string coluna = grid.Columns[e.ColumnIndex].HeaderText;

                if (coluna == "Editar")
                {
                    using (var form = new AgendarBanhoTosaForm(banhoTosaSelecionada.Id, true))
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
                        $"Tem certeza que deseja excluir o agendamento para o animal '{banhoTosaSelecionada.NomeAnimalAgendado}'?",
                        "Confirmar exclusão",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        var mensagem = BanhoTosaRepository.TryDelete(banhoTosaSelecionada.Id);
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

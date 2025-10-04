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
        private bool Historico = false;
        public VisualizarBanhoETosasAgendadas(bool historico = false)
        {
            InitializeComponent();
            Historico = historico;
            ConfigurarColunasDataGridView();
            CarregarDados();
            if (historico)
            {
                this.Text = "Histórico de agendamentos realizados";
            }
            HistoricoAgendamentosButton.Visible = NovoAgendamentoButton.Visible = !Historico;
        }

        public void ConfigurarColunasDataGridView()
        {
            // Colunas do DataGridView
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(BanhoTosa.NomeAnimalAgendado),
                HeaderText = "Nome do Animal Agendado",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(BanhoTosa.NomeTutorAnimal),
                HeaderText = "Nome do Tutor do animal agendado",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(BanhoTosa.ModalidadeAgendamento),
                HeaderText = "Modalidade agendamento",
                Width = 150
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(BanhoTosa.DataAgendamento),
                HeaderText = "Data do agendamento",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(BanhoTosa.Observacoes),
                HeaderText = "Observações",
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
            BanhoTosaRepository.ListAll(out BanhoTosasOriginais, Historico);
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

        private void NovoAgendamentoButton_Click(object sender, EventArgs e)
        {
            using (var form = new AgendarBanhoTosaForm(Guid.Empty, true))
            {
                DialogResult result = form.ShowDialog(this);
                if (result == DialogResult.OK || result == DialogResult.Cancel)
                {
                    CarregarDados();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new VisualizarBanhoETosasAgendadas(true))
            {
                form.StartPosition = FormStartPosition.CenterScreen; // centraliza na tela
                DialogResult result = form.ShowDialog(this);

                if (result == DialogResult.OK || result == DialogResult.Cancel)
                {
                    CarregarDados();
                }
            }
        }
    }
}

using PetShop.Data;
using PetShop.Mensagens;
using PetShop.Models;
using PetShopClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Util.MensagemRetorno;

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

            var colEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "✏️ Editar",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dataGridView.Columns.Add(colEditar);

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
            Mensagem mensagem = AnimalRepository.ListAll(out animaisOriginais);
            if (!mensagem.Sucesso)
            {
                MessageBox.Show(string.Format(MensagemErro.ErroAoObterRegistroNoBanco, mensagem.Descricao), MensagemTitulo.ErroAoSalvar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

        private async void DataGridView_CellClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                            Mensagem mensagem = null;
                            ApiPetShopLibrary.Animal.AnimalResposta resposta = null;

                            using (var loading = new LoadingForm(
                                "Apagando animal...",
                                $"Aguarde enquanto o Animal {animalSelecionado.NomeAnimal} está sendo apagado"))
                            {
                                loading.StartPosition = FormStartPosition.CenterScreen;

                                var task = Task.Run(async () =>
                                {
                                    try
                                    {
                                        ApiPetShopLibrary.Animal.AnimalApagarSolicitacao solicitacao;
                                        MontarSolicitacaoApagarAnimal(animalSelecionado, out solicitacao);

                                        Client cliente = new Client();
                                        (mensagem, resposta) = await cliente.ApagarAnimalAsync(solicitacao);

                                        if (mensagem != null && mensagem.Sucesso && resposta != null && resposta.StatusCode == 200)
                                        {
                                            mensagem = AnimalRepository.TryDelete(animalSelecionado.Id);
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

                            if (mensagem != null && !mensagem.Sucesso)
                            {
                                MessageBox.Show($"Erro ao excluir: {mensagem.Descricao}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (resposta == null)
                            {
                                MessageBox.Show(
                                    string.Format(MensagemErro.ErroAoProcessarDados, "Não foi retornado o objeto resposta"),
                                    MensagemTitulo.ErroTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (resposta.StatusCode != 200)
                            {
                                MessageBox.Show(resposta.MensagemRetorno, MensagemTitulo.ErroTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            CarregarDados();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro, detalhes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MontarSolicitacaoApagarAnimal(Animal animal, out ApiPetShopLibrary.Animal.AnimalApagarSolicitacao solicitacao)
        {
            solicitacao = new ApiPetShopLibrary.Animal.AnimalApagarSolicitacao();
            solicitacao.AnimalId = animal.IdAnimalBancoServidor;
            solicitacao.Token = AppSession.Token;
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

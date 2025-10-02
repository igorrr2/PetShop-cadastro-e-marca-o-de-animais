using PetShop.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PetShop.Telas
{
    partial class VisualizarAnimaisCadastrados
    {
        private System.ComponentModel.IContainer components = null;

        private BindingSource animalBindingSource;
        private DataGridView dataGridView;
        private Panel panelTitulo;
        private Label AnimaisCadastradosLabel;
        private Panel panelFiltros;
        private TextBox txtFiltroNomeAnimal;
        private TextBox txtFiltroNomeTutor;
        private TextBox txtFiltroRaca;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            animalBindingSource = new BindingSource();
            dataGridView = new DataGridView();
            panelTitulo = new Panel();
            AnimaisCadastradosLabel = new Label();
            panelFiltros = new Panel();
            txtFiltroNomeAnimal = new TextBox();
            txtFiltroNomeTutor = new TextBox();
            txtFiltroRaca = new TextBox();

            SuspendLayout();

            // 
            // panelTitulo
            // 
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Height = 80;
            panelTitulo.BackColor = Color.WhiteSmoke;
            panelTitulo.Controls.Add(AnimaisCadastradosLabel);

            // 
            // AnimaisCadastradosLabel
            // 
            AnimaisCadastradosLabel.Dock = DockStyle.Fill;
            AnimaisCadastradosLabel.TextAlign = ContentAlignment.MiddleCenter;
            AnimaisCadastradosLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            AnimaisCadastradosLabel.Text = "Animais Cadastrados";

            // 
            // panelFiltros
            // 
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Height = 40; // aumento da altura
            panelFiltros.BackColor = Color.LightGray;
            panelFiltros.Padding = new Padding(5, 5, 5, 5); // espaçamento interno em cima e embaixo
            panelFiltros.Controls.Add(txtFiltroNomeAnimal);
            panelFiltros.Controls.Add(txtFiltroNomeTutor);
            panelFiltros.Controls.Add(txtFiltroRaca);

            // 
            // txtFiltroNomeAnimal
            // 
            txtFiltroNomeAnimal.PlaceholderText = "Filtrar por Nome do Animal";
            txtFiltroNomeAnimal.Width = 200;
            txtFiltroNomeAnimal.Height = 25; // aumento da altura
            txtFiltroNomeAnimal.Top = 5; // distancia do topo do painel
            txtFiltroNomeAnimal.Left = 5; 
            txtFiltroNomeAnimal.TextChanged += Filtro_TextChanged;

            // 
            // txtFiltroNomeTutor
            // 
            txtFiltroNomeTutor.PlaceholderText = "Filtrar por Nome do Tutor";
            txtFiltroNomeTutor.Width = 200;
            txtFiltroNomeTutor.Height = 25;
            txtFiltroNomeTutor.Top = 5;
            txtFiltroNomeTutor.Left = txtFiltroNomeAnimal.Right + 10; // distância entre campos
            txtFiltroNomeTutor.TextChanged += Filtro_TextChanged;

            // 
            // txtFiltroRaca
            // 
            txtFiltroRaca.PlaceholderText = "Filtrar por Raça";
            txtFiltroRaca.Width = 150;
            txtFiltroRaca.Height = 25;
            txtFiltroRaca.Top = 5;
            txtFiltroRaca.Left = txtFiltroNomeTutor.Right + 10;
            txtFiltroRaca.TextChanged += Filtro_TextChanged;

            // 
            // dataGridView
            // 
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.DataSource = animalBindingSource;

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

            dataGridView.CellClick += DataGridView_CellClick;

            // 
            // VisualizarAnimaisCadastrados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(dataGridView);
            Controls.Add(panelFiltros);
            Controls.Add(panelTitulo);
            Text = "Animais Cadastrados";
            ResumeLayout(false);
        }
        #endregion
    }
}

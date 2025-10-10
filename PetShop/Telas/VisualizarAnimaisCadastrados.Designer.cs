using PetShop.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PetShop.Telas
{
    partial class VisualizarAnimaisCadastrados
    {
        private IContainer components = null;

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
            components = new Container();
            animalBindingSource = new BindingSource(components);
            dataGridView = new DataGridView();
            panelTitulo = new Panel();
            AnimaisCadastradosLabel = new Label();
            panelFiltros = new Panel();
            txtFiltroNomeAnimal = new TextBox();
            txtFiltroNomeTutor = new TextBox();
            txtFiltroRaca = new TextBox();
            NovoAnimalButton = new Button();
            ((ISupportInitialize)animalBindingSource).BeginInit();
            ((ISupportInitialize)dataGridView).BeginInit();
            panelTitulo.SuspendLayout();
            panelFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.BackgroundColor = Color.FromArgb(149, 94, 38);
            dataGridView.DataSource = animalBindingSource;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 120);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(1000, 480);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += DataGridView_CellClickAsync;
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.WhiteSmoke;
            panelTitulo.Controls.Add(AnimaisCadastradosLabel);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(0, 0);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(1000, 80);
            panelTitulo.TabIndex = 2;
            // 
            // AnimaisCadastradosLabel
            // 
            AnimaisCadastradosLabel.Dock = DockStyle.Fill;
            AnimaisCadastradosLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            AnimaisCadastradosLabel.Location = new Point(0, 0);
            AnimaisCadastradosLabel.Name = "AnimaisCadastradosLabel";
            AnimaisCadastradosLabel.Size = new Size(1000, 80);
            AnimaisCadastradosLabel.TabIndex = 0;
            AnimaisCadastradosLabel.Text = "Animais Cadastrados";
            AnimaisCadastradosLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFiltros
            // 
            panelFiltros.BackColor = Color.FromArgb(149, 94, 38);
            panelFiltros.Controls.Add(NovoAnimalButton);
            panelFiltros.Controls.Add(txtFiltroNomeAnimal);
            panelFiltros.Controls.Add(txtFiltroNomeTutor);
            panelFiltros.Controls.Add(txtFiltroRaca);
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Location = new Point(0, 80);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Padding = new Padding(5);
            panelFiltros.Size = new Size(1000, 40);
            panelFiltros.TabIndex = 1;
            // 
            // txtFiltroNomeAnimal
            // 
            txtFiltroNomeAnimal.Location = new Point(5, 5);
            txtFiltroNomeAnimal.Name = "txtFiltroNomeAnimal";
            txtFiltroNomeAnimal.PlaceholderText = "Filtrar por Nome do Animal";
            txtFiltroNomeAnimal.Size = new Size(200, 23);
            txtFiltroNomeAnimal.TabIndex = 0;
            txtFiltroNomeAnimal.TextChanged += Filtro_TextChanged;
            // 
            // txtFiltroNomeTutor
            // 
            txtFiltroNomeTutor.Location = new Point(205, 5);
            txtFiltroNomeTutor.Name = "txtFiltroNomeTutor";
            txtFiltroNomeTutor.PlaceholderText = "Filtrar por Nome do Tutor";
            txtFiltroNomeTutor.Size = new Size(200, 23);
            txtFiltroNomeTutor.TabIndex = 1;
            txtFiltroNomeTutor.TextChanged += Filtro_TextChanged;
            // 
            // txtFiltroRaca
            // 
            txtFiltroRaca.Location = new Point(405, 5);
            txtFiltroRaca.Name = "txtFiltroRaca";
            txtFiltroRaca.PlaceholderText = "Filtrar por Raça";
            txtFiltroRaca.Size = new Size(150, 23);
            txtFiltroRaca.TabIndex = 2;
            txtFiltroRaca.TextChanged += Filtro_TextChanged;
            // 
            // NovoAnimalButton
            // 
            NovoAnimalButton.Dock = DockStyle.Right;
            NovoAnimalButton.Location = new Point(882, 5);
            NovoAnimalButton.Name = "NovoAnimalButton";
            NovoAnimalButton.Size = new Size(113, 30);
            NovoAnimalButton.TabIndex = 3;
            NovoAnimalButton.Text = "Novo animal";
            NovoAnimalButton.UseVisualStyleBackColor = true;
            NovoAnimalButton.Click += NovoAnimalButton_Click;
            // 
            // VisualizarAnimaisCadastrados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(dataGridView);
            Controls.Add(panelFiltros);
            Controls.Add(panelTitulo);
            Name = "VisualizarAnimaisCadastrados";
            Text = "Animais Cadastrados";
            ((ISupportInitialize)animalBindingSource).EndInit();
            ((ISupportInitialize)dataGridView).EndInit();
            panelTitulo.ResumeLayout(false);
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private Button NovoAnimalButton;
    }
}

using PetShop.Models;

namespace PetShop.Telas
{
    partial class VisualizarBanhoETosasAgendadas
    {
        private System.ComponentModel.IContainer components = null;

        private BindingSource BanhoTosaBindingSource;
        private DataGridView dataGridView;
        private Panel panelTitulo;
        private Label AgendamentosCadastradosLabel;
        private Panel panelFiltros;
        private TextBox txtFiltroNomeAnimal;
        private TextBox txtFiltroNomeTutor;
        private TextBox txtFiltroModalidade;
        private TextBox txtFiltroDataAgendamento;

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
            components = new System.ComponentModel.Container();
            BanhoTosaBindingSource = new BindingSource(components);
            dataGridView = new DataGridView();
            panelTitulo = new Panel();
            AgendamentosCadastradosLabel = new Label();
            panelFiltros = new Panel();
            txtFiltroNomeAnimal = new TextBox();
            txtFiltroNomeTutor = new TextBox();
            txtFiltroModalidade = new TextBox();
            txtFiltroDataAgendamento = new TextBox();
            ((System.ComponentModel.ISupportInitialize)BanhoTosaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panelTitulo.SuspendLayout();
            panelFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 120);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(1000, 480);
            dataGridView.TabIndex = 0;

            dataGridView.DataSource = BanhoTosaBindingSource;

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
            dataGridView.CellClick += DataGridView_CellClick;
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.WhiteSmoke;
            panelTitulo.Controls.Add(AgendamentosCadastradosLabel);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(0, 0);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(1000, 80);
            panelTitulo.TabIndex = 2;
            // 
            // AgendamentosCadastradosLabel
            // 
            AgendamentosCadastradosLabel.Dock = DockStyle.Fill;
            AgendamentosCadastradosLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            AgendamentosCadastradosLabel.Location = new Point(0, 0);
            AgendamentosCadastradosLabel.Name = "AgendamentosCadastradosLabel";
            AgendamentosCadastradosLabel.Size = new Size(1000, 80);
            AgendamentosCadastradosLabel.TabIndex = 0;
            AgendamentosCadastradosLabel.Text = "Agendamentos Cadastrados";
            AgendamentosCadastradosLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFiltros
            // 
            panelFiltros.BackColor = Color.LightGray;
            panelFiltros.Controls.Add(txtFiltroNomeAnimal);
            panelFiltros.Controls.Add(txtFiltroNomeTutor);
            panelFiltros.Controls.Add(txtFiltroModalidade);
            panelFiltros.Controls.Add(txtFiltroDataAgendamento);
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
            // txtFiltroModalidade
            // 
            txtFiltroModalidade.Location = new Point(405, 5);
            txtFiltroModalidade.Name = "txtFiltroModalidade";
            txtFiltroModalidade.PlaceholderText = "Filtrar por Modalidade";
            txtFiltroModalidade.Size = new Size(150, 23);
            txtFiltroModalidade.TabIndex = 2;
            txtFiltroModalidade.TextChanged += Filtro_TextChanged;
            // 
            // txtFiltroDataAgendamento
            // 
            txtFiltroDataAgendamento.Location = new Point(557, 5);
            txtFiltroDataAgendamento.Name = "txtFiltroDataAgendamento";
            txtFiltroDataAgendamento.PlaceholderText = "Filtrar por Data do agendamento";
            txtFiltroDataAgendamento.Size = new Size(212, 23);
            txtFiltroDataAgendamento.TabIndex = 3;
            txtFiltroDataAgendamento.TextChanged += Filtro_TextChanged;
            // 
            // VisualizarBanhoETosasAgendadas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(dataGridView);
            Controls.Add(panelFiltros);
            Controls.Add(panelTitulo);
            Name = "VisualizarBanhoETosasAgendadas";
            Text = "Agendamentos Cadastrados";
            ((System.ComponentModel.ISupportInitialize)BanhoTosaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panelTitulo.ResumeLayout(false);
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private DataGridViewButtonColumn colEditar;
        private DataGridViewButtonColumn colExcluir;
    }
}

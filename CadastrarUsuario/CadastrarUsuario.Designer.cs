namespace CadastrarUsuario
{
    partial class CadastrarUsuario
    {        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnAtualizar; 

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // txtPesquisar
            this.txtPesquisar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtPesquisar.Location = new System.Drawing.Point(300, 12);
            this.txtPesquisar.Size = new System.Drawing.Size(400, 23);
            this.txtPesquisar.PlaceholderText = "Pesquisar usuário...";
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);

            // btnCadastrar
            this.btnCadastrar.Location = new System.Drawing.Point(12, 12);
            this.btnCadastrar.Size = new System.Drawing.Size(140, 23);
            this.btnCadastrar.Text = "Cadastrar Novo Usuário";
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_ClickAsync);

            // btnAtualizar
            this.btnAtualizar.Location = new System.Drawing.Point(160, 12);
            this.btnAtualizar.Size = new System.Drawing.Size(120, 23);
            this.btnAtualizar.Text = "Atualizar Lista";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_ClickAsync);

            // dgvUsuarios
            this.dgvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 50);
            this.dgvUsuarios.Size = new System.Drawing.Size(760, 420);
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.CellContentClick += new DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClickAsync);

            // Coluna Editar
            var editarBtn = new DataGridViewButtonColumn();
            editarBtn.HeaderText = "Editar";
            editarBtn.Text = "Editar";
            editarBtn.Name = "Editar";
            editarBtn.UseColumnTextForButtonValue = true;
            this.dgvUsuarios.Columns.Add(editarBtn);

            // Coluna Resetar Senha
            var resetarBtn = new DataGridViewButtonColumn();
            resetarBtn.HeaderText = "Resetar Senha";
            resetarBtn.Text = "Resetar";
            resetarBtn.Name = "ResetarSenha";
            resetarBtn.UseColumnTextForButtonValue = true;
            this.dgvUsuarios.Columns.Add(resetarBtn);

            // Coluna Excluir
            var excluirBtn = new DataGridViewButtonColumn();
            excluirBtn.HeaderText = "Excluir";
            excluirBtn.Text = "Excluir";
            excluirBtn.Name = "Excluir";
            excluirBtn.UseColumnTextForButtonValue = true;
            this.dgvUsuarios.Columns.Add(excluirBtn);

            // FormPrincipal
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.dgvUsuarios);
            this.Text = "Gerenciador de Usuários";
            this.WindowState = FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }



    }
}
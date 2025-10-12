namespace CadastrarUsuario
{
    partial class FormResetarSenha
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblSenha = new Label();
            lblConfirmacao = new Label();
            txtSenha = new TextBox();
            txtConfirmacao = new TextBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(10, 7);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(271, 24);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Resetar Senha";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(22, 52);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(42, 15);
            lblSenha.TabIndex = 1;
            lblSenha.Text = "Senha:";
            // 
            // lblConfirmacao
            // 
            lblConfirmacao.AutoSize = true;
            lblConfirmacao.Location = new Point(22, 86);
            lblConfirmacao.Name = "lblConfirmacao";
            lblConfirmacao.Size = new Size(98, 15);
            lblConfirmacao.TabIndex = 3;
            lblConfirmacao.Text = "Confirmar senha:";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(118, 50);
            txtSenha.Margin = new Padding(3, 2, 3, 2);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(158, 23);
            txtSenha.TabIndex = 2;
            // 
            // txtConfirmacao
            // 
            txtConfirmacao.Location = new Point(118, 84);
            txtConfirmacao.Margin = new Padding(3, 2, 3, 2);
            txtConfirmacao.Name = "txtConfirmacao";
            txtConfirmacao.PasswordChar = '*';
            txtConfirmacao.Size = new Size(158, 23);
            txtConfirmacao.TabIndex = 4;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.MediumSeaGreen;
            btnSalvar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(118, 120);
            btnSalvar.Margin = new Padding(3, 2, 3, 2);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(74, 26);
            btnSalvar.TabIndex = 5;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightGray;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.Location = new Point(201, 120);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(74, 26);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FormResetarSenha
            // 
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(298, 165);
            Controls.Add(lblTitulo);
            Controls.Add(lblSenha);
            Controls.Add(txtSenha);
            Controls.Add(lblConfirmacao);
            Controls.Add(txtConfirmacao);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "FormResetarSenha";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Resetar Senha";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSenha;
        private Label lblConfirmacao;
        private TextBox txtSenha;
        private TextBox txtConfirmacao;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}
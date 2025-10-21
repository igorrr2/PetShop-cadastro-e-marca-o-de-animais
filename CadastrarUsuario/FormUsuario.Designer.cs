namespace CadastrarUsuario
{
    partial class FormUsuario
    {
        /// <summary>
        ///  Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ErrorProvider errorProvider;


        /// <summary>
        ///  Limpar recursos que estão sendo usados.
        /// </summary>
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
            components = new System.ComponentModel.Container();
            lblTitulo = new Label();
            lblNome = new Label();
            lblLogin = new Label();
            lblSenha = new Label();
            txtNome = new TextBox();
            txtLogin = new TextBox();
            txtSenha = new TextBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            errorProvider = new ErrorProvider(components);
            AtivoCheckBox = new CheckBox();
            AtivoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(10, 7);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(315, 24);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cadastrar Novo Usuário";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(26, 52);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 15);
            lblNome.TabIndex = 1;
            lblNome.Text = "Nome:";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(26, 82);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(40, 15);
            lblLogin.TabIndex = 3;
            lblLogin.Text = "Login:";
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(26, 112);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(42, 15);
            lblSenha.TabIndex = 5;
            lblSenha.Text = "Senha:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(75, 52);
            txtNome.Margin = new Padding(3, 2, 3, 2);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(219, 23);
            txtNome.TabIndex = 2;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(75, 82);
            txtLogin.Margin = new Padding(3, 2, 3, 2);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(219, 23);
            txtLogin.TabIndex = 4;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(75, 112);
            txtSenha.Margin = new Padding(3, 2, 3, 2);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(219, 23);
            txtSenha.TabIndex = 6;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.MediumSeaGreen;
            btnSalvar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(75, 162);
            btnSalvar.Margin = new Padding(3, 2, 3, 2);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(96, 26);
            btnSalvar.TabIndex = 7;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightGray;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.Location = new Point(198, 162);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 26);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // AtivoCheckBox
            // 
            AtivoCheckBox.AutoSize = true;
            AtivoCheckBox.Location = new Point(75, 143);
            AtivoCheckBox.Name = "AtivoCheckBox";
            AtivoCheckBox.RightToLeft = RightToLeft.Yes;
            AtivoCheckBox.Size = new Size(15, 14);
            AtivoCheckBox.TabIndex = 10;
            AtivoCheckBox.TextAlign = ContentAlignment.MiddleRight;
            AtivoCheckBox.UseVisualStyleBackColor = true;
            // 
            // AtivoLabel
            // 
            AtivoLabel.AutoSize = true;
            AtivoLabel.Location = new Point(28, 140);
            AtivoLabel.Name = "AtivoLabel";
            AtivoLabel.Size = new Size(38, 15);
            AtivoLabel.TabIndex = 9;
            AtivoLabel.Text = "Ativo:";
            // 
            // FormUsuario
            // 
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(322, 199);
            Controls.Add(AtivoCheckBox);
            Controls.Add(AtivoLabel);
            Controls.Add(lblTitulo);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(lblLogin);
            Controls.Add(txtLogin);
            Controls.Add(lblSenha);
            Controls.Add(txtSenha);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "FormUsuario";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Usuário";
            Load += FormUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNome;
        private Label lblLogin;
        private Label lblSenha;
        private TextBox txtNome;
        private TextBox txtLogin;
        private TextBox txtSenha;
        private Button btnSalvar;
        private Button btnCancelar;
        private CheckBox AtivoCheckBox;
        private Label AtivoLabel;
    }
}
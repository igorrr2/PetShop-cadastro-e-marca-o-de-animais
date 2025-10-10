namespace PetShop.Telas
{
    partial class AlterarSenhaForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelCentral;
        private Label SenhaAtualLabel;
        private TextBox SenhaAtualTextBox;
        private Label NovaSenhaLabel;
        private TextBox NovaSenhaTextBox;
        private Label NovaSenhaConfirmacaoLabel;
        private TextBox NovaSenhaConfirmacaoTextBox;
        private Button AlterarSenhaButton;
        private ErrorProvider errorProvider;

        private Button MostrarSenhaAtualButton;
        private Button MostrarNovaSenhaButton;
        private Button MostrarConfirmacaoButton;

        protected override void Dispose(bool disposing)
        {
            if (components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            errorProvider = new ErrorProvider(components);
            panelCentral = new Panel();
            NovaSenhaConfirmacaoLabel = new Label();
            NovaSenhaConfirmacaoTextBox = new TextBox();
            NovaSenhaLabel = new Label();
            NovaSenhaTextBox = new TextBox();
            SenhaAtualLabel = new Label();
            SenhaAtualTextBox = new TextBox();
            AlterarSenhaButton = new Button();
            MostrarSenhaAtualButton = new Button();
            MostrarNovaSenhaButton = new Button();
            MostrarConfirmacaoButton = new Button();

            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            panelCentral.SuspendLayout();
            SuspendLayout();

            // errorProvider
            errorProvider.ContainerControl = this;
            errorProvider.RightToLeft = true;

            // panelCentral
            panelCentral.BackColor = Color.WhiteSmoke;
            panelCentral.Controls.Add(MostrarConfirmacaoButton);
            panelCentral.Controls.Add(MostrarNovaSenhaButton);
            panelCentral.Controls.Add(MostrarSenhaAtualButton);
            panelCentral.Controls.Add(NovaSenhaConfirmacaoLabel);
            panelCentral.Controls.Add(NovaSenhaConfirmacaoTextBox);
            panelCentral.Controls.Add(NovaSenhaLabel);
            panelCentral.Controls.Add(NovaSenhaTextBox);
            panelCentral.Controls.Add(SenhaAtualLabel);
            panelCentral.Controls.Add(SenhaAtualTextBox);
            panelCentral.Controls.Add(AlterarSenhaButton);
            panelCentral.Location = new Point(0, 0);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(314, 256);
            panelCentral.TabIndex = 0;

            // Senha Atual
            SenhaAtualLabel.AutoSize = true;
            SenhaAtualLabel.Location = new Point(25, 16);
            SenhaAtualLabel.Text = "Senha Atual:";
            SenhaAtualTextBox.Location = new Point(25, 41);
            SenhaAtualTextBox.PasswordChar = '●';
            SenhaAtualTextBox.Size = new Size(240, 23);

            // Botão mostrar senha atual
            MostrarSenhaAtualButton.Text = "👁";
            MostrarSenhaAtualButton.Font = new Font("Segoe UI Emoji", 8);
            MostrarSenhaAtualButton.Location = new Point(270, 41);
            MostrarSenhaAtualButton.Size = new Size(25, 23);
            MostrarSenhaAtualButton.Click += MostrarSenhaAtualButton_Click;

            // Nova senha
            NovaSenhaLabel.AutoSize = true;
            NovaSenhaLabel.Location = new Point(25, 76);
            NovaSenhaLabel.Text = "Nova Senha:";
            NovaSenhaTextBox.Location = new Point(25, 101);
            NovaSenhaTextBox.PasswordChar = '●';
            NovaSenhaTextBox.Size = new Size(240, 23);

            // Botão mostrar nova senha
            MostrarNovaSenhaButton.Text = "👁";
            MostrarNovaSenhaButton.Font = new Font("Segoe UI Emoji", 8);
            MostrarNovaSenhaButton.Location = new Point(270, 101);
            MostrarNovaSenhaButton.Size = new Size(25, 23);
            MostrarNovaSenhaButton.Click += MostrarNovaSenhaButton_Click;

            // Confirmação nova senha
            NovaSenhaConfirmacaoLabel.AutoSize = true;
            NovaSenhaConfirmacaoLabel.Location = new Point(25, 135);
            NovaSenhaConfirmacaoLabel.Text = "Confirme sua senha:";
            NovaSenhaConfirmacaoTextBox.Location = new Point(25, 160);
            NovaSenhaConfirmacaoTextBox.PasswordChar = '●';
            NovaSenhaConfirmacaoTextBox.Size = new Size(240, 23);

            // Botão mostrar confirmação
            MostrarConfirmacaoButton.Text = "👁";
            MostrarConfirmacaoButton.Font = new Font("Segoe UI Emoji", 8);
            MostrarConfirmacaoButton.Location = new Point(270, 160);
            MostrarConfirmacaoButton.Size = new Size(25, 23);
            MostrarConfirmacaoButton.Click += MostrarConfirmacaoButton_Click;

            // Botão alterar senha
            AlterarSenhaButton.Location = new Point(25, 202);
            AlterarSenhaButton.Size = new Size(270, 34);
            AlterarSenhaButton.Text = "Alterar Senha";
            AlterarSenhaButton.UseVisualStyleBackColor = true;
            AlterarSenhaButton.Click += AlterarSenhaButton_ClickAsync;

            // AlterarSenhaForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 258);
            Controls.Add(panelCentral);
            Name = "AlterarSenhaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alterar Senha";
            WindowState = FormWindowState.Maximized;
            Load += AlterarSenhaForm_Load;
            Resize += AlterarSenhaForm_Resize;

            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            panelCentral.ResumeLayout(false);
            panelCentral.PerformLayout();
            ResumeLayout(false);
        }

    }
}

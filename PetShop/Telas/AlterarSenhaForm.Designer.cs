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
            MostrarConfirmacaoButton = new Button();
            MostrarNovaSenhaButton = new Button();
            MostrarSenhaAtualButton = new Button();
            NovaSenhaConfirmacaoLabel = new Label();
            NovaSenhaConfirmacaoTextBox = new TextBox();
            NovaSenhaLabel = new Label();
            NovaSenhaTextBox = new TextBox();
            SenhaAtualLabel = new Label();
            SenhaAtualTextBox = new TextBox();
            AlterarSenhaButton = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            panelCentral.SuspendLayout();
            SuspendLayout();
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            errorProvider.RightToLeft = true;
            // 
            // panelCentral
            // 
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
            // 
            // MostrarConfirmacaoButton
            // 
            MostrarConfirmacaoButton.Font = new Font("Segoe UI Emoji", 8F, FontStyle.Regular, GraphicsUnit.Point);
            MostrarConfirmacaoButton.Location = new Point(270, 160);
            MostrarConfirmacaoButton.Name = "MostrarConfirmacaoButton";
            MostrarConfirmacaoButton.Size = new Size(25, 23);
            MostrarConfirmacaoButton.TabIndex = 6;
            MostrarConfirmacaoButton.Text = "👁";
            MostrarConfirmacaoButton.Click += MostrarConfirmacaoButton_Click;
            // 
            // MostrarNovaSenhaButton
            // 
            MostrarNovaSenhaButton.Font = new Font("Segoe UI Emoji", 8F, FontStyle.Regular, GraphicsUnit.Point);
            MostrarNovaSenhaButton.Location = new Point(270, 101);
            MostrarNovaSenhaButton.Name = "MostrarNovaSenhaButton";
            MostrarNovaSenhaButton.Size = new Size(25, 23);
            MostrarNovaSenhaButton.TabIndex = 5;
            MostrarNovaSenhaButton.Text = "👁";
            MostrarNovaSenhaButton.Click += MostrarNovaSenhaButton_Click;
            // 
            // MostrarSenhaAtualButton
            // 
            MostrarSenhaAtualButton.Font = new Font("Segoe UI Emoji", 8F, FontStyle.Regular, GraphicsUnit.Point);
            MostrarSenhaAtualButton.Location = new Point(270, 41);
            MostrarSenhaAtualButton.Name = "MostrarSenhaAtualButton";
            MostrarSenhaAtualButton.Size = new Size(25, 23);
            MostrarSenhaAtualButton.TabIndex = 4;
            MostrarSenhaAtualButton.Text = "👁";
            MostrarSenhaAtualButton.Click += MostrarSenhaAtualButton_Click;
            // 
            // NovaSenhaConfirmacaoLabel
            // 
            NovaSenhaConfirmacaoLabel.AutoSize = true;
            NovaSenhaConfirmacaoLabel.Location = new Point(25, 135);
            NovaSenhaConfirmacaoLabel.Name = "NovaSenhaConfirmacaoLabel";
            NovaSenhaConfirmacaoLabel.Size = new Size(115, 15);
            NovaSenhaConfirmacaoLabel.TabIndex = 3;
            NovaSenhaConfirmacaoLabel.Text = "Confirme sua senha:";
            // 
            // NovaSenhaConfirmacaoTextBox
            // 
            NovaSenhaConfirmacaoTextBox.Location = new Point(25, 160);
            NovaSenhaConfirmacaoTextBox.Name = "NovaSenhaConfirmacaoTextBox";
            NovaSenhaConfirmacaoTextBox.PasswordChar = '●';
            NovaSenhaConfirmacaoTextBox.Size = new Size(240, 23);
            NovaSenhaConfirmacaoTextBox.TabIndex = 2;
            // 
            // NovaSenhaLabel
            // 
            NovaSenhaLabel.AutoSize = true;
            NovaSenhaLabel.Location = new Point(25, 76);
            NovaSenhaLabel.Name = "NovaSenhaLabel";
            NovaSenhaLabel.Size = new Size(73, 15);
            NovaSenhaLabel.TabIndex = 5;
            NovaSenhaLabel.Text = "Nova Senha:";
            // 
            // NovaSenhaTextBox
            // 
            NovaSenhaTextBox.Location = new Point(25, 101);
            NovaSenhaTextBox.Name = "NovaSenhaTextBox";
            NovaSenhaTextBox.PasswordChar = '●';
            NovaSenhaTextBox.Size = new Size(240, 23);
            NovaSenhaTextBox.TabIndex = 1;
            // 
            // SenhaAtualLabel
            // 
            SenhaAtualLabel.AutoSize = true;
            SenhaAtualLabel.Location = new Point(25, 16);
            SenhaAtualLabel.Name = "SenhaAtualLabel";
            SenhaAtualLabel.Size = new Size(73, 15);
            SenhaAtualLabel.TabIndex = 7;
            SenhaAtualLabel.Text = "Senha Atual:";
            // 
            // SenhaAtualTextBox
            // 
            SenhaAtualTextBox.Location = new Point(25, 41);
            SenhaAtualTextBox.Name = "SenhaAtualTextBox";
            SenhaAtualTextBox.PasswordChar = '●';
            SenhaAtualTextBox.Size = new Size(240, 23);
            SenhaAtualTextBox.TabIndex = 0;
            // 
            // AlterarSenhaButton
            // 
            AlterarSenhaButton.Location = new Point(25, 202);
            AlterarSenhaButton.Name = "AlterarSenhaButton";
            AlterarSenhaButton.Size = new Size(270, 34);
            AlterarSenhaButton.TabIndex = 3;
            AlterarSenhaButton.Text = "Alterar Senha";
            AlterarSenhaButton.UseVisualStyleBackColor = true;
            AlterarSenhaButton.Click += AlterarSenhaButton_ClickAsync;
            // 
            // AlterarSenhaForm
            // 
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

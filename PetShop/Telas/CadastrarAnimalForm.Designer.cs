namespace PetShop.Telas
{
    partial class CadastrarAnimalForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelCentral;
        private Label NomeAnimalLabel;
        private TextBox NomeAnimalTextBox;
        private Label NomeTutorLabel;
        private TextBox NomeTutorTextBox;
        private Label RacaLabel;
        private TextBox RacaTextBox;
        private Label SexoLabel;
        private ComboBox SexoComboBox;
        private Label DataNascimentoLabel;
        private DateTimePicker DataNascimentoDateTimerPicker;
        private Label ObservacaoLabel;
        private TextBox ObservacoesTextBox;
        private ErrorProvider errorProvider;

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
            NumeroTelefoneTutoLabel = new Label();
            NumeroTelefoneTutorTextBox = new TextBox();
            CancelarButton = new Button();
            SalvarButton = new Button();
            NomeAnimalLabel = new Label();
            NomeAnimalTextBox = new TextBox();
            NomeTutorLabel = new Label();
            NomeTutorTextBox = new TextBox();
            RacaLabel = new Label();
            RacaTextBox = new TextBox();
            SexoLabel = new Label();
            SexoComboBox = new ComboBox();
            DataNascimentoLabel = new Label();
            DataNascimentoDateTimerPicker = new DateTimePicker();
            ObservacaoLabel = new Label();
            ObservacoesTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            panelCentral.SuspendLayout();
            SuspendLayout();
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // panelCentral
            // 
            panelCentral.BackColor = Color.WhiteSmoke;
            panelCentral.Controls.Add(NumeroTelefoneTutoLabel);
            panelCentral.Controls.Add(NumeroTelefoneTutorTextBox);
            panelCentral.Controls.Add(CancelarButton);
            panelCentral.Controls.Add(SalvarButton);
            panelCentral.Controls.Add(NomeAnimalLabel);
            panelCentral.Controls.Add(NomeAnimalTextBox);
            panelCentral.Controls.Add(NomeTutorLabel);
            panelCentral.Controls.Add(NomeTutorTextBox);
            panelCentral.Controls.Add(RacaLabel);
            panelCentral.Controls.Add(RacaTextBox);
            panelCentral.Controls.Add(SexoLabel);
            panelCentral.Controls.Add(SexoComboBox);
            panelCentral.Controls.Add(DataNascimentoLabel);
            panelCentral.Controls.Add(DataNascimentoDateTimerPicker);
            panelCentral.Controls.Add(ObservacaoLabel);
            panelCentral.Controls.Add(ObservacoesTextBox);
            panelCentral.Location = new Point(0, 0);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(402, 545);
            panelCentral.TabIndex = 0;
            // 
            // NumeroTelefoneTutoLabel
            // 
            NumeroTelefoneTutoLabel.AutoSize = true;
            NumeroTelefoneTutoLabel.Location = new Point(25, 139);
            NumeroTelefoneTutoLabel.Name = "NumeroTelefoneTutoLabel";
            NumeroTelefoneTutoLabel.Size = new Size(159, 15);
            NumeroTelefoneTutoLabel.TabIndex = 4;
            NumeroTelefoneTutoLabel.Text = "Número de telefone do tutor";
            // 
            // NumeroTelefoneTutorTextBox
            // 
            NumeroTelefoneTutorTextBox.Location = new Point(25, 164);
            NumeroTelefoneTutorTextBox.Name = "NumeroTelefoneTutorTextBox";
            NumeroTelefoneTutorTextBox.Size = new Size(343, 23);
            NumeroTelefoneTutorTextBox.TabIndex = 5;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(218, 500);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(150, 34);
            CancelarButton.TabIndex = 15;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // SalvarButton
            // 
            SalvarButton.Location = new Point(25, 500);
            SalvarButton.Name = "SalvarButton";
            SalvarButton.Size = new Size(150, 34);
            SalvarButton.TabIndex = 14;
            SalvarButton.Text = "Salvar";
            SalvarButton.UseVisualStyleBackColor = true;
            SalvarButton.Click += SalvarButton_Click;
            // 
            // NomeAnimalLabel
            // 
            NomeAnimalLabel.AutoSize = true;
            NomeAnimalLabel.Location = new Point(25, 20);
            NomeAnimalLabel.Name = "NomeAnimalLabel";
            NomeAnimalLabel.Size = new Size(98, 15);
            NomeAnimalLabel.TabIndex = 0;
            NomeAnimalLabel.Text = "Nome do Animal";
            // 
            // NomeAnimalTextBox
            // 
            NomeAnimalTextBox.Location = new Point(25, 45);
            NomeAnimalTextBox.Name = "NomeAnimalTextBox";
            NomeAnimalTextBox.Size = new Size(343, 23);
            NomeAnimalTextBox.TabIndex = 1;
            // 
            // NomeTutorLabel
            // 
            NomeTutorLabel.AutoSize = true;
            NomeTutorLabel.Location = new Point(25, 80);
            NomeTutorLabel.Name = "NomeTutorLabel";
            NomeTutorLabel.Size = new Size(125, 15);
            NomeTutorLabel.TabIndex = 2;
            NomeTutorLabel.Text = "Nome tutor do animal";
            // 
            // NomeTutorTextBox
            // 
            NomeTutorTextBox.Location = new Point(25, 105);
            NomeTutorTextBox.Name = "NomeTutorTextBox";
            NomeTutorTextBox.Size = new Size(343, 23);
            NomeTutorTextBox.TabIndex = 3;
            // 
            // RacaLabel
            // 
            RacaLabel.AutoSize = true;
            RacaLabel.Location = new Point(25, 200);
            RacaLabel.Name = "RacaLabel";
            RacaLabel.Size = new Size(90, 15);
            RacaLabel.TabIndex = 6;
            RacaLabel.Text = "Raça do Animal";
            // 
            // RacaTextBox
            // 
            RacaTextBox.Location = new Point(25, 225);
            RacaTextBox.Name = "RacaTextBox";
            RacaTextBox.Size = new Size(343, 23);
            RacaTextBox.TabIndex = 7;
            // 
            // SexoLabel
            // 
            SexoLabel.AutoSize = true;
            SexoLabel.Location = new Point(25, 260);
            SexoLabel.Name = "SexoLabel";
            SexoLabel.Size = new Size(89, 15);
            SexoLabel.TabIndex = 8;
            SexoLabel.Text = "Sexo do Animal";
            // 
            // SexoComboBox
            // 
            SexoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SexoComboBox.Items.AddRange(new object[] { "Macho", "Fêmea" });
            SexoComboBox.Location = new Point(25, 285);
            SexoComboBox.Name = "SexoComboBox";
            SexoComboBox.Size = new Size(343, 23);
            SexoComboBox.TabIndex = 9;
            // 
            // DataNascimentoLabel
            // 
            DataNascimentoLabel.AutoSize = true;
            DataNascimentoLabel.Location = new Point(25, 320);
            DataNascimentoLabel.Name = "DataNascimentoLabel";
            DataNascimentoLabel.Size = new Size(114, 15);
            DataNascimentoLabel.TabIndex = 10;
            DataNascimentoLabel.Text = "Data de Nascimento";
            // 
            // DataNascimentoDateTimerPicker
            // 
            DataNascimentoDateTimerPicker.Location = new Point(25, 345);
            DataNascimentoDateTimerPicker.Name = "DataNascimentoDateTimerPicker";
            DataNascimentoDateTimerPicker.Size = new Size(343, 23);
            DataNascimentoDateTimerPicker.TabIndex = 11;
            // 
            // ObservacaoLabel
            // 
            ObservacaoLabel.AutoSize = true;
            ObservacaoLabel.Location = new Point(25, 380);
            ObservacaoLabel.Name = "ObservacaoLabel";
            ObservacaoLabel.Size = new Size(74, 15);
            ObservacaoLabel.TabIndex = 12;
            ObservacaoLabel.Text = "Observações";
            // 
            // ObservacoesTextBox
            // 
            ObservacoesTextBox.Location = new Point(25, 405);
            ObservacoesTextBox.Multiline = true;
            ObservacoesTextBox.Name = "ObservacoesTextBox";
            ObservacoesTextBox.ScrollBars = ScrollBars.Vertical;
            ObservacoesTextBox.Size = new Size(343, 80);
            ObservacoesTextBox.TabIndex = 13;
            // 
            // CadastrarAnimalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 557);
            Controls.Add(panelCentral);
            Name = "CadastrarAnimalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastrar Animal";
            WindowState = FormWindowState.Maximized;
            Load += CadastrarAnimalForm_Load;
            Resize += CadastrarAnimalForm_Resize;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            panelCentral.ResumeLayout(false);
            panelCentral.PerformLayout();
            ResumeLayout(false);
        }

        private Button SalvarButton;
        private Button CancelarButton;
        private Label NumeroTelefoneTutoLabel;
        private TextBox NumeroTelefoneTutorTextBox;
    }
}

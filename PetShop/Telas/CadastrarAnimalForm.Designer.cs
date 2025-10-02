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
            panelCentral.Size = new Size(402, 529);
            panelCentral.TabIndex = 0;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(218, 440);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(150, 34);
            CancelarButton.TabIndex = 13;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // SalvarButton
            // 
            SalvarButton.Location = new Point(25, 440);
            SalvarButton.Name = "SalvarButton";
            SalvarButton.Size = new Size(150, 34);
            SalvarButton.TabIndex = 12;
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
            RacaLabel.Location = new Point(25, 140);
            RacaLabel.Name = "RacaLabel";
            RacaLabel.Size = new Size(90, 15);
            RacaLabel.TabIndex = 4;
            RacaLabel.Text = "Raça do Animal";
            // 
            // RacaTextBox
            // 
            RacaTextBox.Location = new Point(25, 165);
            RacaTextBox.Name = "RacaTextBox";
            RacaTextBox.Size = new Size(343, 23);
            RacaTextBox.TabIndex = 5;
            // 
            // SexoLabel
            // 
            SexoLabel.AutoSize = true;
            SexoLabel.Location = new Point(25, 200);
            SexoLabel.Name = "SexoLabel";
            SexoLabel.Size = new Size(89, 15);
            SexoLabel.TabIndex = 6;
            SexoLabel.Text = "Sexo do Animal";
            // 
            // SexoComboBox
            // 
            SexoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SexoComboBox.Items.AddRange(new object[] { "Macho", "Fêmea" });
            SexoComboBox.Location = new Point(25, 225);
            SexoComboBox.Name = "SexoComboBox";
            SexoComboBox.Size = new Size(343, 23);
            SexoComboBox.TabIndex = 7;
            // 
            // DataNascimentoLabel
            // 
            DataNascimentoLabel.AutoSize = true;
            DataNascimentoLabel.Location = new Point(25, 260);
            DataNascimentoLabel.Name = "DataNascimentoLabel";
            DataNascimentoLabel.Size = new Size(114, 15);
            DataNascimentoLabel.TabIndex = 8;
            DataNascimentoLabel.Text = "Data de Nascimento";
            // 
            // DataNascimentoDateTimerPicker
            // 
            DataNascimentoDateTimerPicker.Location = new Point(25, 285);
            DataNascimentoDateTimerPicker.Name = "DataNascimentoDateTimerPicker";
            DataNascimentoDateTimerPicker.Size = new Size(343, 23);
            DataNascimentoDateTimerPicker.TabIndex = 9;
            // 
            // ObservacaoLabel
            // 
            ObservacaoLabel.AutoSize = true;
            ObservacaoLabel.Location = new Point(25, 320);
            ObservacaoLabel.Name = "ObservacaoLabel";
            ObservacaoLabel.Size = new Size(74, 15);
            ObservacaoLabel.TabIndex = 10;
            ObservacaoLabel.Text = "Observações";
            // 
            // ObservacoesTextBox
            // 
            ObservacoesTextBox.Location = new Point(25, 345);
            ObservacoesTextBox.Multiline = true;
            ObservacoesTextBox.Name = "ObservacoesTextBox";
            ObservacoesTextBox.ScrollBars = ScrollBars.Vertical;
            ObservacoesTextBox.Size = new Size(343, 80);
            ObservacoesTextBox.TabIndex = 11;
            // 
            // CadastrarAnimalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 508);
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
    }
}

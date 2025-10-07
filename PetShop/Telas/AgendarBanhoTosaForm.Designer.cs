using PetShop.Models;

namespace PetShop.Telas
{
    partial class AgendarBanhoTosaForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelCentral;
        private Label NomeAnimalAgendadoLabel;
        private Label ModalidadeAgendamentoLabel;
        private Label DataAgendamentoLabel;
        private DateTimePicker DataAgendamentoDateTimerPicker;
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
            LabelErro = new Label();
            ModalidadeAgendamentoComBox = new ComboBox();
            NomeAnimalAgendadoCombobox = new ComboBox();
            CancelarButton = new Button();
            SalvarButton = new Button();
            NomeAnimalAgendadoLabel = new Label();
            ModalidadeAgendamentoLabel = new Label();
            DataAgendamentoLabel = new Label();
            DataAgendamentoDateTimerPicker = new DateTimePicker();
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
            panelCentral.Controls.Add(LabelErro);
            panelCentral.Controls.Add(ModalidadeAgendamentoComBox);
            panelCentral.Controls.Add(NomeAnimalAgendadoCombobox);
            panelCentral.Controls.Add(CancelarButton);
            panelCentral.Controls.Add(SalvarButton);
            panelCentral.Controls.Add(NomeAnimalAgendadoLabel);
            panelCentral.Controls.Add(ModalidadeAgendamentoLabel);
            panelCentral.Controls.Add(DataAgendamentoLabel);
            panelCentral.Controls.Add(DataAgendamentoDateTimerPicker);
            panelCentral.Controls.Add(ObservacaoLabel);
            panelCentral.Controls.Add(ObservacoesTextBox);
            panelCentral.Location = new Point(0, 0);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(403, 350);
            panelCentral.TabIndex = 0;
            // 
            // LabelErro
            // 
            LabelErro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LabelErro.AutoSize = true;
            LabelErro.ForeColor = Color.Red;
            LabelErro.Location = new Point(25, 18);
            LabelErro.MaximumSize = new Size(200, 0);
            LabelErro.Name = "LabelErro";
            LabelErro.Size = new Size(0, 15);
            LabelErro.TabIndex = 0;
            LabelErro.TextAlign = ContentAlignment.MiddleLeft;
            LabelErro.Visible = false;
            // 
            // ModalidadeAgendamentoComBox
            // 
            ModalidadeAgendamentoComBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ModalidadeAgendamentoComBox.Items.AddRange(new object[] { "Banho", "Tosa", "Banho e tosa" });
            ModalidadeAgendamentoComBox.Location = new Point(25, 96);
            ModalidadeAgendamentoComBox.Name = "ModalidadeAgendamentoComBox";
            ModalidadeAgendamentoComBox.Size = new Size(343, 23);
            ModalidadeAgendamentoComBox.TabIndex = 5;
            // 
            // NomeAnimalAgendadoCombobox
            // 
            NomeAnimalAgendadoCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            NomeAnimalAgendadoCombobox.Location = new Point(25, 41);
            NomeAnimalAgendadoCombobox.Name = "NomeAnimalAgendadoCombobox";
            NomeAnimalAgendadoCombobox.Size = new Size(343, 23);
            NomeAnimalAgendadoCombobox.TabIndex = 1;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(218, 299);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(150, 34);
            CancelarButton.TabIndex = 11;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // SalvarButton
            // 
            SalvarButton.Location = new Point(25, 299);
            SalvarButton.Name = "SalvarButton";
            SalvarButton.Size = new Size(150, 34);
            SalvarButton.TabIndex = 10;
            SalvarButton.Text = "Salvar";
            SalvarButton.UseVisualStyleBackColor = true;
            SalvarButton.Click += SalvarButton_Click;
            // 
            // NomeAnimalAgendadoLabel
            // 
            NomeAnimalAgendadoLabel.AutoSize = true;
            NomeAnimalAgendadoLabel.Location = new Point(25, 20);
            NomeAnimalAgendadoLabel.Name = "NomeAnimalAgendadoLabel";
            NomeAnimalAgendadoLabel.Size = new Size(156, 15);
            NomeAnimalAgendadoLabel.TabIndex = 0;
            NomeAnimalAgendadoLabel.Text = "Nome do Animal Agendado";
            // 
            // ModalidadeAgendamentoLabel
            // 
            ModalidadeAgendamentoLabel.AutoSize = true;
            ModalidadeAgendamentoLabel.Location = new Point(25, 73);
            ModalidadeAgendamentoLabel.Name = "ModalidadeAgendamentoLabel";
            ModalidadeAgendamentoLabel.Size = new Size(149, 15);
            ModalidadeAgendamentoLabel.TabIndex = 4;
            ModalidadeAgendamentoLabel.Text = "Modalidade Agendamento";
            // 
            // DataAgendamentoLabel
            // 
            DataAgendamentoLabel.AutoSize = true;
            DataAgendamentoLabel.Location = new Point(25, 132);
            DataAgendamentoLabel.Name = "DataAgendamentoLabel";
            DataAgendamentoLabel.Size = new Size(156, 15);
            DataAgendamentoLabel.TabIndex = 6;
            DataAgendamentoLabel.Text = "Data Hora do Agendamento";
            // 
            // DataAgendamentoDateTimerPicker
            // 
            DataAgendamentoDateTimerPicker.CustomFormat = "dd/MM/yyyy HH:mm";
            DataAgendamentoDateTimerPicker.Format = DateTimePickerFormat.Custom;
            DataAgendamentoDateTimerPicker.Location = new Point(25, 154);
            DataAgendamentoDateTimerPicker.Name = "DataAgendamentoDateTimerPicker";
            DataAgendamentoDateTimerPicker.ShowUpDown = true;
            DataAgendamentoDateTimerPicker.Size = new Size(343, 23);
            DataAgendamentoDateTimerPicker.TabIndex = 7;
            // 
            // ObservacaoLabel
            // 
            ObservacaoLabel.AutoSize = true;
            ObservacaoLabel.Location = new Point(25, 186);
            ObservacaoLabel.Name = "ObservacaoLabel";
            ObservacaoLabel.Size = new Size(74, 15);
            ObservacaoLabel.TabIndex = 8;
            ObservacaoLabel.Text = "Observações";
            // 
            // ObservacoesTextBox
            // 
            ObservacoesTextBox.Location = new Point(25, 208);
            ObservacoesTextBox.Multiline = true;
            ObservacoesTextBox.Name = "ObservacoesTextBox";
            ObservacoesTextBox.ScrollBars = ScrollBars.Vertical;
            ObservacoesTextBox.Size = new Size(343, 80);
            ObservacoesTextBox.TabIndex = 9;
            // 
            // AgendarBanhoTosaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 352);
            Controls.Add(panelCentral);
            Name = "AgendarBanhoTosaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastrar Agendamento";
            WindowState = FormWindowState.Maximized;
            Load += AgendarBanhoTosaForm_Load;
            Resize += AgendarBanhoTosaForm_Resize;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            panelCentral.ResumeLayout(false);
            panelCentral.PerformLayout();
            ResumeLayout(false);
        }

        private Button SalvarButton;
        private Button CancelarButton;
        private ComboBox NomeAnimalAgendadoCombobox;
        private ComboBox ModalidadeAgendamentoComBox;
        private Label LabelErro;
    }
}
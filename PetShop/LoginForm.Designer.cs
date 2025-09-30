using System.Windows.Forms;

namespace PetShop
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private ErrorProvider errorProvider;

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
            this.StartPosition = FormStartPosition.CenterScreen; 
            this.WindowState = FormWindowState.Maximized;        
            errorProvider = new ErrorProvider();
            panel1 = new Panel();
            label1 = new Label();
            LoginTextBox = new TextBox();
            Senha = new Label();
            SenhaTextBox = new TextBox();
            EntrarButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(LoginTextBox);
            panel1.Controls.Add(Senha);
            panel1.Controls.Add(SenhaTextBox);
            panel1.Controls.Add(EntrarButton);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(365, 209);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 43);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // textBox1
            // 
            LoginTextBox.Location = new Point(80, 64);
            LoginTextBox.Name = "textBox1";
            LoginTextBox.Size = new Size(245, 23);
            LoginTextBox.TabIndex = 1;
            // 
            // Senha
            // 
            Senha.AutoSize = true;
            Senha.Location = new Point(80, 90);
            Senha.Name = "Senha";
            Senha.Size = new Size(39, 15);
            Senha.TabIndex = 2;
            Senha.Text = "Senha";
            // 
            // textBox2
            // 
            SenhaTextBox.Location = new Point(80, 113);
            SenhaTextBox.Name = "textBox2";
            SenhaTextBox.PasswordChar = '*';
            SenhaTextBox.Size = new Size(245, 23);
            SenhaTextBox.TabIndex = 3;
            // 
            // button1
            // 
            EntrarButton.Location = new Point(80, 151);
            EntrarButton.Name = "button1";
            EntrarButton.Size = new Size(100, 30);
            EntrarButton.TabIndex = 4;
            EntrarButton.Text = "Entrar";
            EntrarButton.UseVisualStyleBackColor = true;
            EntrarButton.Click += Loginbutton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - PetShop";
            Load += Form1_Load;
            Resize += Form1_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox LoginTextBox;
        private Label Senha;
        private TextBox SenhaTextBox;
        private Button EntrarButton;

        private void Form1_Load(object sender, EventArgs e)
        {
            CentralizarPanel();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CentralizarPanel();
        }

        private void CentralizarPanel()
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }
    }
}

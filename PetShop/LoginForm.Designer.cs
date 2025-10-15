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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            errorProvider = new ErrorProvider(components);
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            LoginTextBox = new TextBox();
            Senha = new Label();
            SenhaTextBox = new TextBox();
            EntrarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(LoginTextBox);
            panel1.Controls.Add(Senha);
            panel1.Controls.Add(SenhaTextBox);
            panel1.Controls.Add(EntrarButton);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(602, 546);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(18, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(573, 350);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(178, 381);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // LoginTextBox
            // 
            LoginTextBox.Location = new Point(178, 402);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.Size = new Size(245, 23);
            LoginTextBox.TabIndex = 1;
            // 
            // Senha
            // 
            Senha.AutoSize = true;
            Senha.Location = new Point(178, 428);
            Senha.Name = "Senha";
            Senha.Size = new Size(39, 15);
            Senha.TabIndex = 2;
            Senha.Text = "Senha";
            // 
            // SenhaTextBox
            // 
            SenhaTextBox.Location = new Point(178, 451);
            SenhaTextBox.Name = "SenhaTextBox";
            SenhaTextBox.PasswordChar = '*';
            SenhaTextBox.Size = new Size(245, 23);
            SenhaTextBox.TabIndex = 3;
            // 
            // EntrarButton
            // 
            EntrarButton.Location = new Point(178, 489);
            EntrarButton.Name = "EntrarButton";
            EntrarButton.Size = new Size(100, 30);
            EntrarButton.TabIndex = 4;
            EntrarButton.Text = "Entrar";
            EntrarButton.UseVisualStyleBackColor = true;
            EntrarButton.Click += Loginbutton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 570);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - PetShop";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            this.BackColor = ColorTranslator.FromHtml("#FFF8EC");
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

        private PictureBox pictureBox1;
    }
}

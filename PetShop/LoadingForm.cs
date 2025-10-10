using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetShop
{
    public partial class LoadingForm : Form
    {
        public LoadingForm(string titulo, string mensagem)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
            this.TopMost = true;

            this.Text = titulo;
            // Configura a Label
            int AntigaALturaLabel = lblMensagem.Height;
            lblMensagem.Text = mensagem;
            lblMensagem.AutoSize = false;                  // Permite definir tamanho manual
            lblMensagem.MaximumSize = new Size(400, 0);    // Largura máxima
            lblMensagem.Width = 400;                       // Define a largura inicial
            lblMensagem.Height = TextRenderer.MeasureText(mensagem, lblMensagem.Font, new Size(400, 0), TextFormatFlags.WordBreak).Height;
            lblMensagem.AutoEllipsis = false;
            
            this.Height = this.Height - AntigaALturaLabel + lblMensagem.Height;

            progressBar.Top = lblMensagem.Bottom + 10; // 10px de espaçamento
            progressBar.Left = (this.ClientSize.Width - progressBar.Width) / 2; // centraliza horizontalmente
        }
    }
}

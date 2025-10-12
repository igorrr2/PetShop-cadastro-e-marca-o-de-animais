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

            int AntigaALturaLabel = lblMensagem.Height;
            lblMensagem.Text = mensagem;
            lblMensagem.AutoSize = false;                 
            lblMensagem.MaximumSize = new Size(400, 0);  
            lblMensagem.Width = 400;                      
            lblMensagem.Height = TextRenderer.MeasureText(mensagem, lblMensagem.Font, new Size(400, 0), TextFormatFlags.WordBreak).Height;
            lblMensagem.AutoEllipsis = false;
            
            this.Height = this.Height - AntigaALturaLabel + lblMensagem.Height;

            progressBar.Top = lblMensagem.Bottom + 10; 
            progressBar.Left = (this.ClientSize.Width - progressBar.Width) / 2; 
        }
    }
}

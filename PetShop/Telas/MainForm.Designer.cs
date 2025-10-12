using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetShop.Telas
{
    public partial class MainForm : Form
    {
        private MenuForm menuLateral;
        private Panel panelConteudo;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            SuspendLayout();
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PetShop - Sistema";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        private void AbrirFormularioNoPanel(Form formFilho)
        {
            panelConteudo.Controls.Clear();
            formFilho.TopLevel = false;
            formFilho.FormBorderStyle = FormBorderStyle.None;
            formFilho.Dock = DockStyle.Fill;
            formFilho.BackColor = Color.FromArgb(149, 94, 38);
            panelConteudo.Controls.Add(formFilho);
            panelConteudo.Tag = formFilho;
            formFilho.Show();
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetShop.Telas
{
    public partial class MenuForm : UserControl
    {
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // MenuForm
            // 
            BackColor = Color.FromArgb(13, 196, 202);
            Name = "MenuForm";
            Size = new Size(200, 614);
            ResumeLayout(false);
        }
    }
}

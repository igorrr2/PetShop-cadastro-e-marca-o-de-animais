using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PetShop.Telas
{
    public partial class AgendamentosDoDiaForm : Form
    {
        public AgendamentosDoDiaForm(List<BanhoTosa> listaBanhoTosa)
        {
            InitializeComponent();

            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoGenerateColumns = true,
                DataSource = listaBanhoTosa,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, 
            };

            dgv.DataBindingComplete += (s, e) =>
            {
                if (dgv.Columns.Contains("Id"))
                    dgv.Columns["Id"].Visible = false;
            };

            this.Controls.Add(dgv);

            this.Text = "Agendamentos do Dia";
            this.Size = new System.Drawing.Size(700, 400);
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}

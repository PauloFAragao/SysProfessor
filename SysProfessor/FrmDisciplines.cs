﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SysProfessor
{
    public partial class FrmDisciplines : Form
    {
        public FrmDisciplines()
        {
            InitializeComponent();

            AtualizeDgv();
            HideColumns();
            ChangeColumns();
        }

        private void AtualizeDgv()
        {
            this.DgvDisciplines.DataSource = Data.ShowDisciplines();
        }

        private void HideColumns()
        {
            this.DgvDisciplines.Columns[0].Visible = false;
        }

        private void ChangeColumns()
        {
            // Altera o texto do cabeçalho da coluna 1 para "Nome do aluno"
            this.DgvDisciplines.Columns[1].HeaderText = "Matéria";
            this.DgvDisciplines.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Altera o texto do cabeçalho da coluna 2 para "Número da chamada"
            this.DgvDisciplines.Columns[2].HeaderText = "Média para aprovação";
            this.DgvDisciplines.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void Search()
        {
            this.DgvDisciplines.DataSource = Data.SearchDiscipline(this.TxtSearch.Text);
        }

        private void View()
        {
            if (DgvDisciplines.Rows.Count > 0)
            {
                //Debug.WriteLine("Tem dados");

                FormLoader.OpenChildForm(new FrmViewDiscipline(
                Convert.ToInt32(this.DgvDisciplines.CurrentRow.Cells["idmateria"].Value),
                Convert.ToString(this.DgvDisciplines.CurrentRow.Cells["nome"].Value),
                Convert.ToDecimal(this.DgvDisciplines.CurrentRow.Cells["media"].Value)));
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        private void Del()
        {
            if (DgvDisciplines.Rows.Count > 0)
            {
                //Debug.WriteLine("Tem dados");

                string disciplineName;

                int id = Convert.ToInt32(this.DgvDisciplines.CurrentRow.Cells["idmateria"].Value);

                disciplineName = Convert.ToString(this.DgvDisciplines.CurrentRow.Cells["nome"].Value);

                if (MessageBox.Show(
                    "Realmente Deseja Apagar a Matéria: " + disciplineName + " ?",
                    "Apagar Matéria?",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string resp;

                    resp = Data.DeleteDiscipline(id);

                    Debug.WriteLine(resp);
                }
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        private void Add()
        {
            if (DgvDisciplines.Rows.Count > 0)
            {
                //Debug.WriteLine("Tem dados");

                FormLoader.OpenChildForm(new FrmAddEditDiscipline(true,
                Convert.ToInt32(this.DgvDisciplines.CurrentRow.Cells["idmateria"].Value),
                Convert.ToString(this.DgvDisciplines.CurrentRow.Cells["nome"].Value),
                Convert.ToString(this.DgvDisciplines.CurrentRow.Cells["media"].Value)
                ));
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            View();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormLoader.OpenChildForm(new FrmAddEditDiscipline(false, -1, string.Empty, string.Empty));
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Del();
            AtualizeDgv();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}

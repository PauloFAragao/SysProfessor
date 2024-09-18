using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SysProfessor
{
    public partial class FrmStudents : Form
    {
        public FrmStudents()
        {
            InitializeComponent();

            AtualizeDgv();
            HideColumns();
            ChangeColumns();
        }

        private void AtualizeDgv()
        {
            this.DgvStudants.DataSource = Data.ShowStudants();
        }

        private void HideColumns()
        {
            this.DgvStudants.Columns[0].Visible = false;
        }

        private void ChangeColumns()
        {
            // Altera o texto do cabeçalho da coluna 1 para "Nome do aluno"
            this.DgvStudants.Columns[1].HeaderText = "Nome do aluno";
            this.DgvStudants.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Altera o texto do cabeçalho da coluna 2 para "Número da chamada"
            this.DgvStudants.Columns[2].HeaderText = "Número da chamada";
            this.DgvStudants.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void Del()
        {
            string studantName;

            int id = Convert.ToInt32(this.DgvStudants.CurrentRow.Cells["idaluno"].Value);

            studantName = Convert.ToString(this.DgvStudants.CurrentRow.Cells["nome"].Value) ;

            if (MessageBox.Show(
                "Realmente Deseja Apagar o(a) Aluno(a): "+ studantName + " ?" ,
                "Apagar Aluno?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                string resp;

                resp = Data.DeleteStudant(id);

                Debug.WriteLine(resp);
            }
        }
        
        private void Search()
        {
            this.DgvStudants.DataSource = Data.SearchStudent(this.TxtSearch.Text);
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            FormLoader.OpenChildForm(new FrmViewStudent(
                Convert.ToInt32(this.DgvStudants.CurrentRow.Cells["idaluno"].Value),
                Convert.ToString(this.DgvStudants.CurrentRow.Cells["nome"].Value)
                ));
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormLoader.OpenChildForm(new FrmAddEditStudent(false, -1,string.Empty, string.Empty));
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FormLoader.OpenChildForm(new FrmAddEditStudent(true,
                Convert.ToInt32(this.DgvStudants.CurrentRow.Cells["idaluno"].Value),
                Convert.ToString(this.DgvStudants.CurrentRow.Cells["nome"].Value),
                Convert.ToString(this.DgvStudants.CurrentRow.Cells["numero"].Value)));
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

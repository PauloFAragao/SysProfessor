using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SysProfessor
{
    public partial class FrmViewStudent : Form
    {
        int id;
        string name;

        public FrmViewStudent(int id, string name)
        {
            InitializeComponent();

            this.id = id;
            this.name = name;

            LoadData();
            HideColumns();
            ChangeColumns();
        }

        public void CallLoadData()
        {
            LoadData();
        }

        private void LoadData()
        {
            this.LblName.Text = this.name;
            this.DgvData.DataSource = Data.GetStudantDiscliplines(id);
        }

        private void HideColumns()
        {
            this.DgvData.Columns[0].Visible = false;
            this.DgvData.Columns[1].Visible = false;
            this.DgvData.Columns[2].Visible = false;
        }

        private void ChangeColumns()
        {
            // Altera o texto do cabeçalho da coluna 3 para "Matéria"
            this.DgvData.Columns[3].HeaderText = "Matéria";
            //this.DgvData.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvData.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Altera o texto do cabeçalho da coluna 4 para "Nota do primeiro trimestre"
            this.DgvData.Columns[4].HeaderText = "Nota do primeiro trimestre";
            this.DgvData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Altera o texto do cabeçalho da coluna 5 para "Nota do segundo trimestre"
            this.DgvData.Columns[5].HeaderText = "Nota do segundo trimestre";
            this.DgvData.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Altera o texto do cabeçalho da coluna 6 para "Nota do terceiro trimestre"
            this.DgvData.Columns[6].HeaderText = "Nota do terceiro trimestre";
            this.DgvData.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Altera o texto do cabeçalho da coluna 7 para "Nota do quarto trimestre"
            this.DgvData.Columns[7].HeaderText = "Nota do quarto trimestre";
            this.DgvData.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Altera o texto do cabeçalho da coluna 8 para "Média"
            this.DgvData.Columns[8].HeaderText = "Média";
            this.DgvData.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Altera o texto do cabeçalho da coluna 9 para "Status"
            this.DgvData.Columns[9].HeaderText = "Status";
            this.DgvData.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void BbnBack_Click(object sender, EventArgs e)
        {
            FormLoader.OpenChildForm(new FrmStudents());
        }

        private void EditScores()
        {
            FrmEditScores frmEditScores = new FrmEditScores(
                Convert.ToInt32(this.DgvData.CurrentRow.Cells["idnotas"].Value),
                name,
                Convert.ToString(this.DgvData.CurrentRow.Cells["disciplineName"].Value),
                Convert.ToDecimal(this.DgvData.CurrentRow.Cells["notapt"].Value),
                Convert.ToDecimal(this.DgvData.CurrentRow.Cells["notast"].Value),
                Convert.ToDecimal(this.DgvData.CurrentRow.Cells["notatt"].Value),
                Convert.ToDecimal(this.DgvData.CurrentRow.Cells["notaqt"].Value),
                Convert.ToDecimal(this.DgvData.CurrentRow.Cells["media"].Value), CallLoadData);

            frmEditScores.ShowDialog();
        }

        private void BtmEdit_Click(object sender, EventArgs e)
        {
            EditScores();
        }
    }
}

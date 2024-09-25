using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace SysProfessor
{
    public partial class FrmViewDiscipline : Form
    {
        int id;
        string disciplineName;
        decimal minimumAverage, classAverage;

        public FrmViewDiscipline(int id, string disciplineName,decimal average)
        {
            InitializeComponent();

            this.id = id;
            this.disciplineName = disciplineName;
            this.minimumAverage = average;

            LoadData();
            HideColumns();
            ChangeColumns();
        }

        private void LoadData()
        {
            DataTable data = Data.GetDiscliplineStudents(id, minimumAverage);

            this.LblName.Text = disciplineName;
            this.LblAverage.Text = Convert.ToString(minimumAverage);

            this.DgvData.DataSource = data;

            //para evitar dar erro no caso de não ter nenhum aluno adiconado
            if (DgvData.Rows.Count > 0)
            {
                CalculateClassAverage(data);
                this.LblClassAverage.Text = classAverage.ToString("F2");//Convert.ToString(classAverage);
            }
            else
                this.LblClassAverage.Text = "0";

            //reorganizando os números
            DgvData.Sort(DgvData.Columns["numero"], System.ComponentModel.ListSortDirection.Ascending);
        }

        public void CallLoadData()
        {
            LoadData();
        }

        private void HideColumns()
        {
            this.DgvData.Columns[0].Visible = false;
            this.DgvData.Columns[1].Visible = false;
            this.DgvData.Columns[2].Visible = false;
        }

        private void ChangeColumns()
        {
            // Altera o texto do cabeçalho da coluna 3 para "Nome do aluno"
            this.DgvData.Columns[3].HeaderText = "Nome do aluno";
            this.DgvData.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Altera o texto do cabeçalho da coluna 4 para "Número da chamada"
            this.DgvData.Columns[4].HeaderText = "Número da chamada";
            this.DgvData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Altera o texto do cabeçalho da coluna 5 para "Nota do primeiro trimestre"
            this.DgvData.Columns[5].HeaderText = "Nota do primeiro trimestre";
            this.DgvData.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Altera o texto do cabeçalho da coluna 6 para "Nota do segundo trimestre"
            this.DgvData.Columns[6].HeaderText = "Nota do segundo trimestre";
            this.DgvData.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Altera o texto do cabeçalho da coluna 7 para "Nota do terceiro trimestre"
            this.DgvData.Columns[7].HeaderText = "Nota do terceiro trimestre";
            this.DgvData.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Altera o texto do cabeçalho da coluna 8 para "Nota do quarto trimestre"
            this.DgvData.Columns[8].HeaderText = "Nota do quarto trimestre";
            this.DgvData.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Altera o texto do cabeçalho da coluna 9 para "Média"
            this.DgvData.Columns[9].HeaderText = "Média";
            this.DgvData.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Altera o texto do cabeçalho da coluna 10 para "Status"
            this.DgvData.Columns[10].HeaderText = "Status";
            this.DgvData.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CalculateClassAverage(DataTable data)
        {
            int qtd = 0;

            foreach(DataRow row in data.Rows)
            {
                decimal value = Convert.ToDecimal(row["media"]);

                //Debug.WriteLine("média da Aluno: " + value);

                classAverage += value;    
                qtd++;
            }

            classAverage /= qtd;

            //Debug.WriteLine("média da turma: " + classAverage);
        }

        private void EditScores()
        {
            if (DgvData.Rows.Count > 0)
            {
                Debug.WriteLine("Tem dados");

                FrmEditScores frmEditScores = new FrmEditScores(
                Convert.ToInt32(this.DgvData.CurrentRow.Cells["idnotas"].Value),
                Convert.ToString(this.DgvData.CurrentRow.Cells["studentName"].Value),
                disciplineName,
                Convert.ToDecimal(this.DgvData.CurrentRow.Cells["notapt"].Value),
                Convert.ToDecimal(this.DgvData.CurrentRow.Cells["notast"].Value),
                Convert.ToDecimal(this.DgvData.CurrentRow.Cells["notatt"].Value),
                Convert.ToDecimal(this.DgvData.CurrentRow.Cells["notaqt"].Value),
                Convert.ToDecimal(this.DgvData.CurrentRow.Cells["media"].Value), CallLoadData);

                frmEditScores.ShowDialog();
            }
            else
            {
                Debug.WriteLine("não tem dados");
            }
        }

        private void Search()
        {
            string searchName = this.TxtSearch.Text;

            DataTable data = Data.GetDisciplineStudentsFilderStudent(id, minimumAverage, searchName);

            this.DgvData.DataSource = data;
        }

        private void BtmEdit_Click(object sender, EventArgs e)
        {
            EditScores();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            FormLoader.OpenChildForm(new FrmDisciplines());
        }
    }
}

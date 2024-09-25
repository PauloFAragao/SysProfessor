using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SysProfessor
{
    public partial class FrmAddEditDiscipline : Form
    {
        bool editMode;//true - modo de edição/false - modo para adicionar
        int id;//id para edição

        public FrmAddEditDiscipline(bool editMode, int id, string name, string average)
        {
            InitializeComponent();

            this.editMode = editMode;

            this.TxtName.Text = name;
            this.TxtAverage.Text = average;
            this.id = id;
        }

        private void ErrorMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool Save()
        {
            string name;
            decimal average;

            //validando o campo nome
            if (!String.IsNullOrWhiteSpace(this.TxtName.Text))
            {
                name = this.TxtName.Text;
            }
            else
            {
                //Debug.WriteLine("Campo nome não preenchido");
                ErrorIcone.SetError(this.TxtName, "Insira o nome");
                ErrorMessage("Campo nome não preenchido", "Campo não preenchido");
                
                return false;
            }

            //validando o campo numero
            if (!String.IsNullOrWhiteSpace(this.TxtAverage.Text))
            {
                if (Decimal.TryParse(this.TxtAverage.Text, out decimal parsedNumber))
                {
                    average = parsedNumber;
                }
                else
                {
                    //Debug.WriteLine("O valor inserido no campo id não pode ser convertido para inteiro!");
                    ErrorIcone.SetError(this.TxtAverage, "Insira um número Decimal");
                    ErrorMessage("Valor invalido! - O valor inserido no campo média não pode ser convertido para decimal!", "Campo preenchido incorretamente");
                    
                    return false;
                }
            }
            else
            {
                //Debug.WriteLine("Campo numero não preenchido");
                ErrorIcone.SetError(this.TxtAverage, "Insira um número Decimal");
                ErrorMessage("Campo média não preenchido", "Campo não preenchido");
                
                return false;
            }

            if (editMode)
                return EditStudant(name, average);

            else
                return InsertNewStudant(name, average);
        }

        private bool InsertNewStudant(string name, decimal average)
        {
            string resp;

            resp = Data.InsertDiscipline(name, average);

            Debug.WriteLine(resp);

            if (resp == "Registro inserido com sucesso.")
            {
                MessageBox.Show(resp, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else 
            {
                ErrorMessage(resp, "ERRO!");
                return false;
            }   
        }

        private bool EditStudant(string name, decimal average)
        {
            string resp;

            resp = Data.EditDiscipline(id, name, average);

            Debug.WriteLine(resp);

            if (resp == "Registro editado com sucesso.")
            {
                MessageBox.Show(resp, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                ErrorMessage(resp, "ERRO!");
                return false;
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            FormLoader.OpenChildForm(new FrmDisciplines());
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FormLoader.OpenChildForm(new FrmDisciplines());
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                FormLoader.OpenChildForm(new FrmDisciplines());
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            ErrorIcone.SetError(TxtName, string.Empty);
        }

        private void TxtAverage_TextChanged(object sender, EventArgs e)
        {
            ErrorIcone.SetError(TxtAverage, string.Empty);
        }
    }
}

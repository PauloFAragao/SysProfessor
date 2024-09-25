using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SysProfessor
{
    public partial class FrmAddEditStudent : Form
    {
        bool editMode;//true - modo de edição/false - modo para adicionar
        int id;//id para edição

        public FrmAddEditStudent(bool editMode, int id, string name, string number)
        {
            InitializeComponent();
            this.editMode = editMode;
            this.TxtName.Text = name;
            this.TxtNumber.Text = number;
            this.id = id;

            Debug.WriteLine("ID: "+id);
        }

        private void ErrorMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool Save()
        {
            string name = "";
            int number = 0;

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
            if (!String.IsNullOrWhiteSpace(this.TxtNumber.Text))
            {
                if (int.TryParse(this.TxtNumber.Text, out int parsedNumber))
                {
                    number = parsedNumber;
                }
                else
                {
                    //Debug.WriteLine("O valor inserido no campo id não pode ser convertido para inteiro!");
                    ErrorIcone.SetError(this.TxtNumber, "Insira um número inteiro");
                    ErrorMessage("Valor invalido! - O valor inserido no campo número não pode ser convertido para inteiro!", "Campo preenchido incorretamente");


                    return false;
                    
                }
            }
            else
            {
                //Debug.WriteLine("Campo numero não preenchido");
                ErrorIcone.SetError(this.TxtNumber, "Insira um número inteiro");
                ErrorMessage("Campo número não preenchido", "Campo não preenchido");

                return false;
            }

            if (editMode)
                return EditStudant(name, number);

            else
                return InsertNewStudant(name, number);

        }

        private bool InsertNewStudant(string name, int number)
        {
            string resp;

            resp = Data.InsertStudant(name, number);

            //Debug.WriteLine(resp);

            if(resp == "Registro inserido com sucesso.")
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

        private bool EditStudant(string name, int number)
        {
            string resp;

            resp = Data.EditStudant(id, name, number);

            //Debug.WriteLine(resp);

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
            FormLoader.OpenChildForm(new FrmStudents());
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FormLoader.OpenChildForm(new FrmStudents());
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(Save())
                FormLoader.OpenChildForm(new FrmStudents());
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            ErrorIcone.SetError(TxtName, string.Empty);
        }

        private void TxtNumber_TextChanged(object sender, EventArgs e)
        {
            ErrorIcone.SetError(TxtNumber, string.Empty);
        }
    }
}

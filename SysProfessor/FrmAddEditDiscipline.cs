using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Debug.WriteLine("Campo nome não preenchido");

                return false;
                //ErrorIcone.SetError(this.TxtName, "Insira o nome");
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
                    Debug.WriteLine("O valor inserido no campo id não pode ser convertido para inteiro!");

                    return false;
                    //ErrorIcone.SetError(this.TxtNome, "Insira um número inteiro");
                }
            }
            else
            {
                Debug.WriteLine("Campo numero não preenchido");

                return false;
                //ErrorIcone.SetError(this.TxtNumber, "Insira o número da chamada");
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
                return true;

            else
                return false;
        }

        private bool EditStudant(string name, decimal average)
        {
            string resp;

            resp = Data.EditDiscipline(id, name, average);

            Debug.WriteLine(resp);

            if (resp == "Registro editado com sucesso.")
                return true;

            else
                return false;
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
    }
}

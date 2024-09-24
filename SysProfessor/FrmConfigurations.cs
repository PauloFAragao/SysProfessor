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
using System.Xml.Linq;

namespace SysProfessor
{
    public partial class FrmConfigurations : Form
    {
        public FrmConfigurations()
        {
            InitializeComponent();

            LoadConfigurations();
        }

        private void LoadConfigurations()
        {
            string[] values = Data.GetConfigurations();

            this.TxtProfessorName.Text = values[0];
            this.TxtSchoolName.Text = values[1];
        }

        private void ErrorMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Save()
        {
            string professorName = "";
            string schollName = "";

            //validando o campo nome do professor
            if (!String.IsNullOrWhiteSpace(this.TxtProfessorName.Text))
            {
                professorName = this.TxtProfessorName.Text;
            }
            else
            {
                //Debug.WriteLine("Campo nome não preenchido");
                ErrorMessage("Campo nome do professor não preenchido", "Campo não preenchido");
                return;
                //ErrorIcone.SetError(this.TxtName, "Insira o nome");
            }

            //validando o campo nome da escola
            if (!String.IsNullOrWhiteSpace(this.TxtSchoolName.Text))
            {
                schollName = this.TxtSchoolName.Text;
            }
            else
            {
                //Debug.WriteLine("Campo nome não preenchido");
                ErrorMessage("Campo nome da escola não preenchido", "Campo não preenchido");
                return;
                //ErrorIcone.SetError(this.TxtName, "Insira o nome");
            }

            //Debug.WriteLine(Data.SetConfigurations(professorName, schollName));

            string resp = Data.SetConfigurations(professorName, schollName);

            MessageBox.Show(resp, resp, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}

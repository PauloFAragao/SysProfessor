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
    public partial class FrmViewDiscipline : Form
    {
        int id;
        public FrmViewDiscipline(int id)
        {
            InitializeComponent();

            this.id = id;

            //temporario
            Debug.WriteLine("ID: "+id);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            FormLoader.OpenChildForm(new FrmDisciplines());
        }
    }
}

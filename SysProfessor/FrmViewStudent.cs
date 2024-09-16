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
    public partial class FrmViewStudent : Form
    {
        int id;

        public FrmViewStudent(int id)
        {
            InitializeComponent();

            this.id = id;

            //temporario
            Debug.WriteLine("ID: " + id);
        }

        private void BbnBack_Click(object sender, EventArgs e)
        {
            FormLoader.OpenChildForm(new FrmStudents());
        }
    }
}

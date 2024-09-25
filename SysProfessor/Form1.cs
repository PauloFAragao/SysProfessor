using System;
using System.Drawing;
using System.Windows.Forms;

namespace SysProfessor
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        
        public Form1()
        {
            InitializeComponent();

            //enviando a referencia do panel para a classe
            FormLoader.PanelBody = this.PanelBody;

            //setando para o programa iniciar com na home
            currentButton = BtnHome;
            FormLoader.OpenChildForm(new FrmHome());
        }
        
        private void ActivateButton(object btnSender)
        {
            if (btnSender != currentButton)
            {
                //resetando o outro botão q estava selecionado
                if (currentButton != null)
                {
                    currentButton.BackColor = Color.FromArgb(106, 162, 117);
                    currentButton.ForeColor = Color.Black;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    currentButton.Padding = new Padding(10, 0, 0, 0);
                }

                //marcando o botão o botão selecionado
                if (currentButton != (Button)btnSender)
                {
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(79, 128, 88);
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    currentButton.Padding = new Padding(25, 0, 0, 0); 
                }
            }
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            FormLoader.OpenChildForm(new FrmHome());
        }

        private void BtnStudent_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            FormLoader.OpenChildForm(new FrmStudents());
        }

        private void BtnDisciplines_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            FormLoader.OpenChildForm(new FrmDisciplines());
        }

        private void BtnConfiguration_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            FormLoader.OpenChildForm(new FrmConfigurations());
        }
    }
}

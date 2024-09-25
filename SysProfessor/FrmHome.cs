﻿using System;
using System.Windows.Forms;

namespace SysProfessor
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();

            LoadConfigurations();
            LoadAmounts();
        }

        private void LoadConfigurations()
        {
            string[] values = Data.GetConfigurations();

            if(values[0] != "")
            {
                this.LblProfessorName.Text = values[0];
                this.LblSchoolName.Text = values[1];
            }
        }

        private void LoadAmounts()
        {
            int[] values = Data.GetAmount();

            this.LblStudentsQuantity.Text = Convert.ToString(values[0]);
            this.LblDisciplineQuantity.Text = Convert.ToString(values[1]);
        }
    }
}

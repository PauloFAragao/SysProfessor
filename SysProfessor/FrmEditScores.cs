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
    public partial class FrmEditScores : Form
    {
        int id;
        decimal sfiq, ssq, stq, sfoq, average;
        private Action _onCloseCallback;

        public FrmEditScores(int id, string studantName, string disciplineName, decimal sfiq, 
                                decimal ssq, decimal stq, decimal sfoq, decimal average, Action onCloseCallback)
        {
            InitializeComponent();

            _onCloseCallback = onCloseCallback;

            this.id = id;
            this.sfiq = sfiq;
            this.ssq = ssq;
            this.stq = stq;
            this.sfoq = sfoq;
            this.average = average;

            this.LblStudantName.Text = studantName;
            this.LblDisciplineName.Text = disciplineName;

            this.TxtSfiq.Text = Convert.ToString(sfiq);
            this.TxtSsq.Text = Convert.ToString(ssq);
            this.TxtStq.Text = Convert.ToString(stq);
            this.TxtSfoq.Text = Convert.ToString(sfoq);

            this.LblAverage.Text = Convert.ToString(average);
        }

        private void CalculateAverage()
        {
            if(ReadFristQuarterScore() &&
               ReadSecondQuarterScore() &&
               ReadThirdQuarterScore() &&
               ReadFourthQuarterScore() )
            {
                average = (sfiq + ssq + stq + sfoq) / 4;

                this.LblAverage.Text = Convert.ToString(average);
            }
            else
            {
                this.LblAverage.Text = "";
            }
        }

        private bool ReadFristQuarterScore()
        {
            //validando o campo numero
            if (!String.IsNullOrWhiteSpace(this.TxtSfiq.Text))
            {
                if ( Decimal.TryParse ( this.TxtSfiq.Text, out decimal value ) )
                {
                    sfiq = value;
                    Debug.WriteLine("Valor: " + sfiq);
                    return true;
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
        }

        private bool ReadSecondQuarterScore()
        {
            //validando o campo numero
            if (!String.IsNullOrWhiteSpace(this.TxtSsq.Text))
            {
                if (Decimal.TryParse(this.TxtSsq.Text, out decimal value))
                {
                    ssq = value;

                    return true;
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
        }

        private bool ReadThirdQuarterScore()
        {
            bool ret = true;
            //validando o campo numero
            if (!String.IsNullOrWhiteSpace(this.TxtStq.Text))
            {
                if (Decimal.TryParse(this.TxtStq.Text, out decimal value))
                {
                    stq = value;

                    return true;
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
        }

        private bool ReadFourthQuarterScore()
        {
            //validando o campo numero
            if (!String.IsNullOrWhiteSpace(this.TxtSfoq.Text))
            {
                if (Decimal.TryParse(this.TxtSfoq.Text, out decimal value))
                {
                    sfoq = value;

                    return true;
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
        }

        private bool Save()
        {
            if (ReadFristQuarterScore() &&
               ReadSecondQuarterScore() &&
               ReadThirdQuarterScore() &&
               ReadFourthQuarterScore())
            {
                Data.EditScores(id, sfiq, ssq, stq, sfoq, average);

                

                return true;
            }
            else return false;
        }

        private void TxtSfiq_TextChanged(object sender, EventArgs e)
        {
            CalculateAverage();
        }

        private void TxtSsq_TextChanged(object sender, EventArgs e)
        {
            CalculateAverage();
        }

        private void FrmEditScores_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onCloseCallback?.Invoke();
        }

        private void TxtStq_TextChanged(object sender, EventArgs e)
        {
            CalculateAverage();
        }

        private void TxtSfoq_TextChanged(object sender, EventArgs e)
        {
            CalculateAverage();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(Save())
                this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
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

            ErrorIcone.SetError(this.TxtSfiq, string.Empty);
            ErrorIcone.SetError(this.TxtSsq, string.Empty);
            ErrorIcone.SetError(this.TxtStq, string.Empty);
            ErrorIcone.SetError(this.TxtSfoq, string.Empty);

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
                    if (value >= 0 && value <= 10)
                    {
                        sfiq = value;

                        return true;
                    }
                    else
                    {
                        //Debug.WriteLine("O valor inserido no campo primeiro trimestre tem que ser maior ou igual a zero e menor ou igual a 10!");
                        ErrorIcone.SetError(this.TxtSfiq, "Insira um número Decimal");
                        return false;
                    }
                }
                else
                {
                    //Debug.WriteLine("O valor inserido no campo primeiro trimestre não pode ser convertido para decimal!");
                    ErrorIcone.SetError(this.TxtSfiq, "Insira um número Decimal");
                    return false;
                }
            }
            else
            {
                //Debug.WriteLine("Campo nota do primeiro trimestre não preenchido");
                ErrorIcone.SetError(this.TxtSfiq, "Insira um número Decimal");
                return false;
            }
        }

        private bool ReadSecondQuarterScore()
        {
            //validando o campo numero
            if (!String.IsNullOrWhiteSpace(this.TxtSsq.Text))
            {
                if (Decimal.TryParse(this.TxtSsq.Text, out decimal value))
                {
                    if (value >= 0 && value <= 10)
                    {
                        ssq = value;

                        return true;
                    }
                    else
                    {
                        //Debug.WriteLine("O valor inserido no campo segundo trimestre tem que ser maior ou igual a zero e menor ou igual a 10!");
                        ErrorIcone.SetError(this.TxtSfiq, "Insira um número Decimal");
                        return false;
                    }
                }
                else
                {
                    //Debug.WriteLine("O valor inserido no campo segundo trimestre não pode ser convertido para decimal!");
                    ErrorIcone.SetError(this.TxtSfiq, "Insira um número Decimal");
                    return false;
                }
            }
            else
            {
                //Debug.WriteLine("Campo segundo trimestre não preenchido"); 
                ErrorIcone.SetError(this.TxtSfiq, "Insira um número Decimal");
                return false;
            }
        }

        private bool ReadThirdQuarterScore()
        {
            //validando o campo numero
            if (!String.IsNullOrWhiteSpace(this.TxtStq.Text))
            {
                if (Decimal.TryParse(this.TxtStq.Text, out decimal value))
                {
                    if (value >= 0 && value <= 10)
                    {
                        stq = value;

                        return true;
                    }
                    else
                    {
                        //Debug.WriteLine("O valor inserido no campo terceiro trimestre tem que ser maior ou igual a zero e menor ou igual a 10!");
                        ErrorIcone.SetError(this.TxtSfiq, "Insira um número Decimal");
                        return false;
                    }
                }
                else
                {
                    //Debug.WriteLine("O valor inserido no campo terceiro trimestre não pode ser convertido para decimal!");
                    ErrorIcone.SetError(this.TxtSfiq, "Insira um número Decimal");
                    return false;
                }
            }
            else
            {
                //Debug.WriteLine("Campo terceiro trimestre não preenchido");
                ErrorIcone.SetError(this.TxtSfiq, "Insira um número Decimal");
                return false;
            }
        }

        private bool ReadFourthQuarterScore()
        {
            //validando o campo numero
            if (!String.IsNullOrWhiteSpace(this.TxtSfoq.Text))
            {
                if (Decimal.TryParse(this.TxtSfoq.Text, out decimal value))
                {
                    if (value >= 0 && value <= 10)
                    {
                        sfoq = value;

                        return true;
                    }
                    else
                    {
                        //Debug.WriteLine("O valor inserido no campo terceiro trimestre tem que ser maior ou igual a zero e menor ou igual a 10!");
                        ErrorIcone.SetError(this.TxtSfiq, "Insira um número Decimal");
                        return false;
                    }
                }
                else
                {
                    //Debug.WriteLine("O valor inserido no campo quarto trimestre não pode ser convertido para decimal!");
                    ErrorIcone.SetError(this.TxtSfiq, "Insira um número Decimal");
                    return false;
                }
            }
            else
            {
                //Debug.WriteLine("Campo quarto trimestre não preenchido");
                ErrorIcone.SetError(this.TxtSfiq, "Insira um número Decimal");
                return false;
            }
        }

        private bool Save()
        {
            if (ReadFristQuarterScore() &&
               ReadSecondQuarterScore() &&
               ReadThirdQuarterScore() &&
               ReadFourthQuarterScore())
            {
                string resp = Data.EditScores(id, sfiq, ssq, stq, sfoq, average);

                MessageBox.Show(resp, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            else
            {
                MessageBox.Show("Todos os campos tem que ser preenchidos corretamente! (números decimais entre 0 e 10) ", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void TxtSfiq_TextChanged(object sender, EventArgs e)
        {
            ErrorIcone.SetError(this.TxtSfiq, string.Empty);
            CalculateAverage();
        }

        private void TxtSsq_TextChanged(object sender, EventArgs e)
        {
            ErrorIcone.SetError(this.TxtSsq, string.Empty);
            CalculateAverage();
        }

        private void TxtStq_TextChanged(object sender, EventArgs e)
        {
            ErrorIcone.SetError(this.TxtStq, string.Empty);
            CalculateAverage();
        }

        private void TxtSfoq_TextChanged(object sender, EventArgs e)
        {
            ErrorIcone.SetError(this.TxtSfoq, string.Empty);
            CalculateAverage();
        }

        private void FrmEditScores_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onCloseCallback?.Invoke();
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

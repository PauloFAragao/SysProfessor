namespace SysProfessor
{
    partial class FrmEditScores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtSfiq = new System.Windows.Forms.TextBox();
            this.TxtSsq = new System.Windows.Forms.TextBox();
            this.TxtStq = new System.Windows.Forms.TextBox();
            this.TxtSfoq = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LblAverage = new System.Windows.Forms.Label();
            this.LblStudantName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblDisciplineName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ErrorIcone = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorIcone)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(26, 228);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 25);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "Salvar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nota do primeiro trimestre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nota do primeiro trimestre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nota do primeiro trimestre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nota do primeiro trimestre:";
            // 
            // TxtSfiq
            // 
            this.TxtSfiq.Location = new System.Drawing.Point(147, 78);
            this.TxtSfiq.Name = "TxtSfiq";
            this.TxtSfiq.Size = new System.Drawing.Size(100, 20);
            this.TxtSfiq.TabIndex = 5;
            this.TxtSfiq.TextChanged += new System.EventHandler(this.TxtSfiq_TextChanged);
            // 
            // TxtSsq
            // 
            this.TxtSsq.Location = new System.Drawing.Point(147, 104);
            this.TxtSsq.Name = "TxtSsq";
            this.TxtSsq.Size = new System.Drawing.Size(100, 20);
            this.TxtSsq.TabIndex = 6;
            this.TxtSsq.TextChanged += new System.EventHandler(this.TxtSsq_TextChanged);
            // 
            // TxtStq
            // 
            this.TxtStq.Location = new System.Drawing.Point(147, 131);
            this.TxtStq.Name = "TxtStq";
            this.TxtStq.Size = new System.Drawing.Size(100, 20);
            this.TxtStq.TabIndex = 7;
            this.TxtStq.TextChanged += new System.EventHandler(this.TxtStq_TextChanged);
            // 
            // TxtSfoq
            // 
            this.TxtSfoq.Location = new System.Drawing.Point(147, 157);
            this.TxtSfoq.Name = "TxtSfoq";
            this.TxtSfoq.Size = new System.Drawing.Size(100, 20);
            this.TxtSfoq.TabIndex = 8;
            this.TxtSfoq.TextChanged += new System.EventHandler(this.TxtSfoq_TextChanged);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(194, 228);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 25);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Média: ";
            // 
            // LblAverage
            // 
            this.LblAverage.AutoSize = true;
            this.LblAverage.Location = new System.Drawing.Point(151, 196);
            this.LblAverage.Name = "LblAverage";
            this.LblAverage.Size = new System.Drawing.Size(13, 13);
            this.LblAverage.TabIndex = 11;
            this.LblAverage.Text = "0";
            // 
            // LblStudantName
            // 
            this.LblStudantName.AutoSize = true;
            this.LblStudantName.Location = new System.Drawing.Point(144, 23);
            this.LblStudantName.Name = "LblStudantName";
            this.LblStudantName.Size = new System.Drawing.Size(59, 13);
            this.LblStudantName.TabIndex = 13;
            this.LblStudantName.Text = "Sem Nome";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Nome do aluno:";
            // 
            // LblDisciplineName
            // 
            this.LblDisciplineName.AutoSize = true;
            this.LblDisciplineName.Location = new System.Drawing.Point(144, 48);
            this.LblDisciplineName.Name = "LblDisciplineName";
            this.LblDisciplineName.Size = new System.Drawing.Size(59, 13);
            this.LblDisciplineName.TabIndex = 15;
            this.LblDisciplineName.Text = "Sem Nome";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Nome da Matéria:";
            // 
            // ErrorIcone
            // 
            this.ErrorIcone.BlinkRate = 0;
            this.ErrorIcone.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorIcone.ContainerControl = this;
            // 
            // FrmEditScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 282);
            this.Controls.Add(this.LblDisciplineName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LblStudantName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LblAverage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.TxtSfoq);
            this.Controls.Add(this.TxtStq);
            this.Controls.Add(this.TxtSsq);
            this.Controls.Add(this.TxtSfiq);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSave);
            this.Name = "FrmEditScores";
            this.Text = "Editar Notas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEditScores_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorIcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtSfiq;
        private System.Windows.Forms.TextBox TxtSsq;
        private System.Windows.Forms.TextBox TxtStq;
        private System.Windows.Forms.TextBox TxtSfoq;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblAverage;
        private System.Windows.Forms.Label LblStudantName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblDisciplineName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider ErrorIcone;
    }
}
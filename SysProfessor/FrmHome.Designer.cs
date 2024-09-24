namespace SysProfessor
{
    partial class FrmHome
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblProfessorName = new System.Windows.Forms.Label();
            this.LblSchoolName = new System.Windows.Forms.Label();
            this.LblStudentsQuantity = new System.Windows.Forms.Label();
            this.LblDisciplineQuantity = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do professor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome da Escola:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantidade de Alunos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Materias:";
            // 
            // LblProfessorName
            // 
            this.LblProfessorName.AutoSize = true;
            this.LblProfessorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProfessorName.Location = new System.Drawing.Point(165, 33);
            this.LblProfessorName.Name = "LblProfessorName";
            this.LblProfessorName.Size = new System.Drawing.Size(181, 16);
            this.LblProfessorName.TabIndex = 4;
            this.LblProfessorName.Text = "Nome ainda não configurado";
            // 
            // LblSchoolName
            // 
            this.LblSchoolName.AutoSize = true;
            this.LblSchoolName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSchoolName.Location = new System.Drawing.Point(150, 62);
            this.LblSchoolName.Name = "LblSchoolName";
            this.LblSchoolName.Size = new System.Drawing.Size(181, 16);
            this.LblSchoolName.TabIndex = 5;
            this.LblSchoolName.Text = "Nome ainda não configurado";
            // 
            // LblStudentsQuantity
            // 
            this.LblStudentsQuantity.AutoSize = true;
            this.LblStudentsQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStudentsQuantity.Location = new System.Drawing.Point(182, 93);
            this.LblStudentsQuantity.Name = "LblStudentsQuantity";
            this.LblStudentsQuantity.Size = new System.Drawing.Size(14, 16);
            this.LblStudentsQuantity.TabIndex = 6;
            this.LblStudentsQuantity.Text = "0";
            // 
            // LblDisciplineQuantity
            // 
            this.LblDisciplineQuantity.AutoSize = true;
            this.LblDisciplineQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDisciplineQuantity.Location = new System.Drawing.Point(101, 121);
            this.LblDisciplineQuantity.Name = "LblDisciplineQuantity";
            this.LblDisciplineQuantity.Size = new System.Drawing.Size(14, 16);
            this.LblDisciplineQuantity.TabIndex = 7;
            this.LblDisciplineQuantity.Text = "0";
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblDisciplineQuantity);
            this.Controls.Add(this.LblStudentsQuantity);
            this.Controls.Add(this.LblSchoolName);
            this.Controls.Add(this.LblProfessorName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmHome";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblProfessorName;
        private System.Windows.Forms.Label LblSchoolName;
        private System.Windows.Forms.Label LblStudentsQuantity;
        private System.Windows.Forms.Label LblDisciplineQuantity;
    }
}
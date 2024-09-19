namespace SysProfessor
{
    partial class FrmViewDiscipline
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
            this.DgvData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtmEdit = new System.Windows.Forms.Button();
            this.LblClassAverage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.LblAverage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.BtnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvData
            // 
            this.DgvData.AllowUserToAddRows = false;
            this.DgvData.AllowUserToDeleteRows = false;
            this.DgvData.AllowUserToOrderColumns = true;
            this.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvData.Location = new System.Drawing.Point(0, 68);
            this.DgvData.Name = "DgvData";
            this.DgvData.ReadOnly = true;
            this.DgvData.Size = new System.Drawing.Size(740, 443);
            this.DgvData.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtmEdit);
            this.panel1.Controls.Add(this.LblClassAverage);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LblName);
            this.panel1.Controls.Add(this.LblAverage);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtSearch);
            this.panel1.Controls.Add(this.BtnBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 68);
            this.panel1.TabIndex = 11;
            // 
            // BtmEdit
            // 
            this.BtmEdit.Location = new System.Drawing.Point(599, 31);
            this.BtmEdit.Name = "BtmEdit";
            this.BtmEdit.Size = new System.Drawing.Size(79, 23);
            this.BtmEdit.TabIndex = 15;
            this.BtmEdit.Text = "Editar Notas";
            this.BtmEdit.UseVisualStyleBackColor = true;
            this.BtmEdit.Click += new System.EventHandler(this.BtmEdit_Click);
            // 
            // LblClassAverage
            // 
            this.LblClassAverage.AutoSize = true;
            this.LblClassAverage.Location = new System.Drawing.Point(410, 41);
            this.LblClassAverage.Name = "LblClassAverage";
            this.LblClassAverage.Size = new System.Drawing.Size(13, 13);
            this.LblClassAverage.TabIndex = 14;
            this.LblClassAverage.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Média da turma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nome da Matéria:";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(317, 15);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(42, 13);
            this.LblName.TabIndex = 11;
            this.LblName.Text = "Matéria";
            // 
            // LblAverage
            // 
            this.LblAverage.AutoSize = true;
            this.LblAverage.Location = new System.Drawing.Point(554, 14);
            this.LblAverage.Name = "LblAverage";
            this.LblAverage.Size = new System.Drawing.Size(13, 13);
            this.LblAverage.TabIndex = 9;
            this.LblAverage.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Média mínima para aprovação:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar:";
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(95, 38);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(188, 20);
            this.TxtSearch.TabIndex = 5;
            // 
            // BtnBack
            // 
            this.BtnBack.Location = new System.Drawing.Point(5, 5);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(75, 23);
            this.BtnBack.TabIndex = 4;
            this.BtnBack.Text = "< Voltar";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // FrmViewDiscipline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 511);
            this.Controls.Add(this.DgvData);
            this.Controls.Add(this.panel1);
            this.Name = "FrmViewDiscipline";
            this.Text = "FrmViewDiscipline";
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblAverage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblClassAverage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtmEdit;
    }
}
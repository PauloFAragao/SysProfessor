namespace SysProfessor
{
    partial class FrmViewStudent
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.BtmEdit = new System.Windows.Forms.Button();
            this.BbnBack = new System.Windows.Forms.Button();
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
            this.DgvData.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar:";
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(63, 38);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(188, 20);
            this.TxtSearch.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LblName);
            this.panel1.Controls.Add(this.BtmEdit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtSearch);
            this.panel1.Controls.Add(this.BbnBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 68);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nome do Aluno:";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(355, 16);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(34, 13);
            this.LblName.TabIndex = 8;
            this.LblName.Text = "Aluno";
            // 
            // BtmEdit
            // 
            this.BtmEdit.Location = new System.Drawing.Point(570, 31);
            this.BtmEdit.Name = "BtmEdit";
            this.BtmEdit.Size = new System.Drawing.Size(79, 23);
            this.BtmEdit.TabIndex = 7;
            this.BtmEdit.Text = "Editar Notas";
            this.BtmEdit.UseVisualStyleBackColor = true;
            this.BtmEdit.Click += new System.EventHandler(this.BtmEdit_Click);
            // 
            // BbnBack
            // 
            this.BbnBack.Location = new System.Drawing.Point(6, 6);
            this.BbnBack.Name = "BbnBack";
            this.BbnBack.Size = new System.Drawing.Size(75, 23);
            this.BbnBack.TabIndex = 4;
            this.BbnBack.Text = "< Voltar";
            this.BbnBack.UseVisualStyleBackColor = true;
            this.BbnBack.Click += new System.EventHandler(this.BbnBack_Click);
            // 
            // FrmViewStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 511);
            this.Controls.Add(this.DgvData);
            this.Controls.Add(this.panel1);
            this.Name = "FrmViewStudent";
            this.Text = "FrmViewStudent";
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BbnBack;
        private System.Windows.Forms.Button BtmEdit;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label label2;
    }
}
namespace SysProfessor
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.BtnConfiguration = new System.Windows.Forms.Button();
            this.BtnDisciplines = new System.Windows.Forms.Button();
            this.BtnStudent = new System.Windows.Forms.Button();
            this.BtnHome = new System.Windows.Forms.Button();
            this.PanelBody = new System.Windows.Forms.Panel();
            this.PanelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(162)))), ((int)(((byte)(117)))));
            this.PanelMenu.Controls.Add(this.BtnConfiguration);
            this.PanelMenu.Controls.Add(this.BtnDisciplines);
            this.PanelMenu.Controls.Add(this.BtnStudent);
            this.PanelMenu.Controls.Add(this.BtnHome);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.PanelMenu.Size = new System.Drawing.Size(200, 550);
            this.PanelMenu.TabIndex = 0;
            // 
            // BtnConfiguration
            // 
            this.BtnConfiguration.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnConfiguration.FlatAppearance.BorderSize = 0;
            this.BtnConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfiguration.Location = new System.Drawing.Point(0, 175);
            this.BtnConfiguration.Name = "BtnConfiguration";
            this.BtnConfiguration.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnConfiguration.Size = new System.Drawing.Size(200, 55);
            this.BtnConfiguration.TabIndex = 3;
            this.BtnConfiguration.Text = "Configurações";
            this.BtnConfiguration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConfiguration.UseVisualStyleBackColor = true;
            this.BtnConfiguration.Click += new System.EventHandler(this.BtnConfiguration_Click);
            // 
            // BtnDisciplines
            // 
            this.BtnDisciplines.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnDisciplines.FlatAppearance.BorderSize = 0;
            this.BtnDisciplines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDisciplines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDisciplines.Location = new System.Drawing.Point(0, 120);
            this.BtnDisciplines.Name = "BtnDisciplines";
            this.BtnDisciplines.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnDisciplines.Size = new System.Drawing.Size(200, 55);
            this.BtnDisciplines.TabIndex = 2;
            this.BtnDisciplines.Text = "Diciplinas";
            this.BtnDisciplines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDisciplines.UseVisualStyleBackColor = true;
            this.BtnDisciplines.Click += new System.EventHandler(this.BtnDisciplines_Click);
            // 
            // BtnStudent
            // 
            this.BtnStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnStudent.FlatAppearance.BorderSize = 0;
            this.BtnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStudent.Location = new System.Drawing.Point(0, 65);
            this.BtnStudent.Name = "BtnStudent";
            this.BtnStudent.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnStudent.Size = new System.Drawing.Size(200, 55);
            this.BtnStudent.TabIndex = 1;
            this.BtnStudent.Text = "Alunos";
            this.BtnStudent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnStudent.UseVisualStyleBackColor = true;
            this.BtnStudent.Click += new System.EventHandler(this.BtnStudent_Click);
            // 
            // BtnHome
            // 
            this.BtnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(128)))), ((int)(((byte)(88)))));
            this.BtnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnHome.FlatAppearance.BorderSize = 0;
            this.BtnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnHome.Location = new System.Drawing.Point(0, 10);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.BtnHome.Size = new System.Drawing.Size(200, 55);
            this.BtnHome.TabIndex = 0;
            this.BtnHome.Text = "Início";
            this.BtnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHome.UseVisualStyleBackColor = false;
            this.BtnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // PanelBody
            // 
            this.PanelBody.BackColor = System.Drawing.Color.LightGray;
            this.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBody.Location = new System.Drawing.Point(200, 0);
            this.PanelBody.Name = "PanelBody";
            this.PanelBody.Size = new System.Drawing.Size(756, 550);
            this.PanelBody.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 550);
            this.Controls.Add(this.PanelBody);
            this.Controls.Add(this.PanelMenu);
            this.MinimumSize = new System.Drawing.Size(972, 589);
            this.Name = "Form1";
            this.Text = "Systema Professor";
            this.PanelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Panel PanelBody;
        private System.Windows.Forms.Button BtnConfiguration;
        private System.Windows.Forms.Button BtnDisciplines;
        private System.Windows.Forms.Button BtnStudent;
        private System.Windows.Forms.Button BtnHome;
    }
}


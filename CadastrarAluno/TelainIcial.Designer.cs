namespace UI
{
    partial class TelaInicial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_cadastrar = new Button();
            btn_editar = new Button();
            btn_deletar = new Button();
            dataGridLista = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridLista).BeginInit();
            SuspendLayout();
            // 
            // btn_cadastrar
            // 
            btn_cadastrar.Location = new Point(413, 307);
            btn_cadastrar.Name = "btn_cadastrar";
            btn_cadastrar.Size = new Size(75, 23);
            btn_cadastrar.TabIndex = 0;
            btn_cadastrar.Text = "Cadastrar";
            btn_cadastrar.UseVisualStyleBackColor = true;
            btn_cadastrar.Click += AoClicarAbreTelaDeCadastro;
            // 
            // btn_editar
            // 
            btn_editar.Location = new Point(494, 307);
            btn_editar.Name = "btn_editar";
            btn_editar.Size = new Size(75, 23);
            btn_editar.TabIndex = 1;
            btn_editar.Text = "Editar";
            btn_editar.UseVisualStyleBackColor = true;
            btn_editar.Click += AoClicarEditar;
            // 
            // btn_deletar
            // 
            btn_deletar.Location = new Point(575, 307);
            btn_deletar.Name = "btn_deletar";
            btn_deletar.Size = new Size(75, 23);
            btn_deletar.TabIndex = 2;
            btn_deletar.Text = "Remover";
            btn_deletar.UseVisualStyleBackColor = true;
            btn_deletar.Click += AoClicarRemover;
            // 
            // dataGridLista
            // 
            dataGridLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridLista.Location = new Point(1, 2);
            dataGridLista.MultiSelect = false;
            dataGridLista.Name = "dataGridLista";
            dataGridLista.RowTemplate.Height = 25;
            dataGridLista.ShowCellErrors = false;
            dataGridLista.ShowRowErrors = false;
            dataGridLista.Size = new Size(662, 299);
            dataGridLista.TabIndex = 3;
            //dataGridLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      
            // 
            // TelaInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 340);
            Controls.Add(dataGridLista);
            Controls.Add(btn_deletar);
            Controls.Add(btn_editar);
            Controls.Add(btn_cadastrar);
            Name = "TelaInicial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alunos";
            ((System.ComponentModel.ISupportInitialize)dataGridLista).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_cadastrar;
        private Button btn_editar;
        private Button btn_deletar;
        private DataGridView dataGridLista;
    }
}
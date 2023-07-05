namespace UI
{
    partial class TelaCadastro
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
            lbl_nome = new Label();
            lbl_cpf = new Label();
            lbl_telefone = new Label();
            lbl_data_nascimento = new Label();
            tb_nome_aluno = new TextBox();
            btn_cadastrar_aluno = new Button();
            button2 = new Button();
            mtb_telefone = new MaskedTextBox();
            mtb_cpf = new MaskedTextBox();
            fontDialog1 = new FontDialog();
            dtp_data_nascimento = new DateTimePicker();
            SuspendLayout();
            // 
            // lbl_nome
            // 
            lbl_nome.AutoSize = true;
            lbl_nome.Location = new Point(26, 30);
            lbl_nome.Name = "lbl_nome";
            lbl_nome.Size = new Size(40, 15);
            lbl_nome.TabIndex = 0;
            lbl_nome.Text = "Nome";
            // 
            // lbl_cpf
            // 
            lbl_cpf.AutoSize = true;
            lbl_cpf.Location = new Point(26, 87);
            lbl_cpf.Name = "lbl_cpf";
            lbl_cpf.Size = new Size(26, 15);
            lbl_cpf.TabIndex = 1;
            lbl_cpf.Text = "Cpf";
            // 
            // lbl_telefone
            // 
            lbl_telefone.AutoSize = true;
            lbl_telefone.Location = new Point(26, 145);
            lbl_telefone.Name = "lbl_telefone";
            lbl_telefone.Size = new Size(51, 15);
            lbl_telefone.TabIndex = 2;
            lbl_telefone.Text = "Telefone";
            // 
            // lbl_data_nascimento
            // 
            lbl_data_nascimento.AutoSize = true;
            lbl_data_nascimento.Location = new Point(26, 201);
            lbl_data_nascimento.Name = "lbl_data_nascimento";
            lbl_data_nascimento.Size = new Size(114, 15);
            lbl_data_nascimento.TabIndex = 3;
            lbl_data_nascimento.Text = "Data de Nascimento";
            // 
            // tb_nome_aluno
            // 
            tb_nome_aluno.Location = new Point(26, 48);
            tb_nome_aluno.Name = "tb_nome_aluno";
            tb_nome_aluno.Size = new Size(318, 23);
            tb_nome_aluno.TabIndex = 1;
            // 
            // btn_cadastrar_aluno
            // 
            btn_cadastrar_aluno.Location = new Point(26, 401);
            btn_cadastrar_aluno.Name = "btn_cadastrar_aluno";
            btn_cadastrar_aluno.Size = new Size(75, 23);
            btn_cadastrar_aluno.TabIndex = 5;
            btn_cadastrar_aluno.Text = "Salvar";
            btn_cadastrar_aluno.UseVisualStyleBackColor = true;
            btn_cadastrar_aluno.Click += AoClicarSalvar;
            // 
            // button2
            // 
            button2.Location = new Point(269, 401);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += CancelarFormularioCadastro;
            // 
            // mtb_telefone
            // 
            mtb_telefone.Location = new Point(26, 167);
            mtb_telefone.Mask = "(99) 00000-0000";
            mtb_telefone.Name = "mtb_telefone";
            mtb_telefone.Size = new Size(319, 23);
            mtb_telefone.TabIndex = 3;
            mtb_telefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // mtb_cpf
            // 
            mtb_cpf.Location = new Point(26, 108);
            mtb_cpf.Mask = "000,000,000-00";
            mtb_cpf.Name = "mtb_cpf";
            mtb_cpf.Size = new Size(318, 23);
            mtb_cpf.TabIndex = 2;
            mtb_cpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // dtp_data_nascimento
            // 
            dtp_data_nascimento.Format = DateTimePickerFormat.Short;
            dtp_data_nascimento.Location = new Point(26, 231);
            dtp_data_nascimento.Name = "dtp_data_nascimento";
            dtp_data_nascimento.Size = new Size(318, 23);
            dtp_data_nascimento.TabIndex = 4;
            // 
            // TelaCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 450);
            Controls.Add(dtp_data_nascimento);
            Controls.Add(mtb_cpf);
            Controls.Add(mtb_telefone);
            Controls.Add(button2);
            Controls.Add(btn_cadastrar_aluno);
            Controls.Add(tb_nome_aluno);
            Controls.Add(lbl_data_nascimento);
            Controls.Add(lbl_telefone);
            Controls.Add(lbl_cpf);
            Controls.Add(lbl_nome);
            Name = "TelaCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro";
            Load += TelaCadastro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_nome;
        private Label lbl_cpf;
        private Label lbl_telefone;
        private Label lbl_data_nascimento;
        private TextBox tb_nome_aluno;
        private Button btn_cadastrar_aluno;
        private Button button2;
        private MaskedTextBox mtb_telefone;
        private MaskedTextBox mtb_cpf;
        private FontDialog fontDialog1;
        private DateTimePicker dtp_data_nascimento;
    }
}
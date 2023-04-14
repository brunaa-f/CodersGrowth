namespace CadastrarAluno
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
            label1=new Label();
            label2=new Label();
            label3=new Label();
            label4=new Label();
            textBox1=new TextBox();
            textBox2=new TextBox();
            textBox3=new TextBox();
            dateTimePicker1=new DateTimePicker();
            btn_cadastrar_aluno=new Button();
            button2=new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(26, 30);
            label1.Name="label1";
            label1.Size=new Size(40, 15);
            label1.TabIndex=0;
            label1.Text="Nome";
            label1.Click+=lbl_nome;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(26, 87);
            label2.Name="label2";
            label2.Size=new Size(26, 15);
            label2.TabIndex=1;
            label2.Text="Cpf";
            label2.Click+=lbl_cpf;
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(26, 145);
            label3.Name="label3";
            label3.Size=new Size(51, 15);
            label3.TabIndex=2;
            label3.Text="Telefone";
            label3.Click+=lbl_telefone;
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(26, 201);
            label4.Name="label4";
            label4.Size=new Size(114, 15);
            label4.TabIndex=3;
            label4.Text="Data de Nascimento";
            label4.Click+=lbl_data_nascimento;
            // 
            // textBox1
            // 
            textBox1.Location=new Point(26, 48);
            textBox1.Name="textBox1";
            textBox1.Size=new Size(318, 23);
            textBox1.TabIndex=4;
            textBox1.TextChanged+=tb_nome;
            // 
            // textBox2
            // 
            textBox2.Location=new Point(26, 106);
            textBox2.Name="textBox2";
            textBox2.Size=new Size(318, 23);
            textBox2.TabIndex=5;
            textBox2.TextChanged+=tb_cpf;
            // 
            // textBox3
            // 
            textBox3.Location=new Point(26, 164);
            textBox3.Name="textBox3";
            textBox3.Size=new Size(318, 23);
            textBox3.TabIndex=6;
            textBox3.TextChanged+=tb_telefone;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location=new Point(26, 221);
            dateTimePicker1.Name="dateTimePicker1";
            dateTimePicker1.Size=new Size(318, 23);
            dateTimePicker1.TabIndex=7;
            dateTimePicker1.ValueChanged+=dtp_data_nascimento;
            // 
            // btn_cadastrar_aluno
            // 
            btn_cadastrar_aluno.Location=new Point(26, 401);
            btn_cadastrar_aluno.Name="btn_cadastrar_aluno";
            btn_cadastrar_aluno.Size=new Size(114, 23);
            btn_cadastrar_aluno.TabIndex=8;
            btn_cadastrar_aluno.Text="Cadastrar Aluno";
            btn_cadastrar_aluno.UseVisualStyleBackColor=true;
            btn_cadastrar_aluno.Click+=SubmitFormularioCadastro;
            // 
            // button2
            // 
            button2.Location=new Point(269, 401);
            button2.Name="button2";
            button2.Size=new Size(75, 23);
            button2.TabIndex=9;
            button2.Text="Cancelar";
            button2.UseVisualStyleBackColor=true;
            button2.Click+=CancelarFormularioCadastro;
            // 
            // TelaCadastro
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(371, 450);
            Controls.Add(button2);
            Controls.Add(btn_cadastrar_aluno);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name="TelaCadastro";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Form2";
            Load+=TelaCadastro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
        private Button btn_cadastrar_aluno;
        private Button button2;
    }
}
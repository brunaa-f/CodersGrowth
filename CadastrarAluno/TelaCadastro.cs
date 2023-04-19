using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastrarAluno
{
    public partial class TelaCadastro : Form
    {

        private List<Aluno> Alunos;
        public TelaCadastro(List<Aluno> alunos)
        {
            InitializeComponent();
            Alunos = alunos;
        }

        private void TelaCadastro_Load(object sender, EventArgs e)
        {

        }

        private void SubmitFormularioCadastro(object sender, EventArgs e)

        {
            if (ValidarForm())
            {
                Aluno novoAluno = new Aluno();
                novoAluno.NomeAluno = tb_nome_aluno.Text;
                novoAluno.Cpf = mtb_cpf.Text;
                novoAluno.Telefone = mtb_telefone.Text;
                novoAluno.DataNascimento = Convert.ToDateTime(dtp_data_nascimento.Text);
                Alunos.Add(novoAluno);
                Close();    
                MessageBox.Show("Usuário Cadastrado com sucesso!");   
            } 
        }

        private bool ValidarForm()
        {
            if (String.IsNullOrWhiteSpace(tb_nome_aluno.Text))
            {
                MessageBox.Show("O campo NOME deve ser preenchido!");
                tb_nome_aluno.Focus();
                return false;
            }
            else if (!mtb_cpf.MaskCompleted)
            {
                MessageBox.Show("O campo CPF deve ser preenchido!");
                mtb_cpf.Focus();
                return false;
            }
            else if (!mtb_telefone.MaskCompleted)
            {
                MessageBox.Show("O campo Telefone deve ser preenchido!");
                mtb_telefone.Focus();
                return false;
            }
            else if (dtp_data_nascimento.Text == "")
            {
                MessageBox.Show("O campo Data de Nascimento deve ser preenchido!");
                mtb_cpf.Focus();
                return false;
            }
            return true;

        }

        private void CancelarFormularioCadastro(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void mtb_cpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}

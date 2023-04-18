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

        Aluno aluno = new Aluno(1, "bruna", "70416149138", "62992820061", DateTime.Now);
        private List <Aluno> Alunos;
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
            Aluno novoAluno = new Aluno();
            novoAluno.NomeAluno = tb_nome_aluno.Text;
            novoAluno.Cpf = mtb_cpf.Text;
            novoAluno.Telefone = mtb_telefone.Text;
            novoAluno.DataNascimento = Convert.ToDateTime(mtb_data_nascimento.Text);
              
            Alunos.Add(novoAluno);
            DialogResult = DialogResult.OK;
        }
        private void CancelarFormularioCadastro(object sender, EventArgs e)
        {

        }
    }
}

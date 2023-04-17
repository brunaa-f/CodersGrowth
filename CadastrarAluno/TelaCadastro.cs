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

        public TelaCadastro()
        {
            InitializeComponent();
        }

        private void TelaCadastro_Load(object sender, EventArgs e)
        {

        }

        private void SubmitFormularioCadastro(object sender, EventArgs e)

        {
            aluno.NomeAluno = tb_nome_aluno.Text;
            aluno.Cpf = mtb_cpf.Text;
            aluno.Telefone = mtb_telefone.Text;
            aluno.DataNascimento = Convert.ToDateTime(mtb_data_nascimento.Text);
              
         
            DialogResult = DialogResult.OK;
        }
        private void CancelarFormularioCadastro(object sender, EventArgs e)
        {

        }
    }
}

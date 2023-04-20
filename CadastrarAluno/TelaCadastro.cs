using CadastrarAluno.Services;

namespace CadastrarAluno
{
    public partial class TelaCadastro : Form
    {
        private int idIncremental;
        public Aluno _novoAluno;

        public TelaCadastro(Aluno alunos, int id)
        {
            InitializeComponent();

            //criar um novo aluno
            if (alunos == null)
            {
                _novoAluno = new Aluno();
                idIncremental = id;
            }
        }
        private void aoClicarCadastrarNovoAluno(object sender, EventArgs e)

        {
            try
            {
                _novoAluno.Id = NovoId();
                _novoAluno.NomeAluno = tb_nome_aluno.Text;
                _novoAluno.Cpf = mtb_cpf.Text;
                _novoAluno.Telefone = mtb_telefone.Text;
                _novoAluno.DataNascimento = Convert.ToDateTime(dtp_data_nascimento.Text);

                ValidarForm.Valida(_novoAluno);
                DialogResult = DialogResult.OK;
                MessageBox.Show("Usuário Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void CancelarFormularioCadastro(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private int NovoId()
        {
            return ++idIncremental;
        }

    }
}
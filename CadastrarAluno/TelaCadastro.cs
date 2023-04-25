using CadastrarAluno.Servicos;

namespace CadastrarAluno
{
    public partial class TelaCadastro : Form
    {
        public Aluno _novoAluno;

        public TelaCadastro(Aluno alunos)
        {
            InitializeComponent();

            if (alunos == null)
            {
                _novoAluno = new Aluno();
            }
        }
        private void aoClicarCadastrarNovoAluno(object sender, EventArgs e)

        {
            try
            {
                _novoAluno.NomeAluno = tb_nome_aluno.Text;
                _novoAluno.Cpf = mtb_cpf.Text;
                _novoAluno.Telefone = mtb_telefone.Text;
                _novoAluno.DataNascimento = Convert.ToDateTime(dtp_data_nascimento.Text);

                ValidarForm.Valida(_novoAluno);
                _novoAluno.Id = NovoId();
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
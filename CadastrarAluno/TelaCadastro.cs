using CadastrarAluno.Servicos;


namespace CadastrarAluno
{
    public partial class TelaCadastro : Form
    {
        public Aluno alunoParaAtualizar;
        public static Aluno AlunoParaCadastrar;

        public TelaCadastro(List<Aluno> _alunos, Aluno aluno = null)
        {
            InitializeComponent();
            alunoParaAtualizar = aluno;
            if (_alunos != null) PreencherFormulario(aluno);
        }

        private void aoClicarSalvar(object sender, EventArgs e)

        {
            try
            {
                if (alunoParaAtualizar != null)
                {
                    AtualizarAluno(alunoParaAtualizar);
                }
                else
                {
                    CriarAluno();
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelarFormularioCadastro(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Cancelar? Você pode perder esses dados", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void PreencherFormulario(Aluno aluno)
        {

            tb_nome_aluno.Text = aluno?.NomeAluno;
            mtb_cpf.Text = aluno?.Cpf;
            mtb_telefone.Text = aluno?.Telefone;
            dtp_data_nascimento.Text = aluno?.DataNascimento.ToString();
        }

        private Aluno ObterDadosDoFormulario()
        {
            var date = dtp_data_nascimento.Value;

            var aluno = new Aluno()
            {
                NomeAluno = tb_nome_aluno.Text,
                Cpf = mtb_cpf.Text,
                Telefone = mtb_telefone.Text,
                DataNascimento = new DateTime(date.Year, date.Month, date.Day)
            };

            return aluno;
        }

        public Aluno ObterAlunoParaCadastrar()
        {
            return AlunoParaCadastrar;
        }

        private void CriarAluno()
        {
            var aluno = ObterDadosDoFormulario();
            ValidarForm.Valida(aluno);
            aluno.Id = ListaSingleton.NovoId();
            AlunoParaCadastrar = aluno;
        }

        private void AtualizarAluno(Aluno alunoParaSerAtualizado)
        {
            var alunoAtualizado = ObterDadosDoFormulario();
            ValidarForm.Valida(alunoAtualizado);
            alunoAtualizado.Id = alunoParaSerAtualizado.Id;
            AlunoParaCadastrar = alunoAtualizado;
        }
    }
}
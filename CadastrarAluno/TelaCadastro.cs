using CadastrarAluno.Servicos;

namespace CadastrarAluno
{
    public partial class TelaCadastro : Form
    {
        public Aluno alunoParaAtualizar;
        public static Aluno AlunoParaCadastrar;

        private static int idIncremental;

        public TelaCadastro(List<Aluno> alunos, Aluno aluno = null)
        {
            InitializeComponent();
            alunoParaAtualizar = aluno;
            if (alunos != null) PreencherFormulario(aluno);
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
            DialogResult = DialogResult.Cancel;
        }

        private int NovoId()
        {
            return ++idIncremental;
        }

        private Aluno RecebeDadosAluno(Aluno aluno)
        {

            aluno.NomeAluno = tb_nome_aluno.Text;
            aluno.Cpf = mtb_cpf.Text;
            aluno.Telefone = mtb_telefone.Text;
            aluno.DataNascimento = Convert.ToDateTime(dtp_data_nascimento.Text);

            return aluno;
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

        private void CriarAluno()
        {
            var aluno = ObterDadosDoFormulario();
            ValidarForm.Valida(aluno);
            aluno.Id = NovoId();
            AlunoParaCadastrar = aluno;
        }

        private void AtualizarAluno(Aluno alunoParaSerAtualizado)
        {
            var alunoAtualizado = ObterDadosDoFormulario();
            alunoAtualizado.Id = alunoParaSerAtualizado.Id;
            AlunoParaCadastrar = alunoAtualizado;

        }
        public Aluno ObterAlunoParaCadastrar()
        {
            return AlunoParaCadastrar;
        }

        private void PreencherFormulario(Aluno aluno)
        { 
            
            tb_nome_aluno.Text = aluno?.NomeAluno;
            mtb_cpf.Text = aluno?.Cpf;
            mtb_telefone.Text = aluno?.Telefone;
            dtp_data_nascimento.Text = aluno?.DataNascimento.ToString();
        }  
    }



















































































































}
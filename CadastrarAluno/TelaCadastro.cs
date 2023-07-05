using CadastrarAluno.Servicos;
using Dominio;
using Infra;

namespace UI
{
    public partial class TelaCadastro : Form
    {
        public Aluno novoAluno = new Aluno();
        public Aluno alunoParaAtualizar;
        public static Aluno AlunoParaCadastrar;

        public TelaCadastro(Aluno? aluno)
        {
            InitializeComponent();

            if (aluno != null)
            {
                alunoParaAtualizar = aluno;
                PreencherFormulario(alunoParaAtualizar);
            }
            else
            {
                AlunoParaCadastrar = new Aluno();
            }
        }

        private void AoClicarSalvar(object sender, EventArgs e)
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
            tb_nome_aluno.Text = aluno?.Nome;
            mtb_cpf.Text = aluno?.Cpf;
            mtb_telefone.Text = aluno?.Telefone;
            dtp_data_nascimento.Text = aluno?.Nascimento.ToString();
        }

        private Aluno ObterDadosDoFormulario()
        {
            var date = dtp_data_nascimento.Value;

            var aluno = new Aluno()
            {
                Nome = tb_nome_aluno.Text,
                Cpf = mtb_cpf.Text,
                Telefone = mtb_telefone.Text,
                Nascimento = new DateTime(date.Year, date.Month, date.Day)
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

        private void TelaCadastro_Load(object sender, EventArgs e)
        {

        }
    }
}
using CadastrarAluno.Servicos;

namespace CadastrarAluno
{
    public partial class TelaCadastro : Form
    {
        public Aluno _aluno;
        public Aluno _novoAluno;
        private static int idIncremental;

        public TelaCadastro(List<Aluno> alunos, Aluno aluno = null)
        {
            InitializeComponent();

            _aluno = aluno;
            if (alunos == null)
            {
                _novoAluno = new Aluno();
            }
            else
            {
                ExibirDadosParaEditar();
            }
        }

        private void aoClicarSalvar(object sender, EventArgs e)

        {
            try
            {
                if (_aluno != null)
                {
                    RecebeDadosAluno(_aluno);

                    ValidarForm.Valida(_aluno);
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Usuário Editado com sucesso!");

                }
                else
                {
                    RecebeDadosAluno(_novoAluno);

                    ValidarForm.Valida(_novoAluno);
                    _novoAluno.Id = NovoId();
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Usuário Cadastrado com sucesso!");
                }
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

        private void RecebeDadosAluno(Aluno aluno)
        {
            aluno.NomeAluno = tb_nome_aluno.Text;
            aluno.Cpf = mtb_cpf.Text;
            aluno.Telefone = mtb_telefone.Text;
            aluno.DataNascimento = Convert.ToDateTime(dtp_data_nascimento.Text);

        }

        private void ExibirDadosParaEditar()
        {
            tb_nome_aluno.Text = _aluno.NomeAluno;
            mtb_cpf.Text = _aluno.Cpf;
            mtb_telefone.Text = _aluno.Telefone;
            dtp_data_nascimento.Text = _aluno.DataNascimento.ToString();
        }
    }



















































































































}
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
                EditarDadosCadastro(_aluno);
            }
        }

        private void aoClicarCadastrarNovoAluno(object sender, EventArgs e)

        {
            try
            {
                if (_aluno != null)
                {
                    PegarDadosFormulario(_aluno);
                    ValidarForm.Valida(_aluno);
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Usuário Editado com sucesso!");

                }
                else
                {
                    PegarDadosFormulario(_novoAluno);
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

        private void PegarDadosFormulario(Aluno aluno)
        {
            aluno.NomeAluno = tb_nome_aluno.Text;
            aluno.Cpf = mtb_cpf.Text;
            aluno.Telefone = mtb_telefone.Text;
            aluno.DataNascimento = Convert.ToDateTime(dtp_data_nascimento.Text);
        }

        private void EditarDadosCadastro(Aluno aluno)
        {
            tb_nome_aluno.Text = aluno.NomeAluno;
            mtb_cpf.Text = aluno.Cpf;
            mtb_telefone.Text = aluno.Telefone;
            dtp_data_nascimento.Text = aluno.DataNascimento.ToString();
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
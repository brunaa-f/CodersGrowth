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
        private void SubmitFormularioCadastro(object sender, EventArgs e)

        {
            if (ValidarForm())
            {
                _novoAluno.Id = NovoId();
                _novoAluno.NomeAluno = tb_nome_aluno.Text;
                _novoAluno.Cpf = mtb_cpf.Text;
                _novoAluno.Telefone = mtb_telefone.Text;
                _novoAluno.DataNascimento = Convert.ToDateTime(dtp_data_nascimento.Text);
                MessageBox.Show("Usuário Cadastrado com sucesso!");
                DialogResult = DialogResult.OK;
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
            DialogResult = DialogResult.Cancel;
        }

        private int NovoId()
        { 
            return ++idIncremental;
        }
    }
}
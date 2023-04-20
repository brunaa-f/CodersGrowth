namespace CadastrarAluno
{
    public partial class TelaInicial : Form
    {
        List<Aluno> lista = new List<Aluno>();
        public int _id { get; set; }

        public TelaInicial()
        {
            InitializeComponent();
            dataGridLista.DataSource = lista;
            AtualizarALista();
        }

        private void aoClicarCadastrar(object sender, EventArgs e)
        {
            TelaCadastro cadastro = new TelaCadastro(null, _id);
            cadastro.ShowDialog();

            var alunoParaCadastrar = cadastro._novoAluno;
            _id = alunoParaCadastrar.Id;
            lista.Add(alunoParaCadastrar);
            AtualizarALista();
        }
        private void aoClicarRemover(object sender, EventArgs e)
        {

        }

        private void aoClicarEditar(object sender, EventArgs e)
        {

        }
        public void AtualizarALista()
        {
            dataGridLista.DataSource = null;
            dataGridLista.DataSource = lista;
        }
    }
}
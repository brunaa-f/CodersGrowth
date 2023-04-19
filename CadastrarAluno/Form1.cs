namespace CadastrarAluno
{
    public partial class TelaInicial : Form
    {
        List<Aluno> lista = new List<Aluno>();

        public TelaInicial()
        {
            InitializeComponent();
            dataGridLista.DataSource = lista;
            AtualizarALista();
        }

        private void aoClicarCadastrar(object sender, EventArgs e)
        {
            TelaCadastro cadastro = new TelaCadastro(lista);
            cadastro.ShowDialog();
            AtualizarALista();

        }
        private void aoClicarRemover(object sender, EventArgs e)
        {

        }

        private void aoClicarEditar(object sender, EventArgs e)
        {

        }

        private void dataGridLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AtualizarALista()
        {
            dataGridLista.DataSource = null;
            dataGridLista.DataSource = lista;
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {

        }
    }
}
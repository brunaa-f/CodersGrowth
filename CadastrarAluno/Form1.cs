namespace CadastrarAluno
{
    public partial class TelaInicial : Form
    {
        List<Aluno> lista = new List<Aluno>();


        Aluno Aluno = new Aluno();
        

        public TelaInicial()
        {
            InitializeComponent();
            lista = new List<Aluno>();
            AtualizarALista();
        }

        private void aoClicarCadastrar(object sender, EventArgs e)
        {
            TelaCadastro cadastro = new TelaCadastro();
            cadastro.ShowDialog();
             

        }

        private void aoClicarRemover(object sender, EventArgs e)
        {

        }

        private void aoClicarEditar(object sender, EventArgs e)
        {

        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AtualizarALista()
        {
            dataGridLista.DataSource = lista.ToList();
        }

        

    }
}
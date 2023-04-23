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
        private void aoClicarAbreTelaDeCadastro(object sender, EventArgs e)
        {
            TelaCadastro cadastro = new TelaCadastro(null);

            if (cadastro.ShowDialog() == DialogResult.OK)
            {
                var alunoParaCadastrar = cadastro._novoAluno;
                lista.Add(alunoParaCadastrar);
                AtualizarALista();
            }
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
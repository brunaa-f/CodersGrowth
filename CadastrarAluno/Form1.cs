namespace CadastrarAluno
{
    public partial class TelaInicial : Form
    {
        List<Aluno> lista = new List<Aluno>();

        public TelaInicial()
        {
            InitializeComponent();

            var aluno = new Aluno(1, "bruna", "70416149138", "62992820064", DateTime.Now);
            Aluno aluno1 = new Aluno(2, "julia", "70416149127", "62992820077", DateTime.Now);
            Aluno aluno2 = new Aluno(3, "ana", "70416149176", "62992820078", DateTime.Now);


            lista.Add(aluno);
            lista.Add(aluno1);
            lista.Add(aluno2);

            dataGridLista.DataSource = lista;
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
    }
}
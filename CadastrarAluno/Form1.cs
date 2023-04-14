namespace CadastrarAluno
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
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
    }
}
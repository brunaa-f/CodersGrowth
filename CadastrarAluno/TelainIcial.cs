using System.Windows.Forms;

namespace CadastrarAluno
{
    public partial class TelaInicial : Form
    {
        List<Aluno> lista = new List<Aluno>();

        public int _id { get; set; }
        public TelaInicial()
        {
            InitializeComponent();
            AtualizarALista();
        }
        private void aoClicarAbreTelaDeCadastro(object sender, EventArgs e)
        {
            TelaCadastro cadastro = new TelaCadastro(null);

            if (cadastro.ShowDialog() == DialogResult.OK)
            {
                var alunoParaCadastrar = cadastro._novoAluno;
                lista.Add(alunoParaCadastrar);
                _id = alunoParaCadastrar.Id;
                AtualizarALista();
            }
        }
        private void aoClicarRemover(object sender, EventArgs e)
        {
            var id = (int)dataGridLista.SelectedRows[0].Cells[0].Value;
            var alunoParaRemover = lista.Find(x => x.Id == id);
            lista.Remove(alunoParaRemover);
            AtualizarALista();
        }

        private void aoClicarEditar(object sender, EventArgs e)
        {
            var id = (int)dataGridLista.SelectedRows[0].Cells[0].Value;
            var alunoParaEditar = lista.Find(x => x.Id == id);
            TelaCadastro cadastro = new TelaCadastro(lista, alunoParaEditar);

            if (cadastro.ShowDialog() == DialogResult.OK)
            {
                Aluno alunoEditado = lista.Find(x => x.Id == cadastro._aluno.Id);
                lista[lista.IndexOf(alunoEditado)] = cadastro._aluno;
                AtualizarALista();
            }
        }
        public void AtualizarALista()
        {
            dataGridLista.DataSource = null;
            dataGridLista.DataSource = lista.ToList();
        }
    }
}
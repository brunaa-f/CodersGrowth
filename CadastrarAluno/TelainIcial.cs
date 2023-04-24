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
         
        static int id = 0;
        public int gerarId()
        {
            id++;
            return _id;    
        }
        private void aoClicarAbreTelaDeCadastro(object sender, EventArgs e)
        {
            TelaCadastro cadastro = new TelaCadastro(null, gerarId());

            if (cadastro.ShowDialog() == DialogResult.OK)
            {
                var alunoParaCadastrar = cadastro._novoAluno;
                _id = alunoParaCadastrar.Id;
                lista.Add(alunoParaCadastrar);
                AtualizarALista();
            }
        }
        private void aoClicarRemover(object sender, EventArgs e)
        {
           var id = (int) dataGridLista.SelectedRows[0].Cells[0].Value;
           var alunoParaRemover = lista.Find(x => x.Id == id);
           lista.Remove(alunoParaRemover);
           AtualizarALista();
        } 

        private void aoClicarEditar(object sender, EventArgs e)
        {
            DataGridViewRow linha = new DataGridViewRow();
            linha = dataGridLista.CurrentRow;
        }
        public void AtualizarALista()
        {
            dataGridLista.DataSource = null;
            dataGridLista.DataSource = lista.ToList();
        }
    }
}
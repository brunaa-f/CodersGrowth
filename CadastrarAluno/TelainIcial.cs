using System.Windows.Forms;

namespace CadastrarAluno
{
    public partial class TelaInicial : Form
    {
        List<Aluno> lista = new();

        public int _id { get; set; }
        public TelaInicial()
        {
            InitializeComponent();
            AtualizarALista();
        }

        private void aoClicarAbreTelaDeCadastro(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                throw;
            }

        }


        private void AoClicarEditar(object sender, EventArgs e)

        {
            int linhaSelecionada = dataGridLista.SelectedRows.Count;
            try
            {
                VerificarLinhasSelecionadas(linhaSelecionada);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void aoClicarRemover(object sender, EventArgs e)
        {
            int linhaSelecionada = dataGridLista.SelectedRows.Count;
            try
            {
                VerificarLinhasSelecionadas(linhaSelecionada);
                var id = (int)dataGridLista.SelectedRows[0].Cells[0].Value;
                var alunoParaRemover = lista.Find(x => x.Id == id);
                if (MessageBox.Show("Deseja remover esse usuário?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lista.Remove(alunoParaRemover);
                }
                AtualizarALista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerificarLinhasSelecionadas(int linhaSelecionada)
        {
            const int unicaLinhaSelecionada = 1;
            if (linhaSelecionada > unicaLinhaSelecionada)
            {
                throw new Exception("Selecione um aluno para editar");
            }

            if (linhaSelecionada < unicaLinhaSelecionada)
            {
                throw new Exception("Selecione pelo menos um aluno para editar");
            }
        }
        public void AtualizarALista()
        {
            dataGridLista.DataSource = null;
            dataGridLista.DataSource = lista.ToList();
        }

    }
}

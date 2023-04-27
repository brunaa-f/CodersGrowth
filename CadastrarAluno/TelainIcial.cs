using System.Windows.Forms;

namespace CadastrarAluno
{
    public partial class TelaInicial : Form
    {
        List<Aluno> lista = new();
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
                    var alunoParaCadastrar = cadastro.ObterAlunoParaCadastrar();
                    lista.Add(alunoParaCadastrar);
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
                    Aluno alunoEditado = lista.Find(x => x.Id == cadastro.alunoParaAtualizar.Id);
                    lista[lista.IndexOf(alunoEditado)] = cadastro.ObterAlunoParaCadastrar();
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
                if (MessageBox.Show("Deseja remover esse aluno?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                throw new Exception("Selecione um aluno");
            }

            if (linhaSelecionada < unicaLinhaSelecionada)
            {
                throw new Exception("Selecione pelo menos um aluno");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AtualizarALista()
        {
            dataGridLista.DataSource = null;
            dataGridLista.DataSource = lista.ToList();
        }

    }
}

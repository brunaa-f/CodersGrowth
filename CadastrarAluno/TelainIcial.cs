using Dominio;
using Infra;

namespace UI
{
    public partial class TelaInicial : Form
    {
        public IRepositorio _repositorioAluno;

        public TelaInicial(IRepositorio repositorioAluno)
        {
            InitializeComponent();
            _repositorioAluno = repositorioAluno;

            AtualizarALista();
        }

        private void AoClicarAbreTelaDeCadastro(object sender, EventArgs e)
        {
            try
            {
                TelaCadastro cadastro = new(null);

                if (cadastro.ShowDialog() == DialogResult.OK)
                {
                    var alunoParaCadastrar = cadastro.ObterAlunoParaCadastrar();
                    _repositorioAluno.Criar(alunoParaCadastrar);
                    AtualizarALista();
                    MessageBox.Show("Aluno cadastrado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarEditar(object sender, EventArgs e)
        {
            int linhaSelecionada = dataGridLista.SelectedRows.Count;
            try
            {
                VerificarLinhasSelecionadas(linhaSelecionada);

                var idAluno = (int)dataGridLista.SelectedRows[0].Cells[0].Value;
                var index = dataGridLista.CurrentCell.RowIndex;
                var alunoParaEditar = dataGridLista.Rows[index].DataBoundItem as Aluno;

                TelaCadastro cadastro = new(alunoParaEditar);

                if (cadastro.ShowDialog() == DialogResult.OK)
                {
                    _repositorioAluno.Atualizar(idAluno, cadastro.ObterAlunoParaCadastrar());
                    AtualizarALista();
                    MessageBox.Show("Aluno atualizado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarRemover(object sender, EventArgs e)
        {
            int linhaSelecionada = dataGridLista.SelectedRows.Count;
            try
            {
                VerificarLinhasSelecionadas(linhaSelecionada);
                var id = (int)dataGridLista.SelectedRows[0].Cells[0].Value;

                if (MessageBox.Show("Deseja remover esse aluno?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _repositorioAluno.Remover(id);
                    MessageBox.Show("Aluno removido com sucesso!");
                }

                AtualizarALista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void VerificarLinhasSelecionadas(int linhaSelecionada)
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
        }

        public void AtualizarALista()
        {
            dataGridLista.DataSource = null;
            dataGridLista.DataSource = _repositorioAluno.ObterTodos();
        }
    }
}
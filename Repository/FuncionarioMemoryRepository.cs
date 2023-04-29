using testepratico.iniflex.Model;

namespace testepratico.iniflex.Repository
{
    public class FuncionarioMemoryRepository : IFuncionarioRepository
    {
        private List<Funcionario> tabelaFuncionarios = new List<Funcionario>();

        public void Inserir(IEnumerable<Funcionario> funcionarios)
        {
            int maxId = tabelaFuncionarios.Count > 0 ? tabelaFuncionarios.Max(o => o.Id) : 0;

            foreach (var funcionario in funcionarios)
                funcionario.Id = maxId++;

            tabelaFuncionarios.AddRange(funcionarios);
        }

        public void AtualizarSalario(int id, decimal salario)
        {
            var funcionario = tabelaFuncionarios.FirstOrDefault(o => o.Id == id);
            if (funcionario != null)
                funcionario.Salario = salario;
        }

        public IEnumerable<Funcionario> ListarTodos()
        {
            return tabelaFuncionarios;
        }

        public void Remover(string nome)
        {
            tabelaFuncionarios = tabelaFuncionarios.Where(o => o.Nome != nome).ToList();
        }
    }
}

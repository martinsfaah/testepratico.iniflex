using testepratico.iniflex.Model;

namespace testepratico.iniflex.Repository
{
    public interface IFuncionarioRepository
    {
        void Inserir(IEnumerable<Funcionario> funcionarios);
        void AtualizarSalario(int id, decimal salario);
        void Remover(string nome);
        IEnumerable<Funcionario> ListarTodos();
    }
}

namespace testepratico.iniflex.Model
{
    public class Funcionario : Pessoa
    {
        public int Id { get; set; }
        public decimal Salario { get; set; }
        public string Funcao { get; set; }

        public Funcionario(string nome, DateTime dataNascimento, decimal salario, string funcao)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Salario = salario;
            Funcao = funcao;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} | Data Nascimento: {DataNascimento.ToString("dd/MM/yyyy")} | Salário: {string.Format("{0:N}", Salario)} | Função: {Funcao} ";
        }
    }
}

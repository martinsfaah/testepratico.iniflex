using testepratico.iniflex.Model;
using testepratico.iniflex.Repository;

namespace testepratico.iniflex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFuncionarioRepository funcionarioRepository = new FuncionarioMemoryRepository();

            // 3.1 – Inserir todos os funcionários, na mesma ordem e informações da tabela acima.
            InserirFuncionarios(funcionarioRepository);

            // 3.2 – Remover o funcionário “João” da lista.
            RemoverFuncionarioJoao(funcionarioRepository);

            var todosFuncionarios = funcionarioRepository.ListarTodos();

            // 3.3 – Imprimir todos os funcionários com todas suas informações
            Imprimir(todosFuncionarios);

            // 3.4 – Os funcionários receberam 10% de aumento de salário, atualizar a lista de funcionários com novo valor.
            DarAumentoSalarial(funcionarioRepository, todosFuncionarios);

            // 3.5 e 3.6 – Agrupar e imprimir os funcionários por função
            ImprimirFuncionariosAgrupadosPorFuncao(todosFuncionarios);

            // 3.8 – Imprimir os funcionários que fazem aniversário no mês 10 e 12.
            ImprimirFuncionariosNascidosEmOutubroEDezembro(todosFuncionarios);

            // 3.9 – Imprimir o funcionário com a maior idade, exibir os atributos: nome e idade.
            ImprimirFuncionarioMaisVelho(todosFuncionarios);

            // 3.10 – Imprimir a lista de funcionários por ordem alfabética.
            ImprimirFuncionariosPorOrdemAlfabetica(todosFuncionarios);

            // 3.11 – Imprimir o total dos salários dos funcionários.
            ImprimirTotalSalarios(todosFuncionarios);

            // 3.12 – Imprimir quantos salários mínimos ganha cada funcionário, considerando que o salário mínimo é R$1212.00.
            ImprimirQuantidadeSalariosMinimosPorFuncionario(todosFuncionarios);
        }

        private static void InserirFuncionarios(IFuncionarioRepository funcionarioRepository)
        {
            var funcionariosParaAdicionar = new List<Funcionario>() {
                new Funcionario("Maria",new DateTime(2000, 10, 18),2009.44m,"Operador"),
                new Funcionario("João",new DateTime(1990, 05, 12),2284.38m,"Operador"),
                new Funcionario("Caio",new DateTime(1961, 05, 02),9836.14m,"Coordenador"),
                new Funcionario("Miguel",new DateTime(1988, 10, 14),19119.88m,"Diretor"),
                new Funcionario("Alice",new DateTime(1995, 01, 05),2234.68m,"Recepcionista"),
                new Funcionario("Heitor",new DateTime(1999, 11, 19),1582.72m,"Operador"),
                new Funcionario("Arthur",new DateTime(1993, 03, 31),4071.84m,"Contador"),
                new Funcionario("Laura",new DateTime(1994, 07, 08),3017.45m,"Gerente"),
                new Funcionario("Heloísa",new DateTime(2003, 05, 24),1606.85m,"Eletricista"),
                new Funcionario("Helena",new DateTime(1996, 09, 02),2799.93m,"Gerente")
            };

            funcionarioRepository.Inserir(funcionariosParaAdicionar);
        }

        private static void RemoverFuncionarioJoao(IFuncionarioRepository funcionarioRepository)
        {
            funcionarioRepository.Remover("João");
        }

        private static void Imprimir(IEnumerable<Funcionario> todosFuncionarios)
        {
            Console.WriteLine("3.3 – Imprimir todos os funcionários com todas suas informações: ");

            ImprimirFuncionarios(todosFuncionarios);
        }

        private static void DarAumentoSalarial(IFuncionarioRepository funcionarioRepository, IEnumerable<Funcionario> todosFuncionarios)
        {
            foreach (var funcionario in todosFuncionarios)
            {
                var aumentoSalarial = Math.Round(funcionario.Salario * 0.1m, 2);
                var novoSalario = funcionario.Salario + aumentoSalarial;

                funcionarioRepository.AtualizarSalario(funcionario.Id, novoSalario);
            }
        }

        private static void ImprimirFuncionariosAgrupadosPorFuncao(IEnumerable<Funcionario> todosFuncionarios)
        {
            Console.WriteLine("");
            Console.WriteLine("3.6 – Imprimir os funcionários, agrupados por função.");

            var funcaoFuncionariosMap = todosFuncionarios.GroupBy(o => o.Funcao);

            foreach (var grupoFuncionarosPorFuncao in funcaoFuncionariosMap)
            {
                Console.WriteLine(grupoFuncionarosPorFuncao.Key);

                ImprimirFuncionarios(grupoFuncionarosPorFuncao);

                Console.WriteLine("");
            }
        }

        private static void ImprimirFuncionariosNascidosEmOutubroEDezembro(IEnumerable<Funcionario> todosFuncionarios)
        {
            Console.WriteLine("");
            Console.WriteLine("3.8 – Imprimir os funcionários que fazem aniversário no mês 10 e 12.");

            var funcionariosNascidosOutubroDezembro = todosFuncionarios.Where(o => o.DataNascimento.Month == 10 || o.DataNascimento.Month == 12);

            ImprimirFuncionarios(funcionariosNascidosOutubroDezembro);
        }

        private static void ImprimirFuncionarioMaisVelho(IEnumerable<Funcionario> todosFuncionarios)
        {
            var funcionarioMaisVelho = todosFuncionarios.OrderBy(o => o.DataNascimento).First();
            var idadeFuncionario = Math.Floor((DateTime.Now - funcionarioMaisVelho.DataNascimento).TotalDays / 365);

            Console.WriteLine("");
            Console.WriteLine("3.9 – Imprimir o funcionário com a maior idade, exibir os atributos: nome e idade.");

            Console.WriteLine($"Nome: {funcionarioMaisVelho.Nome}, Idade: {idadeFuncionario}");
        }

        private static void ImprimirFuncionariosPorOrdemAlfabetica(IEnumerable<Funcionario> todosFuncionarios)
        {
            Console.WriteLine("");
            Console.WriteLine("3.10 – Imprimir a lista de funcionários por ordem alfabética.");

            ImprimirFuncionarios(todosFuncionarios.OrderBy(o => o.Nome));
        }

        private static void ImprimirTotalSalarios(IEnumerable<Funcionario> todosFuncionarios)
        {
            Console.WriteLine("");
            Console.WriteLine("3.11 – Imprimir o total dos salários dos funcionários.");

            Console.WriteLine(todosFuncionarios.Sum(o => o.Salario));
        }

        private static void ImprimirQuantidadeSalariosMinimosPorFuncionario(IEnumerable<Funcionario> todosFuncionarios)
        {
            Console.WriteLine("");
            Console.WriteLine("3.12 – Imprimir quantos salários mínimos ganha cada funcionário, considerando que o salário mínimo é R$1212.00.");

            var salarioMinimo = 1212m;
            foreach (var funcionario in todosFuncionarios)
            {
                var quantidadeSalariosMinimos = funcionario.Salario / salarioMinimo;
                Console.WriteLine($"Funcionario(a) {funcionario.Nome} recebe um total de {quantidadeSalariosMinimos.ToString("#.##")} salarios mínimos.");
            }
        }

        private static void ImprimirFuncionarios(IEnumerable<Funcionario> todosFuncionarios)
        {
            foreach (var funcionario in todosFuncionarios)
            {
                Console.WriteLine(funcionario.ToString());
            }
        }
    }
}
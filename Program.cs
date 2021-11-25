using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            var opcao = ObterOpcao();

            while (opcao != "X")
            {
                switch (opcao)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Adicionar();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        Visualizar();
                        break;
                    case "C": // LIMPAR TELA
                        Console.Clear();
                        break;
                    default:
                        break;
                }

                opcao = ObterOpcao();
                Console.WriteLine();
            }
        }

        private static void Excluir()
        {
            Console.WriteLine("Informe o ID da Série: ");
            var idInformado = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornarPorId(idInformado);
            if (serie != null && serie != default)
            {
                serie.Desativar();
                Console.WriteLine("Série Excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível localizar o ID da Série informado!");
            }
        }

        private static void Visualizar()
        {
            Console.WriteLine("Informe o ID da Série: ");
            var idInformado = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornarPorId(idInformado);
            if (serie != null && serie != default)
                Console.WriteLine(serie.ToString());
            else
                Console.WriteLine("Não foi possível localizar o ID da Série informado!");
        }

        private static void Atualizar()
        {
            Listar();
            if (repositorio.Lista().Count == 0)
                return;
            Console.WriteLine("Informe o ID da Série");
            var idInformado = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornarPorId(idInformado);

            ListarGeneros();
            Console.WriteLine("Informe o novo Gênero: ");
            serie.SetGenero((Genero) int.Parse(Console.ReadLine()));
            Console.WriteLine("Informe o novo Título: ");
            serie.SetTitulo(Console.ReadLine());
            Console.WriteLine("Informe a nova Descrição: ");
            serie.SetDescricao(Console.ReadLine());
            Console.WriteLine("Informe o novo Ano: ");
            serie.SetAno(int.Parse(Console.ReadLine()));
        }

        private static void Adicionar()
        {
            ListarGeneros();
            Console.WriteLine("Informe o Gênero: ");
            var generoInformado = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            var tituloInformado = Console.ReadLine();

            Console.WriteLine("Informe a Descrição da Série: ");
            var descricaoInformada = Console.ReadLine();

            Console.WriteLine("Informe o Ano da Série: ");
            var anoInformado = int.Parse(Console.ReadLine());

            var serie = new Serie(repositorio.ProximoId(), (Genero)generoInformado, tituloInformado, descricaoInformada, anoInformado);
            repositorio.Insere(serie);
        }

        private static void ListarGeneros()
        {
            foreach (int genero in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{genero} - {Enum.GetName(typeof(Genero), genero)}");
            }
            Console.WriteLine();
        }

        private static void Listar()
        {
            Console.Clear();
            if (repositorio.Lista().Count == 0)
                Console.WriteLine("Não possui Série cadastrada!");

            foreach (var serie in repositorio.Lista())
            {
                Console.WriteLine($"{serie.Id} - {serie.GetTitulo()}");
                Console.WriteLine();
            }
        }

        private static string ObterOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("Opções: ");
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Adicionar Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            var opcao = Console.ReadLine().ToUpper();
            return opcao;
        }
    }
}

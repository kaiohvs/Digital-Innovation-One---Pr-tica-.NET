using System;


namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {           
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }           
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar series ");
            
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada. ");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(),(excluido ? "*Excluido*" : "") );
            }
        }
        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova serie ");


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();
            
            Serie novaSerie = new Serie(Id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);    
            
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o ID da Serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
               System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
             System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();
            
            Serie atualizarSerie = new Serie(Id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualizar(indiceSerie, atualizarSerie);
        }
        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Digite o ID da Serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }
          private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o ID da Serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        
        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Series a seu dispor");
            System.Console.WriteLine("Informa a opção desejada: ");

            System.Console.WriteLine("1- Listar series ");
            System.Console.WriteLine("2- Inserir nova serie ");
            System.Console.WriteLine("3- Atualizar serie ");
            System.Console.WriteLine("4- Excluir serie ");
            System.Console.WriteLine("5- Visualizar serie ");
            System.Console.WriteLine("C- Limpar Tela ");
            System.Console.WriteLine("X- Sair ");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
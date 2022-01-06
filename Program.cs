using System;
using DIO.Series.Classes;

namespace DIO.Series
{

    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpecaoUsuario();

           while(opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                   case "1":
                        ListarSeriesAtiva();
                        break;
                   case "2":
                        ListarSeries();
                        break;
                   case "3":
                        InserirSerie();
                        break;
                   case "4":
                        AtualizarSerie();
                        break;
                   case "5":
                        ExcluirSerie();
                       break;
                   case "6":
                        VisualizarSerie();
                       break;
                   case "C":
                        Console.Clear();
                       break;
                   default:
                        throw new ArgumentOutOfRangeException();
               }

               opcaoUsuario = ObterOpecaoUsuario();

           }

           Console.WriteLine("Programa finalizado");
           Console.WriteLine();
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("*#*#*# Módulo de visualizar detalhes da série *#*#*#");
                    
            // Lista as séries cadastradas para o usuário saber o ID  que irá detalhar
            ListarSeries();

            Console.WriteLine("Digite o ID da série que deseja detalhar: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serieDetalhe = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serieDetalhe);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("*#*#*# Módulo de excluir de série *#*#*#");
            
            // Lista as séries cadastradas para o usuário saber o ID  que irá excluir
            ListarSeries();

            Console.WriteLine("Digite o ID da série que deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

        }       

        private static void AtualizarSerie(){
            Console.WriteLine("*#*#*# Módulo de atualizar de séries *#*#*#");

            // Lista as séries cadastradas para que o usuário saiba qual ID ira excluir 
            ListarSeries();

            Console.WriteLine("Digite o Id da série que voce quer atualizar: ");

            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, novaSerie);


        }
        private static void ListarSeries()
        {

            Console.WriteLine("*#*#*# Módulo de listagem de séries *#*#*#");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");          

                return;
            }

            foreach(var serie in lista){

                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }
        private static void ListarSeriesAtiva()
        {

            Console.WriteLine("*#*#*# Módulo de listagem de séries *#*#*#");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");          

                return;
            }

            foreach(var serie in lista){

                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSerie(){
            Console.WriteLine("*#*#*# Módulo de inserir série *#*#*#");

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }

                Console.WriteLine("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o Título da série: ");
                string entradaTitulo = Console.ReadLine();

                Console.WriteLine("Digite o Ano da série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a Descrição da série: ");
                string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorio.Insere(novaSerie);


        }
        
        private static string ObterOpecaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao App para gerenciamento de série");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Séries Ativas");
            Console.WriteLine("2 - Listar TODAS as Séries");
            Console.WriteLine("3 - Inserir nova Série ");
            Console.WriteLine("4 - Atualizar Série ");
            Console.WriteLine("5 - Excluir Série ");
            Console.WriteLine("6 - Visualizar Série ");
            Console.WriteLine("C - Limpar Tela ");
            Console.WriteLine("X - Sair ");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();

            return opcaoUsuario;
        }
            
    }
}
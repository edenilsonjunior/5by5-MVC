using Controllers;
using Models;
using System.Runtime.InteropServices;

namespace MVC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                switch (Menu())
                {
                    case 1:
                        TelaInserirCarro();
                        break;
                    case 2:
                        TelaAtualizarCarro();
                        break;
                    case 3:
                        TelaDeletarCarro();
                        break;
                    case 4:
                        TelaListagemCarros(listarTodos: true);
                        break;
                    case 5:
                        TelaListagemCarros(listarTodos: false);
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opcao invalida!");
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }


        static void TelaInserirCarro()
        {
            Console.Clear();
            Console.WriteLine("=====|Inserir um novo carro|=====");

            string name = LerString("Digite o nome do carro.");
            string color = LerString("Digite a cor do carro.");
            int year = LerInt("Digite o ano do carro");

            var car = new Car()
            {
                Name = name,
                Color = color,
                Year = year
            };
            Console.Write("\nR: ");
            Console.WriteLine(new CarController().Insert(car) ? "Registro inserido" : "Erro ao inserir registro");
        }

        static void TelaAtualizarCarro()
        {
            Console.Clear();
            Console.WriteLine("=====|Atualizar um carro|=====");

            var car = new Car()
            {
                Id = LerInt("Digite o id do carro que deseja atualizar."),
                Name = LerString("Digite o novo nome do carro."),
                Color = LerString("Digite a nova cor do carro."),
                Year = LerInt("Digite o novo ano do carro.")
            };

            Console.Write("\nR: ");
            Console.WriteLine(new CarController().Updade(car) ? "Registro atualizado" : "Erro ao atualizar registro");
        }

        static void TelaDeletarCarro()
        {
            Console.Clear();
            Console.WriteLine("=====|Deletar um carro|=====");

            int id = LerInt("Digite o id do carro que deseja deletar.");

            Console.Write("\nR: ");
            Console.WriteLine(new CarController().Delete(id) ? "Registro deletado" : "Erro ao deletar registro");
        }

        static void TelaListagemCarros(bool listarTodos)
        {
            Console.Clear();
            if (listarTodos)
            {
                Console.WriteLine("=====|Listagem de carros|=====");
                var list = new CarController().GetAll();

                if (list.Count != 0)
                {
                    list.ForEach((c) => { Console.WriteLine(c); });
                }
                else
                    Console.WriteLine("Nao existem carros cadastrados!");
            }
            else
            {
                Console.WriteLine("=====|Exibir carro especifico|=====");

                int id = LerInt("Digite o id do carro para busca");

                Car? encontrado = new CarController().Get(id);
                Console.WriteLine(encontrado != null ? "Carro encontrado: " + encontrado : "Carro nao encontrado!");
            }
        }



        static int Menu()
        {
            Console.Clear();
            Console.WriteLine($"=====|Carros|=====");
            Console.WriteLine("1- Inserir um novo carro");
            Console.WriteLine("2- Atualizar os dados de um carro");
            Console.WriteLine("3- Deletar o registro de um carro");
            Console.WriteLine("4- Listar todos os carros");
            Console.WriteLine("5- Exibir os dados de um carro especifico");
            Console.WriteLine("0- Sair");
            Console.WriteLine($"=================================");

            return LerInt("Digite sua resposta:");
        }

        public static int LerInt(string titulo)
        {
            int resposta;

            Console.WriteLine(titulo);
            Console.Write("R: ");

            string? s = Console.ReadLine();


            while (!int.TryParse(s, out resposta))
            {
                Console.WriteLine("Resposta invalida! Tente novamente.");
                Console.WriteLine(titulo);
                Console.Write("R: ");
                s = Console.ReadLine();
            }

            return resposta;
        }

        public static string LerString(string titulo)
        {
            Console.WriteLine(titulo);
            Console.Write("R: ");

            string? str = Console.ReadLine();

            if (str == null)
            {
                return "";
            }

            return str;
        }
    }
}

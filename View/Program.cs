using Controllers;
using Models;

namespace View
{
    internal class Program
    {
        static readonly Dictionary<int, Action> options = new()
        {
            { 1, InsertCar },
            { 2, UpdateCar },
            { 3, DeleteCar },
            { 4, () => ListCars(listAll: true) },
            { 5, () => ListCars(listAll: false) }
        };

        static void Main(string[] args)
        {
            while (true)
            {
                int choose = Menu();

                if (choose == 0) break;

                if (options.ContainsKey(choose))
                    options[choose]();
                else
                    Console.WriteLine("Opcao invalida!");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            Console.WriteLine("\n\n***Obrigado por utilizar o sistema!***");
        }


        static int Menu()
        {
            Title("Carros");
            Console.WriteLine("1- Inserir um novo carro");
            Console.WriteLine("2- Atualizar os dados de um carro");
            Console.WriteLine("3- Deletar o registro de um carro");
            Console.WriteLine("4- Listar todos os carros");
            Console.WriteLine("5- Exibir os dados de um carro especifico");
            Console.WriteLine("0- Sair");
            Console.WriteLine($"=================================");

            return ReadInt("Digite sua resposta:");
        }

        static void InsertCar()
        {
            Title("Inserir um novo carro");

            var car = new Car()
            {
                Name = ReadString("Digite o nome do carro."),
                Color = ReadString("Digite a cor do carro."),
                Year = ReadInt("Digite o ano do carro"),
                Insurance = new Insurance()
                {
                    Description = ReadString("Digite a descricao do seguro do carro.")
                }
            };

            Console.WriteLine(new CarController().Insert(car) ? "***Registro inserido***" : "***Erro ao inserir registro***");
        }

        static void UpdateCar()
        {
            Title("Atualizar um carro");

            var car = new Car()
            {
                Id = ReadInt("Digite o id do carro que deseja atualizar."),
                Name = ReadString("Digite o novo nome do carro."),
                Color = ReadString("Digite a nova cor do carro."),
                Year = ReadInt("Digite o novo ano do carro.")
            };

            Console.WriteLine(new CarController().Updade(car) ? "***Registro atualizado***" : "***Erro ao atualizar registro***");
        }

        static void DeleteCar()
        {
            Title("Deletar um carro");

            int id = ReadInt("Digite o id do carro que deseja deletar.");

            Console.WriteLine(new CarController().Delete(id) ? "***Registro deletado***" : "***Erro ao deletar registro***");
        }

        static void ListCars(bool listAll)
        {
            if (listAll)
            {
                Title("Listagem de carros");
                var list = new CarController().GetAll();

                if (list.Count != 0)
                {
                    Console.WriteLine("Nao existem carros cadastrados!");
                    return;
                }

                list.ForEach((c) => { Console.WriteLine(c); });
            }
            else
            {
                Title("Exibir carro especifico");
                int id = ReadInt("Digite o id do carro para busca");

                Car? encontrado = new CarController().Get(id);
                Console.WriteLine(encontrado != null ? "Carro encontrado: " + encontrado : "Carro nao encontrado!");
            }
        }


        static void Title(string title)
        {
            Console.Clear();
            Console.WriteLine($"=====|{title}|=====");
        }

        static int ReadInt(string titulo)
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

        static string ReadString(string titulo)
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

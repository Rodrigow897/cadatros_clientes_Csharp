class Cliente
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
}

class Program
{
    static List<Cliente> listaClientes = new List<Cliente>();
    static int proximoId = 1;

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("=== Cadastro de Clientes ===");
            Console.WriteLine("1 - Adicionar Cliente");
            Console.WriteLine("2 - Listar Clientes");
            Console.WriteLine("3 - Buscar Cliente por Nome");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    AdicionarCliente();
                    break;
                case 2:
                    ListarClientes();
                    break;
                case 3:
                    BuscarClientePorNome();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        } while (opcao != 0);
    }

    static void AdicionarCliente()
    {
        Cliente cliente = new Cliente();
        cliente.Id = proximoId++;

        Console.Write("Nome: ");
        cliente.Nome = Console.ReadLine();

        Console.Write("Email: ");
        cliente.Email = Console.ReadLine();

        Console.Write("Telefone: ");
        cliente.Telefone = Console.ReadLine();

        listaClientes.Add(cliente);

        Console.WriteLine("Cliente adicionado com sucesso!");
    }

    static void ListarClientes()
    {
        if (listaClientes.Count == 0)
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
            return;
        }

        Console.WriteLine("\n--- Lista de Clientes ---");
        foreach (var cliente in listaClientes)
        {
            Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Email: {cliente.Email}, Telefone: {cliente.Telefone}");
        }
    }

    static void BuscarClientePorNome()
    {
        Console.Write("Digite o nome do cliente: ");
        string nomeBusca = Console.ReadLine().ToLower();

        var encontrados = listaClientes.FindAll(c => c.Nome.ToLower().Contains(nomeBusca));

        if (encontrados.Count == 0)
        {
            Console.WriteLine("Nenhum cliente encontrado com esse nome.");
            return;
        }

        Console.WriteLine("\n--- Clientes Encontrados ---");
        foreach (var cliente in encontrados)
        {
            Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Email: {cliente.Email}, Telefone: {cliente.Telefone}");
        }
    }
};
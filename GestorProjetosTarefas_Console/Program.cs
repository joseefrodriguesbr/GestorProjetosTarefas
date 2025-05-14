using GestorProjetosTarefas_Console;

internal class Program
{
    public static Dictionary<string, Empregado> EmpregadoList = new();
    private static void Main(string[] args)
    {
       

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Você chegou no Gestor de Projetos e Tarefas!\n");
            Console.WriteLine("Digite 1 para registrar um empregado");
            Console.WriteLine("Digite 2 para registrar a tarefa de um empregado");
            Console.WriteLine("Digite 3 para mostrar todos os empregados");
            Console.WriteLine("Digite 4 para mostrar as tarefas de um empregado");
            Console.WriteLine("Digite -1 para sair\n");
            Console.WriteLine("Informe sua opção:");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    RegistrarEmpregado();
                    break;
                case 2:
                    RegistrarTarefa();
                    break;
                case 3:
                    ObterEmpregados();
                    break;
                case 4:
                    ObterTarefas();
                    break;
                case -1:
                    Console.Clear();
                    Console.WriteLine("Até mais!");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
            Thread.Sleep(2000);
            Console.Clear();
        }
    }

    private static void ObterTarefas()
    {
        Console.Clear();
        Console.WriteLine("Exibir detalhes do empregado\n");
        Console.Write("Digite o empregado cujas tarefas deseja consultar: ");
        string matricula = Console.ReadLine();
        if (EmpregadoList.ContainsKey(matricula))
        {
            Empregado empregado = EmpregadoList[matricula];
            empregado.showTarefas();
        }
        else Console.WriteLine($"\nO empregado de matrícula {matricula} não foi encontrado");
    }

    private static void ObterEmpregados()
    {
        Console.Clear();
        Console.WriteLine("Lista de empregados:\n");
        foreach (var empregado in EmpregadoList.Values)
        {
            Console.WriteLine(empregado);
        }
    }

    private static void RegistrarTarefa()
    {
        Console.Clear();
        Console.WriteLine("Registro de Tarefas\n");
        Console.Write("Digite o matrícula do empregado cuja categoria deseja registrar: ");
        string matricula = Console.ReadLine();
        if (EmpregadoList.ContainsKey(matricula))
        {
            Empregado empregado = EmpregadoList[matricula];
            Console.Write($"Informe o nome da tarefa do empregado {empregado.Nome}: ");
            string nome = Console.ReadLine();
            Console.Write($"Informe a descrição da tarefa {nome}: ");
            string descricao = Console.ReadLine();
            //Equipment Equipment = EquipmentList[EquipmentName];
            empregado.adicionarTarefas (new Tarefa(nome, descricao));
            Console.WriteLine($"A tarefa {nome} do { empregado.Nome} foi registrada com sucesso!");
        }
        else Console.WriteLine($"\nO empregado de matrícula {matricula} não foi encontrado");
    }

    private static void RegistrarEmpregado()
    {
        Console.Clear();
        Console.WriteLine("Registro de Empregados\n");
        Console.Write("Digite o nome do empregado que deseja registrar: ");
        string nome = Console.ReadLine();
        Console.Write("Digite a matricula do empregado que deseja registrar: ");
        string matricula = Console.ReadLine();
        Empregado empregado = new Empregado(nome, matricula);
        EmpregadoList.Add(matricula, empregado);
        Console.WriteLine($"O empregado {nome} foi registrado com sucesso!");
    }
}
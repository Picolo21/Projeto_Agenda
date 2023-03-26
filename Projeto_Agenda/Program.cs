using Projeto_Agenda.Entities;

internal class Program
{
    private static int Menu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("|".PadRight(56) + "|");
        Console.WriteLine("|\t\t   MENU DE OPÇÕES\t\t        |");
        Console.WriteLine("|".PadRight(56) + "|");
        Console.WriteLine("|\t[1] - Inserir Contato".PadRight(50) + "|");
        Console.WriteLine("|\t[2] - Editar Contato".PadRight(50) + "|");
        Console.WriteLine("|\t[3] - Bloquear Contato".PadRight(50) + "|");
        Console.WriteLine("|\t[4] - Remover Contato".PadRight(50) + "|");
        Console.WriteLine("|\t[5] - Imprimir Contatos".PadRight(50) + "|");
        Console.WriteLine("|\t[6] - Sair".PadRight(50) + "|");
        Console.WriteLine("|".PadRight(56) + "|");
        Console.WriteLine("---------------------------------------------------------");

        Console.WriteLine();
        Console.Write("Escolha uma opção: ");
        int option = int.Parse(Console.ReadLine());
        Console.WriteLine();
        return option;
    }

    private static void Main(string[] args)
    {
        Console.Title = "Agenda de Contatos";

        string contacts = "Contatos.txt";
        string blockedContacts = "Contatos Bloqueados.txt";
        string path = @"C:\Users\" + Environment.UserName + @"\";

        string pathContacts = path + contacts;
        string pathBlockedContacts = path + blockedContacts;

        List<Contact> phoneBook = new List<Contact>();
        int op;

        do
        {
            op = Menu();
            switch (op)
            {
                case 1:
                    InsertContact(pathContacts);
                    break;
                case 2:
                    EditContact(phoneBook, pathContacts);
                    break;
                case 3:
                    phoneBook.Remove(RemoveContact(phoneBook, pathContacts));
                    break;
                case 4:
                    Print(phoneBook, pathContacts);
                    do
                    {
                        Console.WriteLine("Aperte ENTER para voltar ao MENU DE OPÇÕES");
                    } while (Console.ReadKey().Key != ConsoleKey.Enter);
                    break;
                case 5:

                    break;
                case 6:
                    Exit();
                    break;
                default:
                    InvalidOption();
                    break;
            }
        } while (op != 6);
    }

    private static void InsertContact(string path)
    {
        Console.Clear();
        Console.Write("Digite o nome do novo contato: ");
        string name = Console.ReadLine();
        Console.Write("Digite o número do novo contato: ");
        string phone = Console.ReadLine();
        Console.WriteLine();
        Contact contact = new Contact(name, phone);
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(contact.ToStringFile());
        }
        Console.Clear();
        Console.WriteLine("Contato salvo com sucesso!");
        Thread.Sleep(3000);
    }

    private static void EditContact(List<Contact> phoneBook, string pathContacts)
    {
        Console.Clear();
        PrintAllContacts(phoneBook, pathContacts);
        Console.Write("Digite o nome do contato que deseja editar: ");
        string name = Console.ReadLine();
        Console.WriteLine();
        foreach (Contact x in phoneBook)
        {
            if (x.Name.Equals(name))
            {
                int op;
                do
                {
                    op = EditMenu();
                    switch (op)
                    {
                        case 1:
                            x.EditAll();
                            break;
                        case 2:
                            x.LivesAt.EditAllAddress();
                            break;
                        case 3:
                            x.EditName();
                            break;
                        case 4:
                            x.EditPhone();
                            break;
                        case 5:
                            x.EditEmail();
                            break;
                        case 6:
                            x.LivesAt.EditStreet();
                            break;
                        case 7:
                            x.LivesAt.EditCity();
                            break;
                        case 8:
                            x.LivesAt.EditState();
                            break;
                        case 9:
                            x.LivesAt.EditPostalCode();
                            break;
                        case 10:
                            x.LivesAt.EditCountry();
                            break;
                        case 11:
                            break;
                        default:
                            InvalidOption();
                            break;
                    }
                } while (op != 11);
            }
        }
    }

    private static Contact RemoveContact(List<Contact> phoneBook, string pathContacts)
    {
        Console.Clear();
        PrintAllContacts(phoneBook, pathContacts);
        Console.Write("Digite o nome do contato que deseja excluir: ");
        string name = Console.ReadLine();
        foreach (Contact x in phoneBook)
        {
            if (x.Name.Equals(name))
            {
                return x;
            }
        }
        return null;
    }

    private static void Exit()
    {
        Console.Clear();
        Console.WriteLine("Agenda Fechada!");
    }

    private static void InvalidOption()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Opção inválida. Por favor aperte ENTER para selecionar novamente uma opção válida");
        } while (Console.ReadKey().Key != ConsoleKey.Enter);
    }

    private static int PrintMenu()
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine("|".PadRight(64) + "|");
        Console.WriteLine("|                 MENU DE OPÇÕES PARA IMPRESSÃO".PadRight(64) + "|");
        Console.WriteLine("|".PadRight(64) + "|");
        Console.WriteLine("|   " + "[1] - Imprimir todos os contatos".PadRight(60) + "|");
        Console.WriteLine("|   " + "[2] - Imprimir todos os contatos por ordem alfabética".PadRight(60) + "|");
        Console.WriteLine("|   " + "[3] - Imprimir contatos por letra escolhida".PadRight(60) + "|");
        Console.WriteLine("|   " + "[4] - Retornar ao Menu Principal".PadRight(60) + "|");
        Console.WriteLine("|".PadRight(64) + "|");
        Console.WriteLine("-----------------------------------------------------------------\n");
        Console.Write("Escolha a opção que deseja editar no contato selecionado: ");
        int option = int.Parse(Console.ReadLine());
        return option;
    }

    private static int EditMenu()
    {
        Console.Clear();
        Console.WriteLine("MENU DE OPÇÕES PARA EDIÇÃO\n");
        Console.WriteLine("[1] - Editar todos os dados do contato");
        Console.WriteLine("[2] - Editar todos os dados de endereço do contato");
        Console.WriteLine("[3] - Editar Nome");
        Console.WriteLine("[4] - Editar Telefone");
        Console.WriteLine("[5] - Editar E-mail");
        Console.WriteLine("[6] - Editar Endereço");
        Console.WriteLine("[7] - Editar Cidade");
        Console.WriteLine("[8] - Editar Estado");
        Console.WriteLine("[9] - Editar CEP");
        Console.WriteLine("[10] - Editar País");
        Console.WriteLine("[11] - Retornar ao Menu Principal\n");
        Console.Write("Escolha a opção que deseja editar no contato selecionado: ");
        int option = int.Parse(Console.ReadLine());
        return option;
    }

    private static void PrintPhoneBookByLetter(List<Contact> phoneBook)
    {
        Console.Clear();
        List<Contact> phoneBookByLetter = new List<Contact>();
        Console.Write("Escolha uma letra para imprimir a lista: ");
        char choice = char.Parse(Console.ReadLine().ToLower());
        Console.Clear();
        foreach (Contact x in phoneBook)
        {
            if (x.Name.ToLower()[0] == choice)
            {
                phoneBookByLetter.Add(x);
            }
        }
        foreach (Contact x in phoneBookByLetter)
        {
            Console.Write(x.ToString() + "\n");
        }
    }

    private static void PrintInAlphabeticalOrder(List<Contact> phoneBook)
    {
        Console.Clear();
        List<Contact> sortedPhoneBook = new List<Contact>();
        sortedPhoneBook = phoneBook.OrderBy(x => x.Name).ToList();
        foreach (Contact x in sortedPhoneBook)
        {
            Console.WriteLine(x.ToString());
        }
    }

    private static void PrintAllContacts(List<Contact> phoneBooks, string pathContacts)
    {
        Console.Clear();
        if (File.Exists(pathContacts))
        {
            using (StreamReader sr = new StreamReader(pathContacts))
            {
                do
                {
                    string[] text = sr.ReadLine().Split(';');
                    phoneBooks.Add(new Contact(text[0], text[1]));
                } while (!sr.EndOfStream);
            }
        }
    }

    private static void Print(List<Contact> phoneBook, string pathContacts)
    {
        int op;
        do
        {
            op = PrintMenu();
            switch (op)
            {
                case 1:
                    PrintAllContacts(phoneBook, pathContacts);
                    break;
                case 2:
                    PrintInAlphabeticalOrder(phoneBook);
                    break;
                case 3:
                    PrintPhoneBookByLetter(phoneBook);
                    break;
                case 4:
                    break;
                default:
                    InvalidOption();
                    break;
            }
        } while (op != 4);
    }
}
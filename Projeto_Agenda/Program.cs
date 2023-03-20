using Projeto_Agenda.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Title = "Agenda de Contatos";

        List<Contact> phoneBook = new List<Contact>();
        int op;

        do
        {
            op = Menu();
            switch (op)
            {
                case 1:
                    phoneBook.Add(InsertContact());
                    break;
                case 2:
                    EditContact();
                    break;
                case 3:
                    phoneBook.Remove(RemoveContact());
                    break;
                case 4:
                    Print();
                    do
                    {
                        Console.WriteLine("Aperte ENTER para voltar ao MENU DE OPÇÕES");
                    } while (Console.ReadKey().Key != ConsoleKey.Enter);
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    InvalidOption();
                    break;
            }
        } while (op != 5);

        int Menu()
        {
            Console.Clear();
            Console.WriteLine("MENU DE OPÇÕES\n");
            Console.WriteLine("[1] - Inserir Contato");
            Console.WriteLine("[2] - Editar Contato");
            Console.WriteLine("[3] - Remover Contato");
            Console.WriteLine("[4] - Imprimir Agenda de Contatos");
            Console.WriteLine("[5] - Sair\n");
            Console.Write("Escolha uma opção: ");
            int option = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return option;
        }

        Contact InsertContact()
        {
            Console.Clear();
            Console.Write("Digite o nome do novo contato: ");
            string name = Console.ReadLine();
            Console.Write("Digite o número do novo contato: ");
            string phone = Console.ReadLine();
            Console.WriteLine();
            Contact contact = new Contact(name, phone);
            return contact;
        }

        void EditContact()
        {
            Console.Clear();
            PrintAllContacts();
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

        Contact RemoveContact()
        {
            Console.Clear();
            PrintAllContacts();
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


        void Exit()
        {
            Console.Clear();
            Console.WriteLine("Agenda Fechada!");
        }

        void InvalidOption()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Opção inválida. Por favor aperte ENTER para selecionar novamente uma opção válida");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
        }

        int EditMenu()
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

        int PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("MENU DE OPÇÕES PARA IMPRESSÃO\n");
            Console.WriteLine("[1] - Imprimir todos os contatos");
            Console.WriteLine("[2] - Imprimir todos os contatos por ordem alfabética");
            Console.WriteLine("[3] - Imprimir contatos por letra escolhida");
            Console.WriteLine("[4] - Retornar ao Menu Principal\n");
            Console.Write("Escolha a opção que deseja editar no contato selecionado: ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

        void Print()
        {
            do
            {
                int op = PrintMenu();
                switch (op)
                {
                    case 1:
                        PrintAllContacts();
                        break;
                    case 2:
                        PrintInAlphabeticalOrder();
                        break;
                    case 3:
                        PrintPhoneBookByLetter();
                        break;
                    case 4:
                        break;
                    default:
                        InvalidOption();
                        break;
                }
            } while (op != 4);
        }

        void PrintAllContacts()
        {
            Console.Clear();
            foreach (Contact x in phoneBook)
            {
                Console.WriteLine(x.ToString());
            }
        }

        void PrintInAlphabeticalOrder()
        {
            Console.Clear();
            List<Contact> sortedPhoneBook = new List<Contact>();
            sortedPhoneBook = phoneBook.OrderBy(x => x.Name).ToList();
            foreach (Contact x in sortedPhoneBook)
            {
                Console.WriteLine(x.ToString());
            }
        }

        void PrintPhoneBookByLetter()
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
    }
}
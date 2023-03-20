using Projeto_Agenda.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Title = "Agenda de Contatos";

        List<Contact> phonebook = new List<Contact>();
        int op;

        do
        {
            op = Menu();
            switch (op)
            {
                case 1:
                    phonebook.Add(InsertContact());
                    break;
                case 2:
                    EditContact();
                    break;
                case 3:
                    phonebook.Remove(RemoveContact());
                    break;
                case 4:
                    PrintContacts();
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
            PrintContacts();
            Console.Write("Digite o nome do contato que deseja editar: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            foreach (Contact x in phonebook)
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
                                x.LivesAt.EditStreet();
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
            PrintContacts();
            Console.Write("Digite o nome do contato que deseja excluir: ");
            string name = Console.ReadLine();
            foreach (Contact x in phonebook)
            {
                if (x.Name.Equals(name))
                {
                    return x;
                }
            }
            return null;
        }

        void PrintContacts()
        {
            Console.Clear();
            foreach (Contact x in phonebook)
            {
                Console.WriteLine(x.ToString());
            }
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
            Console.WriteLine("[2] - Imprimir contatos por ordem alfabética");
            Console.WriteLine("[3] - Imprimir contatos por letra escolhida");
            Console.WriteLine("[4] - Retornar ao Menu Principal\n");
            Console.Write("Escolha a opção que deseja editar no contato selecionado: ");
            int option = int.Parse(Console.ReadLine());
        }
    }
}
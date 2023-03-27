namespace Projeto_Agenda.Entities
{
    internal class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Address LivesAt { get; set; }

        public Contact(string name, string phone)
        {
            Name = name;
            Phone = phone;
            LivesAt = new Address();
        }

        public Contact(string name, string phone, string email, string street, string city, string state, string postalCode, string country)
        {
            Name = name;
            Phone = phone;
            Email = email;
            LivesAt = new Address(street, city, state, postalCode, country);
        }

        public void EditAll()
        {
            Console.Clear();
            Console.Write("Digite o novo nome do contato: ");
            string name = Console.ReadLine();
            Name = name;
            Console.Write("Digite o novo telefone do contato: ");
            string phone = Console.ReadLine();
            Phone = phone;
            Console.Write("Digite o novo email do contato: ");
            string email = Console.ReadLine();
            Email = email;
            Console.Write("Digite o novo endereço do contato: ");
            string street = Console.ReadLine();
            LivesAt.Street = street;
            Console.Write("Digite a nova cidade do contato: ");
            string city = Console.ReadLine();
            LivesAt.City = city;
            Console.Write("Digite o novo estado do contato: ");
            string state = Console.ReadLine();
            LivesAt.State = state;
            Console.Write("Digite o novo CEP do contato: ");
            string postalCode = Console.ReadLine();
            LivesAt.PostalCode = postalCode;
            Console.Write("Digite o novo país do contato: ");
            string country = Console.ReadLine();
            LivesAt.Country = country;
        }

        public void EditName()
        {
            Console.Clear();
            Console.Write("Digite o novo nome do contato: ");
            string name = Console.ReadLine();
            Name = name;
        }

        public void EditPhone()
        {
            Console.Clear();
            Console.Write("Digite o novo telefone do contato: ");
            string phone = Console.ReadLine();
            Phone = phone;
        }

        public void EditEmail()
        {
            Console.Clear();
            Console.Write("Digite o novo email do contato: ");
            string email = Console.ReadLine();
            Email = email;
        }

        public string ToStringFile()
        {
            return $"{Name};{Phone};{Email};{LivesAt.Street};{LivesAt.City};{LivesAt.State};{LivesAt.PostalCode};{LivesAt.Country}";
        }

        public override string ToString()
        {
            return $"Nome: {Name}\nTelefone: {Phone}\n{LivesAt.ToString()}";
        }
    }
}

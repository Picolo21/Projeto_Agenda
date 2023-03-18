namespace Projeto_Agenda.Entities
{
    internal class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Address()
        {
        }

        public void EditAllAddress()
        {
            Console.Clear();
            Console.Write("Digite o novo endereço do contato: ");
            string street = Console.ReadLine();
            Street = street;
            Console.Write("Digite a nova cidade do contato: ");
            string city = Console.ReadLine();
            City = city;
            Console.Write("Digite o novo estado do contato: ");
            string state = Console.ReadLine();
            State = state;
            Console.Write("Digite o novo CEP do contato: ");
            string postalCode = Console.ReadLine();
            PostalCode = postalCode;
            Console.Write("Digite o novo país do contato: ");
            string country = Console.ReadLine();
            Country = country;
        }

        public void EditStreet()
        {
            Console.Clear();
            Console.Write("Digite o novo endereço do contato: ");
            string street = Console.ReadLine();
            Street = street;
        }

        public void EditCity()
        {
            Console.Clear();
            Console.Write("Digite a nova cidade do contato: ");
            string city = Console.ReadLine();
            City = city;
        }

        public void EditState()
        {
            Console.Clear();
            Console.Write("Digite o novo estado do contato: ");
            string state = Console.ReadLine();
            State = state;
        }

        public void EditPostalCode()
        {
            Console.Clear();
            Console.Write("Digite o novo CEP do contato: ");
            string postalCode = Console.ReadLine();
            PostalCode = postalCode;
        }

        public void EditCountry()
        {
            Console.Clear();
            Console.Write("Digite o novo país do contato: ");
            string country = Console.ReadLine();
            Country = country;
        }

        public override string ToString()
        {
            return "Endereço: " + Street + "\nCidade: " + City + "\nEstado: " + State + "\nCEP: " + PostalCode + "\nPaís: " + Country + "\n";
        }
    }
}

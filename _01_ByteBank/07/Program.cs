using System;

using _05_;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("07");

            //ContaCorrente conta = new ContaCorrente();
            Cliente cliente = new Cliente();
            cliente.nome = "Gabriela";
            cliente.cpf = "353.458.868-14";

            ContaCorrente conta = new ContaCorrente(09876, 768);
            Console.WriteLine(conta.Numero);

            ContaCorrente.TotalDeContasCriadas;
            
            Console.ReadKey();
        }
    }
}

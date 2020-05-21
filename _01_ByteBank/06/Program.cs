using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("06!");

            ContaCorrente conta = new ContaCorrente();
            Cliente cliente = new Cliente;
            cliente.nome = "gabriela";
            cliente.cpf = "125463";

                conta.titular = cliente;
                conta.Saldo = 1000;
                Console.WriteLine(conta.Saldo);

            Console.ReadKey();
        }
    }
}

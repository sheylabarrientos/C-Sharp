using System;

namespace _02_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("02!");

            ContaCorrente conta = new ContaCorrente();

            conta.titular = "Gabriela";
            Console.WriteLine("Saldo : " + conta.saldo);
            Console.WriteLine("Agencia :" + conta.agencia);
            
            conta.saldo    
         

            Console.ReadKey();
        }
    }
}

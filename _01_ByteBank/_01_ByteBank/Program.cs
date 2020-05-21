using System;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("01 Byte Bank!");

            

            //instancia
            ContaCorrente contaGabriela = new ContaCorrente();

            contaGabriela.titular = "Gabriela";
            contaGabriela.agencia = 789;
            contaGabriela.numero = 987600;
            contaGabriela.saldo = 100;

            contaGabriela.saldosaldo + 100;

            Console.WriteLine("Saldo atual : " + contaGabriela.saldo);
            Console.WriteLine(contaGabriela.titular);



            Console.ReadKey();
    
        }
    }
}

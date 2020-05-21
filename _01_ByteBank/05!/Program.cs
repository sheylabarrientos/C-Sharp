using System;

namespace _05_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("05!");

            Cliente gabriela = new Cliente();
            gabriela.nome = "Gabriela";
            gabriela.cpf = "353.458.868-14";


            ContaCorrente contaGabriela = new ContaCorrente();

            //contaGabriela.titular = gabriela

            contaGabriela.saldo = 500;
            contaGabriela.agencia = 8790;
            contaGabriela.numero = 94984;
            if(contaGabriela.titular == null)
        {
            Console.WriteLine("Ops a referencia ek conta.titular é NULL");
        }

            Console.ReadKey();
        }
    }
}

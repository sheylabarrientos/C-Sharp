using System;

namespace _04_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("4!");

            ContaCorrente contaBruna = new ContaCorrente();
            contaBruna.titular = "Bruna";

            Console.WriteLine(contaBruna.saldo);

            bool resultadoSaque = contaBruna.Sacar(9000);
            Console.WriteLine("Resposta metodo sacar: " + resultadoSaque);
            Console.WriteLine("Saldo após saque: " + contaBruna.saldo);

            contaBruna.Depositar(500);
            Console.WriteLine("")

            ContaCorrente contaGabriela = new ContaCorrente();
            Console.WriteLine("saldo bruna: " + contaBruna.saldo);
            Console.WriteLine("saldo gabriela: " + contaGabriela.saldo);

            bool resultadoTranferencia = contaBruna.Transferir(400, contaGabriela);
            Console.WriteLine("Resultado da transferencia: " + resultadoTranferencia);
            Console.WriteLine("saldo bruna apos transf : " + contaBruna.saldo);
            Console.WriteLine("saldo gabriela apos transf: " + contaGabriela.saldo);


            contaGabriela.titular = "Gabriela";


            Console.ReadKey();

        }
    }
}

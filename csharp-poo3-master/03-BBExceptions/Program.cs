using System;

namespace _03_BBExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("03!");


            try
            {
                ContaCorrente conta2 = new ContaCorrente(425, 5354);
                ContaCorrente conta = new ContaCorrente(22323, 3232);

                conta2.Depositar(50);
                Console.WriteLine("Saldo após depósito: " + conta2.Saldo);
                
                //conta2.Sacar(5);
                //Console.WriteLine("Saldo após saque: " + conta2.Saldo);
                
                conta2.Transferir(3000, conta);
                Console.WriteLine("Saldo após transferência: " + conta2.Saldo);

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Argumento com problema: " + e.ParamName);
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException");
            }
            catch (SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Saldo);
                Console.WriteLine(e.ValorSaque);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine(e.Message);
                Console.WriteLine("Ocorreu uma exceção do tipo SaldoInsuficienteException");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine(e.StackTrace);

                //exceção interna (erro original) - fica dentro dessa exceção de fora - contém informações que queremos exibir
                Console.WriteLine("Informações da Inner Exception - exceção interna: ");
                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }

            Console.ReadKey();
        }
    }
}

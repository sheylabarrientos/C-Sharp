using System;

namespace _01_BBExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ByteBank Exceptions!");


            ContaCorrente conta = new ContaCorrente(867, 86712540);
            //propriedade somente leitura
            //conta.Agencia = 982;
            Console.WriteLine(conta.Agencia);
            Console.WriteLine(conta.Numero);



            //try
            //{
            //    ContaCorrente conta2 = new ContaCorrente(45, 0);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            try
            {
                ContaCorrente conta2 = new ContaCorrente(45, 0);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Argumento com problema: " + e.ParamName);
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            Console.ReadKey();
        }
    }
}

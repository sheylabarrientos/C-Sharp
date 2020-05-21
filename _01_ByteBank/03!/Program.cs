using System;

namespace _03_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("03!");


            //tipo de referencia - guarda o endereço do objeto
            ContaCorrente contaGabriela = new ContaCorrente();

            contaGabriela.titular = "Gabriela";
            contaGabriela.agencia = 876;
            contaGabriela.numero = 589682;
            contaGabriela.saldo = 500;

            ContaCorrente contaGabrielaCosta = new ContaCorrente();

            contaGabrielaCosta.titular = "Gabriela";
            contaGabrielaCosta.agencia = 876;
            contaGabrielaCosta.numero = 589682;
            contaGabrielaCosta.saldo = 500;

            Console.WriteLine("Igualdade de tipo referecia" + contaGabriela == contaGabrielaCosta);
            Console.WriteLine("Igualdade de tipo valor - campo da classe" + contaGabriela.numero == contaGabrielaCosta.numero);

            //tipo de valor
            int idade = 27;
            int idadeDeNovo = 27;
            Console.WriteLine("igualdade de tipo valor" + idade == idadeDeNovo);

            contaGabriela = contaGabrielaCosta;
            Console.WriteLine(contaGabriela == contaGabrielaCosta);

            contaGabriela.saldo = 300;
            Console.WriteLine(contaGabriela.saldo);
            Console.WriteLine(contaGabrielaCosta.saldo);

            if (contaGabrielaCosta.saldo >= 100)
            {
                contaGabrielaCosta.saldo -= 100;
            }          
         


            Console.ReadKey();

      
        }
    }
}

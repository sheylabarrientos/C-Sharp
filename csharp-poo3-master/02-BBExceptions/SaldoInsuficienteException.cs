using System;
using System.Collections.Generic;
using System.Text;

namespace _02_BBExceptions
{
    //public class SaldoInsuficienteException
    //Nao podemos gerar exceção que nao faz parte dessa hierarquia
    //Boas práticas Construtor com parâmetro de mensagem, Construtor sem parâmetros, Sufixo Exception no nome da classe.
    public class SaldoInsuficienteException : Exception
    {
        public double Saldo { get; }
        public double ValorSaque { get; }

        public SaldoInsuficienteException()
        {

        }
        public SaldoInsuficienteException(string mensagem) : base(mensagem)
        {
        }
        public SaldoInsuficienteException(double saldo, double valorSaque)
           : this("Tentativa de saque do valor de " + valorSaque + " em uma conta com saldo de " + saldo)
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
    }
}

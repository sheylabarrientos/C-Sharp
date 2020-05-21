using System;
using System.Collections.Generic;
using System.Text;

namespace _04_BBExceptions
{
    //o saldo insufiente é uma operação financeira
    //public class SaldoInsuficienteException : Exception
    public class SaldoInsuficienteException : OperacaoFinanceiraException
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

        public SaldoInsuficienteException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }
}

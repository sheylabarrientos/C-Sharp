
using System;

namespace _02_BBExceptions
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }
        public static int TotalDeContasCriadas { get; private set; }
        public int Agencia { get; }
        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0 )
            {
                throw new ArgumentException("A agencia deve ser maior que 0.", nameof(agencia));
            }
            if (numero <= 0)
            {
                throw new ArgumentException("O numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
        }


        //public bool Sacar(double valor)
        public void Sacar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor inválido para saque", nameof(valor));
            }

            //msdn exception 
            if (_saldo < valor)
            {
                //return false;
                //Exceção especifica para nossas regras de negocio
                //throw new SaldoInsuficienteException();
                //throw new SaldoInsuficienteException("Saldo insuficiente para saque no valor de: " + valor);
                throw new SaldoInsuficienteException(_saldo, valor);
            }

            _saldo -= valor;
            //return true;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        //public bool Transferir(double valor, ContaCorrente contaDestino)
        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            //if (_saldo < valor)
            //{
            //    return false;
            //}

            if (valor <= 0)
            {
                throw new ArgumentException("Valor inválido para transferência", nameof(valor));
            }

            Sacar(valor);
            contaDestino.Depositar(valor);
            //return true;
        }
    }
}

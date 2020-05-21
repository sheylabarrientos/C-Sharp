
using System;

namespace _03_BBExceptions
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }
        public static int TotalDeContasCriadas { get; private set; }
        public static int ContadorSaquesNaoPermitidos { get; private set; }
        public static int ContadorTransferenciasNaoPermitidas { get; private set; }
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

        public void Sacar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor inválido para saque", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(_saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {

            if (valor <= 0)
            {
                //ContadorTransferenciasNaoPermitidas++;
                throw new ArgumentException("Valor inválido para transferência", nameof(valor));
            }

            try
            {
                Sacar(valor);

            }
            //Stack Trace para de ser preenchido ao manipula-lo
            catch (SaldoInsuficienteException e)
            {
                ContadorTransferenciasNaoPermitidas++;
                //para propagar a exceção adianta
                //preenchimento do StackTrace
                //throw e;

                //dentro do contexto de catch não é necessário instanciar a exceção
                //throw ;

                //exceção interna (erro original) - fica dentro dessa exceção de fora - contém informações que queremos exibir
                throw new Exception("Operação não realizada.", e);
            }
            contaDestino.Depositar(valor);
        }
    }
}

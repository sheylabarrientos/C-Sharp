
using System;

namespace _01_BBExceptions
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }
        public static int TotalDeContasCriadas { get; private set; }

        //setados uma unica vez
        //private int _agencia;
        //public int Agencia
        //{
        //    get
        //    {
        //        return _agencia;
        //    }
        //    private set
        //    {
        //        if(value <= 0)
        //        {
        //            return;
        //        }

        //        _agencia = value;
        //    }
        //}

        //setados uma unica vez
        //public int Numero { get; private set; }

        //propriedades somente leitura (só o get)  são alteradas apenas no construtor e não nos metodos
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
            //if(agencia <= 0 || numero <= 0)
            //{
            //    //queremos lançar uma exceção
            //    //Console.WriteLine(Titular.Nome);

            //    //não é permitido modificar a propriedade Messagem pois é uma propriedade somente leitura porém a classe exception aceita alterar pelo construtor
            //    Exception excesao = new Exception();
            //    //excesao.Message = "A agencia e o numero devem ser maiores que 0";

            //    //throw só funciona no bloco catch, porém ao instanciar um objeto tipo Exception ele funciona
            //    //throw new Exception("A agencia e o numero devem ser maiores que 0");

            //    throw new ArgumentException("A agencia e o numero devem ser maiores que 0");
            //}

            //Casos pontuais se não é dificil gerenciar
            //if (agencia <= 0 && numero <= 0)
            //{
            //    throw new ArgumentException("A agencia e o numero devem ser maiores que 0");
            //}

            if (agencia <= 0 )
            {
                //resolver o problema de argumentos quando se referem a um parametro
                //nameof - operador no qual passamos a variavel/classe/argumento e nos devolve a string com nome, não aceita valores literais
                //throw new ArgumentException("A agencia deve ser maior que 0.", "agencia");
                throw new ArgumentException("A agencia deve ser maior que 0.", nameof(agencia));

            }
            if (numero <= 0)
            {
                //throw new ArgumentException("O numero deve ser maior que 0.", "numero");
                throw new ArgumentException("O numero deve ser maior que 0.", nameof(numero));

            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
        }


        public bool Sacar(double valor)
        {

            //Agencia = 23;
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}

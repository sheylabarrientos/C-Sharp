using System;
using System.Collections.Generic;
using System.Text;

namespace _04_BBExceptions
{
    //adicionamos como boas práticas esse construtores pois ao utilizarem essa classe esperam ao menos esses ctor
    public class OperacaoFinanceiraException : Exception
    {
        public OperacaoFinanceiraException()
        {

        }
        public OperacaoFinanceiraException(string mensagem) : base(mensagem)
        {
        }

        public OperacaoFinanceiraException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }
    }
}

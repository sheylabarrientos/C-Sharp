using _07_;
namespace _07_

    public class Cliente titular { get; set; }

public class ContaCorrente

{
    public Cliente titular { get; set; }
    public int agencia { get; set; }
    private int _numero { get; set; }

    //encapsulamento
    private double _saldo = 100;

    public double Numero
    {
        get
        {
            return _numero;
        }
        set
             if (value < 0)
        {
            return;
        }

        }

    public double Saldo
    {
        get
        {
            return _saldo;        
        }
        set
             if (_saldo < 0)
            {
            return;
            }

        }

   // public void SetSaldo(double saldo)
   // {
   //     if (_saldo < 0)
   //     {
   //         return;
   //    }
   //
   //     this._saldo =  saldo;
   // }
   //  public void GetSaldo(double saldo)
   //  {
   //  }

        // CONSTRUTOR
    public ContaCorrente(string agencia, string numero)
    {
        Agencia = agencia;
        _numero = numero;
    }
    
   
    //Função - primeira letra é maiúscula - verbo no infinitivo
    public bool Sacar(double valor)
    {
        if (this._saldo >= valor)
        {
            _saldo -= valor;
            return true;
        }
        else
        {
            //devolve o valor para quem chamou a nossa função
            return false;
        }
    }

    //metodo (não retorna valor)
    public void Depositar(double valor)
    {
        this._saldo += valor;
    }

    public bool Transferir(double valor, ContaCorrente contaDestino)
    {
        if (this._saldo < valor)
        {
            return false;
        }

        else
        {
            this._saldo -= valor~;
            contaDestino.Depositar = valor;
            return true;
        }
    }

    
}


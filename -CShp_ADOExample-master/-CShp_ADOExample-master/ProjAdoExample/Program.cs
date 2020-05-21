using System;

namespace ProjAdoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ADO.NET EXAMPLE!");

            GravarUsandoAdoNet();
            Console.ReadKey();
        }
        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}

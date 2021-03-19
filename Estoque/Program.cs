using Estoque.Entities;
using System;
using System.Globalization;
using System.IO;

namespace Estoque
{
    class Program
    {
        static void Main(string[] args)
        {
            string CaminhoArquivo = @"C:\Windows\Temp\estoque.txt";
            Console.WriteLine("Qual função você deseja? (1/2/3)");
            Console.WriteLine("1 - Adicionar, 2 - mostrar e 3 - remover.");
            int func = int.Parse(Console.ReadLine());
            if (func == 1)
            {
                Console.WriteLine("A adição de produtos é feita da seguinte forma:");
                Console.WriteLine("Nome,Quantidade,Preço");
                Console.WriteLine("Exemplo: Shampoo,2,43.50");
                StreamWriter func1;
                func1 = File.CreateText(CaminhoArquivo);
                Console.Write("Quantos produtos você quer adicionar? ");
                int n = int.Parse(Console.ReadLine());
                func1.WriteLine("Estoque / Dia:" + DateTime.Now);
                func1.WriteLine("");
                for (int i = 0; i < n; i++)
                {                    
                    string[] prod = Console.ReadLine().Split(',');
                    string nome = prod[0];
                    int quantidade = int.Parse(prod[1]);
                    double preco = double.Parse(prod[2], CultureInfo.InvariantCulture);
                    Produto produto = new Produto(nome, quantidade, preco);
                    func1.WriteLine(produto);
                }
                func1.Close();
            }
        }
    }
}

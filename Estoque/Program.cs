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
            else if (func == 2)
            {
                StreamReader func2;
                func2 = File.OpenText(CaminhoArquivo);
                string[] linhas = File.ReadAllLines(CaminhoArquivo);
                foreach (string linha in linhas)
                {
                    Console.WriteLine(linha);
                }
                func2.Close();
            }
            else if (func == 3)
            {
                Console.WriteLine("ATENÇÃO");
                Console.WriteLine("DIGITAR SIM NA PRÓXIMA LINHA FARÁ COM QUE TODO O ARQUIVO SEJA APAGADO.");
                Console.WriteLine("VOCÊ TEM CERTEZA?");
                string pergunta = Console.ReadLine();
                if (pergunta == "SIM" || pergunta == "sim")
                {
                    File.Delete(CaminhoArquivo);
                    Console.WriteLine("Arquivo apagado. " + "Caminho: " + CaminhoArquivo);
                }
                else
                {
                    Console.WriteLine("O arquivo não foi apagado.");
                }

                Console.WriteLine("");

                string caminho1 = @"C:\Windows\Temp\estoqueAtualizado.txt";
                File.Copy(CaminhoArquivo, caminho1);
                Console.WriteLine("Qual produto deve ser apagado? ");
                string apagar = Console.ReadLine();

                string line = null;
                string line_to_delete = apagar;

                using (StreamReader reader = new StreamReader(CaminhoArquivo))
                {
                    using (StreamWriter writer = new StreamWriter(caminho1))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (String.Compare(line, line_to_delete) == 0)
                                continue;

                            writer.WriteLine(line);
                        }
                    }
                }

            }
            Console.WriteLine("");
            Console.WriteLine("Sistema de estoque encerrado.");
            Console.WriteLine("");
            Console.WriteLine("Você deseja iniciar novamente o programa? (SIM/NÃO)");
            string confsn = Console.ReadLine();
            if (confsn == "sim" || confsn == "SIM")
            {
                Console.WriteLine("Reiniciando programa.");
                Main(args);
            }
            Console.WriteLine("Encerrando programa. ");
        }
    }
}

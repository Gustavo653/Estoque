using System;
using System.Collections.Generic;
using System.Text;

namespace Estoque.Entities
{
    class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, int quantidade, double preco)
        {
            Nome = nome;
            Quantidade = quantidade;
            Preco = preco;
        }

        public double Total()
        {
            return Preco * Quantidade;
        }

        public override string ToString()
        {
            return "Produto: " + Nome + ", quantidade: " + Quantidade + ", valor unitário: " + Preco + ", valor total: " + Total();
        }
    }
}

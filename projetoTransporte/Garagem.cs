using System;
using System.Collections.Generic;
using System.Text;

namespace projetoTransporte
{
    internal class Garagem
    {
        private int id;
        private string local;
        private Stack<Veiculo> veiculos = new Stack<Veiculo>();

        public int Id { get => id; set => id = value; }
        public string Local { get => local; set => local = value; }
        internal Stack<Veiculo> Veiculos { get => veiculos; set => veiculos = value; }

        public Garagem(int id, string local)
        {
            this.Id = id;
            this.Local = local;
        }

        public Veiculo GetVeiculo()
        {
            return veiculos.Pop();
        }

        public int QtdeVeiculos()
        {
            return Veiculos.Count;
        }

        public int PotencialDeTransporte()
        {
            int potencial = 0;

            foreach(Veiculo veiculo in Veiculos)
            {
                potencial += veiculo.Lotacao;
            }

            return potencial;
        }

        public void ListarVeiculos()
        {
            Console.Clear();
            Console.WriteLine($"\n\nQuantidade de veiculos na garagem {Id}: {QtdeVeiculos()}");
            Console.WriteLine($"Potencial de transporte: {PotencialDeTransporte()}");

            Console.WriteLine("Listando Veiculos:");
            foreach (Veiculo veiculo in veiculos)
            {
                Console.WriteLine($"\nid: {veiculo.Id}");
                Console.WriteLine($"placa: {veiculo.Placa}");
                Console.WriteLine($"lotacao: {veiculo.Lotacao}");
            }
            Console.WriteLine("===============================================\n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace projetoTransporte
{
    internal class Viagem
    {
        private int id;
        private Garagem origem;
        private Garagem destino;
        private Veiculo veiculo;

        public Viagem(int id, Garagem origem, Garagem destino, Veiculo veiculo)
        {
            this.id = id;
            this.origem = origem;
            this.destino = destino;
            this.veiculo = veiculo;
        }

        public int Id { get => id; set => id = value; }
        internal Garagem Origem { get => origem; set => origem = value; }
        internal Garagem Destino { get => destino; set => destino = value; }
        internal Veiculo Veiculo { get => veiculo; set => veiculo = value; }
    }
}

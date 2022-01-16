using System;
using System.Collections.Generic;
using System.Text;

namespace projetoTransporte
{
    internal class Transporte
    {
        private Veiculo veiculo;
        private int qtdeTransportada;

        public Transporte(Veiculo veiculo, int qtdeTransportada)
        {
            this.QtdeTransportada = qtdeTransportada;
            this.Veiculo = veiculo;
        }

        public int QtdeTransportada { get => qtdeTransportada; set => qtdeTransportada = value; }
        internal Veiculo Veiculo { get => veiculo; set => veiculo = value; }
    }
}

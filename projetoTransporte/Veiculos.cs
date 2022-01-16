using System;
using System.Collections.Generic;
using System.Text;

namespace projetoTransporte
{
    internal class Veiculos
    {
        private List<Veiculo> veiculos = new List<Veiculo>();

        internal List<Veiculo> VeiculosList { get => veiculos; set => veiculos = value; }

        public void incluir (Veiculo veiculo)
        {
            VeiculosList.Add(veiculo);
        }
        public int QtVeiculos()
        {
            return veiculos.Count;
        }
    }
}

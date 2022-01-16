using System;
using System.Collections.Generic;
using System.Text;

namespace projetoTransporte
{
    internal class Veiculo
    {
        private int id;
        private string placa;
        private int lotacao;

        public Veiculo(int id, string placa, int lotacao)
        {
            this.id = id;
            this.placa = placa;
            this.Lotacao = lotacao;
        }

        public int Id { get => id; set => id = value; }
        public string Placa { get => placa; set => placa = value; }
        public int Lotacao { get => lotacao; set => lotacao = value; }
    }
}

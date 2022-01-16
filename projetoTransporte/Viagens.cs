using System;
using System.Collections.Generic;
using System.Text;

namespace projetoTransporte
{
    internal class Viagens
    {
        private Queue<Viagem> viagens = new Queue<Viagem>();

        internal Queue<Viagem> ViagensList { get => viagens; set => viagens = value; }

        public void incluir(Viagem viagem)
        {
            ViagensList.Enqueue(viagem);
        }

        public int QtdeViagens()
        {
            return ViagensList.Count;
        }

        public int QtdeViagensOrigemDestino(Garagem origem, Garagem destino)
        {
            int qtd = 0;
            foreach (Viagem viagem in viagens)
            {
                if (viagem.Origem == origem && viagem.Destino == destino)
                    qtd++;
            }

            return qtd;
        }
        public int QtdePassageirosViagem(Garagem origem, Garagem destino)
        {
            int qtd = 0;
            foreach (Viagem viagem in viagens)
            {
                if (viagem.Origem == origem && viagem.Destino == destino)
                    qtd += viagem.Veiculo.Lotacao;
            }

            return qtd;
        }


        public void ListarViagensOrigemDestino(Garagem origem, Garagem destino)
        {
            if (QtdeViagensOrigemDestino(origem, destino) == 0)
            {
                Console.Clear();
                Console.WriteLine("Nenhuma viagem foi realizada com as localizações fornecidas");
            } else
            {
                foreach (Viagem viagem in viagens)
                {
                    if (viagem.Origem == origem && viagem.Destino == destino)
                    {
                        Console.WriteLine($"id: {viagem.Id}");
                        Console.WriteLine($"origem: {viagem.Origem.Local}");
                        Console.WriteLine($"destino: {viagem.Destino.Local}");
                        Console.WriteLine($"placa do veiculo: {viagem.Veiculo.Placa}");
                    }
                }

            }
        }
    }
}

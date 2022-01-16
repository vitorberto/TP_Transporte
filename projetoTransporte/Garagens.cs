using System;
using System.Collections.Generic;
using System.Text;

namespace projetoTransporte
{
    internal class Garagens
    {
        private List<Garagem> garagens = new List<Garagem>();
        private bool jornadaAtiva = false;

        internal List<Garagem> GaragensList { get => garagens; set => garagens = value; }
        public bool JornadaAtiva { get => jornadaAtiva; set => jornadaAtiva = value; }

        public void incluir(Garagem garagem)
        {
            GaragensList.Add(garagem);
        }

        public void IniciarJornada()
        {
            if (!JornadaAtiva)
            {
                JornadaAtiva = true;

                Console.Clear();
                Console.WriteLine("Jornada iniciada com sucesso!");
                return;
            }
            Console.Clear();
            Console.WriteLine("A jornada já foi iniciada e não pode ser iniciada novamente");
        }

        public List<Transporte> EncerrarJornada(Viagens viagens, Veiculos veiculos)
        {
            List<Transporte> transportes = new List<Transporte>();
            foreach (Veiculo veiculo in veiculos.VeiculosList)
            {
                transportes.Add(new Transporte(veiculo, 0));
            }

            while (viagens.QtdeViagens() > 0)
            {
                Viagem viagem = viagens.ViagensList.Dequeue();
                foreach(Transporte transporte in transportes)
                {
                    if (transporte.Veiculo == viagem.Veiculo)
                        transporte.QtdeTransportada += viagem.Veiculo.Lotacao;
                }
            }

            return transportes;
        }

        public Garagem GetGaragem(int id)
        {
            return GaragensList.Find(x => x.Id == id);
        }

        public int QtdeGaragens()
        {
            return garagens.Count;
        }
    }
}

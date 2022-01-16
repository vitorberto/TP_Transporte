using System;
using System.Collections.Generic;

namespace projetoTransporte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garagens garagens = new Garagens();
            Veiculos veiculos = new Veiculos();
            Viagens viagens = new Viagens();
            List<Transporte> transportes = new List<Transporte>();

            int escolha = 0;

            // Definindo as garanges iniciais, informadas no enunciado
            garagens.incluir(new Garagem(1, "Congonhas"));
            garagens.incluir(new Garagem(2, "Guarulhos"));

            // Criando as 8 vans do enunciado
            // Vans tem em média 14 assentos
            for (int i = 0; i < 8; i++)
            {
                veiculos.incluir(new Veiculo(i + 1, "placa" + i, 14));
            }

            // Criando layout
            do
            {
                Console.WriteLine("Digite uma das opções a seguir:");
                Console.WriteLine("1. Cadastrar veículo");
                Console.WriteLine("2. Cadastrar garagem");
                Console.WriteLine("3. Iniciar jornada");
                Console.WriteLine("4. Encerrar jornada");
                Console.WriteLine("5. Liberar viagem de determinada origem para um determinado destino");
                Console.WriteLine("6. Listar veiculos em determinada garagem (informando a quantidade de veículos e seu potencial de transporte)");
                Console.WriteLine("7. Informar qtde de viagens efetuadas de uma determinada origem para um determinado destino");
                Console.WriteLine("8. Listar viagens efetuadas de uma determinada origem para um determinado destino");
                Console.WriteLine("9. Informar qtde de passageiros transportados de uma determinada origem para um determinado destino");
                Console.WriteLine("0. Sair.")

                Console.Write("\nSua escolha: ");
                escolha = int.Parse(Console.ReadLine());

                if (escolha == 1)
                    CadastrarVeiculo();
                else if (escolha == 2)
                    CadastrarGaragem();
                else if (escolha == 3)
                    IniciarJornada();
                else if (escolha == 4)
                    EncerrarJornada();
                else if (escolha == 5)
                    LiberarViagem();
                else if (escolha == 6)
                    listarVeiculosGaragem();
                else if (escolha == 7)
                    QtdViagensOrigemDestino();
                else if (escolha == 8)
                    ListarViagensOrigemDestino();
                else if (escolha == 9)
                    QtdPassageirosViagens();
            } while (escolha != 0);

            // funções usadas nas escolhas
            void CadastrarVeiculo()
            {
                Console.WriteLine("Digite a placa do veiculo");
                string placa = Console.ReadLine();

                Console.WriteLine("Digite o número máximo de passageiros");
                int limite = int.Parse(Console.ReadLine());

                veiculos.incluir(new Veiculo(veiculos.QtVeiculos() + 1, placa, limite));
            }

            void CadastrarGaragem()
            {
                Console.WriteLine("Digite a localização da garagem");
                string local = Console.ReadLine();

                garagens.incluir(new Garagem(garagens.QtdeGaragens() + 1, local));
            }

            void IniciarJornada()
            {

                garagens.IniciarJornada();

                if (garagens.JornadaAtiva)
                {
                    foreach(Garagem garagem in garagens.GaragensList)
                    {
                        garagem.Veiculos.Clear();
                    }

                    int i = 0;
                    while (i < veiculos.QtVeiculos())
                    {
                        for (int j = 0; j < garagens.QtdeGaragens(); j++)
                        {
                            if (i < veiculos.QtVeiculos())
                            {
                                garagens.GaragensList[j].Veiculos.Push(veiculos.VeiculosList[i]);
                                i++;
                            }
                        }
                    }
                }
            }

            void EncerrarJornada()
            {
                if (garagens.JornadaAtiva)
                {
                    transportes = garagens.EncerrarJornada(viagens, veiculos);

                    Console.Clear();
                    Console.WriteLine("Jornada encerrada com sucesso!");
                    Console.WriteLine("Quantidade de pessoas transportadas por veiculo:");
                    foreach (Transporte transporte in transportes)
                    {
                        Console.WriteLine($"Placa do veiculo: {transporte.Veiculo.Placa}");
                        Console.WriteLine($"Quantidade transportada: {transporte.QtdeTransportada}");
                    }
                    Console.WriteLine("================================");
                } else
                {
                    Console.Clear();
                    Console.WriteLine("A jornada não está ativa e, portanto, não pode ser encerrada");
                }
            }

            void LiberarViagem()
            {
                Console.Clear();
                Console.WriteLine("Digite o id da garagem de origem");
                int idOrigem = int.Parse((Console.ReadLine()));

                Console.WriteLine("Digite o id da garagem de destino");
                int idDestino = int.Parse((Console.ReadLine()));

                Garagem origem = garagens.GetGaragem(idOrigem);
                Garagem destino = garagens.GetGaragem(idDestino);

                if (origem.QtdeVeiculos() == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Não há veículos disponíveis na garagem de origem");
                    return;
                }

                Veiculo veiculo = origem.GetVeiculo();
                viagens.incluir(new Viagem(viagens.QtdeViagens() + 1, origem, destino, veiculo));
                destino.Veiculos.Push(veiculo);

                Console.Clear();
                Console.WriteLine("Viagem liberada com sucesso!");
            }

            void listarVeiculosGaragem()
            {
                Console.Clear();
                Console.WriteLine("Digite o id da garagem que deseja listar os veiculos:");
                int idGaragem = int.Parse((Console.ReadLine()));

                Garagem garagem = garagens.GetGaragem(idGaragem);
                garagem.ListarVeiculos();
            }

            void QtdViagensOrigemDestino()
            {
                Console.Write("Digite o id da garagem de origem:");
                int idOrigem = int.Parse((Console.ReadLine()));

                Console.Write("Digite o id da garagem de destino:");
                int idDestino = int.Parse((Console.ReadLine()));

                Garagem origem = garagens.GetGaragem(idOrigem);
                Garagem destino = garagens.GetGaragem(idDestino);

                int qtde = viagens.QtdeViagensOrigemDestino(origem, destino);

                Console.Clear();
                Console.WriteLine($"Quantidade de viagens de {origem.Local} para {destino.Local}: {qtde}");
                Console.WriteLine("====================================");
            }

            void ListarViagensOrigemDestino()
            {
                Console.Write("Digite o id da garagem de origem:");
                int idOrigem = int.Parse((Console.ReadLine()));

                Console.Write("Digite o id da garagem de destino:");
                int idDestino = int.Parse((Console.ReadLine()));


                Garagem origem = garagens.GetGaragem(idOrigem);
                Garagem destino = garagens.GetGaragem(idDestino);

                viagens.ListarViagensOrigemDestino(origem, destino);
            }

            void QtdPassageirosViagens()
            {
                Console.Write("Digite o id da garagem de origem:");
                int idOrigem = int.Parse((Console.ReadLine()));

                Console.Write("Digite o id da garagem de destino:");
                int idDestino = int.Parse((Console.ReadLine()));

                Garagem origem = garagens.GetGaragem(idOrigem);
                Garagem destino = garagens.GetGaragem(idDestino);

                int qtde = viagens.QtdePassageirosViagem(origem, destino);

                Console.Clear();
                Console.WriteLine($"Quantidade de passageiros em viagens de {origem.Local} para {destino.Local}: {qtde}");
                Console.WriteLine("====================================");
            }

        }
    }
}

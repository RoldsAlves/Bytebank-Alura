using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytebank.SistemaAgencia;
using Bytebank.SistemaAgencia.Comparadores;
using Bytebank.SistemaAgencia.Extensoes;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using System.IO;

namespace ByteBank.SistemaAgencia
{ 
    partial class Program
    {

        static void LidandoComFileStreamDiretamente()
        {
            var enderecoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; // buffer = 1 Kb
                var numerosDeBytesLidos = -1;

                while (numerosDeBytesLidos != 0)
                {
                    numerosDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numerosDeBytesLidos);
                }
            }
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = Encoding.Default;

            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);

            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }

        static void TestandoListaContas()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(340, 18509),
                null,
                new ContaCorrente(304, 150503),
                new ContaCorrente(304, 190840),
                null,
                new ContaCorrente(410, 4664),
                new ContaCorrente(410, 1965),
                null,
                new ContaCorrente(290, 190800),
                new ContaCorrente(290, 109940)
            };

            var contasNaoNulas = contas.Where(contas => contas != null);
            //contas.Sort(); ~~> Chamar a imprelementação dada em IComparable
            //contas.Sort(new ComparadorContaCorrentePorAgencia());
            IOrderedEnumerable<ContaCorrente> contasOrdenada = contasNaoNulas.OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenada)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }
        }

        static void TestandoListas()
        {

            var nomes = new List<string>
            {
                "Guilherme", "wellington", "Marcia", "Rodolfo", "Ana"
            };
            nomes.Sort();
            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }

            var idades = new List<int>();
            idades.Add(5);
            idades.Add(45);
            idades.Add(20);
            idades.Add(35);
            idades.AdicionarVarios(15, 25, 4, 28);
            idades.Sort();
            int idadeSoma = 0;
            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine($"Idade no indice {i}: {idades[i]}");
                idadeSoma += idades[i];
            }
        }

        static void Estatico()
        {

            MinhaClasse<Funcionario>.ContadorEstatico++;
            MinhaClasse<Funcionario>.ContadorEstatico++;
            MinhaClasse<Diretor>.ContadorEstatico++;
            MinhaClasse<Funcionario>.ContadorEstatico++;

            Console.WriteLine(MinhaClasse<Diretor>.ContadorEstatico);
            Console.WriteLine(MinhaClasse<Funcionario>.ContadorEstatico);

        }

        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach (int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }

        static void TestalistaT()
        {
            Lista<int> idades = new Lista<int>();
            idades.Adicionar(5);
            idades.AdicionarVarios(1, 5, 50, 78);
            idades.Remover(5);
            int idadeSoma = 0;
            for (int i = 0; i < idades.Tamanho; i++)
            {
                Console.WriteLine($"Idade no indice {i}: {idades[i]}");
                idadeSoma += idades[i];
            }

            Console.WriteLine($"Soma das Idades: {idadeSoma}");

        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdade = new ListaDeObject();

            listaDeIdade.Adicionar(10);
            listaDeIdade.Adicionar(5);
            listaDeIdade.Adicionar(4);
            listaDeIdade.AdicionarVarios(16, 26, 60);

            for (int i = 0; i < listaDeIdade.Tamanho; i++)
            {
                int idade = (int)listaDeIdade[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
            }


        }

        static void TestaListaDeContaCorrente()
        {
            //ListaDeContaCorrente lista = new ListaDeContaCorrente();
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaDoGui = new ContaCorrente(11111, 1111111);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679754)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }
        }

        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
                {
                    new ContaCorrente(874, 5679787),
                    new ContaCorrente(874, 4456668),
                    new ContaCorrente(874, 7781438)
                };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }
        }

        static void TestaArrayInt()
        {
            // ARRAY de inteiros, com 5 posições!
            int[] idades = null;
            idades = new int[3];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            //idades[3] = 50;
            //idades[4] = 28;
            //idades[5] = 60;

            Console.WriteLine(idades.Length);

            int acumulador = 0;
            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array idades no índice {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                acumulador += idade;
            }

            int media = acumulador / idades.Length;
            Console.WriteLine($"Média de idades = {media}");
        }

    }
}
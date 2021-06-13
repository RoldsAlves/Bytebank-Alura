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
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using(var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "456, 78945, 4795.15,Tiago Santos";
                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(contaComoString);

                fluxoArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using(var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                using(var escritor = new StreamWriter(fluxoArquivo))
                {
                    escritor.Write("456, 78945, 4795.15,Tiago Santos");
                }
            }
        }

        static void TestaEscrita()
        {
            var caminhoArquivo = "teste.txt";

            using (var fluxoArquivo = new FileStream(caminhoArquivo, FileMode.Create))
            {
                using(var escritor = new StreamWriter(fluxoArquivo))
                {
                    for(int i = 0; i < 100; i++)
                    {
                        escritor.WriteLine($"Linha {i}");

                        escritor.Flush(); //Joga a informação para o HD

                        Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter para adicionar a próxima...");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}

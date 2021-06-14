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
        static void Main(string[] args)
        {
            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine(linhas.Length);

            foreach (var contas in linhas)
            {
                Console.WriteLine(contas);
            }

            Console.WriteLine("Digite o seu nome:");
            var nome = Console.ReadLine();
            Console.WriteLine(nome);

            // UsarStreamDeEntrada();

            Console.WriteLine("Aplicação Finalizada!");

            Console.ReadLine();
        }

    }
}

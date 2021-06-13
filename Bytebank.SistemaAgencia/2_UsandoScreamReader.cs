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
        static void AbrirArquivoScreamReader()
        {
            var endenrecoDoArquivo = "contas.txt";
            using (var fluxoDeArquivo = new FileStream(endenrecoDoArquivo, FileMode.Open))
            {
                using (var leitor = new StreamReader(fluxoDeArquivo))
                {
                    while (!leitor.EndOfStream)
                    {
                        var linha = leitor.ReadLine();

                        var contaCorrente = ConverterStringParaContaCorrente(linha);

                        var msg = $"{contaCorrente.Titular.Nome} - Conta Número: {contaCorrente.Numero}, Ag.: {contaCorrente.Agencia}, Saldo: R$ {contaCorrente.Saldo}";

                        Console.WriteLine(msg);
                    }
                }
            }

            Console.ReadLine();
        }

         static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(',');
            var agencia = int.Parse(campos[0]);
            var conta = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace('.', ','));
            var nomeTitular = campos[3];

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agencia, conta);
            resultado.Depositar(saldo);
            resultado.Titular = titular;

            return resultado;
        }
    }
}
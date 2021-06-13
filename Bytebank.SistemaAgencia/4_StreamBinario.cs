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
        static void EscritaBinaria()
        {
            using(var fs = new FileStream("contaCorrente.txt", FileMode.Create))
            {
                using(var escritor = new BinaryWriter(fs))
                {
                    escritor.Write(453);
                    escritor.Write(45050);
                    escritor.Write(1509.54);
                    escritor.Write("Rodolfo Alves");
                }
            }
        }

        static void LeituraBinaria()
        {
            using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
            {
                using (var leitor = new BinaryReader(fs))
                {
                    var agencia = leitor.ReadInt32();
                    var conta = leitor.ReadInt32();
                    var saldo = leitor.ReadDouble();
                    var nome = leitor.ReadString();

                    Console.WriteLine(agencia);
                    Console.WriteLine(conta);
                    Console.WriteLine(saldo);
                    Console.WriteLine(nome);
                }
            }
        }
    }
}
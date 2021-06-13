using ByteBank.Modelos.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public class Diretor : FuncionarioAutenticavel
    {
        //public string Nome { get; set; }
        //public string CPF { get; set; }
        //public double Salario { get; set; }
        public Diretor(string cpf) : base(5000, cpf)
        {

        }

        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }

        protected internal override double GetBonificacao()
        {
            return Salario *= 0.5;
        }
    }
}

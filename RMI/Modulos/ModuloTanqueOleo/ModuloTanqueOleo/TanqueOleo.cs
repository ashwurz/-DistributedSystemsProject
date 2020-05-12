using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloTanqueOleo
{
    public class TanqueOleo : MarshalByRefObject, ITanqueOleo
    {
        private double Total;
        public void Adicionar(int volume)
        {
            Console.WriteLine($"Foram adicionados {volume} litros ao tanque de óleo");
            Total += volume;
            Console.WriteLine("-----------------------------------------------------------");
        }

        public double EnviarParaOReator()
        {
            Console.WriteLine("Foram Enviados ao Reator 47,62 Litros de Oleo");
            Console.WriteLine("-----------------------------------------------------------");
            Total -= 47.62;
            return 47.62;
        }
    }
}

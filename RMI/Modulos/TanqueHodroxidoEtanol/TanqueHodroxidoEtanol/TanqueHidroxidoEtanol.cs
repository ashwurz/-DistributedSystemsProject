using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModuloTanqueHidroxidoEtanol
{
    public class TanqueHidroxidoEtanol : MarshalByRefObject, ITanqueHidroxidoEtanol
    {
        private double NaOH;
        private double EtOH;
        public void Adicionar()
        {
            NaOH += 0.45;
            EtOH += 1;
            Console.WriteLine("Foram adicionados 45 Centilitros de NaOH e 1 litro de EtOH");
            Console.WriteLine("-----------------------------------------------------------");
        }
        public double EnviarParaOReator()
        {
            Thread.Sleep(1000);
            NaOH -= 0.48;
            EtOH -= 1.9;
            Console.WriteLine("Foram Enviados ao Reator 0.48 e 1.9 Litros de NaoH e EtOH Respectivamente");
            Console.WriteLine("-----------------------------------------------------------");
            double solucao = 0.48 + 1.9;
            return solucao;
        }
    }
}

using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloReator
{
    public class Reator : MarshalByRefObject, IReator
    {
        private double Total;
        public ITanqueOleo tanqueOleo { get; set; }
        public ITanqueHidroxidoEtanol tanqueHidroxidoEtanol { get; set; }
        public Reator()
        {
            tanqueOleo = (ITanqueOleo)Activator.GetObject(
                             typeof(ITanqueOleo), "tcp://localhost:1000/tanqueoleo");
            tanqueHidroxidoEtanol = (ITanqueHidroxidoEtanol)Activator.GetObject(
                            typeof(ITanqueHidroxidoEtanol), "tcp://localhost:2000/tanquehidroxidoetanol");
        }

        public void RecebeSolucao()
        {
            double oleo = tanqueOleo.EnviarParaOReator();
            double hidroxido = tanqueHidroxidoEtanol.EnviarParaOReator();
            Total += oleo + hidroxido;
            Console.WriteLine("Foram adicionados 48 Centilitros de NaOH e 1.9 litro de EtOH e 47.62 litros de Óleo ao Reator");
            Console.WriteLine("-----------------------------------------------------------");
        }
        public double EnviaParaDecantador()
        {
            Total -= 100;
            Console.WriteLine("Foram retirados 100 litros da Solução presente no Reator");
            Console.WriteLine("-----------------------------------------------------------");
            return 100;
        }

    }
}

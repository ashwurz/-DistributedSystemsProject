using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDecantador
{
    class Decantador : MarshalByRefObject, IDecantador
    {
        private double Total;
        private double tempTotal;
        public IReator reator { get; set; }
        public ISecador secador { get; set; }
        public ILavagem lavagem { get; set; }
        public ITanqueGlicerina tanqueglicerina { get; set; }
        public Decantador()
        {
            reator = (IReator)Activator.GetObject(
                             typeof(IReator), "tcp://localhost:8000/reator");
            secador = (ISecador)Activator.GetObject(
                             typeof(ISecador), "tcp://localhost:6000/secador"); ;
            lavagem = (ILavagem)Activator.GetObject(
                             typeof(ILavagem), "tcp://localhost:7000/lavagem"); ;
            tanqueglicerina = (ITanqueGlicerina)Activator.GetObject(
                             typeof(ITanqueGlicerina), "tcp://localhost:3000/tanqueglicerina"); ;
        }
        public void ReceberSolucao()
        {
            Total += reator.EnviaParaDecantador();
            Console.WriteLine("Foram adicionados 100 litros da solução vinda do reator");
            Console.WriteLine("-----------------------------------------------------------");
            tempTotal = Total;
            EnviarParaLavagem();
            EnviarParaTanqueGlicerina();
            EnviarParaSecadorTanqueEtOH();
        }
        public void EnviarParaLavagem()
        {
            var paraLavagem = (tempTotal * 0.9);
            Total -= paraLavagem;
            Console.WriteLine($"Foram enviados {paraLavagem} litros para Lavagem");
            Console.WriteLine("-----------------------------------------------------------");
            lavagem.Lavar(paraLavagem);
        }
        public void EnviarParaTanqueGlicerina()
        {
            var paraGlicerina = (tempTotal * 0.02);
            Total -= paraGlicerina;
            Console.WriteLine($"Foram enviados {paraGlicerina} litros para o Tanque de Glicerina");
            Console.WriteLine("-----------------------------------------------------------");
            tanqueglicerina.Adicionar(paraGlicerina);
        }
        public void EnviarParaSecadorTanqueEtOH()
        {
            var EtOH = (tempTotal * 0.08);
            Total -= EtOH;
            Console.WriteLine($"Foram enviados {EtOH} litros para o secador antes do Tanque de EtOH");
            Console.WriteLine("-----------------------------------------------------------");
            secador.SecarEnviarParaEtOH(EtOH);
        }
    }
}

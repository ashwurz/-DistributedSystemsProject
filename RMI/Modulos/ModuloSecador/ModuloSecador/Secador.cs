using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModuloSecador
{
    public class Secador : MarshalByRefObject, ISecador
    {
        private ITanqueBiodisel tanqueBiodisel { get; set; }
        private ITanqueEtOH tanqueEtOH { get; set; }          
        public Secador()
        {
            tanqueBiodisel = (ITanqueBiodisel)Activator.GetObject(
                             typeof(ITanqueBiodisel), "tcp://localhost:5000/tanqueBiodisel");

            tanqueEtOH = (ITanqueEtOH)Activator.GetObject(
                             typeof(ITanqueEtOH), "tcp://localhost:4000/tanqueEtOH");
        }
        public void SecarEnviarParaBiodisel(double volume)
        {
            Console.WriteLine("Inicio do processo do Secador");
            Console.WriteLine($"Volume inicial: {volume}");
            double novoVolume = volume - (volume * 0.01);

            Thread.Sleep(3000);

            Console.WriteLine($"Volume Final: {novoVolume}");
            Console.WriteLine($"Enviando para o Tanque de Biodisel");
            Console.WriteLine("--------------------------------------------------------------");
            tanqueBiodisel.Adicionar(novoVolume);
        }

        public void SecarEnviarParaEtOH(double volume)
        {
            Console.WriteLine("Inicio do processo do Secador");
            Console.WriteLine($"Volume inicial: {volume}");
            double novoVolume = volume - (volume * 0.01);

            Thread.Sleep(3000);

            Console.WriteLine($"Volume Final: {novoVolume}");
            Console.WriteLine($"Enviando para o Tanque de Et OH");
            Console.WriteLine("--------------------------------------------------------------");
            tanqueEtOH.Adicionar(novoVolume);
        }
    }
}

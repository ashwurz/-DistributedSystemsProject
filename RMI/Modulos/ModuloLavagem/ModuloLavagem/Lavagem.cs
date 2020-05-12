using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModuloLavagem
{
    public class Lavagem : MarshalByRefObject, ILavagem
    {
        private ISecador secador { get; set; }
        public Lavagem()
        {
            secador = (ISecador)Activator.GetObject(
                             typeof(ISecador), "tcp://localhost:6000/secador");
        }
        public void Lavar(double volume)
        {
            Console.WriteLine($"Inicio do processo de lavagem, volume inicial: {volume}");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Passando pelo {i +1}º lavador");
                volume -= volume * 0.03;
                Console.WriteLine($"Volume da solução agora: {volume}");
            }

            Console.WriteLine($"Volume final: {volume}");
            Console.WriteLine("Enviando para o Secador");
            Console.WriteLine("--------------------------------------------------------------");
            secador.SecarEnviarParaBiodisel(volume);
        }
    }
}

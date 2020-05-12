using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloTanqueEtOH
{
    public class TanqueEtOH : MarshalByRefObject, ITanqueEtOH
    {
        private double Total { get; set; }
        public void Adicionar(double volume)
        {
            Console.WriteLine($"Foi Adicionado {volume} litros ao Tanque de EtOH");

            Total += volume;

            Console.WriteLine($"Totalizando {Total} litros no tanque");
            Console.WriteLine("---------------------------------------------------------");
        }
    }
}

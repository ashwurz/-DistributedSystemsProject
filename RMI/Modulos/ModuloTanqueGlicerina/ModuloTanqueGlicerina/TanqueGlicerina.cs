using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloTanqueGlicerina
{
    public class TanqueGlicerina : MarshalByRefObject, ITanqueGlicerina
    {
        private double Total { get; set; }
        public void Adicionar(double volume)
        {
            Console.WriteLine($"Foi Adicionado {volume} litros ao Tanque de Glicerina");

            Total += volume;

            Console.WriteLine($"Totalizando {Total} litros no tanque");
            Console.WriteLine("---------------------------------------------------------");
        }
    }
}

using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloBiodisel
{
    public class TanqueBiodisel : MarshalByRefObject, ITanqueBiodisel
    {
        private double Total { get; set; }
        public void Adicionar(double volume)
        {
            Console.WriteLine($"Foi Adicionado {volume} litros ao Tanque de Biodisel");

            Total += volume;

            Console.WriteLine($"Totalizando {Total} litros no tanque");
            Console.WriteLine("---------------------------------------------------------");
        }
    }
}

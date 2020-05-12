using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModuloTanqueOleo
{
    class Program
    {
        static void Main(string[] args)
        {
            var numeroAleatorio = new Random();
            var tanque = new TanqueOleo();
            TcpChannel channel = new TcpChannel(1000);

            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof
                           (TanqueOleo), "tanqueoleo", WellKnownObjectMode.Singleton);

            Console.WriteLine($"O módulo do Tanque de óleo foi aberto na porta: 1000");
            Console.WriteLine("-----------------------------------------------------------");
            //Console.Read();

            while (true)
            {
                Thread.Sleep(5000);
                tanque.Adicionar(numeroAleatorio.Next(100, 200));
            }
            //Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModuloReator
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(8000);

            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof
                           (Reator), "reator", WellKnownObjectMode.Singleton);

            var reator = new Reator();

            Console.WriteLine($"O módulo do Reator foi aberto na porta: 8000");
            Console.WriteLine("-----------------------------------------------------------");
            //Console.Read();
            while (true)
            {
                Thread.Sleep(1000);
                reator.RecebeSolucao();
            }
            
            //Console.Read();
        }
    }
}

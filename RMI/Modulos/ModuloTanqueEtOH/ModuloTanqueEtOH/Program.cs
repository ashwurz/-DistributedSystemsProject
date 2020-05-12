using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace ModuloTanqueEtOH
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(4000);

            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof
                           (TanqueEtOH), "tanqueEtOH", WellKnownObjectMode.Singleton);

            Console.WriteLine($"O módulo do Tanque de EtOH foi aberto na porta: 4000");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Read();
        }
    }
}

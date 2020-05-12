using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace ModuloSecador
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(6000);

            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof
                           (Secador), "secador", WellKnownObjectMode.Singleton);

            Console.WriteLine($"O módulo do Secador foi aberto na porta: 6000");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Read();
        }
    }
}

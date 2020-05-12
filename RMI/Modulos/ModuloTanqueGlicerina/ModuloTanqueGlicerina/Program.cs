using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace ModuloTanqueGlicerina
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(3000);

            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof
                           (TanqueGlicerina), "tanqueglicerina", WellKnownObjectMode.Singleton);

            Console.WriteLine($"O módulo do Tanque de Glicerina foi aberto na porta: 3000");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Read();
        }
    }
}

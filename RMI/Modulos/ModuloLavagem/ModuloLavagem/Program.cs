using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace ModuloLavagem
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(7000);

            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof
                           (Lavagem), "lavagem", WellKnownObjectMode.Singleton);

            Console.WriteLine($"O módulo da Lavagem foi aberto na porta: 7000");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Read();
        }
    }
}

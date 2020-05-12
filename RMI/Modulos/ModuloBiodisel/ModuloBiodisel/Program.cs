using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace ModuloBiodisel
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(5000);

            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof
                           (TanqueBiodisel), "tanqueBiodisel", WellKnownObjectMode.Singleton);

            Console.WriteLine($"O módulo do Tanque de Biodisel foi aberto na porta: 5000");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Read();
        }
    }
}

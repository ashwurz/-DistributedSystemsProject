using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModuloTanqueHidroxidoEtanol
{
    class Program
    {
        static void Main(string[] args)
        {
            var tanque = new TanqueHidroxidoEtanol();
            TcpChannel channel = new TcpChannel(2000);

            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof
                           (TanqueHidroxidoEtanol), "tanquehidroxidoetanol", WellKnownObjectMode.Singleton);

            Console.WriteLine("O Módulo do tanque de NaOH e EtOH foi aberto na porta: 2000");
            //Console.Read();

            while (true)
            {
                Thread.Sleep(1000);
                tanque.Adicionar();
            }
            //Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModuloDecantador
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(9000);

            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof
                            (Decantador), "decantador", WellKnownObjectMode.Singleton);

            var decantador = new Decantador();

            Console.WriteLine($"O módulo do Decantador foi aberto na porta: 9000");
            Console.WriteLine("-----------------------------------------------------------");
            //Console.Read();
            while (true)
            {
                Thread.Sleep(5000);
                decantador.ReceberSolucao();
            }

            Console.Read();
        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Pactice6.Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 2000);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread thread = new Thread(Client);
                thread.IsBackground = true;
                thread.Start(client);
            }
        }

        private static void Client(object arg)
        {
            TcpClient client = (TcpClient)arg;
            using (var stream = client.GetStream())
            {
                byte[] buffer = new byte[1024];
                stream.Read(buffer, 0, 4);
                int length = BitConverter.ToInt32(buffer, 0);
                if (length > 0 && length <= 1024)
                {
                    stream.Read(buffer, 0, length);
                }
                string name = Encoding.ASCII.GetString(buffer, 0, length);

                using (var fileStream = File.OpenRead(name))
                {
                    stream.Write(BitConverter.GetBytes(fileStream.Length), 0, 8);
                    while (fileStream.Position < fileStream.Length)
                    {
                        int count = fileStream.Read(buffer, 0, 1024);
                        stream.Write(buffer, 0, count);
                    }
                }
            }
        }
    }
}
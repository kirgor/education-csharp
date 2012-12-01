using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Practice6.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (TcpClient client = new TcpClient("localhost", 2000))
            {
                var stream = client.GetStream();
                string name = Console.ReadLine();
                byte[] nameBytes = Encoding.ASCII.GetBytes(name);
                stream.Write(BitConverter.GetBytes(nameBytes.Length), 0, 4);
                stream.Write(nameBytes, 0, nameBytes.Length);

                byte[] buffer = new byte[1024];
                stream.Read(buffer, 0, 8);
                long length = BitConverter.ToInt64(buffer, 0);
                using (var fileStream = File.Create(Path.GetFileName(name)))
                {
                    for (long i = 0; i < length; i += 1024)
                    {
                        int count = stream.Read(buffer, 0, 1024);
                        fileStream.Write(buffer, 0, count);
                    }
                }
            }
        }
    }
}
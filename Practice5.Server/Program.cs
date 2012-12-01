using System;
using System.Net;
using System.Net.Sockets;

namespace Practice5.Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Any, 2000);
                listener.Start();
                while (true)
                {
                    using (TcpClient client = listener.AcceptTcpClient())
                    {
                        NetworkStream stream = client.GetStream();
                        byte[] buffer = new byte[8];
                        int count = 0;
                        while (count < 8)
                            count += stream.Read(buffer, count, 8 - count);
                        int a = BitConverter.ToInt32(buffer, 0);
                        int b = BitConverter.ToInt32(buffer, 4);
                        int c = a + b;
                        byte[] cBytes = BitConverter.GetBytes(c);
                        stream.Write(cBytes, 0, 4);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
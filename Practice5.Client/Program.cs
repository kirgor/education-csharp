using System;
using System.Net.Sockets;

namespace Practice5.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.Connect("localhost", 2000);
                    NetworkStream stream = client.GetStream();
                    int a = int.Parse(Console.ReadLine());
                    int b = int.Parse(Console.ReadLine());
                    byte[] aBytes = BitConverter.GetBytes(a);
                    byte[] bBytes = BitConverter.GetBytes(b);
                    stream.Write(aBytes, 0, 4);
                    stream.Write(bBytes, 0, 4);
                    byte[] cBytes = new byte[4];
                    stream.Read(cBytes, 0, 4);
                    int c = BitConverter.ToInt32(cBytes, 0);
                    Console.WriteLine(c);
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
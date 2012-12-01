using System.Net;
using System.Text;

namespace Practice6.HttpServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            while (true)
            {
                var context = listener.GetContext();
                string str = context.Request.Headers.ToString();
                context.Response.ContentLength64 = 6;
                context.Response.ContentEncoding = Encoding.UTF8;
                context.Response.OutputStream.Write(Encoding.UTF8.GetBytes("Hello!"), 0, 6);
                context.Response.OutputStream.Close();
            }
        }
    }
}
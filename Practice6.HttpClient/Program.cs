using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Practice6.HttpClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HttpWebRequest req = HttpWebRequest.Create("https://www.google.ru") as HttpWebRequest;
            req.Method = "GET";
            req.Headers.Add(HttpRequestHeader.CacheControl, "max-age=0");
            req.KeepAlive = true;
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            req.Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1,utf-8;q=0.7,*;q=0.3");
            req.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate,sdch");
            req.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8");
            req.Host = "google.ru:80";
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.91 Safari/537.11";

            var resp = req.GetResponse();

            string str = resp.Headers.ToString();

            using (var rs = resp.GetResponseStream())
            {
                byte[] buffer = new byte[resp.ContentLength];
                int offset = 0;
                while (offset < buffer.Length)
                    offset += rs.Read(buffer, offset, buffer.Length - offset);

                Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, buffer.Length));
            }
        }
    }
}
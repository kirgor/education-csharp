using MvcApplication2.Data;
using MvcApplication2.Helpers;
using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication2.Controllers
{
    public class MessageController : ApiController
    {
        public string Post(MessageModel m)
        {
            var time = DateTime.Now;

            using (var context = new ChatEntities())
            {
                var user = context.Users.SingleOrDefault(u => u.Email == m.Email);
                if (user != null)
                {
                    context.Messages.Add(new MvcApplication2.Data.Message
                    {
                        UserId = user.Id,
                        Time = time,
                        Text = m.Text,
                        SessionId = m.SessionId
                    });

                    context.SaveChanges();

                    Dispatcher.NewMessage();
                }
            }

            return time.ToString();
        }

        public IEnumerable<MessageModel> GetNew(int userId, long lastId)
        {
            using (var context = new ChatEntities())
            {
                do
                {
                    var result = context.Messages.Where(m => m.Id > lastId).ToArray();
                    if (result.Length > 0)
                    {
                        return result.Select(m => new MessageModel(m)).ToArray();
                    }
                    else
                    {
                        Dispatcher.Subscribe(userId);
                        Dispatcher.Wait(userId);
                    }
                } while (true);
            }
        }
    }
}
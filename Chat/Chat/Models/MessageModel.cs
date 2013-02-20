using MvcApplication2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class MessageModel
    {
        public MessageModel()
        {
        }

        public MessageModel(Message m)
        {
            Id = m.Id;
            Author = String.Format("{0} {1}", m.User.Name, m.User.LastName);
            Time = m.Time;
            Text = m.Text;
            Email = m.User.Email;
            SessionId = m.SessionId;
        }

        public long Id { get; set; }

        public string Author { get; set; }

        public DateTime Time { get; set; }

        public string TimeString
        {
            get
            {
                return Time.ToString();
            }
            set { }
        }

        public string Text { get; set; }

        public string Email { get; set; }

        public Guid? SessionId { get; set; }
    }
}
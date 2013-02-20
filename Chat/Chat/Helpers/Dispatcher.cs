using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace MvcApplication2.Helpers
{
    public static class Dispatcher
    {
        private static object _sync = new object();
        private static Dictionary<int, EventWaitHandle> _events = new Dictionary<int, EventWaitHandle>();

        public static void Subscribe(int userId)
        {
            lock (_sync)
            {
                if (!_events.ContainsKey(userId))
                {
                    _events.Add(userId, new EventWaitHandle(false, EventResetMode.ManualReset));
                }
            }
        }

        public static void NewMessage()
        {
            foreach (var item in _events.Values)
            {
                item.Set();
            }
        }

        public static void Wait(int userId)
        {
            if (_events.ContainsKey(userId))
            {
                _events[userId].WaitOne();
            }
        }
    }
}
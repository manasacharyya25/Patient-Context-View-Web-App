using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContextViewApp.Models
{
    public static class AcceptCount
    {
        public static readonly object counterLock = new object();
        public static int AcceptCounter;
    }
}
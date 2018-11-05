using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContextViewApp.Models
{
    public static class UserHandler
    {
        public static int connectedClientsCounter = 0;
        public static Dictionary<string,string> connectedClientsDetails = new Dictionary<string,string>();
        public static List<string> AcceptorsList = new List<string>();
    }
}
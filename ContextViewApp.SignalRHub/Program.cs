using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using ContextViewApp.SignalRHub;

namespace SignalRSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:5127";
            WebApp.Start<Startup>(url: baseAddress);
            
            Console.WriteLine("Server running on {0}", baseAddress);
            Console.ReadLine();
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using ContextViewApp.Models;
using ContextViewApp.StaticData;
using System.Threading;

namespace ContextViewApp.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task NotifyServer(string message)
        {
            int x = 0;
            Details();
            Console.WriteLine();
            ReplyCounter.counter = 0;
            Console.WriteLine(UserHandler.connectedClientsDetails[Context.ConnectionId] + " requested for context change to "+ message);
            if (UserHandler.connectedClientsCounter == 1)
            {
                PatientContext.currentContext = message;
                Clients.All.ReceiveContext(GetPatientData(message));
                Console.WriteLine("Context Changed to "+ message);
            }
            else
            {
                AcceptCount.AcceptCounter = 1;
                UserHandler.AcceptorsList.Add(Context.ConnectionId);

                Clients.Others.NotifyClient(message);

                while (ReplyCounter.counter < UserHandler.connectedClientsCounter - 1)
                {
                    await Task.Delay(1000);
                    x++;
                    if (x == 10)
                    {
                        break;
                    }
                }

                await Task.Delay(1000);

                CheckAndChange(message);
            }
        }

        public void GetMyPatients()
        {
            try
            {
                List<string>[] myPatients = new List<string>[3];

                myPatients[0] = new List<string>();
                myPatients[1] = new List<string>();
                myPatients[2] = new List<string>();

                myPatients[0].Add(PatientData.patient1.mrn);
                myPatients[0].Add(PatientData.patient1.name);
                myPatients[0].Add(PatientData.patient1.icu);
                myPatients[0].Add(PatientData.patient1.bed);

                myPatients[1].Add(PatientData.patient2.mrn);
                myPatients[1].Add(PatientData.patient2.name);
                myPatients[1].Add(PatientData.patient2.icu);
                myPatients[1].Add(PatientData.patient2.bed);

                myPatients[2].Add(PatientData.patient3.mrn);
                myPatients[2].Add(PatientData.patient3.name);
                myPatients[2].Add(PatientData.patient3.icu);
                myPatients[2].Add(PatientData.patient3.bed);

                Clients.Caller.setMyPatients(myPatients);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Details()
        {
            Console.Clear();
            Console.WriteLine("No of connected Clients : " + UserHandler.connectedClientsCounter);
            for (int i= 0; i < UserHandler.connectedClientsCounter; i++){
                Console.WriteLine(i+1+".    "+UserHandler.connectedClientsDetails.ElementAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("Current Patient Context: "+PatientContext.currentContext);
        }

        public void SetContext()
        {
            Clients.Caller.GetContext(GetPatientData(PatientContext.currentContext));
        }

        public void Accept()
        {
            ReplyCounter.counter++;
            Console.WriteLine(UserHandler.connectedClientsDetails[Context.ConnectionId] + " has Accepted the context change request ");
            UserHandler.AcceptorsList.Add(Context.ConnectionId);
            lock (AcceptCount.counterLock)
            {
                AcceptCount.AcceptCounter++;
            }
        }

        public void Reject()
        {
            ReplyCounter.counter++;
            Console.WriteLine(UserHandler.connectedClientsDetails[Context.ConnectionId] + " has Rejected the context change request ");
            UserHandler.AcceptorsList.Remove(Context.ConnectionId);
            lock (AcceptCount.counterLock)
            {
                AcceptCount.AcceptCounter--;
            }
        }

        public void CheckAndChange(string message)
        {

            if (AcceptCount.AcceptCounter == UserHandler.connectedClientsCounter)
            {
                Console.WriteLine(AcceptCount.AcceptCounter + " of " +UserHandler.connectedClientsCounter + " connected users have accepted the context change request. ");
                Console.WriteLine("Changing Context to " + message);
                PatientContext.currentContext = message;
                Clients.All.ReceiveContext(GetPatientData(message));
            }
            else
            {
                Console.WriteLine("Context Change to " + message + " Denied");
                foreach (string connId in UserHandler.AcceptorsList)
                {
                    Clients.Client(connId).ReceiveMessage(message);
                }
                UserHandler.AcceptorsList.Clear();

            }
        }

        private object GetPatientData(string message)
        {
            if(message == "MRN001")
            {
                return PatientData.patient1;
            }
            else if(message == "MRN002")
            {
                return PatientData.patient2;
            }
            else if (message == "MRN003")
            {
                return PatientData.patient3;
            }
            else if(message == "-1")
            {
                return "-1";
            }
            else
            {
                return PatientData.patient4;
            }
        }

        public override Task OnConnected()
        {
            UserHandler.connectedClientsCounter++;
            UserHandler.connectedClientsDetails.Add(Context.ConnectionId, "User " + UserHandler.connectedClientsCounter);
            Console.WriteLine(UserHandler.connectedClientsDetails[Context.ConnectionId]+" with Connection ID " + Context.ConnectionId + " has Connected");
;           return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            UserHandler.connectedClientsCounter--;
            Console.WriteLine(UserHandler.connectedClientsDetails[Context.ConnectionId] + " with Connection ID " + Context.ConnectionId + " has Disconnected");
            UserHandler.connectedClientsDetails.Remove(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }


    }
}
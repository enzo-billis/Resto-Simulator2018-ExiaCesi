using Newtonsoft.Json;
using Restaurant.Model.Shared;
using RestaurantSimulator.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Controller.Salle
{
    public class SalleCommandsController
    {
        private IPAddress localIP;
        private IPEndPoint iPEndPoint;
        private Socket sender;
        private readonly object syncLock = new object();

        private static SalleCommandsController instance;

        public static SalleCommandsController Instance
        {
            get
            {
                if (instance == null)
                    instance = new SalleCommandsController();
                return instance;
            }
        }

        private SalleCommandsController() { }

        public async Task InitClientSocketAsync()
        {
            this.localIP = IPAddress.Parse(Parameters.SALLE_CLIENT_LOCAL_IP);
            this.iPEndPoint = new IPEndPoint(localIP, Parameters.SALLE_CLIENT_COMMAND_PORT);
            this.sender = new Socket(localIP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Parameters.SALLE_CLIENT_STARTED = true;
            await LoggerController.AppendLineToFile(Parameters.LOG_PATH, "Salle commands client started");
        }

        public void CloseSocket()
        {
            Parameters.SALLE_CLIENT_STARTED = false;
            this.sender.Shutdown(SocketShutdown.Both);
            this.sender.Close();
            this.sender.Dispose();
        }

        public void SocketConnect()
        {
            byte[] bytes = new byte[1024];
            sender.Connect(this.iPEndPoint);
            /*while(Parameters.SALLE_CLIENT_STARTED == true)
            {
                
            }*/
        }

        public void SendCommand(Object objectGroup)
        {
            Group group = (Group)objectGroup;
            lock(syncLock)
            {
                string JSON = JsonConvert.SerializeObject(group);
                var bytes = SerializeGroup(group);
                this.sender.Send(bytes);
                LoggerController.AppendLineToFile(Parameters.LOG_PATH, "Command send from salle : " + group.ID);
            }
        }

        public static byte[] SerializeGroup(Group group)
        {
            string groupJSON = JsonConvert.SerializeObject(group);
            byte[] bytes = Encoding.ASCII.GetBytes(groupJSON);
            return bytes;
        }

        public static Group DeserializeGroup(byte[] bytes)
        {
            string groupJSON = Encoding.ASCII.GetString(bytes);
            Group group = JsonConvert.DeserializeObject<Group>(groupJSON);
            return group;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class GameObject
    {
        # region Parameter
        public bool IsInError = false;
        private string ServerIP = "";
        private Func<bool, string, bool> ErrorPage;
        private Func<bool, string, bool> TextPage;
        private Func<bool, bool> ChangeTurn;
        private int Port = 0;
        private TcpClient client;
        private TcpListener server;
        Tool Tool = new Tool();
        Random rnd;
        bool MyTurn = false;
        #endregion

        #region Method

        #region GetSet
        public void SetCallBack(Func<bool, string, bool> errorCallBack, Func<bool, string, bool> textCallBack, Func<bool, bool> changeTurn)
        {
            if (IsInError)
            {
                return;
            }
            if (errorCallBack != null && textCallBack != null && changeTurn != null)
            {
                ErrorPage = errorCallBack;
                TextPage = textCallBack;
                ChangeTurn = changeTurn;
            }
            else
            {
                SetError("Call Back non Defenie.");
            }
        }

        public void SetServerIpPort(string value, int port)
        {
            if (IsInError)
            {
                return;
            }
            if (ServerIP == "" && Port == 0)
            {
                ServerIP = value;
                Port = port;
            }
            else
            {
                SetError("Muliple connection tenter.");
            }
        }

        public void SetError(string message)
        {
            IsInError = true;
            ErrorPage(true, message);
        }


        public void SetText(string message)
        {
            if (IsInError)
            {
                return;
            }
            TextPage(true, message);
        }
        #endregion

        #region Server Manager
        public void ServerObjectReceive()
        {
            StreamReader reader = new StreamReader(client.GetStream());

            while (client.Connected)
            {
                byte[] receivedBuffer = new byte[1000];
                NetworkStream stream = client.GetStream();
                stream.Read(receivedBuffer, 0, receivedBuffer.Length);
                var objectReceive = (ObjectSend)Tool.ByteArrayToObject(receivedBuffer);
                if (objectReceive.IsMyTurn != MyTurn)
                {
                    ToogleTurn(objectReceive.IsMyTurn);
                }
                   
            }
        }
        #region Join/Create
        public void JoinOnline()
        {
            if (IsInError)
            {
                return;
            }

            if (this.ServerIP == "" || this.Port == 0)
            {
                SetError("Server Ip ou Port introuvable");
                return;
            }
            rnd = new Random();
            var r = rnd.Next(2);
            client = new TcpClient(ServerIP, Port);
            ObjectSend objectSend = new ObjectSend();

            objectSend.IsMyTurn = (r == 0);
            byte[] sendData = Tool.ObjectToByteArray(objectSend);

            NetworkStream stream = client.GetStream();

            stream.Write(sendData, 0, sendData.Length);
            if(objectSend.IsMyTurn)
                Task.Delay(100).ContinueWith(t => ServerObjectReceive());
            ToogleTurn(objectSend.IsMyTurn == false);
        }

        public void CreateServer()
        {
            if (IsInError)
            {
                return;
            }

            if (this.ServerIP == "" || this.Port == 0)
            {
                SetError("Server Ip ou Port introuvable");
                return;
            }
            rnd = new Random();
            IPAddress ip = Dns.GetHostEntry(this.ServerIP).AddressList[0];
            server = new TcpListener(ip, this.Port);
            client = default(TcpClient);
            try
            {
                server.Start();
                SetText("Waiting for Player...");

            }
            catch (Exception exe)
            {
                SetError(exe.ToString());
            }

            while (true)
            {
                client = server.AcceptTcpClient();
                byte[] receivedBuffer = new byte[1000];
                NetworkStream stream = client.GetStream();
                stream.Read(receivedBuffer, 0, receivedBuffer.Length);
                var objectReceive = (ObjectSend)Tool.ByteArrayToObject(receivedBuffer);
                if (objectReceive.IsMyTurn == false)
                    ServerObjectReceive();
                ToogleTurn(objectReceive.IsMyTurn);
                return;
            }
        }
        #endregion
        #endregion

        #region Turn
        void ToogleTurn(bool isMyTurn)
        {
            ChangeTurn(isMyTurn);
            MyTurn = isMyTurn;
            if (isMyTurn)
            {
                SetText("My Turn");

            }
            else
            {
                SetText("Enemy Turn");
            }
        }

        public void PassTurn()
        {
            ObjectSend objectSend = new ObjectSend();

            objectSend.IsMyTurn = MyTurn;
            byte[] sendData = Tool.ObjectToByteArray(objectSend);
            NetworkStream stream = client.GetStream();

            stream.Write(sendData, 0, sendData.Length);

            Task.Delay(100).ContinueWith(t => ServerObjectReceive());
            ToogleTurn(!MyTurn);
        }
        #endregion

        #endregion
    }
}

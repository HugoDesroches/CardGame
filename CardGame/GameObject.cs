using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CardGame
{
    class GameObject
    {
        # region Parameter
        public bool IsInError = false;
        private string ServerIP = "";
        private int Port = 0;
        private TcpClient client;
        private int limitByteSend = 100000;
        private TcpListener server;
        public Game2 GameDesign;
        Tool Tool = new Tool();
        Random rnd;
        public bool MyTurn = false;
        public Player player1;
        public Player player2;
        List<Emplacement> emplList = new List<Emplacement>();
        public List<Emplacement> otherPlayerPlacement = new List<Emplacement>();
        #endregion

        #region Method

        #region GetSet


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
            GameDesign.ErrorPage(true, message);
        }


        public void SetText(string message)
        {
            if (IsInError)
            {
                return;
            }
            GameDesign.TextPage(true, message);
        }
        #endregion

        #region Server Manager
        public void ServerObjectReceive()
        {
            StreamReader reader = new StreamReader(client.GetStream());

            while (client.Connected)
            {
                byte[] receivedBuffer = new byte[limitByteSend];
                NetworkStream stream = client.GetStream();
                stream.Read(receivedBuffer, 0, receivedBuffer.Length);
                var objectReceive = (ObjectSend)Tool.ByteArrayToObject(receivedBuffer);
                if (objectReceive.IsMyTurn != MyTurn)
                {
                    ToogleTurn(objectReceive.IsMyTurn);
                }
                if(player2.deck != objectReceive.PlayerDeck && objectReceive.PlayerDeck != null)
                {
                    player2.deck = objectReceive.PlayerDeck;
                    GameDesign.ChangeDeck2Text(true, player2.deck.Count.ToString());
                }
                if(player2.cardInHand != objectReceive.CardInHand)
                {
                    player2.cardInHand = objectReceive.CardInHand;
                    GameDesign.ChangeCardInHand2(true, player2.cardInHand.Count.ToString());
                }
                if(player2.Ideo != objectReceive.IdeoPoint)
                {
                    player2.Ideo = objectReceive.IdeoPoint;
                    GameDesign.ChangeIdeo2Text(player2.Ideo.ToString());
                }
                if(objectReceive.EmplacementsList != null && objectReceive.EmplacementsList.Count != player2.EmplacementsList.Count)
                {
                    player2.EmplacementsList = objectReceive.EmplacementsList;
                    GameDesign.CreateEmplacement(player2.EmplacementsList, false);
                }

                foreach (var element in objectReceive.OtherPlayerPlacement)
                {
                    if(element.cardPlace != null)
                    {
                        GameDesign.PlaceCardEmplacement(element.Tag, element.cardPlace);
                    }
                }
                 

                if (objectReceive.IsMyTurn == false)
                    Task.Delay(100).ContinueWith(t => ServerObjectReceive());

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

            MyTurn = (r == 0);

            //emplacement create

            var leftValue = 10;
            var id = 0;
            emplList = new List<Emplacement>();
            for (int i = 0; i < 3; i++)
            {
                Emplacement empl = new Emplacement();
                empl.Top = 0;
                empl.Text = "Attaque";
                empl.Color = Color.DarkRed;
                empl.Left = leftValue;
                empl.Tag = id;
                emplList.Add(empl);
                leftValue += 500;
                id++;
            }
            leftValue = 10;
            for (int i = 0; i < 2; i++)
            {
                Emplacement empl = new Emplacement();
                empl.Top = 150;
                empl.Text = "Passive";
                empl.Color = Color.Blue;
                empl.Left = leftValue;
                empl.Tag = id;
                emplList.Add(empl);
                leftValue += 500;
                id++;
            }
           

            CreateFirstTimePlayer(emplList);
            ToogleTurn(MyTurn);
            player2 = new Player();
            this.SendToServer();
            Task.Delay(100).ContinueWith(t => ServerObjectReceive());
           
           
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
                byte[] receivedBuffer = new byte[limitByteSend];
                NetworkStream stream = client.GetStream();
                stream.Read(receivedBuffer, 0, receivedBuffer.Length);
                var objectReceive = (ObjectSend)Tool.ByteArrayToObject(receivedBuffer);
                player2 = new Player();
                player2.deck = objectReceive.PlayerDeck;
                player2.cardInHand = objectReceive.CardInHand;
                player2.Ideo = objectReceive.IdeoPoint;
                player2.EmplacementsList = objectReceive.EmplacementsList;
                GameDesign.CreateEmplacement(player2.EmplacementsList, false);
                GameDesign.ChangeCardInHand2(true, player2.cardInHand.Count.ToString());
                GameDesign.ChangeDeck2Text(true, player2.deck.Count.ToString());
                GameDesign.ChangeIdeo2Text(player2.Ideo.ToString());


                //emplacement create
                emplList = new List<Emplacement>();
                var leftValue = 10;
                var id = 0;
                for (int i = 0; i < 3; i++)
                {
                    Emplacement empl = new Emplacement();
                    empl.Top = 0;
                    empl.Text = "Attaque";
                    empl.Color = Color.DarkRed;
                    empl.Left = leftValue;
                    empl.Tag = id;
                    emplList.Add(empl);
                    leftValue += 500;
                   
                    id++;
                }
                leftValue = 10;
                for (int i = 0; i < 2; i++)
                {
                    Emplacement empl = new Emplacement();
                    empl.Top = 150;
                    empl.Text = "Passive";
                    empl.Color = Color.Blue;
                    empl.Left = leftValue;
                    empl.Tag = id;
                    emplList.Add(empl);
                    leftValue += 500;
                    id++;
                }

                CreateFirstTimePlayer(emplList);
                ToogleTurn(objectReceive.IsMyTurn);
                
                this.SendToServer();


                if (objectReceive.IsMyTurn == false)
                    ServerObjectReceive();


                return;
            }
        }

        public void SendToServer ()
        {
            ObjectSend objectSend = new ObjectSend();
            objectSend.EmplacementsList = emplList;
            objectSend.OtherPlayerPlacement = otherPlayerPlacement;
            objectSend.CardInHand = player1.cardInHand;
            objectSend.PlayerDeck = player1.deck;
            objectSend.IdeoPoint = player1.Ideo;
            objectSend.IsMyTurn = !MyTurn;
            byte[] sendData = Tool.ObjectToByteArray(objectSend);
            NetworkStream stream = client.GetStream();

            stream.Write(sendData, 0, sendData.Length);

        }

        #endregion
        #endregion

        #region Turn
        void ToogleTurn(bool isMyTurn)
        {
            GameDesign.ChangeTurn(isMyTurn);
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
        public void ResetCardInHand()
        {
            GameDesign.ClearCard();
            var screenWidth = 2000;
            var widthMax = 1500;
            var ajustMax = (screenWidth - widthMax) / 2;
            var cardWidth = 130;
            var start = widthMax / (player1.cardInHand.Count + 1);
            var step = (widthMax - start) / player1.cardInHand.Count;
            for (var i = (player1.cardInHand.Count - 1); i >= 0; i--)
            {
                var card = player1.cardInHand[i];
                GameDesign.CreateCard(start + (i * step) - cardWidth + ajustMax, card.Name, card.Img, card.Description, card.Id.ToString(),
                    card.Ideo.ToString(), card.IsPassive,
                    card.Attaque.ToString());
            }
        }

        public void PickACard()
        {
            player1.cardInHand.Add(player1.deck[player1.deck.Count - 1]);
            GameDesign.ClearCard();
            var screenWidth = 2000;
            var widthMax = 1500;
            var ajustMax = (screenWidth - widthMax) / 2;
            var cardWidth = 130;
            var start = widthMax / (player1.cardInHand.Count + 1);
            var step = (widthMax - start) / player1.cardInHand.Count;
            for (var i = (player1.cardInHand.Count - 1); i >= 0; i--)
            {
                var card = player1.cardInHand[i];
                GameDesign.CreateCard(start + (i * step) - cardWidth + ajustMax, card.Name, card.Img, card.Description, card.Id.ToString(),
                    card.Ideo.ToString(), card.IsPassive,
                    card.Attaque.ToString());
            }
            player1.deck.RemoveAt(player1.deck.Count - 1);
            GameDesign.ChangeDeckText(true, player1.deck.Count.ToString());
        }

        public void PassTurn()
        {
            ToogleTurn(!MyTurn);
            PickACard();
            this.SendToServer();
            Task.Delay(100).ContinueWith(t => ServerObjectReceive());
           
        }
        #endregion

        #region Gestion Card


        private void CreateFirstTimePlayer(List<Emplacement> EmplacementsList)
        {
            player1 = new Player();
            var path = "../../Cards.xml";
            XDocument exist = XDocument.Load(path);
            XElement root = exist.Root;
            foreach (var element in root.Elements("Card"))
            {
                if (element.Element("InDeck").Value == "1")
                {
                    Card card = new Card();
                    card.Id = int.Parse(element.Element("Id").Value);
                    card.Name = element.Element("Name").Value;
                    card.Img = element.Element("Img").Value;
                    card.Description = element.Element("Description").Value;
                    card.Ideo = int.Parse(element.Element("Ideo").Value);
                    card.IsPassive = element.Element("Passive").Value == "True";
                    card.Attaque = int.Parse(element.Element("Attaque").Value);
                    player1.deck.Add(card);
                }
            }
            player1.Ideo = 10;
            otherPlayerPlacement = EmplacementsList;
            this.GameDesign.CreateEmplacement(EmplacementsList);
            this.GameDesign.ChangeDeckText(true, player1.deck.Count.ToString());
            this.GameDesign.ChangeIdeoText(player1.Ideo.ToString());
            for (int i =0; i < 5; i++)
            {
                PickACard();
            }
        }
        #endregion

        #endregion
    }
}

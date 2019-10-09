using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace CardGame
{



    public partial class Game : Form
    {
        //start param
        public bool IsOnline = false;
        public bool IsServer = false;

        //server stuff
        public static string data = null;
        string serverIP = "localhost";
        int port = 8080;
        TcpClient client;
        TcpListener server;
        //turn stuff
        GroupBox CardSelected = new GroupBox();

        private class Card
        {
            public int Id = 0;
            public string Name = "";
            public string Img = "";
            public string Description = "";
            public int Ideo = 0;
            public int Attaque = 0;
            public bool IsPassive = false;
            
        }

        private class Player
        {
            public int Ideo = 10;
            public List<Card> Deck = new List<Card>();
            public List<Card> CardInHand = new List<Card>();


        }

        Player player1 = new Player();
        Player player2 = new Player();

        //delegation
        delegate void SetTextCallback(string text, object objectToChange);

        private void SetText(string text, object objectToChange)
        {
            var toChange = (Label)objectToChange;
            if (toChange.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, toChange });
            }
            else
            {
                toChange.Text = text;
            }
        }



        delegate void SetVisibleCallback(bool visible);

        private void SetVisible(bool visible)
        {
            if (this.btnPassTurn.InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(SetVisible);
                this.Invoke(d, new object[] { visible });
            }
            else
            {
                this.btnPassTurn.Visible = visible;
            }
        }

        int LeftValue = 0;

        public Game()
        {
           
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Cards.AutoScroll = true;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            if (IsOnline && IsServer)
                Task.Delay(1000).ContinueWith(t => FirstCreateLoadOnline());
            else if (IsOnline && !IsServer)
                FirstJoinLoadOnline();
            else
                FirstLoadOffline();

        }

        public void FirstJoinLoadOnline()
        {
            client = new TcpClient(serverIP, port);
            System.Random rnd = new System.Random();
            var r = rnd.Next(2);
            r = 1;
            string messageWithEnd = (r == 0 ? "my turn" : "other turn") + "|end|";

            int byteCount = Encoding.ASCII.GetByteCount(messageWithEnd);

            byte[] sendData = new byte[byteCount];

            sendData = Encoding.ASCII.GetBytes(messageWithEnd);

            NetworkStream stream = client.GetStream();

            stream.Write(sendData, 0, sendData.Length);
            if (r == 1)
            {
                this.FirstLoadOffline();
            }

            SetText((r == 1 ? "my turn" : "other turn"), this.Message);
        }

        public void FirstCreateLoadOnline()
        {
            IPAddress ip = Dns.GetHostEntry(serverIP).AddressList[0];
            server = new TcpListener(ip, port);
            client = default(TcpClient);
            try
            {
                server.Start();
                SetText("server start...", this.Message);

            }
            catch (Exception exe)
            {
                SetText(exe.ToString(), this.Message);
            }

            while (true)
            {
                client = server.AcceptTcpClient();
                byte[] receivedBuffer = new byte[100];
                NetworkStream stream = client.GetStream();

                stream.Read(receivedBuffer, 0, receivedBuffer.Length);

                string msg = Encoding.ASCII.GetString(receivedBuffer, 0, receivedBuffer.Length);
                string msgString = msg.Substring(0, msg.IndexOf("|end|"));
                SetText(msgString, this.Message);
                if (msgString == "my turn")
                {
                    this.FirstLoadOffline();
                    //this.MyTurn();
                }
                else
                {
                    this.FirstLoadOffline();
                    MessageReceive();
                }


                return;
            }
        }

        public void MyTurn()
        {
            if(player1.Ideo > 20)
            {
                Win();
            }
            else if (player1.Ideo <= 0)
            {
                Lose();
            }
            else
            {
                foreach (var element in Emplacement.Controls)
                {
                    var group = (GroupBox)element;
                    if (group.Text == "Passive")
                    {
                     
                        if(group.Controls.Count > 0)
                        {
                            var cardVisuel = group.Controls[0];
                            var card = player1.CardInHand.Where(x => x.Id.ToString() == cardVisuel.Tag.ToString()).First();
                            player1.Ideo += card.Attaque;


                        }
                    }
                }
                SetText(player1.Ideo.ToString(), nbIdeo);
                SetText("my turn", this.Message);
                SetVisible(true);
            }
           
        }

        public void Lose()
        {
            SetText("You lose", this.Message);
            DisableAll();
            SetVisible(false);
        }

        public void Win()
        {
            SetText("You Win", this.Message);
            DisableAll();
            SetVisible(false);
        }

        public void DisableAll()
        {
            foreach(var contro in Emplacement.Controls)
            {
               //((GroupBox)contro).Click -= SelectCard_Click;

                //if (sender is GroupBox)
                //{
                //    tag = ((GroupBox)sender).Tag.ToString();
                //}
                //else if (sender is PictureBox)
                //{
                //    tag = ((PictureBox)sender).Tag.ToString();
                //}
                //else if (sender is Label)
                //{
                //    tag = ((Label)sender).Tag.ToString();
                //}

            }

            //Cards
        }

        public void MessageReceive()
        {
            StreamReader reader = new StreamReader(client.GetStream());

            while (client.Connected)
            {
                string message = reader.ReadLine(); //If the string is null, the connection has been lost.
                if (message == "turnPass")
                {
                    this.MyTurn();
                }
            }
        }
        private void btnPassTurn_Click(object sender, EventArgs e)
        {
            if (IsOnline)
            {
                foreach (var element in Cards.Controls)
                {

                    ((GroupBox)element).Top = 0;
                }
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.AutoFlush = true;

                writer.WriteLine("turnPass");

                Task.Delay(100).ContinueWith(t => MessageReceive());
            }
            else
            {
                Task.Delay(1000).ContinueWith(t => MyTurn());
            }
            PickACard();
            SetText("other turn", this.Message);
            SetVisible(false);
        }


        public void FirstLoadOffline()
        {

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

                    player1.Deck.Add(card);
                    player2.Deck.Add(card);
                }
            }
            player1.Deck.Shuffle();
            player2.Deck.Shuffle();


            for (int i = 0; i < 5; i++)
            {
                if (player1.Deck.Count > i)
                {
                    player1.CardInHand.Add(player1.Deck[i]);
                    CreateCard(LeftValue, player1.Deck[i].Name, player1.Deck[i].Img, player1.Deck[i].Description, player1.Deck[i].Id.ToString(),
                        player1.Deck[i].Ideo.ToString(), player1.Deck[i].IsPassive,
                        player1.Deck[i].Attaque.ToString());
                    LeftValue += 300;
                }
                if (player2.Deck.Count > i)
                {
                    player2.CardInHand.Add(player2.Deck[i]);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (player1.Deck.Count > 0)
                {
                    player1.Deck.RemoveAt(0);
                }
                if (player2.Deck.Count > 0)
                {
                    player2.Deck.RemoveAt(0);
                }
            }

            player1NbCard.Text = player1.Deck.Count.ToString();
            player2NbCard.Text = player2.Deck.Count.ToString();
            CreateEmplacement();
            this.MyTurn();
        }

        private void CreateEmplacement()
        {
            var leftValue = 0;
            for(int i = 0; i < 3; i ++)
            {
                GroupBox empl = new GroupBox();
                empl.Top = 0;
                empl.Text = "Attaque";
                empl.ForeColor = Color.DarkRed;
                empl.Width = 270;
                empl.Height = 300;
                empl.Left = leftValue;

                empl.Click += new EventHandler(SelectEmplacement_Click);

                Emplacement.Controls.Add(empl);
                leftValue += 500;
            }
            leftValue = 0;
            for (int i = 0; i < 2; i++)
            {
                GroupBox empl = new GroupBox();
                empl.Top = 300;
                empl.Text = "Passive";
                empl.Width = 270;
                empl.ForeColor = Color.Blue;
                empl.Height = 300;
                empl.Left = leftValue;

                empl.Click += new EventHandler(SelectEmplacement_Click);

                Emplacement.Controls.Add(empl);
                leftValue += 500;
            }
        }

        private void PickACard()
        {
            if (player1.Deck.Count > 0)
            {
                player1.CardInHand.Add(player1.Deck[0]);
                CreateCard(LeftValue, player1.Deck[0].Name, player1.Deck[0].Img, player1.Deck[0].Description,
                    player1.Deck[0].Id.ToString(), player1.Deck[0].Ideo.ToString(), player1.Deck[0].IsPassive,
                    player1.Deck[0].Attaque.ToString());
                LeftValue += 300;
            }
            if (player2.Deck.Count > 0)
            {
                player2.CardInHand.Add(player2.Deck[0]);
            }

            if (player1.Deck.Count > 0)
            {
                player1.Deck.RemoveAt(0);
            }
            if (player2.Deck.Count > 0)
            {
                player2.Deck.RemoveAt(0);
            }

            player1NbCard.Text = player1.Deck.Count.ToString();
            player2NbCard.Text = player2.Deck.Count.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void player1NbCard_Click(object sender, EventArgs e)
        {

        }


        private void CreateCard(int leftValue, string name, string imgUrl, string descString, string id, string ideoString, bool isPassive, string attaque)
        {
            Cards.HorizontalScroll.Value = 0;
            GroupBox card = new GroupBox();
            card.Top = 0;
            card.Text = name;
            card.Width = 270;
            card.Height = 300;
            card.Left = leftValue;
            card.Tag = id;
            card.Click += new EventHandler(SelectCard_Click);

            PictureBox img = new PictureBox();
            img.Image = Image.FromFile(imgUrl);
            img.Top = 20;
            img.SizeMode = PictureBoxSizeMode.StretchImage;
            img.Left = 10;
            img.Width = 250;
            img.Height = 150;
            img.Tag = id;
            img.Click += new EventHandler(SelectCard_Click);

            Label desc = new Label();
            desc.Text = descString;
            desc.Top = 200;
            desc.Left = 10;
            desc.Tag = id;
            desc.Click += new EventHandler(SelectCard_Click);

            Label ideo = new Label();
            ideo.Text = "Coût de point d'idéo: " + ideoString;
            ideo.Top = 250;
            ideo.Width = 120;
            ideo.Left = 10;
            ideo.Tag = id;
            ideo.Click += new EventHandler(SelectCard_Click);
            Label AttquePassive = new Label();
            if (isPassive)
                AttquePassive.Text = "Passive: " + attaque.ToString();
            else
                AttquePassive.Text = "Attque: " + attaque.ToString();
            AttquePassive.Top = 250;
            AttquePassive.Left = 150;
            AttquePassive.Tag = id;
            AttquePassive.Click += new EventHandler(SelectCard_Click);

            if (isPassive)
            {
                card.ForeColor = Color.Blue;
            }
            else
            {
                card.ForeColor = Color.DarkRed;
            }

            card.Controls.Add(ideo);
            card.Controls.Add(AttquePassive);
            card.Controls.Add(desc);
            card.Controls.Add(img);
            Cards.Controls.Add(card);
        }

        private void SelectEmplacement_Click(object sender, System.EventArgs e)
        {
            if (CardSelected.Tag != null && CardSelected.Tag.ToString() != "")
            {
                var found = false;
                foreach (var element in Cards.Controls)
                {
                    if (found)
                    {
                        ((GroupBox)element).Left -= 300;
                    }
                    else if (((GroupBox)element).Tag.ToString() == CardSelected.Tag.ToString())
                    {
                        var card = player1.CardInHand.Where(x => x.Id.ToString() == CardSelected.Tag.ToString()).First();
                        var ideo = card.Ideo;
                        if (card.IsPassive == (((GroupBox)sender).Text == "Passive") && player1.Ideo - ideo > 0)
                        {
                            player1.Ideo -= ideo;

                            LeftValue -= 300;
                            CardSelected.Left = 0;
                            CardSelected.Left = 0;
                            found = true;

                            nbIdeo.Text = player1.Ideo.ToString();
                        }
                      
                    }
                }
                if(found)
                {
                    ((GroupBox)sender).Controls.Add(CardSelected);
                    Cards.Controls.Remove(CardSelected);
                }
            }
          
        }
            
        private void SelectCard_Click(object sender, System.EventArgs e)
        {
            if (!this.btnPassTurn.Visible)
                return;
            var tag = "";
            if (sender is GroupBox)
            {
                tag = ((GroupBox)sender).Tag.ToString();
            }
            else if (sender is PictureBox)
            {
                tag = ((PictureBox)sender).Tag.ToString();
            }
            else if (sender is Label)
            {
                tag = ((Label)sender).Tag.ToString();
            }

            foreach (var element in Cards.Controls)
            {
              
                if (((GroupBox)element).Tag.ToString() == tag)
                {
                    if(CardSelected.Tag != null && CardSelected.Tag.ToString() == tag)
                    {
                        ((GroupBox)element).Top = 0;
                        CardSelected = new GroupBox();
                    }
                    else
                    {
                        CardSelected = ((GroupBox)element);
                        ((GroupBox)element).Top = 10;
                    }
               
                }
                else
                {
                    ((GroupBox)element).Top = 0;
                }
            }
        }
    }

    public static class IListExtensions
    {
        public static readonly Random RandomGenerator = new Random();

        public static void Shuffle<T>(this IList<T> ts)
        {
            var count = ts.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i)
            {
                var r = RandomGenerator.Next(i, count);
                var tmp = ts[i];
                ts[i] = ts[r];
                ts[r] = tmp;
            }
        }
    }
}

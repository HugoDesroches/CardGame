using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Game2 : Form
    {
        #region Param
        GameObject gameSetting = new GameObject();
        public bool CreateServer = false;
        GroupBox CardSelected = new GroupBox();
        const int widthNormal = 130;
        const int widthZoom = 250;
        const int topNormal = 100;
        const int topZoom = 20;
        const int HeightNormal = 150;
        const int HeightZoom = 230;
        const int widthImgNormal = 110;
        const int widthImgZoom = 160;
        const int HeighImgNormal = 90;
        const int HeighImgZoom = 131;
        const int LeftImgNormal = 10;
        const int LeftImgZoom = 50;

        const int changeLeft = 25;
        #endregion

        #region First Load
        public Game2()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            //set error Call back
            gameSetting.GameDesign = this;
        }

        private void Game2_Load(object sender, EventArgs e)
        {
            gameSetting.SetServerIpPort("localhost", 8080);
            if (this.CreateServer)
            {
                Task.Delay(100).ContinueWith(t => gameSetting.CreateServer());
            }
            else
            {
                Task.Delay(100).ContinueWith(t => gameSetting.JoinOnline());
            }
        }
        #endregion

        #region Text
        #region Error
        public bool ErrorPage(bool val = true, string message = "Erreur")
        {
            SetText(message, this.ErrorLabel, this.PanelError, val);
            return true;
        }

        private void PanelError_Click(object sender, EventArgs e)
        {
            this.ErrorPage(false);
        }

        private void ErrorLabel_Click(object sender, EventArgs e)
        {
            this.ErrorPage(false);
        }
        #endregion
        #region Normal Text
        delegate void SetTextCallback(string text, object objectToChange, object Panel, bool visible);

        private void SetText(string text, object objectToChange, object Panel, bool visible)
        {
            var toChange = (Label)objectToChange;
            if (toChange.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, toChange, Panel, visible });
            }
            else
            {
                toChange.Text = text;
                if(Panel != null)
                {
                    if (visible != toChange.Visible)
                        Animation.Animate((Control)Panel, Animation.Effect.Slide, 200, 90);
                }
               
                
            }
        }
        public bool ChangeDeck2Text(bool val = true, string message = "0")
        {
            SetText(message, this.EnemyDeck, null, val);
            return true;
        }
        public bool ChangeCardInHand2(bool val = true, string message = "0")
        {
            SetText(message, this.CardInHand2, null, val);
            return true;
        }

        public bool ChangeIdeo2Text(string message = "0")
        {
            SetText(message, this.IdeoEnemy, null, true);
            return true;
        }
        
        public bool ChangeIdeoText (string message = "0")
        {
            SetText(message, this.IdeoPoint, null, true);
            return true;
        }

        public bool ChangeDeckText(bool val = true, string message = "0")
        {
            SetText(message, this.Deck, null, val);
            return true;
        }

        public bool TextPage(bool val = true, string message = "Text")
        {
            SetText(message, this.TextMessage, this.MessagePanel, val);
            return true;
        }
        #endregion

        #endregion

        public bool ChangeTurn (bool myTurn)
        {
            SetObject(btnPassTurn, myTurn);
            return true;
        }

        delegate void SetObjectCallback(object objectToChange, bool visible);

        private void SetObject(object objectToChange, bool visible)
        {
            var toChange = (Control)objectToChange;
            if (toChange.InvokeRequired)
            {
                SetObjectCallback d = new SetObjectCallback(SetObject);
                this.Invoke(d, new object[] { objectToChange, visible });
            }
            else
            {
                ((Control)objectToChange).Visible = visible;

            }
        }

        private void TextMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnPassTurn_Click(object sender, EventArgs e)
        {
            gameSetting.PassTurn();
        }

        private void CardInHand2_Click(object sender, EventArgs e)
        {

        }


        delegate void ClearCardCallback();

        public void ClearCard()
        {
            var toChange = (Panel)CardsPanel;
            if (toChange.InvokeRequired)
            {
                ClearCardCallback d = new ClearCardCallback(ClearCard);
                this.Invoke(d, new object[] {  });
            }
            else
            {
                CardsPanel.Controls.Clear();
            }
        }

        delegate void CreateCardCallback(int leftValue, string name, string imgUrl, string descString, string id, string ideoString, bool isPassive, string attaque);

        public void CreateCard(int leftValue, string name, string imgUrl, string descString, string id, string ideoString, bool isPassive, string attaque)
        {
            var toChange = (Panel)CardsPanel;
            if (toChange.InvokeRequired)
            {
                CreateCardCallback d = new CreateCardCallback(CreateCard);
                this.Invoke(d, new object[] { leftValue, name, imgUrl, descString, id, ideoString, isPassive, attaque });
            }
            else
            {
                CardsPanel.HorizontalScroll.Value = 0;

                CardsPanel.Controls.Add(CreateCardVisuel(leftValue, name, imgUrl, descString, id, ideoString, isPassive, attaque));


            }
        }

        private GroupBox CreateCardVisuel(int leftValue, string name, string imgUrl, string descString, string id, string ideoString, bool isPassive, string attaque, bool isEnnemy = false)
        {
            GroupBox card = new GroupBox();
            if (isEnnemy)
                card.Top = 0;
            else
                card.Top = topNormal;
            card.Text = name;
            card.Width = widthNormal;
            card.Height = HeightNormal;
            card.Left = leftValue;
            card.Tag = id;
            card.MouseHover += new EventHandler(HoverCard_Click);
            card.Click += new EventHandler(SelectCard_Click);


            PictureBox img = new PictureBox();
            img.Image = Image.FromFile(imgUrl);
            img.Top = 20;
            img.SizeMode = PictureBoxSizeMode.StretchImage;
            img.Left = LeftImgNormal;
            img.Width = widthImgNormal;
            img.Height = HeighImgNormal;
            img.Tag = id;
            img.MouseHover += new EventHandler(HoverCard_Click);
            img.Click += new EventHandler(SelectCard_Click);

            Label desc = new Label();
            desc.Text = descString;
            desc.Top = 160;
            desc.Left = 10;
            desc.Tag = id;
            desc.MouseHover += new EventHandler(HoverCard_Click);
            desc.Click += new EventHandler(SelectCard_Click);

            Label ideo = new Label();
            ideo.Text = "Coût de point d'idéo: " + ideoString;
            ideo.Top = 200;
            ideo.Width = 120;
            ideo.Left = 10;
            ideo.Tag = id;
            ideo.MouseHover += new EventHandler(HoverCard_Click);
            ideo.Click += new EventHandler(SelectCard_Click);
            Label AttquePassive = new Label();
            if (isPassive)
                AttquePassive.Text = "Passive: " + attaque.ToString();
            else
                AttquePassive.Text = "Attque: " + attaque.ToString();
            AttquePassive.Top = 200;
            AttquePassive.Left = 190;
            AttquePassive.Tag = id;
            AttquePassive.MouseHover += new EventHandler(HoverCard_Click);
            AttquePassive.Click += new EventHandler(SelectCard_Click);

            if (isPassive)
            {
                card.ForeColor = Color.Blue;
            }
            else
            {
                card.ForeColor = Color.DarkRed;
            }
           
            card.BringToFront();
            card.Controls.Add(ideo);
            card.Controls.Add(AttquePassive);
            card.Controls.Add(desc);
            card.Controls.Add(img);

            return card;
        }

        private void SelectEmplacement_Click(object sender, System.EventArgs e)
        {
            if (CardSelected.Tag != null && CardSelected.Tag.ToString() != "")
            {
                var found = false;
                foreach (var element in CardsPanel.Controls)
                {
                    if (((GroupBox)element).Tag.ToString() == CardSelected.Tag.ToString())
                    {
                        var card = gameSetting.player1.cardInHand.Where(x => x.Id.ToString() == CardSelected.Tag.ToString()).First();
                        var ideo = card.Ideo;
                        if (card.IsPassive == (((GroupBox)sender).Text == "Passive") && gameSetting.player1.Ideo - ideo > 0)
                        {
                            gameSetting.player1.Ideo -= ideo;
                            ChangeIdeoText(gameSetting.player1.Ideo.ToString());
                            CardSelected.Left = 0;
                            CardSelected.Top = 0;
                            found = true;

                            //find ou mettre la carte pour l'autre player avant de lenvoyer serveur
                            foreach (var empl in gameSetting.otherPlayerPlacement)
                            {
                                if (empl.Tag.ToString() == ((GroupBox)sender).Tag.ToString())
                                {

                                    empl.cardPlace = card;
                                }
                            }

                            gameSetting.player1.cardInHand.Remove(card);
                        }

                    }
                }
                if (found)
                {
                    ((GroupBox)sender).Controls.Add(CardSelected);
                    CardSelected.Width = widthNormal;
                    CardSelected.Top = 0;
                    
                    CardSelected.Height = HeightNormal;
                    foreach (var element in CardSelected.Controls)
                    {
                        if(element.GetType() == typeof(PictureBox))
                        {
                            ((PictureBox)element).Width = widthImgNormal;
                            ((PictureBox)element).Height = HeighImgNormal;
                            ((PictureBox)element).Left = LeftImgNormal;
                        }
                    }

                    CardsPanel.Controls.Remove(CardSelected);
                    gameSetting.ResetCardInHand();
                    gameSetting.SendToServer();
                }
            }

        }
        delegate void PlaceCardEmplacementCallback(int tag, Card card);
        public void PlaceCardEmplacement(int tag, Card card)
        {
            var toChange = (Panel)Emplacement2;
            if (toChange.InvokeRequired)
            {
                PlaceCardEmplacementCallback d = new PlaceCardEmplacementCallback(PlaceCardEmplacement);
                this.Invoke(d, new object[] { tag, card });
                return;
            }
            foreach (var element in Emplacement2.Controls)
            {
                if (((GroupBox)element).Tag.ToString() == tag.ToString() && ((GroupBox)element).Controls.Count == 0)
                {
                    ((GroupBox)element).Controls.Add(CreateCardVisuel(0, card.Name, card.Img, card.Description, card.Id.ToString(), card.Ideo.ToString(), card.IsPassive, card.Attaque.ToString(), true));
                }
            }
        }

        delegate void CreateEmplacementCallback(List<Emplacement> EmplacementsList, bool isPlayer1 = true);
        public void CreateEmplacement(List<Emplacement> EmplacementsList, bool isPlayer1 = true)
        {
            var toChange = (Panel)Emplacement1;
            if (toChange.InvokeRequired)
            {
                CreateEmplacementCallback d = new CreateEmplacementCallback(CreateEmplacement);
                this.Invoke(d, new object[] { EmplacementsList, isPlayer1 });
                return;
            }

            foreach(var empl in EmplacementsList)
            {
                GroupBox empla = new GroupBox();
                empla.Top = empl.Top;
                empla.Text = empl.Text;
                empla.ForeColor = empl.Color;
                empla.Width = widthNormal;

                empla.Height = 150;
                empla.Left = empl.Left;
                empla.Tag = empl.Tag;
                if (isPlayer1)
                {
                    empla.Click += new EventHandler(SelectEmplacement_Click);

                    Emplacement1.Controls.Add(empla);

                }
                else
                    Emplacement2.Controls.Add(empla);
            }
        }

        private void HoverCard_Click(object sender, System.EventArgs e)
        {
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
            else if (sender is Panel)
            {
                tag = ((Panel)sender).Tag.ToString();
            }
            foreach (var element in CardsPanel.Controls)
            {
                if (((GroupBox)element).Tag.ToString() == tag)
                {
                    if (CardSelected.Tag != null && CardSelected.Tag.ToString() == tag)
                    {
                        ((GroupBox)element).Width = widthNormal;
                        if (((GroupBox)element).Top != topNormal)
                            ((GroupBox)element).Left += changeLeft;
                        foreach (var elementControl in ((GroupBox)element).Controls)
                        {
                            if (elementControl.GetType() == typeof(PictureBox))
                            {
                                ((PictureBox)elementControl).Width = widthImgNormal;
                                ((PictureBox)elementControl).Height = HeighImgNormal;
                                ((PictureBox)elementControl).Left = LeftImgNormal;
                            }
                        }
                        ((GroupBox)element).Top = topNormal;
                        ((GroupBox)element).Height = HeightNormal;
                    }
                    else
                    {
                        ((GroupBox)element).Width = widthZoom;
                        if (((GroupBox)element).Top != topZoom)
                            ((GroupBox)element).Left -= changeLeft;
                        foreach (var elementControl in ((GroupBox)element).Controls)
                        {
                            if (elementControl.GetType() == typeof(PictureBox))
                            {
                                ((PictureBox)elementControl).Width = widthImgZoom;
                                ((PictureBox)elementControl).Height = HeighImgZoom;
                                ((PictureBox)elementControl).Left = LeftImgZoom;
                            }
                        }
                        ((GroupBox)element).Height = HeightZoom;
                        ((GroupBox)element).Top = topZoom;
                    }
                }
                else
                {
                    ((GroupBox)element).Width = widthNormal;
                    if (((GroupBox)element).Top != topNormal)
                        ((GroupBox)element).Left += changeLeft;
                    foreach (var elementControl in ((GroupBox)element).Controls)
                    {
                        if (elementControl.GetType() == typeof(PictureBox))
                        {
                            ((PictureBox)elementControl).Width = widthImgNormal;
                            ((PictureBox)elementControl).Height = HeighImgNormal;
                            ((PictureBox)elementControl).Left = LeftImgNormal;
                        }
                    }
                    ((GroupBox)element).Top = topNormal;
                    ((GroupBox)element).Height = HeightNormal;
                }
            }
        }

        private void SelectCard_Click(object sender, System.EventArgs e)
        {
           
            if (!gameSetting.MyTurn)
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
            else if (sender is Panel)
            {
                tag = ((Panel)sender).Tag.ToString();
            }
            var found = false;
            foreach (var element in CardsPanel.Controls)
            {

                if (((GroupBox)element).Tag.ToString() == tag)
                {
                    found = true;
                    if (CardSelected.Tag != null && CardSelected.Tag.ToString() == tag)
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
            if(found == false)
            {
                CardSelected = new GroupBox();
            }
        }
    }
}

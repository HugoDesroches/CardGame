using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CardGame
{
    public partial class Deck : Form
    {
        string path = "../../Cards.xml";
        XElement root;
        int topValue = 0;
        int LeftValue = 0;

        public Deck()
        {
            //FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();

            XDocument exist = XDocument.Load(path);
            root = exist.Root;

            AllCards.AutoScroll = true;

         
            foreach (var element in root.Elements("Card"))
            {
                if(element.Element("InDeck").Value == "0")
                {
                    CreateCard(topValue, element.Element("Name").Value, element.Element("Img").Value, element.Element("Description").Value, element.Element("Id").Value, element.Element("Ideo").Value, 
                        element.Element("Passive").Value == "True", element.Element("Attaque").Value);
                    topValue += 300;
                }
                else
                {
                    CreateCardDeck(LeftValue, element.Element("Name").Value, element.Element("Img").Value, element.Element("Description").Value, element.Element("Id").Value, element.Element("Ideo").Value, 
                        element.Element("Passive").Value == "True",element.Element("Attaque").Value);
                    LeftValue += 300;
                }
              
            }
        }

        private void CreateCardDeck(int leftValue, string name, string imgUrl, string descString, string id, string ideoString, bool isPassive, string attaque)
        {

            var top = 0;
            if (leftValue > (300 * 3))
            {
                var equil = leftValue / 1200;
                top = equil * 300;
                leftValue -= (300 * 4) * equil;
            }
               
            GroupBox card = new GroupBox();
            card.Top = top;
            card.Text = name;
            card.Width = 270;
            card.Height = 300;
            card.Left = leftValue;
            card.Tag = id;
            card.Click += new EventHandler(RemoveToDeck_Click);

            PictureBox img = new PictureBox();
            img.Image = Image.FromFile(imgUrl);
            img.Top = 20;
            img.SizeMode = PictureBoxSizeMode.StretchImage;
            img.Left = 10;
            img.Width = 250;
            img.Height = 150;
            img.Tag = id;
            img.Click += new EventHandler(RemoveToDeck_Click);

            Label desc = new Label();
            desc.Text = descString;
            desc.Top = 200;
            desc.Left = 10;
            desc.Tag = id;
            desc.Click += new EventHandler(RemoveToDeck_Click);

            Label ideo = new Label();
            ideo.Text = "Coût de point d'idéo: " + ideoString;
            ideo.Top = 250;
            ideo.Width = 120;
            ideo.Left = 10;
            ideo.Tag = id;
            ideo.Click += new EventHandler(RemoveToDeck_Click);
            Label AttquePassive = new Label();
            if (isPassive)
                AttquePassive.Text = "Passive: " + attaque.ToString();
            else
                AttquePassive.Text = "Attque: " + attaque.ToString();
            AttquePassive.Top = 250;
            AttquePassive.Left = 150;
            AttquePassive.Tag = id;
            AttquePassive.Click += new EventHandler(RemoveToDeck_Click);

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
            PanelDeck.Controls.Add(card);
        }


        private void CreateCard(int topValue, string name, string imgUrl, string descString, string id, string ideoString, bool isPassive, string attaque)
        {
            GroupBox card = new GroupBox();
            card.Top = topValue;
            card.Text = name;
            card.Width = 270;
            card.Height = 300;
            card.Left = 50;
            card.Tag = id;
            card.Click += new EventHandler(AddToDeck_Click);

            PictureBox img = new PictureBox();
            img.Image = Image.FromFile(imgUrl);
            img.Top = 20;
            img.SizeMode = PictureBoxSizeMode.StretchImage;
            img.Left = 10;
            img.Width = 250;
            img.Height = 150;
            img.Tag = id;
            img.Click += new EventHandler(AddToDeck_Click);

            Label desc = new Label();
            desc.Text = descString;
            desc.Top = 200;
            desc.Left = 10;
            desc.Tag = id;
            desc.Click += new EventHandler(AddToDeck_Click);

            Label ideo = new Label();
            ideo.Text = "Coût de point d'idéo: " + ideoString;
            ideo.Top = 250;
            ideo.Width = 120;
            ideo.Left = 10;
            ideo.Tag = id;
            ideo.Click += new EventHandler(RemoveToDeck_Click);
            Label AttquePassive = new Label();
            if (isPassive)
                AttquePassive.Text = "Passive: " + attaque.ToString();
            else
                AttquePassive.Text = "Attque: " + attaque.ToString();
            AttquePassive.Top = 250;
            AttquePassive.Left = 150;
            AttquePassive.Tag = id;
            AttquePassive.Click += new EventHandler(AddToDeck_Click);

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
            AllCards.Controls.Add(card);
        }

        private void RemoveToDeck_Click(object sender, System.EventArgs e)
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

            var elementChange = root.Elements("Card").Where(x => x.Element("Id").Value == tag).First();
            elementChange.Element("InDeck").Value = "0";
            root.Save(path);
            object elementDelete = new Control();
            bool found = false;

            foreach (var element in PanelDeck.Controls)
            {
                if (found)
                {
                    var top = 0;
                    var leftValue = ((GroupBox)element).Left + ((((GroupBox)element).Top / 300) * 1200) -300;
                    if (leftValue > (300 * 3))
                    {
                        var equil = leftValue / 1200;
                        top = equil * 300;
                        leftValue -= (300 * 4) * equil;
                    }

                    ((GroupBox)element).Left = leftValue;
                    ((GroupBox)element).Top = top;
                }
                if (((GroupBox)element).Tag.ToString() == tag)
                {
                    LeftValue -= 300;
                    found = true;
                    elementDelete = element;
                }
            }

            PanelDeck.Controls.Remove((Control)elementDelete);

            CreateCard(topValue, elementChange.Element("Name").Value, elementChange.Element("Img").Value, 
                elementChange.Element("Description").Value, elementChange.Element("Id").Value, elementChange.Element("Ideo").Value, 
                elementChange.Element("Passive").Value == "True", elementChange.Element("Attaque").Value);
            topValue += 300;

        }

        
        private void AddToDeck_Click(object sender, System.EventArgs e)
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

            var elementChange = root.Elements("Card").Where(x => x.Element("Id").Value == tag).First();
            elementChange.Element("InDeck").Value = "1";
            root.Save(path);
            object elementDelete = new Control();
            bool found = false;

            foreach (var element in AllCards.Controls)
            {
                if (found)
                {
                    ((GroupBox)element).Top -= 300;
                }
                if (((GroupBox)element).Tag.ToString() == tag)
                {
                    topValue -= 300;
                    found = true;
                    elementDelete = element;
                }
            }

            CreateCardDeck(LeftValue, elementChange.Element("Name").Value, elementChange.Element("Img").Value, 
                elementChange.Element("Description").Value, elementChange.Element("Id").Value, 
                elementChange.Element("Ideo").Value, elementChange.Element("Passive").Value == "True", elementChange.Element("Attaque").Value);
            LeftValue += 300;

            AllCards.Controls.Remove((Control)elementDelete);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    var name = "";
                    var id = "";
                    var description = "";
                    var attaque = "";
                    var defence = "";
                    var ideo = "";
                    var imgUrl = "";
                    var passive = "";

                    foreach (string element in files)
                    {
                        if (element.Contains(".txt"))
                        {
                            string[] lines = System.IO.File.ReadAllLines(element);


                            XDocument exist = XDocument.Load(path);
                            XElement root = exist.Root;
                            if (root.Elements("Card").Count() > 0 && root.Elements("Card").Last().Element("Id") != null)
                                id = (int.Parse(root.Elements("Card").Last().Element("Id").Value) + 1).ToString();
                            else
                                id = "0";

                            foreach (string line in lines)
                            {
                                if (line.Contains("Name:"))
                                {
                                    name = line.Substring(line.LastIndexOf(": ") + 2);
                                }
                                if (line.Contains("Description:"))
                                {
                                    description = line.Substring(line.LastIndexOf(": ") + 2);
                                }
                                if (line.Contains("Attaque:"))
                                {
                                    attaque = line.Substring(line.LastIndexOf(": ") + 2);
                                }
                                if (line.Contains("Defence:"))
                                {
                                    defence = line.Substring(line.LastIndexOf(": ") + 2);
                                }
                                if (line.Contains("Ideo:"))
                                {
                                    ideo = line.Substring(line.LastIndexOf(": ") + 2);
                                }
                                if (line.Contains("Passive:"))
                                {
                                    passive = line.Substring(line.LastIndexOf(": ") + 2);
                                }
                            }
                        }
                        else
                        {
                            var nameImg = element.Substring(element.LastIndexOf("\\") + 1);
                            int number = 1;
                            string originName = nameImg;
                            while(File.Exists("../../Img/" + nameImg))
                            {
                                nameImg = number + originName;
                                number++;
                            }
                            imgUrl = "../../Img/" + nameImg;
                            File.Copy(element, "../../Img/" + nameImg);
                        }
                    }

                    XDocument doc = XDocument.Load(path);
                    XElement rootToAdd = new XElement("Card");
                    rootToAdd.Add(new XElement("Id", id));
                    rootToAdd.Add(new XElement("Name", name));
                    rootToAdd.Add(new XElement("Description", description));
                    rootToAdd.Add(new XElement("Attaque", attaque));
                    rootToAdd.Add(new XElement("Defence", defence));
                    rootToAdd.Add(new XElement("Ideo", ideo));
                    rootToAdd.Add(new XElement("Img", imgUrl));
                    rootToAdd.Add(new XElement("InDeck", "0"));
                    rootToAdd.Add(new XElement("Passive", passive));

                    doc.Element("Cards").Add(rootToAdd);
                    doc.Save(path);
                }
            }
        }

        private void Deck_Load(object sender, EventArgs e)
        {

        }
    }
}

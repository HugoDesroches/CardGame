using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    [Serializable]
    public class Card
    {
        public int Id = 0;
        public string Name = "";
        public string Img = "";
        public string Description = "";
        public int Ideo = 0;
        public int Attaque = 0;
        public bool IsPassive = false;
    }

    [Serializable]
    public class Emplacement
    {
        public int Top = 0;
        public string Text = "";
        public Color Color;
        public int Left = 0;
        public int Tag = 0;
        public Card cardPlace;
    }
}

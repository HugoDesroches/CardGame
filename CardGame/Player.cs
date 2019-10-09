using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Player
    {
        public List<Card> deck = new List<Card>();
        public List<Card> cardInHand = new List<Card>();
        public List<Emplacement> EmplacementsList = new List<Emplacement>();
        public int Ideo = 0;
        public Player()
        {
        }
    }
   

}

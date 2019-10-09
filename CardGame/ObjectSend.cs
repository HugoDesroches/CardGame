using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    [Serializable]
    class ObjectSend
    {
        public string message = "";
        public bool IsMyTurn = false;
        public int IdeoPoint = 0;
        public List<Card> PlayerDeck;
        public List<Emplacement> EmplacementsList;
        public List<Emplacement> OtherPlayerPlacement;
        public List<Card> CardInHand;
    }
}

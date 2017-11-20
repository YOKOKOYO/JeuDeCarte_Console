using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuDeCarte_Console.Models.Enums;

namespace JeuDeCarte_Console.Models
{
    public class Card
    {
        public CardSuit CardSuit { get; set; }
        public CardValue CardValue { get; set; }

        public Card(CardSuit cardSuit, CardValue cardValue)
        {
            CardSuit = cardSuit;
            CardValue = cardValue;
        }
    }
}

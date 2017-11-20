using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuDeCarte_Console.Models.Enums;

namespace JeuDeCarte_Console.Models
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public List<CardSuit> AvailableCardSuits { get; set; }
        public List<CardValue> AvailableCardValues { get; set; }

        public Deck(List<CardSuit> availableCardSuits, List<CardValue> availableCardValues)
        {
            AvailableCardSuits = availableCardSuits;
            AvailableCardValues = availableCardValues;

            CreateDeck();
        }

        #region Private Methodes

        private void CreateDeck()
        {
            if (AvailableCardSuits.Count < 1 || AvailableCardValues.Count < 1)
                throw new NotSupportedException("Not enough cards to make a deck.");

            Cards = new List<Card>();

            foreach (var cardSuit in AvailableCardSuits)
            {
                foreach (var cardValue in AvailableCardValues)
                {
                    var card = new Card(cardSuit, cardValue);
                    Cards.Add(card);
                }
            }
        }

        #endregion
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using JeuDeCarte_Console.Interfaces;
using JeuDeCarte_Console.Models;
using JeuDeCarte_Console.Models.Enums;

namespace JeuDeCarte_Console.GameStrategies.Battle_32
{
    // ReSharper disable once InconsistentNaming
    public class Battle32_Strategy : IGameStrategy

    {
        public Window Window { get; set; }
        public Deck Deck { get; set; }

        public Player HumanPlayer { get; set; }
        public Player ComputerPlayer { get; set; }

        public Battle32_Strategy()
        {
            Window = new Window(100, 10);
            HumanPlayer = new Player("Human");
            ComputerPlayer = new Player("Computer");
        }

        public void RenderWindow()
        {
            Console.Clear();

            Console.SetWindowSize(Window.Width, Window.Height);
            Console.SetBufferSize(Window.Width, Window.Height);

            Console.CursorVisible = false;

            Console.Title = "Battle with 32 cards !!";
        }

        public void CreateDeck()
        {
            var availableCardSuits = new List<CardSuit> { CardSuit.Clubs, CardSuit.Diamonds, CardSuit.Hearts, CardSuit.Spades };
            var availableCardValues = new List<CardValue> {CardValue.Ace, CardValue.King, CardValue.Queen, CardValue.Jack, CardValue.Ten, CardValue.Nine, CardValue.Eight, CardValue.Seven };
            
            Deck = new Deck(availableCardSuits, availableCardValues);
        }

        /* Fisher - Yates shuffle */
        public void ShuffleDeck()
        {
            var random = new Random();
            int n = Deck.Cards.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + random.Next(n - i);
                var card = Deck.Cards[r];
                Deck.Cards[r] = Deck.Cards[i];
                Deck.Cards[i] = card;
            }
        }

        public void DistributeDeck()
        {
            for (int i = 0; i < Deck.Cards.Count; i++)
            {
                if (i % 2 == 0)
                    HumanPlayer.Cards.Add(Deck.Cards[i]);
                else
                    ComputerPlayer.Cards.Add(Deck.Cards[i]);
            }
        }

        public void Play()
        {
            var isVictoryDecided = false;

            while (isVictoryDecided == false)
            {
                isVictoryDecided = PlayTurn();
                var key = Console.ReadKey();
            }
        }

        private bool PlayTurn()
        {
            var cardHuman = HumanPlayer.Cards.First();
            HumanPlayer.Cards.Remove(cardHuman);
            var cardComputer = ComputerPlayer.Cards.First();
            ComputerPlayer.Cards.Remove(cardComputer);

            ShowCards(cardHuman, cardComputer);

            if (cardHuman.CardValue >= cardComputer.CardValue)
            {
                HumanPlayer.Cards.Add(cardHuman);
                HumanPlayer.Cards.Add(cardComputer);
            }
            else
            {
                ComputerPlayer.Cards.Add(cardHuman);
                ComputerPlayer.Cards.Add(cardComputer);
            }

            if (HumanPlayer.Cards.Any() == false || ComputerPlayer.Cards.Any() == false)
                return true;

            return false;
        }

        private void ShowCards(Card cardHuman, Card cardComputer)
        {
            Console.Clear();
            Console.WriteLine($"Human    {HumanPlayer.Cards.Count}: {cardHuman.CardValue} of {cardHuman.CardSuit}.");
            Console.WriteLine($"Computer {ComputerPlayer.Cards.Count}: {cardComputer.CardValue} of {cardComputer.CardSuit}.");
        }
    }
}

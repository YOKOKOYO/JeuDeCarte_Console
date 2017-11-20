using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeCarte_Console.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public List<Card> Cards { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
            Cards = new List<Card>();
        }
    }
}

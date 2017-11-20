using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeCarte_Console.Interfaces
{
    public interface IGameStrategy
    {
        void RenderWindow();

        void CreateDeck();

        void ShuffleDeck();

        void DistributeDeck();

        void Play();
    }
}

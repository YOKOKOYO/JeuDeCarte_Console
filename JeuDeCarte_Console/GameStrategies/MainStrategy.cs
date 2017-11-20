using System;
using System.Collections.Generic;
using JeuDeCarte_Console.Helpers.Factories;
using JeuDeCarte_Console.Helpers.Mappers;
using JeuDeCarte_Console.Interfaces;
using JeuDeCarte_Console.Models.Enums;

namespace JeuDeCarte_Console.GameStrategies
{
    class MainStrategy
    {
        #region Dependencies

        private GameNameMapper GameNameMapper
            => new GameNameMapper();

        private GameStrategyFactory GameStrategyFactory
            => new GameStrategyFactory();

        #endregion

        public List<GameName> GamesAvailables
            => new List<GameName> {GameName.Battle_32, GameName.Battle_52};

        private IGameStrategy _gameStrategy { get; set; }

        public void InitTable()
        {
            var gameName = ChooseGame();

            _gameStrategy = GameStrategyFactory.Get(gameName);

            _gameStrategy.RenderWindow();
        }

        public void InitGame()
        {
            _gameStrategy.CreateDeck();
            _gameStrategy.ShuffleDeck();
            _gameStrategy.DistributeDeck();
        }

        public void StartGame()
        {
            _gameStrategy.Play();
        }

        private GameName ChooseGame()
        {
            Console.WriteLine("Choose your game : ");

            for (int i = 0; i < GamesAvailables.Count; i++)
            {
                Console.WriteLine($"Type [{i}] for a game of : [{GameNameMapper.Map(GamesAvailables[i])}].");
            }

            Console.Write("Your answer : ");

            var answer = Console.ReadKey();

            Console.WriteLine();

            for (int i = 0; i < GamesAvailables.Count; i++)
            {
                if (i.ToString() == answer.KeyChar.ToString())
                {
                    Console.WriteLine($"You've choosed to play a game of : [{GameNameMapper.Map(GamesAvailables[i])}].");
                    return GamesAvailables[i];
                }
                    
            }

            throw new NotSupportedException($"Key : [{answer.KeyChar} not supported.]");
        }


    }
}

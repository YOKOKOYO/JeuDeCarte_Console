using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuDeCarte_Console.GameStrategies.Battle_32;
using JeuDeCarte_Console.GameStrategies.Battle_52;
using JeuDeCarte_Console.Interfaces;
using JeuDeCarte_Console.Models.Enums;

namespace JeuDeCarte_Console.Helpers.Factories
{
    public class GameStrategyFactory
    {
        public IGameStrategy Get(GameName gameName)
        {
            switch (gameName)
            {
                case GameName.Battle_32:
                    return new Battle32_Strategy();

                case GameName.Battle_52:
                    return new Battle52_Strategy();

                default:
                    throw new NotSupportedException($"Game : [{gameName}] not supported.");
            }
        }
    }
}

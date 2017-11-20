using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuDeCarte_Console.Models.Enums;

namespace JeuDeCarte_Console.Helpers.Mappers
{
    public class GameNameMapper
    {
        public string Map(GameName gameName)
        {
            switch (gameName)
            {
                case GameName.Battle_32:
                    return "Battle with 32 cards";

                case GameName.Battle_52:
                    return "Battle with 52 cards";

                default:
                    throw new NotSupportedException($"Game : [{gameName}] not supported.");
            }
        }
    }
}

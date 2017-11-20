using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuDeCarte_Console.GameStrategies;

namespace JeuDeCarte_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainStrategy = new MainStrategy();

            mainStrategy.InitTable();
            mainStrategy.InitGame();
            mainStrategy.StartGame();

            Console.ReadKey();
        }
    }
}

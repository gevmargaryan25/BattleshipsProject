using Battleships.Models;
using System.Collections.Generic;
namespace Battleships.ViewModels
{
    public class BattleshipsViewModel
    {
        public BattleshipsViewModel()
        {
            Player = new BoardGenerator();
            Collection = Player.Generate(10);
            Array = new Position[100];
            int k = 0;
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Array[k] = Collection[i, j];
                }
            }
        }
        public BoardGenerator Player { get; set; }
        public Position[,] Collection { get; set; }
        public Position[] Array { get; set; }
    }
}

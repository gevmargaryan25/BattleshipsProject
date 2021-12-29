using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Battleships
{
    public class BoardGenerator
    {
        public List<List<Position>> Generate(int rank)
        {
            var board = new Position[rank, rank];
            GenerateMatrix(board);
            List<List<Position>> result = new List<List<Position>>();
            for (int i = 0; i < 10; ++i)
            {
                List<Position> temp = new List<Position>();
                for (int j = 0; j < 10; ++j)
                {
                    temp.Add(board[i, j]);
                }
                result.Add(temp);
            }
            return result;
        }
        //private static void DisplayMatrix(int[,] matrix)
        //{
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            Console.Write(matrix[i, j] + " ");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine("++++++++++++++++++++++++++++++++++++");
        //}
        private static void GenerateMatrix(Position[,] matrix)
        {
            Generate4(matrix);
            Generate3(matrix);
            Generate3(matrix);
            Generate2(matrix);
            Generate2(matrix);
            Generate2(matrix);
            Generate1(matrix);
            Generate1(matrix);
            Generate1(matrix);
            Generate1(matrix);
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    if (matrix[i, j] == null)
                        matrix[i, j] = new Position { PlaceHolderText = "", Text="" };

                }
            }
        }
        private static void Generate4(Position[,] matrix)
        {
            var random = new Random();
            var direction = random.Next(1, 3);
            var start = random.Next(0, 7);
            var position = random.Next(0, 10);
            if (direction == 1)
            {
                for (var i = 0; i < 4; i++)
                {
                    matrix[position, start + i] = new Position
                    {
                        Row = position,
                        Column = start + i,
                        ShipType = 4,
                        Direction = direction,
                        PieceOrderNumber = i + 1,
                        PlaceHolderText = "",
                        Text="4"
                    };
                }
            }
            else
            {
                for (var i = 0; i < 4; i++)
                {
                    matrix[start + i, position] = new Position
                    {
                        Row = start + i,
                        Column = position,
                        ShipType = 4,
                        Direction = direction,
                        PieceOrderNumber = i + 1,
                        PlaceHolderText = "",
                        Text="4"
                    };
                }
            }
        }
        private static void Generate3(Position[,] matrix)
        {
            while (true)
            {
                var random = new Random();
                var direction = random.Next(1, 3);
                if (direction == 1)
                {
                    var row = random.Next(0, 10);
                    var column = random.Next(0, 8);
                    var i = 0;
                    while (i < 3)
                    {
                        if (!IsValid(matrix, row, column + i))
                            break;
                        i++;
                    }
                    if (i == 3)
                    {
                        matrix[row, column] = new Position
                        { Row = row, Column = column, ShipType = 3, Direction = direction, PieceOrderNumber = 1, PlaceHolderText = "", Text="3" };
                        matrix[row, column + 1] = new Position
                        { Row = row, Column = column + 1, ShipType = 3, Direction = direction, PieceOrderNumber = 2, PlaceHolderText = "", Text = "3" };
                        matrix[row, column + 2] = new Position
                        { Row = row, Column = column + 2, ShipType = 3, Direction = direction, PieceOrderNumber = 3, PlaceHolderText = "", Text = "3" };
                        break;
                    }
                }
                else
                {
                    var row = random.Next(0, 8);
                    var column = random.Next(0, 10);
                    var i = 0;
                    while (i < 3)
                    {
                        if (!IsValid(matrix, row + i, column))
                            break;
                        i++;
                    }
                    if (i == 3)
                    {
                        matrix[row, column] = new Position
                        { Row = row, Column = column, ShipType = 3, Direction = direction, PieceOrderNumber = 1, PlaceHolderText = "", Text = "3" };
                        matrix[row + 1, column] = new Position
                        { Row = row + 1, Column = column, ShipType = 3, Direction = direction, PieceOrderNumber = 2, PlaceHolderText = "", Text = "3" };
                        matrix[row + 2, column] = new Position
                        { Row = row + 2, Column = column, ShipType = 3, Direction = direction, PieceOrderNumber = 3, PlaceHolderText = "", Text = "3" };
                        break;
                    }
                }
            }
        }
        private static void Generate2(Position[,] matrix)
        {
            while (true)
            {
                var random = new Random();
                var direction = random.Next(1, 3);
                if (direction == 1)
                {
                    var row = random.Next(0, 10);
                    var column = random.Next(0, 9);
                    var i = 0;
                    while (i < 2)
                    {
                        if (!IsValid(matrix, row, column + i))
                            break;
                        i++;
                    }
                    if (i == 2)
                    {
                        matrix[row, column] = new Position
                        { Row = row, Column = column, ShipType = 2, Direction = direction, PieceOrderNumber = 1, PlaceHolderText = "", Text="2" };
                        matrix[row, column + 1] = new Position
                        { Row = row, Column = column + 1, ShipType = 2, Direction = direction, PieceOrderNumber = 2, PlaceHolderText = "", Text="2" };
                        break;
                    }
                }
                else
                {
                    var row = random.Next(0, 9);
                    var column = random.Next(0, 10);
                    var i = 0;
                    while (i < 2)
                    {
                        if (!IsValid(matrix, row + i, column))
                            break;
                        i++;
                    }
                    if (i == 2)
                    {
                        matrix[row, column] = new Position
                        { Row = row, Column = column, ShipType = 2, Direction = direction, PieceOrderNumber = 1, PlaceHolderText = "", Text = "2" };
                        matrix[row + 1, column] = new Position
                        { Row = row + 1, Column = column, ShipType = 2, Direction = direction, PieceOrderNumber = 2, PlaceHolderText = "", Text = "2" };
                        break;
                    }
                }
            }
        }
        private static void Generate1(Position[,] matrix)
        {
            while (true)
            {
                var random = new Random();
                var direction = random.Next(1, 3);
                if (direction == 1)
                {
                    var row = random.Next(0, 10);
                    var column = random.Next(0, 10);
                    var i = 0;
                    while (i < 1)
                    {
                        if (!IsValid(matrix, row, column + i))
                            break;
                        i++;
                    }
                    if (i == 1)
                    {
                        matrix[row, column] = new Position
                        { Row = row, Column = column, ShipType = 1, Direction = direction, PieceOrderNumber = 1, PlaceHolderText="", Text="1" };
                        break;
                    }
                }
                else
                {
                    var row = random.Next(0, 10);
                    var column = random.Next(0, 10);
                    var i = 0;
                    while (i < 1)
                    {
                        if (!IsValid(matrix, row + i, column))
                            break;
                        i++;
                    }
                    if (i == 1)
                    {
                        matrix[row, column] = new Position
                        { Row = row, Column = column, ShipType = 1, Direction = direction, PieceOrderNumber = 1, PlaceHolderText = "", Text="1" };
                        break;
                    }
                }
            }
        }
        private static bool IsValid(Position[,] matrix, int row, int column)
        {
            var k = matrix.GetLength(1);
            for (var i = row - 1; i <= row + 1; i++)
            {
                for (var j = column - 1; j <= column + 1; j++)
                {
                    if (i < 0 || i >= k || j < 0 || j >= k) continue;
                    if (matrix[i, j] != null) return false;
                }
            }
            return true;
        }
        public static int Hit(List<List<Position>> board, int row, int column)
        {
            var currentCell = board[row][column];
            if (currentCell.ShipType == 0)
            {
                board[row][column].IsDummy = true;
                return 0;
            }
            if (currentCell.IsDummy) return 0;
            currentCell.IsHit = true;
            // check for match end
            if (board.SelectMany(x => x).Count(x => x.ShipType != 0 && x.IsHit) == 20) return 3;
            //check ship destroy
            var direction = currentCell.Direction;
            switch (direction)
            {
                case 1:
                    {
                        var startColumn = currentCell.Column - currentCell.PieceOrderNumber + 1;
                        var endColumn = startColumn + currentCell.ShipType;
                        var count = 0;
                        for (var i = startColumn; i < endColumn; i++)
                            if (board[row][i].IsHit)
                                count++;
                        if (count == currentCell.ShipType) return 2;
                        break;
                    }
                case 2:
                    {
                        var startRow = currentCell.Row - currentCell.PieceOrderNumber + 1;
                        var endRow = startRow + currentCell.ShipType;
                        var count = 0;
                        for (var i = startRow; i < endRow; i++)
                            if (board[i][column].IsHit)
                                count++;
                        if (count == currentCell.ShipType) return 2;
                        break;
                    }
            }
            return 1;
        }
    }
}
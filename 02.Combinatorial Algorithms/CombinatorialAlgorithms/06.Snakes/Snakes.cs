namespace _06.Snakes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Snakes
    {
        private static int size;
        private static int countOfSnakeFound;
        private static HashSet<string> usedSnake = new HashSet<string>();

        public static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());

            Stack<Cell> snake = new Stack<Cell>();
            List<char> directions = new List<char>();

            GenerateSnake(new Cell(0, 0), snake, directions, 'S');
            Console.WriteLine("Snakes count = {0}", countOfSnakeFound);
        }

        private static void GenerateSnake(Cell cell, Stack<Cell> snake, List<char> directions, char direction)
        {
            if (snake.Count == size)
            {
                string currentSnake = new string(directions.ToArray());
                if (!usedSnake.Contains(currentSnake))
                {
                    Console.WriteLine(currentSnake);
                    countOfSnakeFound++;
                    usedSnake.Add(currentSnake);
                    MarkIzomorphicSnake(directions.ToList());
                }

                return;
            }

            if (snake.Contains(cell))
            {
                return;
            }

            snake.Push(cell);
            directions.Add(direction);

            GenerateSnake(new Cell(cell.Row, cell.Col + 1), snake, directions, 'R');

            if (snake.Count > 1)
            {
                GenerateSnake(new Cell(cell.Row + 1, cell.Col), snake, directions, 'D');
            }

            if (snake.Count > 2)
            {
                GenerateSnake(new Cell(cell.Row, cell.Col - 1), snake, directions, 'L');
            }

            if (snake.Count > 3)
            {
                GenerateSnake(new Cell(cell.Row - 1, cell.Col), snake, directions, 'U');
            }

            snake.Pop();
            directions.RemoveAt(directions.Count - 1);
        }

        private static void MarkIzomorphicSnake(List<char> directions)
        {
            FlipSnake(directions);
            usedSnake.Add(new string(directions.ToArray()));

            SwitchSnakeHeadAndTail(directions);
            directions.Reverse();

            while (directions.Count > 1 && directions[1] != 'R')
            {
                RotateSnakeClockSize(directions);
            }
            usedSnake.Add(new string(directions.ToArray()));

            FlipSnake(directions);
            usedSnake.Add(new string(directions.ToArray()));
        }

        private static void FlipSnake(List<char> directions)
        {
            for (int i = 0; i < directions.Count; i++)
            {
                switch (directions[i])
                {
                    case 'U':
                        directions[i] = 'D'; break;
                    case 'D':
                        directions[i] = 'U'; break;
                }
            }
        }

        private static void RotateSnakeClockSize(List<char> directions)
        {
            for (int i = 0; i < directions.Count; i++)
            {
                switch (directions[i])
                {
                    case 'U':
                        directions[i] = 'R'; break;
                    case 'D':
                        directions[i] = 'L'; break;
                    case 'R':
                        directions[i] = 'D'; break;
                    case 'L':
                        directions[i] = 'U'; break;
                }
            }
        }

        private static void SwitchSnakeHeadAndTail(List<char> directions)
        {
            char temp = directions[0];
            directions.RemoveAt(0);
            directions.Add(temp);

            for (int i = 0; i < directions.Count; i++)
            {
                switch (directions[i])
                {
                    case 'U':
                        directions[i] = 'D'; break;
                    case 'D':
                        directions[i] = 'U'; break;
                    case 'L':
                        directions[i] = 'R'; break;
                    case 'R':
                        directions[i] = 'L'; break;
                }
            }
        }
    }

    public class Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public override bool Equals(object obj)
        {
            Cell other = obj as Cell;
            return this.Row == other.Row && this.Col == other.Col;
        }

        public override int GetHashCode()
        {
            return this.Row.GetHashCode() ^ this.Col.GetHashCode();
        }
    }
}

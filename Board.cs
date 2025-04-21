using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    public class Board
    {
        public Cell[,] Cells { get; }

        public Board(int boardSize, int numberOfSnakes, int numberOfLadders)
        {
            Cells = InitializeCells(boardSize);
            AddSnakesAndLadders(numberOfSnakes, numberOfLadders);
        }

        private Cell[,] InitializeCells(int boardSize)
        {
            var cells = new Cell[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    cells[i, j] = new Cell();
                }
            }
            return cells;
        }

        private void AddSnakesAndLadders(int numberOfSnakes, int numberOfLadders)
        {
            var random = new Random();
            int size = Cells.GetLength(0);
            int maxPosition = size * size - 1;

            // Add snakes
            while (numberOfSnakes > 0)
            {
                int start = random.Next(1, maxPosition);
                int end = random.Next(1, maxPosition);

                if (end >= start) continue;

                var cell = GetCell(start);
                cell.Jump = new Jump { Start = start, End = end };
                numberOfSnakes--;
            }

            // Add ladders
            while (numberOfLadders > 0)
            {
                int start = random.Next(1, maxPosition);
                int end = random.Next(1, maxPosition);

                if (start >= end) continue;

                var cell = GetCell(start);
                cell.Jump = new Jump { Start = start, End = end };
                numberOfLadders--;
            }
        }

        public Cell GetCell(int position)
        {
            int size = Cells.GetLength(0);
            int row = position / size;
            int col = position % size;
            return Cells[row, col];
        }
    }
}

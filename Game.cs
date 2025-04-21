using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SnakeLadder
{
    public class Game
    {
        private readonly Board _board;
        private readonly Dice _dice;
        private readonly Queue<Player> _players;
        private Player _winner;

        public Game()
        {
            _board = new Board(10, 5, 4);
            _dice = new Dice(1);
            _players = new Queue<Player>();
            InitializePlayers();
        }

        private void InitializePlayers()
        {
            _players.Enqueue(new Player("p1", 0));
            _players.Enqueue(new Player("p2", 0));
        }

        public void StartGame()
        {
            while (_winner == null)
            {
                Player current = _players.Dequeue();
                Console.WriteLine($"{current.Id}'s turn. Position: {current.CurrentPosition}");

                int roll = _dice.RollDice();
                int newPosition = current.CurrentPosition + roll;
                newPosition = CheckJump(newPosition);
                current.CurrentPosition = newPosition;

                Console.WriteLine($"{current.Id} moved to {newPosition}");

                if (newPosition >= _board.Cells.GetLength(0) * _board.Cells.GetLength(0) - 1)
                {
                    _winner = current;
                }

                _players.Enqueue(current);
            }

            Console.WriteLine($"Winner is: {_winner.Id}");
        }

        private int CheckJump(int position)
        {
            int maxPosition = _board.Cells.GetLength(0) * _board.Cells.GetLength(0) - 1;
            if (position > maxPosition) return position;

            Cell cell = _board.GetCell(position);
            if (cell.Jump == null) return position;

            string type = cell.Jump.Start < cell.Jump.End ? "ladder" : "snake";
            Console.WriteLine($"Jumped by {type} from {cell.Jump.Start} to {cell.Jump.End}");
            return cell.Jump.End;
        }
    }
}

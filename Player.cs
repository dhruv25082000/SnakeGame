using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Player.cs
namespace SnakeLadder
{
    public class Player
    {
        public string Id { get; set; }
        public int CurrentPosition { get; set; }

        public Player(string id, int currentPosition)
        {
            Id = id;
            CurrentPosition = currentPosition;
        }
    }
}

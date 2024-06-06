using System;
using System.Collections.Generic;

#nullable disable

namespace TennisPlayers.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int Wins { get; set; }
    }
}

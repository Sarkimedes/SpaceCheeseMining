using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCheeseMining
{
    public class ServerScore : IComparable<ServerScore>
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int Moves { get; set; }

        public int CompareTo(ServerScore other)
        {
            return Moves.CompareTo(other.Moves);
        }
    }
}

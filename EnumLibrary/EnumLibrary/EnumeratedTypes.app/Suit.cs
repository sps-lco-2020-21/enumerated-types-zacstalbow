using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumLibrary
{
    [Flags]
    public enum Suit
    {
        Spades = 1,
        Clubs = 2,
        Diamonds = 4,
        Hearts = 8,

        Red = Diamonds | Hearts,
        Black = Spades | Clubs
    }

}

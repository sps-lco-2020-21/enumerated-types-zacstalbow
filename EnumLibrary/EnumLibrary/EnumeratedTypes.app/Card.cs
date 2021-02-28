using EnumLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumeratedTypes.app
{
    public class Card
    {
        Cards _value;
        Suit _suit;
        public Cards Value { get { return _value; } set { Value = _value; } }
        public Suit Suit { get { return _suit; } set { Suit = _suit; } }
        public Card(Cards value, Suit suit)
        {
            _value = value;
            _suit = suit;
        }
        public override string ToString()
        {
            return $"{_value.ToString()} of {_suit.ToString()}";
        }
        public string NameCard(string s)
        {
            if (s.Length != 2)
            {
                throw new ArgumentException();
            }
            string picture = null;
            switch (s.Substring(0, 1))
            {
                case "T":
                case "t":
                    picture = "Ten";
                    break;
                case "J":
                case "j":
                    picture = "Jack";
                    break;
                case "Q":
                case "q":
                    picture = "Queen";
                    break;
                case "K":
                case "k":
                    picture = "King";
                    break;
                case "A":
                case "a":
                    picture = "Ace";
                    break;
                default:
                    throw new ArgumentException();
            }
            string card = (Convert.ToInt32(s.Substring(0, 1)) < 10) && Convert.ToInt32(s.Substring(0, 1)) > 1 ? s.Substring(0, 1) : picture;
            switch (s.Substring(1, 1))
            {
                case "C":
                case "c":
                    _suit = Suit.Clubs;
                    break;
                case "D":
                case "d":
                    _suit = Suit.Diamonds;
                    break;
                case "S":
                case "s":
                    _suit = Suit.Spades;
                    break;
                case "H":
                case "h":
                    _suit = Suit.Hearts;
                    break;
                default:
                    throw new ArgumentException();
            }
            return $"the {card} of {_suit}";
        }
    }
}

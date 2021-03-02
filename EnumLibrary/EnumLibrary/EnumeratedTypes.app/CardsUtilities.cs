using EnumeratedTypes.app;
using EnumLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EnumeratedTypes
{
    public static class CardsUtilities
    {
        public static Cards NextCard(Cards current)
        {
            Cards next = current + 1;
            return (Cards)(((int)current + 1) % Enum.GetNames(typeof(Cards)).Count());
        }
        public static List<Cards> CountConsecutive(this List<Cards> cards)
        {

            List<Cards> result = new List<Cards>();
            List<Cards> current = new List<Cards>() { cards[0] };
            for (int i = 0; i < cards.Count - 1; i++)
            {
                int card = Convert.ToInt32(cards[i]);
                int next = Convert.ToInt32(cards[i + 1]);
                if ((next - card) == 1 || card == 13 && next == 1)
                {
                    current.Add(cards[i]);
                }
                else
                {
                    if (current.Count > result.Count)
                    {
                        result = new List<Cards>(current);
                    }
                    if(result.Count > cards.Count - i)
                    {
                        break;
                    }
                    current.Clear();
                    current.Add(cards[i]);
                }
            }
            return result;
        }
        public static List<Card> AllCards()
        {
            List<Card> allCards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Cards value in Enum.GetValues(typeof(Cards)))
                {
                    allCards.Add(new Card(value, suit));
                }
            }
            return allCards;
        }
        public static void Shuffle(List<Card> deck)
        {
            Random random = new Random();
            int n = deck.Count;
            while (n > 1) //loop from back to front
            {
                n--;
                int i = random.Next(n + 1);
                Card temp = deck[i];
                deck[i] = deck[n];
                deck[i] = temp; //swap values from index[loop] with index[random] then loop again with one less value
                                //therefore the value that has just been swapped remains untouched
            }
        }
        public static int[] Sort(int[] a)
        {
            int t;
            for (int p = 0; p <= a.Length - 2; p++)
            {
                for (int i = 0; i <= a.Length - 2; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        t = a[i + 1];
                        a[i + 1] = a[i];
                        a[i] = t;
                    }
                }
            }
            return a;
        }
        public static bool Pair(List<Cards> hand)
        {
            int[] store = new int[5];
            for(int i = 0; i < hand.Count; i++)
            {
                store[i] = Convert.ToInt32(hand[i]);
            }
            Sort(store);
            for (int i = 0; i < hand.Count; i++)
            {
                if (store[i] == store[i + 1])
                {
                    return true;
                }
            }
            return false;
        }
        public static bool TwoPairs(List<Cards> hand)
        {
            int[] store = new int[5];
            for (int i = 0; i < hand.Count; i++)
            {
                store[i] = Convert.ToInt32(hand[i]);
            }
            Sort(store);
            for (int i = 0; i < hand.Count; i++)
            {
                if (store[i] == store[i + 1])
                {
                    for (int j = i - 1; i < hand.Count - 1; i++)
                    {
                        store[i] = store[i + 1];
                    }
                    for (int n = i; n < hand.Count - 2; n++)
                    {
                        store[n] = store[n + 1];
                    }
                }
            }
            for (int i = 0; i < hand.Count - 2; i++)
            {
                if (store[i] == store[i + 1])
                {
                    return true;
                }
            }
            return false;
        }
    }

}



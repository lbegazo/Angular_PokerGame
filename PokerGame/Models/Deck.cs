using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerGame.Models
{
    public class Deck
    {
        public Card[] Cards;

        public Deck()
        {
            Cards = new Card[52];
            var index = 0;

            foreach (var suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (var rank in Enum.GetValues(typeof(Rank)))
                {
                    Cards[index++] = new Card(Convert.ToInt32(suit), Convert.ToInt32(rank));
                }
            }
            this.Shuffle();
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(n => Guid.NewGuid()).ToArray();
            //Cards = Cards.OrderBy(n => n.nSuit).ToArray();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerGame.Models
{
    public class Game
    {
        int numberCardsInHand = 5;
        public Deck deck { get; set; }

        public IEnumerable<Card> CardsInHand { get { return deck.Cards.Take(numberCardsInHand); } }

        public Game()
        {
            deck = new Deck();
        }
    }
}
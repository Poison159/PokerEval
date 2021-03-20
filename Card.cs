using System;
using System.Collections.Generic;
using System.Text;

namespace PokerEval
{
    enum Rank
    {
        two = 2, three, four, five, six,
        seven, eight, nine, ten, jack, queen, king, ace
    }


    enum Suit
    {
        Heart,
        Club,
        Dimond,
        Spade
    }
    class Card
    {
        public Card(Suit _suit, Rank _rank)
        {
            rank = _rank;
            suit = _suit;
        }
        public Rank rank { get; set; }
        public Suit suit { get; set; }
    }
}

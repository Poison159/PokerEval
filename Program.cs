using PokerEval;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet
{
   
   
   
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int j = 0;
            var cards = fiilDeck();
            var randomCards = shuffleDeck(cards);

            while(i < 1000){
                randomCards = shuffleDeck(randomCards);
                i++;
            }

            while (j < 9)
            {
                var myCards = dealHand(randomCards).OrderBy(x => x.rank).ToList();
                printHand(myCards);
                Console.WriteLine(Eval.evaluateDeck(myCards));
                j++;
            }

            //var ownHand = new List<Card> {
            //    new Card(Suit.Spade,Rank.ten),
            //    new Card(Suit.Heart,Rank.ten),
            //    new Card(Suit.Spade,Rank.two),
            //    new Card(Suit.Dimond,Rank.two),
            //    new Card(Suit.Spade,Rank.seven)
            //};
            //var myCards = ownHand.OrderBy(x => x.rank).ToList();
            //printHand(myCards);

            //Console.WriteLine(Eval.evaluateDeck(myCards));
        }
        static List<Card> dealHand(List<Card> cards) {
            var retList = new List<Card>();
            int max = 5;
            int i = 0;
            while (i < max) {
                retList.Add(cards[i]);
                cards.RemoveAt(i);
                i++;
            }
            return retList;
        }

        static List<Card> shuffleDeck(List<Card> cards){
            var retList = new List<Card>();
            Random rnd = new Random();
            var max = 0;
            while(cards.Count != 0){
                max = cards.Count - 1;
                int i = rnd.Next((max));
                if(cards[i] != null)
                    retList.Add(cards[i]);
                cards.RemoveAt(i);
            }
            return retList; 
        }

        static List<Card> fiilDeck(){
            var retCards = new List<Card>();
            
            foreach (Suit suit in (Suit[]) Enum.GetValues(typeof(Suit))){
                foreach(Rank rank in (Rank[]) Enum.GetValues(typeof(Rank))){
                    var card = new Card(suit,rank);
                    retCards.Add(card);
                }
            }
            return retCards;
        }

        static void printHand(List<Card> myCards)
        {
            Console.WriteLine("---------------------------");
            foreach (var card in myCards)
            {
                Console.WriteLine(card.rank.ToString() + " of " + card.suit.ToString() + "s");

            }
            Console.WriteLine("---------------------------------");
        }
    }
}

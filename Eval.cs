using PokerEval;
using System.Collections.Generic;

namespace dotnet{
    enum Hand{
        royalFlush = 1,
        straightFlush,
        fourOfAKind,
        fullHouse,
        flush,
        straight,
        threeOfAKind,
        twoPair,
        pair,
        highCard
    }
    class Eval{
        public static string evaluateDeck(List<Card> cards){
            if (isPair(cards))
                return Hand.pair.ToString().ToUpper();
            else if (isTwoPair(cards))
                return Hand.twoPair.ToString().ToUpper();
            else if (isThreeOfAKind(cards))
                return Hand.threeOfAKind.ToString().ToUpper();
            else if (isStraight(cards))
                return Hand.straight.ToString().ToUpper();
            else if (isFlush(cards))
                return Hand.flush.ToString().ToUpper();
            else if (isFullHouse(cards))
                return Hand.fullHouse.ToString().ToUpper();
            else if (isFourOfAKind(cards))
                return Hand.fourOfAKind.ToString().ToUpper();
            else if(isStraightFlush(cards))
                 return Hand.straightFlush.ToString().ToUpper();
            else if (isRoyalFlush(cards))
                return Hand.royalFlush.ToString().ToUpper();
            else
                return Hand.highCard.ToString().ToUpper();
        }

        static bool isPair(List<Card> cards){
            var occ = getRankOcuurences(cards);
            if(occ.Count == 4)
                return true;
            else
                return false;
        }
        static bool isTwoPair(List<Card> cards){
            var occ = getRankOcuurences(cards);
            if(occ.Count == 3 && checkBins(occ) == 2)
                return true;
            else
                return false;
        }
         static bool isThreeOfAKind(List<Card> cards){
            var occ = getRankOcuurences(cards);
            if(occ.Count == 3 && checkBins(occ) == 1)
                return true;
            else
                return false;
        }

        static bool isFourOfAKind(List<Card> cards){
            var occ = getRankOcuurences(cards);
            if(occ.Count == 2 && checkBins(occ) == 1)
                return true;
            else
                return false;
        }

         static bool isFullHouse(List<Card> cards){
            var occ = getRankOcuurences(cards);
            if(occ.Count == 2 && checkBins(occ) == 2)
                return true;
            else
                return false;
        }

        static bool isFlush(List<Card> cards){
            if(getSuitsFound(cards) == 1 && isDiffOne(cards) == false)
                return true;
            else
                return false;
        }

        static bool isStraight(List<Card> cards) {
            if (isDiffOne(cards) == true && getSuitsFound(cards) > 1)
                return true;
            else
                return false;
        }

        static bool isStraightFlush(List<Card> cards)
        {
            if (isDiffOne(cards) && getSuitsFound(cards) == 1 && !checkRoyalRank(cards))
                return true;
            else
                return false;
        }

        static bool isRoyalFlush(List<Card> cards) {

            if (checkRoyalRank(cards) == true && getSuitsFound(cards) == 1)
                return true;
            else
                return false;
        }

        //-----------------------------Utils -------------------------------------------//
        static int checkBins(Dictionary<Rank,int> occ){
            int count = 0;
            foreach (var item in occ){
                if(item.Value > 1){
                    count++;
                }
            }
            return count;
        }

        static bool isDiffOne(List<Card> cards) {
            int i = 0;
            var ret = false;
            while (i < cards.Count - 1)
            {
                if ((int)cards[i + 1].rank - (int)cards[i].rank == 1)
                    ret = true;
                else
                    return false;
                i++;
            }
            return ret;
        }

        static Dictionary<Rank,int> getRankOcuurences(List<Card> cards){
            var occurances = new Dictionary<Rank,int>();
            foreach(var card in cards){
                if(occurances.ContainsKey(card.rank)){
                    occurances[card.rank] += 1;
                }else{
                    occurances[card.rank] = 1;
                }
            }
            return occurances;
        }

        static int getSuitsFound(List<Card> cards){
            var occurances = new Dictionary<Suit,int>();
            var temp = "";
            int ret = 0;
            foreach(var card in cards){
                if(string.IsNullOrEmpty(temp)){
                    ret += 1;
                    temp = card.suit.ToString();
                }else{
                    if (temp == card.suit.ToString())
                        continue;
                    else {
                        ret += 1;
                    }
                }
            }
            return ret;
        }
        static bool checkRoyalRank(List<Card> cards) {
            var ret = false;
            var royalRank = new List<Rank>{
                Rank.ten,Rank.jack,Rank.queen,Rank.king,Rank.ace
            };

            foreach (var card in cards)
                if (royalRank.Contains(card.rank))
                    ret = true;
                else
                    return false;
            return ret;
        }
    }
}


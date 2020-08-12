
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameConsole
{
    
    class Program
    {
        static void Main(string[] args)
        {
            PokerDeck poker = new PokerDeck();
           List<PlayingCard> hand= poker.DealCard();
            foreach(var card in hand)
            {
                Console.WriteLine($"{card.Suite.ToString()} of {card.Value.ToString()}");
            }
            


            Console.WriteLine(hand);
        }
    }

    public abstract class Deck
    {
        protected List<PlayingCard> fullDeck = new List<PlayingCard>();
        public List<PlayingCard> drawPile = new List<PlayingCard>();

        public void CreateDeck()
        {
            for(int i=0; i<4; i++)
            {
                for(int j=0; j<13; j++)
                {
                    fullDeck.Add(new PlayingCard { Suite = (CardSuite)i, Value = (CardValue)j });
                }
            }

        }

        public void ShuffleDeck()
        {
            var rnd = new Random();
            drawPile = fullDeck.OrderBy(x => rnd.Next()).ToList();
        }

        public abstract List<PlayingCard> DealCard();

        public PlayingCard RequestCard()
        {
            PlayingCard output = drawPile.Take(1).First();//take one card from draw pile
            drawPile.Remove(output);// remove one card from draw pile 
            return output;
        }
    }

    public class PokerDeck : Deck
    {
        public PokerDeck()
        {
            CreateDeck();
            ShuffleDeck();
        }
        public override List<PlayingCard> DealCard()
        {
            List<PlayingCard> dealCard = new List<PlayingCard>();
            
            for(int i=0; i<5; i++)
            {
                dealCard.Add(RequestCard());
            }

            return dealCard;
        }
    }

    public class BlackJack : Deck
    {
        public override List<PlayingCard> DealCard()
        {
            List<PlayingCard> dealCard = new List<PlayingCard>();
            for(int i=0; i<2; i++)
            {
                dealCard.Add(RequestCard());

            }

            return dealCard;
        }
    }

    public class PlayingCard
    {
        public CardSuite Suite { get; set; }
        public CardValue Value { get; set; }


    }

    public enum CardValue
    {
        Ace,
        two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King

            }

    public enum CardSuite
    {
        Speads,
        Heats,
        Clubs,
        Diamonds
    }
}


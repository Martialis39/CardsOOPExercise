using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsOOP
{

    // Practicing OOP with playing cards
    class Program
    {
        static void Main(string[] args)
        {

         
            //initialize a new deck
            Deck newDeck = new Deck();

            //get a new hand
            List<Card> newHand = new List<Card>();
            
            for (int i = 0; i < 7; i++)
            {
                newHand.Add(Deck.DealRandomCard());
            }

            //assign the new hand to the Hand object hand field.
            Hand.hand = newHand;

            //print out each card
            foreach (Card item in Hand.hand)
            {
                item.ToString();
            }
        }
    }


    class Card
    {
        private string _Rank;
        private string _Suit;
        private int _CardValue;

        public Card (string rank, string suit, int cardValue) {
            _Rank = rank;
            _Suit = suit;
            _CardValue = cardValue;
        }
        public string Suit
        {
            get => _Suit;
            set
            {
                _Suit= value;
            }

        }
        public string Rank
        {
            get => _Rank;
            set
            {
                _Rank = value;
            }

        }

        public int CardValue
        {
            get => _CardValue;

            set
            {
                _CardValue = value;
            }    
        }
        
        //Override the toString() method for easy printing
        public override string ToString() // public function (overrided)
        {
            return $"{_Suit} {_Rank} : {_CardValue} points";
        }


    }

    class Deck
    {

        private enum _Suit { Clubs, Diamonds, Hearts, Spades }
        private enum _Card { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace}
        

        public static List<Card> cards = MakeDeck();


        // make a new deck of 52 cards in order
        public static List<Card> MakeDeck()
        {

            List<Card> deck = new List<Card>();
            for (int i = 0; i < 52; i++)
            {
                _Suit suit = (_Suit)(i / 13);
                _Card card = (_Card)(i % 13 +2);

                Card newCard = new Card(suit.ToString(), card.ToString(), (int)card);
                deck.Add(newCard);
            }
            return deck;
        }


        // take out a random card from the deck and delete it from the deck;
        public static Card DealRandomCard()
        {
            Random r = new Random();

            int randomNumber = r.Next(0, cards.Count);

            Card cardDealt = cards[randomNumber];
            cards.RemoveAt(randomNumber);
            //Console.WriteLine(cardDealt.ToString());
            //Console.WriteLine(cards.Count);
            return cardDealt;
        }

    }

    class Hand
    {
        public static List<Card> hand = new List<Card>();
    }
}

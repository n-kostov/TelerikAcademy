using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class HandsTests
    {
        [TestMethod]
        public void TestNullHandToString()
        {
            ICard[] cards = new ICard[0];
            IHand hand = new Hand(cards);

            Assert.AreEqual(string.Empty, hand.ToString(), "Hand constructor does not work correctly.");
        }

        [TestMethod]
        public void TestFullHandToString()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);

            Assert.AreEqual("2♥ 9♠ J♦ J♣ A♦", hand.ToString(), "Hand conversion to string does not work correctly.");
        }

        [TestMethod]
        public void TestOneCardHandToString()
        {
            ICard[] cards = new ICard[1]
            {
                new Card(CardFace.Jack, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            Assert.AreEqual("J♣", hand.ToString(), "Hand conversion to string does not work correctly.");
        }
    }
}

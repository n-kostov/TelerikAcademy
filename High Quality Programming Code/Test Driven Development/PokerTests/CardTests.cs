using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestFiveDiamondsToString()
        {
            Card card = new Card(CardFace.Five, CardSuit.Diamonds);
            Assert.AreEqual("5♦", card.ToString(), "Card conversion to string is incorrect.");
        }

        [TestMethod]
        public void TestAceHeartsToString()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            Assert.AreEqual("A♥", card.ToString(), "Card conversion to string is incorrect.");
        }

        [TestMethod]
        public void TestTwoClubsToString()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            Assert.AreEqual("2♣", card.ToString(), "Card conversion to string is incorrect.");
        }

        [TestMethod]
        public void TestJackSpadesToString()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Spades);
            Assert.AreEqual("J♠", card.ToString(), "Card conversion to string is incorrect.");
        }

        [TestMethod]
        public void TestTenSpadesToString()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Spades);
            Assert.AreEqual("10♠", card.ToString(), "Card conversion to string is incorrect.");
        }
    }
}

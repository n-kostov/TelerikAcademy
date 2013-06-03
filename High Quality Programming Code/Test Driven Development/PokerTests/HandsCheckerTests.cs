using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class HandsCheckerTests
    {
        private static IPokerHandsChecker handChecker = new PokerHandsChecker();

        [TestMethod]
        public void TestIsValid_ValidHand()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);

            bool validHand = handChecker.IsValidHand(hand);

            Assert.AreEqual(true, validHand);
        }

        [TestMethod]
        public void TestIsValid_RepeatingCard()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);

            bool validHand = handChecker.IsValidHand(hand);

            Assert.AreEqual(false, validHand);
        }

        [TestMethod]
        public void TestIsValid_NullHand()
        {
            bool validHand = handChecker.IsValidHand(null);

            Assert.AreEqual(false, validHand);
        }

        [TestMethod]
        public void TestIsValid_IncompleteHand()
        {
            ICard[] cards = new ICard[3]
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool validHand = handChecker.IsValidHand(hand);

            Assert.AreEqual(false, validHand);
        }

        [TestMethod]
        public void TestIsStraightFlush_ValidStraightFlush()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);

            bool isStraightFlush = handChecker.IsStraightFlush(hand);

            Assert.AreEqual(true, isStraightFlush);
        }

        [TestMethod]
        public void TestIsStraightFlush_ValidStraightFlushWithFirstAce()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);

            bool isStraightFlush = handChecker.IsStraightFlush(hand);

            Assert.AreEqual(true, isStraightFlush);
        }

        [TestMethod]
        public void TestIsStraightFlush_Flush()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);

            bool isStraightFlush = handChecker.IsStraightFlush(hand);

            Assert.AreEqual(false, isStraightFlush);
        }

        [TestMethod]
        public void TestIsFourOfAKind_FourNines()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };

            IHand hand = new Hand(cards);

            bool isFourOfAKind = handChecker.IsFourOfAKind(hand);

            Assert.AreEqual(true, isFourOfAKind);
        }

        [TestMethod]
        public void TestIsFourOfAKind_ThreeNines()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };

            IHand hand = new Hand(cards);

            bool isFourOfAKind = handChecker.IsFourOfAKind(hand);

            Assert.AreEqual(false, isFourOfAKind);
        }

        [TestMethod]
        public void TestIsFullHouse_FourNines()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };

            IHand hand = new Hand(cards);

            bool isFullHouse = handChecker.IsFullHouse(hand);

            Assert.AreEqual(false, isFullHouse);
        }

        [TestMethod]
        public void TestIsFullHouse_ThreeNinesAndTwoSeven()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool isFullHouse = handChecker.IsFullHouse(hand);

            Assert.AreEqual(true, isFullHouse);
        }

        [TestMethod]
        public void TestIsFlush_OneDifferentSuit()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);

            bool isFlush = handChecker.IsFlush(hand);

            Assert.AreEqual(false, isFlush, "Flush is not identified correctly.");
        }

        [TestMethod]
        public void TestIsFlush_ValidStraightFlush()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);

            bool isFlush = handChecker.IsFlush(hand);

            Assert.AreEqual(true, isFlush, "Flush is not identified correctly.");
        }

        [TestMethod]
        public void TestIsFlush_StraightFlush()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            IHand hand = new Hand(cards);

            bool isFlush = handChecker.IsFlush(hand);

            Assert.AreEqual(false, isFlush);
        }

        [TestMethod]
        public void TestIsFlush_StraightFlushAceFirst()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts)
            };

            IHand hand = new Hand(cards);

            bool isFlush = handChecker.IsFlush(hand);

            Assert.AreEqual(false, isFlush);
        }

        [TestMethod]
        public void TestIsStraight_StraightFlush()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            IHand hand = new Hand(cards);

            bool isStraight = handChecker.IsStraight(hand);

            Assert.AreEqual(false, isStraight);
        }

        [TestMethod]
        public void TestIsStraight_Straight()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            IHand hand = new Hand(cards);

            bool isStraight = handChecker.IsStraight(hand);

            Assert.AreEqual(true, isStraight);
        }

        [TestMethod]
        public void TestIsStraight_StraightAceFirst()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };

            IHand hand = new Hand(cards);

            bool isStraight = handChecker.IsStraight(hand);

            Assert.AreEqual(true, isStraight);
        }

        [TestMethod]
        public void TestIsStraight_RandomCards()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };

            IHand hand = new Hand(cards);

            bool isStraight = handChecker.IsStraight(hand);

            Assert.AreEqual(false, isStraight);
        }

        [TestMethod]
        public void TestThreeOfAKind_FourNines()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };

            IHand hand = new Hand(cards);

            bool isThreeOfAKind = handChecker.IsThreeOfAKind(hand);

            Assert.AreEqual(false, isThreeOfAKind);
        }

        [TestMethod]
        public void TestThreeOfAKind_ThreeNinesAndTwoSeven()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool isThreeOfAKind = handChecker.IsThreeOfAKind(hand);

            Assert.AreEqual(false, isThreeOfAKind);
        }

        [TestMethod]
        public void TestThreeOfAKind_ThreeNines()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool isThreeOfAKind = handChecker.IsThreeOfAKind(hand);

            Assert.AreEqual(true, isThreeOfAKind);
        }

        [TestMethod]
        public void TestThreeOfAKind_Twos()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool isThreeOfAKind = handChecker.IsThreeOfAKind(hand);

            Assert.AreEqual(false, isThreeOfAKind);
        }

        [TestMethod]
        public void TestTwoPair_FullHouse()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool isTwoPairs = handChecker.IsTwoPair(hand);

            Assert.AreEqual(false, isTwoPairs);
        }

        [TestMethod]
        public void TestTwoPair_TwoPair()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool isTwoPairs = handChecker.IsTwoPair(hand);

            Assert.AreEqual(true, isTwoPairs);
        }

        [TestMethod]
        public void TestTwoPair_OnePair()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool isTwoPairs = handChecker.IsTwoPair(hand);

            Assert.AreEqual(false, isTwoPairs);
        }

        [TestMethod]
        public void TestOnePair_TwoPair()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool isOnePair = handChecker.IsOnePair(hand);

            Assert.AreEqual(false, isOnePair);
        }

        [TestMethod]
        public void TestOnePair_OnePair()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool isOnePair = handChecker.IsOnePair(hand);

            Assert.AreEqual(true, isOnePair);
        }

        [TestMethod]
        public void TestHighCard_OnePair()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool isHighCard = handChecker.IsHighCard(hand);

            Assert.AreEqual(false, isHighCard);
        }

        [TestMethod]
        public void TestHighCard_HighCard()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool isHighCard = handChecker.IsHighCard(hand);

            Assert.AreEqual(true, isHighCard);
        }

        [TestMethod]
        public void TestCompareHands_TwoPairAndOnePair()
        {
            ICard[] cards1 = new ICard[5]
            {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Spades)
            };
            IHand hand1 = new Hand(cards1);

            ICard[] cards2 = new ICard[5]
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs)
            };
            IHand hand2 = new Hand(cards2);

            int compareResult = handChecker.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0);
        }

        [TestMethod]
        public void TestCompareHands_StraightFlushAndBiggerStraightFlush()
        {
            ICard[] cards1 = new ICard[5]
            {
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades)
            };
            IHand hand1 = new Hand(cards1);

            ICard[] cards2 = new ICard[5]
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades)
            };
            IHand hand2 = new Hand(cards2);

            int compareResult = handChecker.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult < 0);
        }

        [TestMethod]
        public void TestCompareHands_TwoEqualStraightFlush()
        {
            ICard[] cards1 = new ICard[5]
            {
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            };
            IHand hand1 = new Hand(cards1);

            ICard[] cards2 = new ICard[5]
            {
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            };
            IHand hand2 = new Hand(cards2);

            int compareResult = handChecker.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult == 0);
        }

        [TestMethod]
        public void TestCompareHands_FourOfAKindAndLesserFourOFAKind()
        {
            ICard[] cards1 = new ICard[5]
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            };
            IHand hand1 = new Hand(cards1);

            ICard[] cards2 = new ICard[5]
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            };
            IHand hand2 = new Hand(cards2);

            int compareResult = handChecker.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0);
        }

        [TestMethod]
        public void TestCompareHands_TwoEqualFourOfAKind()
        {
            ICard[] cards1 = new ICard[5]
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            };
            IHand hand1 = new Hand(cards1);

            ICard[] cards2 = new ICard[5]
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades)
            };
            IHand hand2 = new Hand(cards2);

            int compareResult = handChecker.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult == 0);
        }

        [TestMethod]
        public void TestCompareHands_FullHouse()
        {
            ICard[] cards1 = new ICard[5]
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades)
            };
            IHand hand1 = new Hand(cards1);

            ICard[] cards2 = new ICard[5]
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts)
            };
            IHand hand2 = new Hand(cards2);

            int compareResult = handChecker.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult < 0);
        }

        [TestMethod]
        public void TestCompareHands_TwoFlush()
        {
            ICard[] cards1 = new ICard[5]
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };
            IHand hand1 = new Hand(cards1);

            ICard[] cards2 = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            IHand hand2 = new Hand(cards2);

            int compareResult = handChecker.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult < 0);
        }

        [TestMethod]
        public void TestCompareHands_StraightAndStraightFlush()
        {
            ICard[] cards1 = new ICard[5]
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            IHand hand1 = new Hand(cards1);

            ICard[] cards2 = new ICard[5]
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds)
            };
            IHand hand2 = new Hand(cards2);

            int compareResult = handChecker.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0);
        }

        [TestMethod]
        public void TestCompareHands_HighCard()
        {
            ICard[] cards1 = new ICard[5]
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs)
            };
            IHand hand1 = new Hand(cards1);

            ICard[] cards2 = new ICard[5]
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Diamonds)
            };
            IHand hand2 = new Hand(cards2);

            int compareResult = handChecker.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0);
        }
        
        // there could be tests for all cases but I didnt have enough time
    }
}

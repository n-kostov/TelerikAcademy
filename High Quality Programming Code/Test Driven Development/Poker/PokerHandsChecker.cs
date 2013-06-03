using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int HandSize = 5;

        private Dictionary<CardFace, int> cardFaceRepetitions = new Dictionary<CardFace, int>();

        public bool IsValidHand(IHand hand)
        {
            if (hand == null || hand.Cards.GetLength(0) != handSize)
            {
                return false;
            }

            for (int i = 0; i < handSize - 1; i++)
            {
                for (int j = i + 1; j < handSize; j++)
                {
                    if (hand.Cards[i].Equals(hand.Cards[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.IsSameSuit(hand) && this.ContainsConsecutiveFaces(hand))
            {
                return true;
            }

            return false;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            this.FillDictionary(hand);

            this.SortDictionary();

            if (this.cardFaceRepetitions.First().Value == 4)
            {
                this.ClearDictionary();
                return true;
            }
            else
            {
                this.ClearDictionary();
                return false;
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            this.FillDictionary(hand);

            this.SortDictionary();

            if (this.cardFaceRepetitions.First().Value == 3)
            {
                if (this.cardFaceRepetitions.First(x => x.Value == 2).Value == 2)
                {
                    this.ClearDictionary();
                    return true;
                }
            }

            this.ClearDictionary();
            return false;
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.IsSameSuit(hand))
            {
                // straight flush
                if (this.ContainsConsecutiveFaces(hand))
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.IsSameSuit(hand))
            {
                return false;
            }
            else if (this.ContainsConsecutiveFaces(hand))
            {
                return true;
            }

            return false;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            this.FillDictionary(hand);

            this.SortDictionary();

            if (this.cardFaceRepetitions.First().Value == 3)
            {
                if (this.cardFaceRepetitions.First(x => x.Value != 3).Value == 1)
                {
                    this.ClearDictionary();
                    return true;
                }
            }

            this.ClearDictionary();
            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            this.FillDictionary(hand);

            this.SortDictionary();

            if (this.cardFaceRepetitions.Where(x => x.Value == 2).Count() == 2)
            {
                this.ClearDictionary();
                return true;
            }

            this.ClearDictionary();
            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            this.FillDictionary(hand);

            this.SortDictionary();

            if (this.cardFaceRepetitions.Where(x => x.Value == 2).Count() == 1)
            {
                this.ClearDictionary();
                return true;
            }

            this.ClearDictionary();
            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            this.FillDictionary(hand);

            this.SortDictionary();

            if (this.cardFaceRepetitions.First().Value == 1)
            {
                this.ClearDictionary();
                return true;
            }
            else
            {
                this.ClearDictionary();
                return false;
            }
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (!this.IsValidHand(firstHand) || !this.IsValidHand(secondHand))
            {
                throw new ArgumentException("The hands cannot be compared if they are invalid!");
            }

            HandCategory firstHandCategory = this.DetermineHandCategory(firstHand);
            HandCategory secondHandCategory = this.DetermineHandCategory(secondHand);

            if (firstHandCategory < secondHandCategory)
            {
                return -1;
            }
            else if (firstHandCategory > secondHandCategory)
            {
                return 1;
            }
            else
            {
                CardFace firstCategoryHighestCard = this.GetHighestCardFace(firstHand);
                CardFace secondCategoryHighestCard = this.GetHighestCardFace(secondHand);

                if (firstCategoryHighestCard < secondCategoryHighestCard)
                {
                    return -1;
                } 
                else if (firstCategoryHighestCard > secondCategoryHighestCard)
                {
                    return 1;
                }
                else
                {
                    // three's are equal
                    if (this.IsFullHouse(firstHand))
                    {
                        this.FillDictionary(firstHand);

                        this.SortDictionary();

                        CardFace firstCategorySecondHighestCard =
                            this.cardFaceRepetitions.First(x => x.Value == 2).Key;

                        this.ClearDictionary();

                        this.FillDictionary(secondHand);

                        this.SortDictionary();

                        CardFace secondCategorySecondHighestCard =
                            this.cardFaceRepetitions.First(x => x.Value == 2).Key;

                        this.ClearDictionary();

                        if (firstCategorySecondHighestCard < secondCategorySecondHighestCard)
                        {
                            return -1;
                        }
                        else if (firstCategorySecondHighestCard > secondCategorySecondHighestCard)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        private bool IsSameSuit(IHand hand)
        {
            CardSuit suit = hand.Cards[0].Suit;
            for (int i = 1; i < handSize; i++)
            {
                if (suit != hand.Cards[i].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ContainsConsecutiveFaces(IHand hand)
        {
            int face = (int)hand.Cards[0].Face;
            for (int i = 1; i < handSize; i++)
            {
                if ((int)hand.Cards[i].Face == face + i)
                {
                    continue;
                }
                else
                {
                    // check for Ace
                    if (i == 4)
                    {
                        if (face == 2)
                        {
                            if (hand.Cards[i].Face != CardFace.Ace)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void ClearDictionary()
        {
            this.cardFaceRepetitions.Clear();
        }

        private void FillDictionary(IHand hand)
        {
            for (int i = 0; i < handSize; i++)
            {
                CardFace currentFace = hand.Cards[i].Face;
                if (this.cardFaceRepetitions.ContainsKey(currentFace))
                {
                    this.cardFaceRepetitions[currentFace]++;
                }
                else
                {
                    this.cardFaceRepetitions.Add(hand.Cards[i].Face, 1);
                }
            }
        }

        private void SortDictionary()
        {
            this.cardFaceRepetitions = this.cardFaceRepetitions.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        private HandCategory DetermineHandCategory(IHand hand)
        {
            if (this.IsHighCard(hand))
            {
                return HandCategory.HighCard;
            }
            else if (this.IsOnePair(hand))
            {
                return HandCategory.OnePair;
            }
            else if (this.IsTwoPair(hand))
            {
                return HandCategory.TwoPair;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                return HandCategory.ThreeOfAKind;
            }
            else if (this.IsStraight(hand))
            {
                return HandCategory.Straight;
            }
            else if (this.IsFlush(hand))
            {
                return HandCategory.Flush;
            }
            else if (this.IsFullHouse(hand))
            {
                return HandCategory.FullHouse;
            }
            else if (this.IsFourOfAKind(hand))
            {
                return HandCategory.FourOfAKind;
            }
            else if (this.IsStraightFlush(hand))
            {
                return HandCategory.StraightFlush;
            }
            else
            {
                throw new ArgumentException("Invalid hand category!");
            }
        }

        private CardFace GetHighestCardFace(IHand hand)
        {
            this.FillDictionary(hand);

            this.SortDictionary();

            CardFace result;
            if (this.IsStraight(hand) || this.IsStraightFlush(hand))
            {
                if (this.cardFaceRepetitions.ContainsKey(CardFace.Ace) && this.cardFaceRepetitions.ContainsKey(CardFace.Five))
                {
                    result = CardFace.Five;
                }
                else
                {
                    result = this.cardFaceRepetitions.First().Key;
                }
            }
            else
            {
                result = this.cardFaceRepetitions.First().Key;
            }

            this.ClearDictionary();

            return result;
        }
    }
}

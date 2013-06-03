using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class Hand : IHand
    {
        public Hand(ICard[] cards)
        {
            this.Cards = cards;
            this.SortHand();
        }

        public ICard[] Cards { get; private set; }

        public override string ToString()
        {
            return string.Join<ICard>(" ", this.Cards);
        }

        private void SortHand()
        {
            this.Cards = this.Cards.OrderBy(x => (int)x.Face).ThenBy(y => (int)y.Suit).ToArray();
        }
    }
}

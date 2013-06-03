using System;
using System.Collections.Generic;

namespace Poker
{
    public interface IHand
    {
        ICard[] Cards { get; }

        string ToString();
    }
}

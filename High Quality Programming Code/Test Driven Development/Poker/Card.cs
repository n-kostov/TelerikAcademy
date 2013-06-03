using System.Text;

namespace Poker
{
    public class Card : ICard
    {
        private char[] suits = { '♥', '♦', '♣', '♠' };

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if ((int)this.Face <= 10)
            {
                result.Append((int)this.Face);
            }
            else
            {
                char highCardLetter = this.Face.ToString()[0];
                result.Append(highCardLetter);
            }

            result.Append(this.suits[(int)this.Suit - 1]);

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Card card = obj as Card;
            if (card == null)
            {
                return false;
            }

            return (this.Face == card.Face) && (this.Suit == card.Suit);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

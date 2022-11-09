using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Cards
{
    internal class Card
    {
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            this.face = face;
            this.suit = suit;
        }

        public override string ToString()
        {
            return $"[{this.face}{this.suit}]";
        }
    }
}

using System;
using System.Collections.Generic;

namespace Project
{
public class Card
    {
        public string suit;
        public string rank;
        public Card(string suit,string rank)
        {
            this.suit=suit;
            this.rank=rank;
        }

        public string ToString()
        {
            return (this.rank+" of "+this.suit);
        }
    }
}

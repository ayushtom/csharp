using System;
using System.Collections.Generic;

namespace Project
{
public class Hand
    {
        public List<Card> cards = new List<Card>();
        public long value;
        public int aces;
        public Hand()
        {
            this.cards.Clear();
            this.value=0;
            this.aces=0;
        }

        public void add_card(Card card,Dictionary<string, int> values)
        {
            this.cards.Add(card);
            this.value=this.value+values[card.rank];
        
            if (card.rank.Equals("ace")==true)
                this.aces=this.aces+1;
        }

        public void adjust_ace()
        {   

            if (this.value>21 && this.aces>0)
            {
                this.value=this.value-10;
                this.aces=this.aces-1;

            }
        }
    }
}

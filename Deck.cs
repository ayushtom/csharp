using System;
using System.Collections.Generic;

namespace Project
{

public class Deck 
    {
        public List<Card> deck = new List<Card>();
        public Deck(string[] suits,string[] ranks)
        {
            this.deck.Clear();
            foreach(string str in suits)
            {
                foreach(string str1 in ranks)
                {
                    Card card1=new Card(str,str1);
                    this.deck.Add(card1);
                }
            }
        }
        

       

        public void shuffle()
        {
            //  var rnd = new Random();
            // this.deck.OrderBy(item => rnd.Next());
            

        }

        public Card deal()
        {
            Card single_card=null;
            try{
                single_card=deck[(deck.Count - 1)];
                deck.RemoveAt(deck.Count-1);

            }

            catch(Exception e)
            {
                Console.WriteLine("exception occured");
            }
            
                return single_card;
           

        }   
    }

}
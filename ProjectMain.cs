using System;
using System.Collections.Generic;

namespace Project
{
//     class Card
//     {
//         public string suit;
//         public string rank;
//         public Card(string suit,string rank)
//         {
//             this.suit=suit;
//             this.rank=rank;
//         }

//         public string ToString()
//         {
//             return (this.rank+" of "+this.suit);
//         }
//     }
//     class Hand
//     {
//         public List<Card> cards = new List<Card>();
//         public long value;
//         public int aces;
//         public Hand()
//         {
//             this.cards.Clear();
//             this.value=0;
//             this.aces=0;
//         }

//         void add_card(Card card,Dictionary<string, int> values)
//         {
//             this.cards.Add(card);
//             this.value=this.value+values[card.rank];
        
//             if (card.rank.Equals("ace")==true)
//                 this.aces=this.aces+1;
//         }

//         void adjust_ace()
//         {   

//             if (this.value>21 && this.aces>0)
//             {
//                 this.value=this.value-10;
//                 this.aces=this.aces-1;

//             }
//         }
//     }
//     class Deck 
//     {
//         public List<Card> deck = new List<Card>();
//         public Deck(string[] suits,string[] ranks)
//         {
//             this.deck.Clear();
//             foreach(string str in suits)
//             {
//                 foreach(string str1 in ranks)
//                 {
//                     Card card1=new Card(str,str1);
//                     this.deck.Add(card1);
//                 }
//             }
//         }

//         void shuffle()
//         {

//             var rnd = new Random();
//             var randomized = list1.OrderBy(item => rnd.Next());

//         }

//         Card deal()
//         {
//             Card single_card=null;
//             try{
//                 single_card=deck[(deck.Count - 1)];
//                 deck.RemoveAt(deck.Count-1);

//             }

//             catch(Exception e)
//             {
//                 Console.WriteLine("exception occured");
//             }
//             finally
//             {
//                 return single_card;
//             }

//         }   
//     }

//     class Chip
//     {
//         public int total;
//         public int bet;
//         public Chip()
//         {
//             this.total=100;
//             this.bet=0;
//         }
//         public Chip(int total)
//         {
//             this.total=total;
//         }

//         void win_bet()
//         {
//             this.total=this.total+this.bet;
//         }

//         void lose_bet()
//         {
//             this.total=this.total-this.bet;
//         }
//     }
//     class Gameplay
// {
//     static void place_bet(Chip chips)
//     {
        
//         while (true)
//         {
//             Console.WriteLine("Enter the amount of bet placed");

//             chips.bet=Convert.ToInt32(Console.ReadLine());
//             if(chips.bet>chips.total)
//             {
//                 Console.WriteLine("not enough money");
//                 continue;
//             }
//             else
//             {
//                 break;
//             }

           
            
//         }
//     }

//     static void hit(Hand hand,Deck deck,Dictionary<string, int> values)
//     {
//         Card single_card=deck.deal();
//         hand.add_card(single_card,values);
//         hand.adjust_ace();
//     }

//     static boolean hit_stand(Hand player,Deck deck,boolean playing,Dictionary<string, int> values)
//     {
        
//         while (true)
//         {

//             Console.WriteLine("Enter h for hit and s for Stand \n");
            
//             string d = Console.ReadLine();

//             if (d.charAt(0)=='h')
//             {
//                 hit(player,deck,values);
//                 return playing;
//             }

//             else if (d.charAt(0)=='s')
//             {
//                 Console.WriteLine("Player Stands Dealer's Turn");
//                 playing=false;
//                 return playing;
//             }
//             else
//             {
//                 Console.WriteLine("Invalid choice");
//                 continue;
//             }
//         }
//     }

//     static void player_busts(Chip chips)
//     { Console.WriteLine("Player Busts! ");
//         chips.lose_bet();
//     }

//     static void player_wins(Chip chips)
//     {Console.WriteLine("Player Wins! ");
//         chips.win_bet();
//     }

//     static void dealer_busts(Chip chips)
//     {Console.WriteLine("Dealer  Busts!");
//         chips.win_bet();
//     }

//     static void dealer_wins(Chip chips)
//     {Console.WriteLine("Dealer Wins ");
//         chips.lose_bet();
//     }

//     static void push()
//     {Console.WriteLine("\nIt's a tie!PUSH \n");}

//     static void show_some(Hand player,Hand dealer)
//     {   Console.WriteLine("\nPlayer's hands");
//         var enu = player.cards;
//         foreach (var one in enu) 
//             Console.WriteLine(one.ToString());

//         Console.WriteLine("\ndealer's hands");
//         Console.WriteLine("one card hidden!");
//         Console.WriteLine(dealer.cards[1].ToString());
//     }

//     static void show_all(Hand player,Hand dealer)
//     {
//         Console.WriteLine("\nPlayer's hands");
//         var enu2 = player.cards;
//         foreach (var one in enu2) 
//             Console.WriteLine(one.ToString());


//         Console.WriteLine("\ndealer's hands");
//         var enu1 = dealer.cards;
//         foreach (var one in enu1) {
//             Console.WriteLine(one.ToString());
//     }
//         }

// }
public class ProjectMain: Gameplay
{
    static bool playing =true;
    public static void Main(string[] args)
    {

        String[] suits = new String[] {"spades","diamonds","clubs","spades"};
        String[] ranks = new String[] {"two","three","four","five","six","seven","eight","nine","ten","jack","queen","king","ace"};
        bool playing=true;
        Dictionary<string,int> values=new  Dictionary<string,int>();
        values.Add("two",2);
        values.Add("three",3);
        values.Add("four",4);
        values.Add("five",5);
        values.Add("six",6);
        values.Add("seven",7);
        values.Add("eight",8);
        values.Add("nine",9);
        values.Add("ten",10);
        values.Add("jack",10);
        values.Add("king",10);
        values.Add("queen",10);
        values.Add("ace",11);
        while(true)
        {
            Console.WriteLine("WELCOME TO BLACKJACK");
            Deck deck=new Deck(suits,ranks);
            deck.shuffle();

            Hand player_hand=new Hand();
            player_hand.add_card(deck.deal(),values);
            player_hand.add_card(deck.deal(), values);

            Hand dealer_hand=new Hand();
            dealer_hand.add_card(deck.deal(), values);
            dealer_hand.add_card(deck.deal(), values);

            Chip player_chips= new Chip();
            place_bet(player_chips);
            show_some(player_hand,dealer_hand);
            Console.WriteLine("------------------------------------------------------------------------------------------");

            while (playing==true)
            {
                playing=hit_stand(player_hand,deck,playing,values);
                show_some(player_hand,dealer_hand);
                Console.WriteLine("------------------------------------------------------------------------------------------");
                
                if (player_hand.value>21)
                {
                    
                    player_busts(player_chips);
                    show_all(player_hand,dealer_hand);
                    
                    break;
                }
            }

            if (player_hand.value<=21)
            {
                while (dealer_hand.value<=21)
                {
                    hit(dealer_hand,deck,values);
                    show_all(player_hand,dealer_hand);
                    

                    if (dealer_hand.value>21)
                        {player_wins(player_chips);
                        break;}
                    else if (dealer_hand.value>player_hand.value)
                        {dealer_wins(player_chips);
                        break;}
                    else if (player_hand.value>dealer_hand.value)
                        {player_wins(player_chips);
                        break;}
                    else
                        {push();
                        break;}
                }
            }
            Console.WriteLine("\nPlayer total chips are : "+player_chips.total);
            Console.WriteLine("enter 'y' to play again and 'n' to end the game") ;
            string new_game= Console.ReadLine();
            char c=new_game.ToLower()[0];
            if(c=='y')
            {
                playing=true;
                
                continue;
            }
            else
            {
                Console.WriteLine("thank you for playing!");
                break;
            }

        }
    }  


 
}}
using System;
using System.Collections.Generic;

namespace Project
{

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
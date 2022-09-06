using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            SmackTalkingPlayer player1 = new SmackTalkingPlayer();
            player1.Name = "Bob";
            player1.Taunt = "When you're hot, you're hot!!";

            Player player2 = new OneHigherPlayer();
            player2.Name = "Sue";

            player2.Play(player1);

            Console.WriteLine("-------------------");

            Player player3 = new HumanPlayer();
            player3.Name = "Wilma";

            player3.Play(player2);

            Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            player1.Play(large);

            Console.WriteLine("-------------------");

            CreativeSmackTalkingPlayer creative = new CreativeSmackTalkingPlayer();
            creative.Name = "Sir Tauntsalot";
            creative.SmackTalk = new List<string>(){
                "You've met your match!!", "Every dog has his day!!", "I've the Luck of the Irish today!!"
            };

            player1.Play(creative);

            Console.WriteLine("-------------------");

            Player loser = new SoreLoserPlayer();
            loser.Name = "Crybaby Whinesalot";

            loser.Play(creative);

            Console.WriteLine("-------------------");

            Player upper = new UpperHalfPlayer();
            upper.Name = "Dice R. Loaded";

            upper.Play(loser);

            Console.WriteLine("-------------------");

            Player upperLoser = new UpperHalfPlayer();
            upperLoser.Name = "Cheats N. Cries";

            upperLoser.Play(upper);

            Console.WriteLine("-------------------");

            List<Player> players = new List<Player>() {
                player1, player2, player3, large, creative, loser, upper, upperLoser

            };

            PlayMany(players);
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play one another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                player1.Play(player2);
            }
        }
    }
}
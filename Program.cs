using System;
using System.Collections.Generic;

//This solution requires .NET Framework 4.7 or higher or by adding Syste.ValueTuple using the NuGet Package Manager
namespace ClimbingTheLeaderboard
{
    class Program
    {
        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            //make an empty tuple list for the parameters of the leaderboard
            List<(int, string, int)> leaderBoard = new List<(int, string, int)> { };

            //Fill current leaderboard scores with name of Anon and set their ranks respective to their score
            int rank = 1;
            int currentScore = scores[0];
            leaderBoard.Add((rank, "Anon", currentScore));
            for (int i = 1; i < scores.Length; i++)
            {
                if (currentScore == scores[i])
                {
                    leaderBoard.Add((rank, "Anon", scores[i]));
                }
                else if (scores[i] < currentScore){
                    rank++;
                    leaderBoard.Add((rank, "Anon", scores[i]));
                    currentScore = scores[i];
                }
            }

            //print the leaderboard tuple list
            //Console.WriteLine("Leaderboard before alice's score\n------------------------------");
            //for (int i = 0; i < leaderBoard.Count; i++)
            //{
            //    Console.WriteLine(leaderBoard[i]);
            //}
            //Console.WriteLine("------------------------------");
            
            int[] results = new int[alice.Length];

            //Analyze what Alice's score would be ranked in comparison to the leaderboard tuple list
            for (int i = 0; i < alice.Length; i++)
            {
                for(int j = 0; j < leaderBoard.Count; j++)
                {
                    if(alice[i] > leaderBoard[j].Item3)
                    {
                        
                        if (j == 0)
                        {
                            //Console.WriteLine("ALICE'S SCORE WAS THE BEST ON THE LEADERBOARD");
                            //Console.WriteLine("--Therefore Alice's rank for the match is 1");
                            results[i] = 1;

                        }
                        else
                        {
                            //Console.WriteLine("Alice's rank is therefore "+leaderBoard[j].Item1);
                            results[i] = leaderBoard[j].Item1;
                        }
                        break;
                        
                    }
                    else if (alice[i] == leaderBoard[j].Item3) {
                        //Console.WriteLine("Alice's " + i + " score was equal to " + j);
                        //Console.WriteLine("--Therefore Alice's rank for the match is " + leaderBoard[j].Item1);
                        results[i] = leaderBoard[j].Item1;
                        break;
                    }
                    else
                    {
                        
                        if (j == leaderBoard.Count - 1)
                        {
                            //Console.WriteLine("ALICE'S SCORE IS THE WORST ON THE LEADERBOARD");
                            int newRank = leaderBoard[j].Item1;
                            newRank++;
                            //Console.WriteLine("--Therefore it is: " + newRank);
                            results[i] = newRank;
                        }
                        else
                        {
                            //Console.WriteLine("Alice's score was less than j");
                        }
                    }
                }
            }

            return results;
        }

        static void Main(string[] args)
        {


            int scoresCount = Convert.ToInt32(Console.ReadLine());
            int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));

            int aliceCount = Convert.ToInt32(Console.ReadLine());
            int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp));

            int[] result = climbingLeaderboard(scores, alice);

            Console.WriteLine(string.Join("\n", result));

        }
    }
}

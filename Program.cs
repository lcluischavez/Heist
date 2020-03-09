using System;
using System.Collections.Generic;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan your heist!");

            List<Dictionary<string, string>> entireTeam = new List<Dictionary<string, string>>();

            while(true)
            {
                Dictionary<string, string> teamMember = new Dictionary<string, string>();

                    
                Console.WriteLine("Please enter team member's name.");
                String name = Console.ReadLine();

                if (name == "")
                    {
                        break;
                    }

                teamMember.Add("name", name);

                Console.WriteLine("Please enter team member's skill level (1-80).");
                String skill = Console.ReadLine();
                teamMember.Add("skill", skill);


                Console.WriteLine("Please enter team member's courage factor (0.0-2.0).");
                String courage = Console.ReadLine();
                teamMember.Add("courage", courage);
            
                // foreach(KeyValuePair<string, string> member in teamMember)
                //     {
                //         Console.WriteLine($"Member's {member.Key} is {member.Value}");  
                //     };

                entireTeam.Add(teamMember);

                foreach (Dictionary<string, string> member in entireTeam)
                {
                    // Iterate the KeyValuePairs of the Dictionary
                    foreach (KeyValuePair<string, string> info in member )
                    {
                        Console.WriteLine($"{info.Key}: {info.Value}");
                    }
                }
            }
            
            int failedRuns = 0;
            int successfulRuns = 0;

            Console.WriteLine("How many trials should the program run?");
            int numberOfTrials = int.Parse(Console.ReadLine());
            for (int i=0; i < numberOfTrials; i++)
            {
                Random rand = new Random();
                int heistLuck = rand.Next(-10, 11);
                
                int bankDifficulty = 100 + heistLuck;

                int teamSkillLevel = 0;

                foreach(Dictionary<string, string> member in entireTeam)
                {
                    int memberSkillLevel = int.Parse(member["skill"]);
                    teamSkillLevel += memberSkillLevel;
                }

                
                Console.WriteLine($"Team Count: {entireTeam.Count}");
                
                Console.WriteLine($"Bank Difficulty: {bankDifficulty}");            
                
                Console.WriteLine($"Team Skill Level:  {teamSkillLevel}");

                if (teamSkillLevel < bankDifficulty)
                {
                    Console.WriteLine("Team is too weak. Got caught!");
                    failedRuns ++;
                }
                else if (teamSkillLevel >= bankDifficulty)
                {
                    Console.WriteLine("Success: CASHHHHH");
                    successfulRuns++;
                }


                Console.WriteLine($"--------------------");
                

                foreach (Dictionary<string, string> member in entireTeam)
                {
                    // Iterate the KeyValuePairs of the Dictionary
                    foreach (KeyValuePair<string, string> info in member )
                    {
                        Console.WriteLine($"{info.Key}: {info.Value}");
                    }
                }
            }
            Console.WriteLine("---------------------");
            Console.WriteLine($"Successful Runs: {successfulRuns}");

            Console.WriteLine($"Failed Runs: {failedRuns}");
            
                        
        }
    }
}

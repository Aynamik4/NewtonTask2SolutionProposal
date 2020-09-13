using System;

namespace NewtonTask2SolutionProposalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool competitionStarted = false;
            int winnerStartNumber = 0;
            int winnerHours = 24;
            int winnerMinutes = 60;
            int winnerSeconds = 60;
            int numberOfCompetitors = 0;

            bool competitionInProgress;
            do
            {
                Console.Write("Ange startnummer: > ");
                string input = Console.ReadLine();
                int startNumber = int.Parse(input);
                competitionInProgress = startNumber > 0;

                if (competitionInProgress)
                {
                    numberOfCompetitors++;
                    competitionStarted = true;

                    // Start
                    Console.Write("Ange timme för start: > ");
                    input = Console.ReadLine();
                    int startHour = int.Parse(input);

                    Console.Write("Ange minut för start: > ");
                    input = Console.ReadLine();
                    int startMinute = int.Parse(input);

                    Console.Write("Ange sekund för start: > ");
                    input = Console.ReadLine();
                    int startSecond = int.Parse(input);

                    // Finish
                    Console.Write("Ange timme för mål: > ");
                    input = Console.ReadLine();
                    int finishHour = int.Parse(input);

                    Console.Write("Ange minut för mål: > ");
                    input = Console.ReadLine();
                    int finishMinute = int.Parse(input);

                    Console.Write("Ange sekund för mål: > ");
                    input = Console.ReadLine();
                    int finishSecond = int.Parse(input);

                    // Check if finish hour is less than start hour.
                    if (finishHour <= startHour)
                        finishHour = startHour + (24 - startHour + finishHour);

                    int totalHours = finishHour - startHour;

                    // Check if finish minute is less than start minute.
                    if (finishMinute <= startMinute)
                    {
                        totalHours--;
                        finishMinute = startMinute + (60 - startMinute + finishMinute);
                    }

                    int totalMinutes = finishMinute - startMinute;

                    // Check if finish second is less than start second.
                    if (finishSecond <= startSecond)
                    {
                        totalMinutes--;
                        finishSecond = startSecond + (60 - startSecond + finishSecond);
                    }

                    int totalSeconds = finishSecond - startSecond;

                    if (totalSeconds == 60)
                    {
                        totalMinutes++; // Add 1 minute (60 seconds) to totalMinutes.
                        totalSeconds = 0;
                    }

                    if (totalMinutes == 60)
                    {
                        totalHours++; // Add 1 hour (60 minutes) to totalHours.
                        totalMinutes = 0;
                    }

                    // Convert the number of hours, minutes and seconds to seconds
                    int totalTimeInSeconds = totalHours * 60 * 60 + totalMinutes * 60 + totalSeconds;
                    int winnerTotalTimeInSeconds = winnerHours * 60 * 60 + winnerMinutes * 60 + winnerSeconds;

                    if (totalTimeInSeconds <= winnerTotalTimeInSeconds)
                    {
                        winnerHours = totalHours;
                        winnerMinutes = totalMinutes;
                        winnerSeconds = totalSeconds;
                        winnerStartNumber = startNumber;
                    }
                }

            } while (competitionInProgress);

            if (competitionStarted)
            {
                Console.WriteLine($"Startnummer {winnerStartNumber} är vinnaren.");
                Console.WriteLine($"Vinnande sluttid: {winnerHours} timmar {winnerMinutes} minuter {winnerSeconds} sekunder.");
                Console.WriteLine($"Antal tävlande: {numberOfCompetitors}");
            }
            else
            {
                Console.WriteLine("Inga tävlande");
            }

            Console.WriteLine("Programmet avslutas.");
        }
    }
}
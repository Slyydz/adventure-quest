using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace adventure_quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge

            Console.Write("What is your name adventurer?: ");
            string userName = Console.ReadLine();
            var colorList = new List<string>()
            {
                "Red", "Yellow", "Green"
            };

            Robe userRobe = new Robe(colorList, 10);

            Hat userHat = new Hat(7);

            Prize finalPrize = new Prize("*");

            Adventurer theAdventurer = new Adventurer(userName, userRobe, userHat);

            theAdventurer.getDescrip();

            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge guessEmpire = new Challenge("How tall is the Empire State Building (feet)?", 1454, 50);

            Challenge guessAlligator = new Challenge("How long is the largest Alligator recorded? (feet)?", 19, 15);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                guessEmpire,
                guessAlligator
            };

            // Loop through all the challenges and subject the Adventurer to them
            string keepGoing = "";
            while (keepGoing != "n")
            {
                var indexes = new List<int> { };
                var challengesRandom = new List<Challenge> { };

                while (indexes.Count < 5)
                {
                    Random randInt = new Random();
                    int candidate = randInt.Next(1, challenges.Count);
                    if (!indexes.Contains(candidate))
                    {
                        indexes.Add(candidate);
                    }
                }

                foreach (var item in indexes)
                {
                    challengesRandom.Add(challenges[item]);
                }

                foreach (Challenge challenge in challengesRandom)
                {
                    challenge.RunChallenge(theAdventurer);
                }
                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }
                Console.WriteLine();
                finalPrize.ShowPrize(theAdventurer);
                Console.WriteLine();
                Console.Write("Do you wish to play again? (Y/N): ");
                keepGoing = Console.ReadLine().ToLower();
                Console.WriteLine();
            }
        }
    }
}

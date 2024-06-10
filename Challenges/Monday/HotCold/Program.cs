/*
    Hot or Cold - The classic "hot or cold" game, but with numbers. 
    The computer generates a random number, and the player has to make guesses until they correctly guess the random number. 
    The computer can only tell the player if they guessed too high, too low, or correctly. 
    Challenge: Allow the player to select the possible number range (ie. 3 - 9, 0 - 20, 30 - 100) to choose their own difficulty.
*/

using System;
using System.Collections.Generic;  
using System.Diagnostics;
using System.Net;

public class HotCold {

    public static void Main(string[] args){
        string name; 

        Console.WriteLine("Please your name: ");
        name = Console.ReadLine();
        while(Run(name)){}
       
    }

    //Get user name and allow the player to select the possible number range (ie. 0 - 20, 3 - 9, 30 - 100) to choose their own difficulty.
    public static (int,int,string) DifficultySelector(string name){
        int difficulty = -1;
        (int, int, string) cupcake = (3,9,"Cupcake"); 
        (int, int, string) meh = (0,20,"Meh"); 
        (int, int, string) impossible = (30,100,"Impossible"); 

        Dictionary<int,(int,int,string)> levels = new Dictionary<int,(int,int,string)>();
        levels.Add(1, cupcake);
        levels.Add(2, meh);
        levels.Add(3, impossible);

        Console.WriteLine("\nWelcome " + name + "! Now, Choose Your Difficulty:\n" );
        Console.WriteLine("***********ALL NUMBER RANGES ARE INCLUSIVE***********" );
        Console.WriteLine("[1] - Cupcake (Range 3 - 9)");
        Console.WriteLine("[2] - Meh (Range 0 - 20)");
        Console.WriteLine("[3] - Impossible (Range 30 - 100)\n");

        Console.WriteLine("Please select your dificulty level (Enter 1, 2, or 3): ");

        try{
            difficulty = Int32.Parse(Console.ReadLine());
        } catch(Exception){
            Console.WriteLine("Input should be an integer! Please enter either 1, 2, or 3. Try again...\n");
            DifficultySelector(name);
        }

        if (difficulty < 1 || difficulty > 3){
            Console.WriteLine("Input should only be either 1, 2, or 3. Try again...\n");
            DifficultySelector(name);
        }

        return levels[difficulty];
    }

    // UserGuess method: Asks user to input an int as a prediction, uses try/catch statements to handle various incorrect user inputs
    public static int UserGuess(string name, int start, int end, string difficulty){
        int prediction = -1;

        //INCORRECT NOT MIDPOINT BUT RATHER HOW FAR IS USER GUESS FROM AI GUESS!?!?
        int mid = (start + end) /2;

        Console.WriteLine("\nLevel " + difficulty + ": Enter any number from " + start + "-" + end + " (Inclusive):");

         try{
            prediction = Int32.Parse(Console.ReadLine());
        } catch(Exception){
            Console.WriteLine("\nInput should be only an integer (whole number) between " + start + "-" + end + " (Inclusive)! Please Try Again...\n");
            UserGuess(name, start, end, difficulty);
        }

        
        if (prediction < mid|| prediction > end){
            Console.WriteLine("Input should be only an integer (whole number) between " + start + "-" + end + " (Inclusive)! Please Try Again...\n");
            UserGuess(name, start, end, difficulty);
        }

         return prediction;
    }

    public static bool Run(string name){
        int userGuess;
        int computerGuess;
        string again;
        

        //Gets user input and translates to a difficulty range
        var (start, end, difficulty) = DifficultySelector(name);

        //Converts user difficulty range into a random computer guess (inclusive)
        computerGuess = new Random().Next(start,end);

        //Asks user for guess as input
        userGuess = UserGuess(name, start, end, difficulty);

        //Output both guesses (AI and Computer)
        Console.WriteLine("\nAI Guess = " + computerGuess);
        Console.WriteLine(name + "'s Guess =  " + userGuess); 

        //Compares user vs computer guess and outputs all results
        int mid = end - start;
        if (userGuess > mid){
            Console.WriteLine("\nTOO HIGH!");
        } else if (userGuess < mid){
            Console.WriteLine("\nTOO LOW!");
        } else {
            Console.WriteLine("\nCONGRATULATIONS! YOU GOT IT!");
        }

        Console.WriteLine("\nWould you like to try again(y/n)?"); 
        again = Console.ReadLine();

        return (again == "y" || again == "Y" || again == "Yes" || again == "YES");
    }

}


﻿/*To DO

-To save memory instead only read in the list with the appropriate difficulty
-Display instructions for user
-have player choose difficulty
-use chosen difficulty to select list
-Generate a rando
-Use rando to index the chosen list to grab a word

-Create a hashmap (dictionary) for user guesses (keys will be the guess and val will be how many times that letter has been guessed)?
-Total guesses =  Hard: word.Count + 3 | Medium: word.Count + (word.Count/2) | Easy = word.Count * 2
-Countdown from total guesses on each turn

//Challenge - do this for level easy
-Is it possible to do it this way and allow user to reveal all similar letters at the same time?
-if not maybe only implement this on the hardest difficulty, forcing the user to have to guess letter b letter one index at a time

-if level is med or hard, allow user to reveal all letters in the word simultaneously

-Iterate through the word-string and removeAt every time a player gets a correct guess
-When string,Count == 0, user wins! else if countdown == 0, user loses

-If a word has multiple letters, should all similar letters get revealed? or should user have to guess letter by position... the latter would prob be too hard for user...
-Result array should be filled with underscores for word.count
-On screen, initially just print out underscores equal to word.Count
-Every correct guess replaces result array with correct answer
-re print every turn?
*/

using System;
using System.Net.NetworkInformation;
using System.IO;

public class HangMan {
    public static readonly string easy = "Easy";
    public static readonly string medium = "Medium";
    public static readonly string hard = "Hard";


    public static void Main(string[] args){
        List<string> words;
        string gameWord;

        //Removes definitions, white spaces, and duplicates from .txt file
        words = PreProcessTxtFile("-");

        //Prompt user to select their difficulty
        DifficultySelector();

        //SOrt words by count, divvy the words into buckets (lists) of 9 words a piece based on word length (easy <= 9 words, med <= 12 words, and hard <= 17 words), return game word
        gameWord = BucketizeLists(words,difficulty);
    }

    public static List<string> PreProcessTxtFile(string deliminator){
        //https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
        String line;
        String word;
        List<string> words = new List<string>();
        string rawTxtPath = "rawVocab.txt";
        
        try {
            StreamReader sr = new StreamReader(rawTxtPath);

            //ERROR: Exception: Object reference not set to an instance of an object.
            do {
                line = sr.ReadLine();
                word = line.Split(deliminator)[0];

                //Prevent duplicates and empty spaces from going in list
                if (word.Count() != 0 && !words.Contains(word)){ words.Add(word); }

            } while (line != null);

            sr.Close();
            Console.ReadLine();

        } catch(Exception e){
            Console.WriteLine("Exception: " + e.Message);

        } finally {
            Console.WriteLine("Executing finally block.");
        }

        //Sort by count words list by word length
        words.Sort((a,b) => a.Length - b.Length);

        return words;
    }

    public static void Testing(List<string> words){
        //What is the longest and shortest count of a particular list in the word?
        //Need to sort list by word.Count

        //int min, max = words[0].Count();
        int min = words[0].Count();
        int max = words[0].Count();

        foreach (string word in words){
            if (word.Count() < min){
                min = word.Count();
            }

            if (word.Count() > max){
                max = word.Count();
            }
        }

        Console.WriteLine($"\n\nmin = {min}");
        Console.WriteLine($"max = {max}");
    }

    public static string BucketizeLists(List<string> words, string difficulty){

        //Sort by count words list by word length
        words.Sort((a,b) => a.Length - b.Length);
        
        string selectedDifficulty = DifficultySelector();
        List<string> easyList = new List<string>();
        List<string> mediumList = new List<string>();
        List<string> hardList = new List<string>();
        Random rando = new Random();
        int limit = 9;



        //PUT SWITCH HERE that way only 1 list will need to be made instead of 3
        
        //Bucketize words by difficulty/Count
        for (int i = 0; i < words.Count; i++){
            if (words[i].Count() <= 9 && easyList.Count < 9){
                easyList.Add(words[i]);

            } else if (words[i].Count() > 9 && words[i].Count() < 13 && mediumList.Count < 9) {
                mediumList.Add(words[i]);

            } else if (words[i].Count() >= 13 && hardList.Count < 9) {
                hardList.Add(words[i]);
            }
        }

        //Need to finish ediitng difficulty selector to fit this code
        switch(selectedDifficulty){
        case 1:
            limit = 10;
            return easyList[rando.Next(limit)];

        case 2:
            limit = 13;
            return mediumList[rando.Next(limit)];

        case 3:
            limit = 18;
            return hardList[rando.Next(limit)];
        }
    }

    //Need to decompartmentalize the bucketizeList functin... too long. Title doesn't properly convey what it is doing
    //public static string selectRandomWord(){}

   
    //Allow user to select the word difficulty
    public static string DifficultySelector(){
        int difficulty = -1;
        (int, int, string) cupcake = (3,9,"Cupcake"); 
        (int, int, string) meh = (0,20,"Meh"); 
        (int, int, string) impossible = (30,100,"Impossible"); 

        Dictionary<int,(int,int,string)> levels = new Dictionary<int,(int,int,string)>();
        levels.Add(1, cupcake);
        levels.Add(2, meh);
        levels.Add(3, impossible);

        Console.WriteLine("\n*********** Choose Your Difficulty: ***********\n" );
        Console.WriteLine("[1] - Easy");
        Console.WriteLine("[2] - Medium");
        Console.WriteLine("[3] - Hard\n");
        Console.WriteLine("Please select your difficulty by entering either 1, 2, or 3: ");

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

        public static bool IsValidIntInput(string userInput, int min, int max){
        int value;

          try{
            value = Int32.Parse(userInput);
        } catch(Exception){
            Console.WriteLine("\nInput type should be only an integer value,  Please check your entry and try Again...\n");
            return false;
        }

        if ((min + max > 0) && (value < min || value > max)){
            Console.WriteLine("Input should be only an integer value between " + min + "-" + max + " (Inclusive)! Please Try Again...\n");
            return false;
        }

        return true;
    }

}



/*
Hangman - Play a game of hangman with the computer. 
A "random" word is chosen, and the number of letters is displayed. 
The player has to guess letters, which are revealed in the word if correct. 
Incorrect guessed can be counted, or used as a countdown against the player. 

Challenge: Use formatting in the console display to "update" the display without moving down the terminal output. 
Keep the hidden word, previously guessed letters, and the players input in fixed locations on screen.
*/

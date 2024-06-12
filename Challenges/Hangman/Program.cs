/*To DO

//PreProcessing
-List difficulty splitter should be 4
-remove duplicates
-Sort words by count
-format vocab words into 3 dif files or categories based on length
-Convert notes vocab list into .txt file (or read in as is)
-convert read txt file into 3 lists based on difficulty
-To save memory instead only read in the list with the appropriate difficulty
-Display instructions for user
-ask user name?
-have player choose difficulty

-use chosen difficulty to
-Generate a random number rando
-Use rando to index the chosen list to grab a word
-Create a hashmap (dictionary) for user guesses (keys will be the guess and val will be how many times that letter has been guessed)?
-Total guesses =  Hard: word.Count + 3 | Medium: word.Count + (word.Count/2) | Easy = word.Count * 2
-Countdown from total guesses on each turn

-Iterate through the word-string and removeAt every time a player gets a correct guess
-When string,Count == 0, user wins! else if countdown == 0, user loses

-If a word has multiple letters, should all similar letters get revealed? or should user have to guess letter by position... the latter would prob be too hard for user...
-Result array should be filled with underscores for word.count
-On screen, initially just print out underscores equal to word.Count
-Every correct guess replaces result array with correct answer
-re print every turn?

//Challenge
-Is it possible to do it this way and allow user to reveal all similar letters at the same time?
-if not maybe only implement this on the hardest difficulty, forcing the user to have to guess letter b letter one index at a time
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

        //Removes definitions, white spaces, and duplicates from .txt file
        words = PreProcessTxtFile("-");

        //Sort by count words list by word length
        words.Sort((a,b) => a.Length - b.Length);

        //Divvy the words list into buckets of 9 words a piece based on word length (easy <= 9 words, med <= 12 words, and hard <= 17 words)
        BucketizeLists(words);
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

    public static string BucketizeLists(List<string> words){
        string selectedDifficulty;
        Random rando = new Random();
        int limit = 9;
        

        //selectedDifficulty = DifficultySelector();

        List<string> easyList = new List<string>();
        List<string> mediumList = new List<string>();
        List<string> hardList = new List<string>();

        //Bucketize words by difficulty/Count
        for (int i = 0; i < words.Count; i++){
            if (words[i].Count() <= 9 && easy.Count < 9){
                easy.Add(words[i]);

            } else if (words[i].Count() > 9 && words[i].Count() < 13 && medium.Count < 9) {
                medium.Add(words[i]);

            } else if (words[i].Count() >= 13 && hard.Count < 9) {
                hard.Add(words[i]);
            }
        }

        //Need to finish ediitng difficulty selector to fit this code
        switch(selectedDifficulty){
        case easy:
            limit = 10;
            return easyList[rando.Next(limit)];

        case medium:
            limit = 13;
            return mediumList[rando.Next(limit)];

        case hard:
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

        Console.WriteLine("\nWelcome! Choose Your Difficulty:\n" );
        Console.WriteLine("***********ALL NUMBER RANGES ARE INCLUSIVE***********" );
        Console.WriteLine("[1] - Easy");
        Console.WriteLine("[2] - Medium");
        Console.WriteLine("[3] - Hard\n");

        Console.WriteLine("Please select your difficulty level (Enter 1, 2, or 3): ");

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

}



/*
Hangman - Play a game of hangman with the computer. 
A "random" word is chosen, and the number of letters is displayed. 
The player has to guess letters, which are revealed in the word if correct. 
Incorrect guessed can be counted, or used as a countdown against the player. 

Challenge: Use formatting in the console display to "update" the display without moving down the terminal output. 
Keep the hidden word, previously guessed letters, and the players input in fixed locations on screen.
*/

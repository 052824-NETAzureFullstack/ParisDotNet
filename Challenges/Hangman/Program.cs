/*To DO

//PreProcessing
-List difficulty splitter should be 6
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

    public static void Main(string[] args){
        List<string> words;
        words = PreProcessTxtFile("-");

        Console.WriteLine("STARTING SORT!");
        words.Sort((a,b) => a.Length - b.Length);
        Console.WriteLine("ENDING SORT!");

        for (int i = 0; i < words.Count(); i++){
            Console.WriteLine(words[i]);
        }

        
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
                if (word.Count() != 0){words.Add(word);}
                //Console.WriteLine(word.Count());

            } while (line != null);

            //Testing(words);
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
}



/*
Hangman - Play a game of hangman with the computer. 
A "random" word is chosen, and the number of letters is displayed. 
The player has to guess letters, which are revealed in the word if correct. 
Incorrect guessed can be counted, or used as a countdown against the player. 

Challenge: Use formatting in the console display to "update" the display without moving down the terminal output. 
Keep the hidden word, previously guessed letters, and the players input in fixed locations on screen.
*/

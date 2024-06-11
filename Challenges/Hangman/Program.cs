/*To DO

//PreProcessing
-What type of file is Apple notes files saved in?
-Format file to just a separate word on each line
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
public class HangMan {

    public static void Main(string[] args){

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

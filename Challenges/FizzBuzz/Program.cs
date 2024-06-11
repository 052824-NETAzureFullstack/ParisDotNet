/*

FizzBuzz - The frustratingly common FizzBuzz game.
The player selects a range of numbers (2 - 18) and the computer plays FizzBuzz. 
It prints the number on it's own line in the output. 
If the number is divisible by 3, replace it with "Fizz". If the number is divisible by 5, replace with with "Buzz". 
If the number is divisible by BOTH 3 and 5, replace with with "FizzBuzz". 
Challenge: Add "Bang" for numbers divisible by 7, and all the combinations of 3, 5, and 7 get the combinations of Fizz, Buzz, Bang. 
Challenge: Alternate between the computer and user input to complete the game. The computer starts, printing "2". 
The play has to continue, either entering the word "Fizz", or selecting an option from a list.
*/

using System;

public class FizzBuzz {

    public static void Main(string[] args){
        //Console.WriteLine("Hello, World!");
        string start; 
        string end; 

        Console.WriteLine("To play FizzBuzz, select a range of numbers to start! ");
        Console.Write("First enter the starting number of the range: ");
        start = Console.ReadLine();

        Console.Write("Great! Now enter the ending number of the range: ");
        end = Console.ReadLine();

        while(Run(name));
       
    }

    public static bool IsValidIntInput(string userInput, int min, int max){
        int value;

          try{
            value = Int32.Parse(userInput);
        } catch(Exception){
            Console.WriteLine("\nInput type should be only an integer value,  Please check your entry and try Again...\n");
            return false;
        }

        if (value < min|| value > max){
            Console.WriteLine("Input should be only an integer value between " + min + "-" + max + " (Inclusive)! Please Try Again...\n");
            return false;
        } else{
            return true;
        }    
    }
}



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
        int start; 
        int end; 
        string temp;
        string output = "   ";

        Console.WriteLine("To play FizzBuzz, select a range of numbers to start! ");
        Console.Write("First enter the starting number of the range: ");
        temp = Console.ReadLine();

        if (!IsValidIntInput(temp)){
            temp = Console.ReadLine();
        }

        start = Int32.Parse(temp);

        Console.Write("Great! Now enter the ending number of the range: ");
        temp = Console.ReadLine();

        if (!IsValidIntInput(temp)){
            temp = Console.ReadLine();
        }

        end = Int32.Parse(temp);

        for (int i = start; i < end+1; i++){

            if (by3(i)){output += "Fizz";}
            if (by5(i)){output += "Buzz";}
            if (by7(i)){output += "Bang";}
            
        }
    }
        public static bool by3(int num){ return (num % 3 == 0) ? true : false;}
        public static bool by5(int num){ return (num % 5 == 0) ? true : false; }
        public static bool by7(int num){ return (num % 7 == 0) ? true : false; }


    public static bool IsValidIntInput(string userInput){
        int value;

          try{
            value = Int32.Parse(userInput);
        } catch(Exception){
            Console.WriteLine("\nInput type should be only an integer value,  Please check your entry and try Again...\n");
            return false;
        }

        return true;
    }
}



/*

FizzBuzz - The frustratingly common FizzBuzz game.
The player selects a range of numbers (2 - 18) and the computer plays FizzBuzz. 

It prints the number on it's own line in the output. 
If the number is divisible by 3, replace it with "Fizz". If the number is divisible by 5, replace with with "Buzz". 
If the number is divisible by BOTH 3 and 5, replace with with "FizzBuzz". 
Challenge: Add "Bang" for numbers divisible by 7, and all the combinations of 3, 5, and 7 get the combinations of Fizz, Buzz, Bang. 

Challenge: Alternate between the computer and user input to complete the game. The computer starts, printing "2". 
The player has to continue, either entering the word "Fizz", or selecting an option from a list.
*/

using System;
using System.ComponentModel;

public class FizzBuzz {
    HashSet<string> userOptions = new HashSet<string>();

    public static void Main(string[] args){
        (int start, int end) = UserSetRange();

        //First run is to fill a Hashset (so no duplicates) with realistic options for user selection
        SimulateRun(start,end,false);

        //This is the actual gameplay with user
        SimulateRun(start,end,true);

    }
    
    public static bool By3(int num){ return (num % 3 == 0) ? true : false;}
    public static bool By5(int num){ return (num % 5 == 0) ? true : false;}
    public static bool By7(int num){ return (num % 7 == 0) ? true : false;}

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
        } else{
            return true;
        }  

        return true;
    }

    public static string UserPlayMenu(int i){
        string userInput;
        int rando1 = new Random().Next(0,userOptions.Count);
        int rando2 = new Random().Next(0,userOptions.Count);
        int rando3 = new Random().Next(0,userOptions.Count);
        string[] options = [userOptions[rando1],userOptions[rando2],userOptions[rando3]];


        Console.WriteLine("***********Options***********" );
        Console.WriteLine("[0] - " + options[0]);
        Console.WriteLine("[1] - " + options[1]);
        Console.WriteLine("[2] - " + options[2]);    
        Console.WriteLine("[3] - " + i.ToString());


        Console.Write("Please select a number option between 0-3: ");
        userInput = Console.ReadLine(); 

        if (IsValidIntInput(userInput)){
            return options[Int32.Parse(userInput)];
        }
    }

    public static void SimulateRun(int start, int end, bool isUser){
        for (int i = start; i < end+1; i++){
            string output = "";
            if (By3(i)){output += "Fizz";}
            if (By5(i)){output += "Buzz";}
            if (By7(i)){output += "Bang";}  

            if ((!By3(i) && !By5(i) && !By7(i)) || i == 0){ 
                output = i.ToString();
            }

            if (isUser){
                //answerAsString = UserPlayMenu();
                //Must compare user Answer with computer answer
                // if true print user answer to console and go to next iteration
                //if false game is over and print message for the user
                //Console.WriteLine(output);
            } else {
                userOptions.Add(output);
            }
        }
    }

    public static (int, int) UserSetRange(){
        string temp;
        int start;
        int end;

        Console.WriteLine("To play FizzBuzz, select a range of numbers to start!");
        Console.Write("First enter the starting number of the range: ");
        temp = Console.ReadLine();
        
        if (!IsValidIntInput(temp,0,0)){
            temp = Console.ReadLine();
        }

        start = Int32.Parse(temp);

        Console.Write("Great! Now enter the ending number of the range: ");
        temp = Console.ReadLine();

        if (!IsValidIntInput(temp,0,0)){
            temp = Console.ReadLine();
        }

        end = Int32.Parse(temp);

        return (start, end);
    }
}
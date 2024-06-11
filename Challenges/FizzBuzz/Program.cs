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

    public static void Main(string[] args){

        (int start, int end) = UserSetRange();
        SimulateRun(start,end,false);
        SimulateRun(start,end,true);




    }
    
    public static bool By3(int num){ return (num % 3 == 0) ? true : false;}
    public static bool By5(int num){ return (num % 5 == 0) ? true : false;}
    public static bool By7(int num){ return (num % 7 == 0) ? true : false;}

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


    public static void GameSetup(){
        //Better idea: the game will go through the list first before allowing the user to play and input all the dif fizz/buzz/bang combination possibilites into a dictionary (because you can check each key to see whether or not that value already exists to avoid duplicates)
        //If C# has sets then a dictionary may not be necessary

        HashSet<string> userOptions = new HashSet<string>();
            //userOptions.Add()
    }

    public static void UserPlayMenu(int i){
        //There are too many different possible variations to consider them all as options. Going to have randomly give the user 4 options
        Console.WriteLine("***********Options***********" );
        Console.WriteLine("[1] - " + i.ToString());
        Console.WriteLine("[2] - Fizz (Range 0 - 20)");
        Console.WriteLine("[3] - Buzz (Range 30 - 100)\n");
        Console.WriteLine("[4] - Bang (Range 30 - 100)\n");

        Console.WriteLine("[5] - FizzBuzz (Range 30 - 100)\n");
        Console.WriteLine("[6] - FizzBang (Range 30 - 100)\n");
        Console.WriteLine("[7] - FizzBuzzBang (Range 30 - 100)\n");


        string[] weekDays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

        Dictionary<int,string> userOptions = new Dictionary<int,string>();
      
    }

    public static void SimulateRun(int start, int end, bool isUser){
        HashSet<string> userOptions = new HashSet<string>();
        for (int i = start; i < end+1; i++){
            string output = "";
            if (By3(i)){output += "Fizz";}
            if (By5(i)){output += "Buzz";}
            if (By7(i)){output += "Bang";}  

            if ((!By3(i) && !By5(i) && !By7(i)) || i == 0){ 
                output = i.ToString();
            }

            if (isUser){
                Console.WriteLine(output);
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

        return (start, end);
    }
}
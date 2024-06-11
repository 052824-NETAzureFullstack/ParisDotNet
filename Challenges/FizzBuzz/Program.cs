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
using System.Linq;


public class FizzBuzz {    
    public static List<string> userOptionsList;

    public static void Main(string[] args){
        HashSet<string> userOptions = new HashSet<string>();

        (int start, int end) = UserSetRange();

        //First run is to fill a Hashset (so no duplicates) with realistic options for user selection
        userOptions = SimulateRun(start,end,false);

        //Convert our non-duplicate options into a list for easier random indexing.
        userOptionsList = userOptions.ToList();

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
        }

        return true;
    }

    public static string UserPlayMenu(int i, string answer, int min, int max){
        List<string> menuList = new List<string>();
        List<string> finalList = new List<string>();

        string userInput;
        int rando;
     
        menuList.Add(answer);

        //Create a unique menu with 3 values: 2 dummy (but realistically possible) vals, and the answer
        while (menuList.Count < 3){
            rando = new Random().Next(0,userOptionsList.Count);

            if (userOptionsList[rando] != answer){
                menuList.Add(userOptionsList[rando]);
            }
        }

        //Construct the final menu as an array starting with the integer option, then a random string from the previously constructed list, and finally the last two remaining values
        finalList.Add(i.ToString());
        rando = new Random().Next(0,2);
        finalList.Add(menuList[rando]);
        menuList.RemoveAt(rando);
        finalList.Add(menuList[0]);
        finalList.Add(menuList[1]);

        Console.WriteLine("***********Options***********" );
        for (int x = 0; x < finalList.Count; x++) {
             Console.WriteLine("[{x}] - " + finalList[x]);
        }

        Console.Write("Please select a number option between 0-3: ");
        userInput = Console.ReadLine(); 

        do {
            Console.Write("Please select a number option between 0-3: ");
            userInput = Console.ReadLine(); 

        } while (!IsValidIntInput(userInput, min, max));
  
  
        return finalList[Int32.Parse(userInput)];

    }

    public static HashSet<string> SimulateRun(int start, int end, bool isUser){
        HashSet<string> userOptionsSet = new HashSet<string>();

        for (int i = start; i < end+1; i++){
            string output = "";
            if (By3(i)){output += "Fizz";}
            if (By5(i)){output += "Buzz";}
            if (By7(i)){output += "Bang";}  

            if ((!By3(i) && !By5(i) && !By7(i)) || i == 0){ 
                output = i.ToString();
            }

            if (isUser){
                //answerAsString = UserPlayMenu(i,answer);
                //Must compare user Answer with computer answer
                // if true print user answer to console and go to next iteration
                //if false game is over and print message for the user
                //Console.WriteLine(output);
            } else {
                userOptionsSet.Add(output);
            }
        }

        return userOptionsSet;
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
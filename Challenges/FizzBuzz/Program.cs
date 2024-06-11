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

        (int min, int max) = UserSetRange();

        ShowRules();

        //First run is to fill a Hashset (so no duplicates) with realistic options for user selection
        userOptions = SimulateRun(min,max,false);

        //Convert our non-duplicate options into a list for easier random indexing.
        userOptionsList = userOptions.ToList();

        //This is the actual gameplay with user
        SimulateRun(min,max,true);
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

    public static string UserPlayMenu(int i, string cpuAnswer, int min, int max){
        List<string> menuList = new List<string>();
        List<string> finalList = new List<string>();

        string userInput;
        int rando;

        //menuList.Add(i.ToString());
        if (i.ToString() != cpuAnswer){
            menuList.Add(cpuAnswer);
        }

        //Create a unique menu with 3 values: 2 dummy (but realistically possible) vals, and the answer
        while (menuList.Count < 5){
            rando = new Random().Next(0,userOptionsList.Count);

            if (userOptionsList[rando] != cpuAnswer){
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
             Console.WriteLine($"[{x}] - " + finalList[x]);
        }

        do {
            Console.Write("Please select a number option between 0-3: ");
            userInput = Console.ReadLine(); 

        } while (!IsValidIntInput(userInput, min, max));
  

        return finalList[Int32.Parse(userInput)];

    }

    public static HashSet<string> SimulateRun(int min, int max, bool isUser){
        HashSet<string> userOptionsSet = new HashSet<string>();
        string userAnswer;

        for (int i = min+1; i < max+2; i++){
            if (i == 0 && isUser){
                Console.WriteLine("\nCPU TURN: " + (i).ToString());
                continue;
            }

            if (i%2==0){
                Console.WriteLine("\nCPU TURN: " + (i).ToString());
            }

            string cpuOutput = "";
            if (By3(i)){cpuOutput += "Fizz";}
            if (By5(i)){cpuOutput += "Buzz";}
            if (By7(i)){cpuOutput += "Bang";} 

            if ((!By3(i) && !By5(i) && !By7(i))){ 
                cpuOutput = i.ToString();
            }

            if (isUser){
                userAnswer = UserPlayMenu(i,cpuOutput,min, max);
                
                if (userAnswer == cpuOutput){
                    Console.WriteLine($"\n {userAnswer} IS CORRECT!");
                    continue;
                } else {
                    Console.WriteLine("INCORRECT... GAME OVER....");
                    break;
                }
            } else {
                if(!int.TryParse(cpuOutput, out int value)){
                    userOptionsSet.Add(cpuOutput);      
                }
            }
        }

        return userOptionsSet;
    }

    public static (int, int) UserSetRange(){
        string temp;
        int min;
        int max;

        Console.WriteLine("To play FizzBuzz, select a range of numbers to start!\n");

        do {
            Console.Write("First enter the starting number of the range: ");
            temp = Console.ReadLine();

        } while (!IsValidIntInput(temp, 0, 0));
    
        min = Int32.Parse(temp);

        do {
            Console.Write("Great! Now enter the ending number of the range: ");
            temp = Console.ReadLine();

        } while (!IsValidIntInput(temp, 0, 0));

        max = Int32.Parse(temp);

        return (min, max);
    }

    public static void ShowRules(){
        Console.WriteLine("\n**************RULES**************");
        Console.WriteLine("The CPU will output a number starting from the beginning of the range.");
        Console.WriteLine("As the player, you must either choose the next number in the sequence or choose the string corresponding to one of the following situations: \n");

        Console.WriteLine("If the number is divisible by 3, replace it with \"Fizz\".");
        Console.WriteLine("If the number is divisible by 5, replace with with \"Buzz\".");
        Console.WriteLine("If the number is divisible by BOTH 3 and 5, replace with with \"FizzBuzz\".");
        Console.WriteLine("Add \"Bang\" for numbers divisible by 7, and all the combinations of 3, 5, and 7 get the combinations of Fizz, Buzz, Bang.\n");
    }
}
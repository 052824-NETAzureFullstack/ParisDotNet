public class Program{
    public static void Main(string[] args){
        string name = Register();
        bool exit = false;
        int count = 0;
        string userGuessValue;
        string result;



        while(!exit){
            userGuessValue = (UserGuess() == 0) ? "Heads" : "Tails";
            exit = CoinFlip(name, (count+1),userGuessValue);
            count++;
        }

        Console.WriteLine("Thanks for playing! \n");
    }

    public static bool CoinFlip(string name, int iteration, string userGuess){
        Console.WriteLine("Flipping in progress...\n");

        Random rand = new Random();
        string flipResult; //True == Tails else Heads
        string? again;
        int value = rand.Next();
        int remainder = value % 2;
    
        Console.WriteLine(name + "' Guess " + iteration + " Results = " + userGuess);

        flipResult = (remainder == 0) ? "Heads" : "Tails";
        Console.WriteLine(name + "' Flip " + iteration + " Results = " + flipResult + "!");

        if (userGuess == flipResult){
            Console.WriteLine("Congratulations! you guessed correctly. \n");
        } else {
            Console.WriteLine("Ooooh! unfortuantely you guessed incorrectly. \n");
        }

        Console.WriteLine("Would you like to flip again (y/n)? ");
        again =  Console.ReadLine();

        return (again == "n" || again == "N" || again == "no" || again == "NO" || again == "No");
    }

    public static string Register(){
        Console.WriteLine("Please your name: ");
        return Console.ReadLine();
    }

        public static int UserGuess(){
            Console.WriteLine("What is your coin flip prediction?");
            Console.WriteLine("Enter: \n 0 = Heads \n OR \n 1 = Tails \n");
            int prediction = Int32.Parse(Console.ReadLine());

            if (prediction == 0 || prediction == 1){
                return prediction;
            } else {
                Console.WriteLine("Input should only be either 1 or 0. Try again.");
                return UserGuess();
            }


        }



}
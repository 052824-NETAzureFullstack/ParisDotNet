public class Program{
    public static void Main(string[] args){
        string name = Register();
        bool exit = false;
        int count = 0;

        while(!exit){
            exit = CoinFlip(name, (count+1));
            count++;
        }

        Console.WriteLine("Thanks for playing! \n");
    }

    public static bool CoinFlip(string name, int iteration){
        Console.WriteLine("Flipping in progress...\n");

        Random rand = new Random();
        string flipResult;
        string? again;
        int value = rand.Next();
        int remainder = value % 2;
    
        flipResult = (remainder == 0) ? "Tails" : "Heads";
        Console.WriteLine(name + "' Flip " + iteration + " Results = " + flipResult + "!");

        Console.WriteLine("Would you like to flip again (y/n)? ");
        again =  Console.ReadLine();

        return (again == "n" || again == "N" || again == "no" || again == "NO" || again == "No");
    }

    public static string Register(){
        Console.WriteLine("Please your name: ");
        return Console.ReadLine();
    }


}
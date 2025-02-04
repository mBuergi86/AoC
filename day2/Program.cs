class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Select which part to run:");
        Console.WriteLine("1 - Part 1");
        Console.WriteLine("2 - Part 2");

        string input = Console.ReadLine() ?? "";

        if (input.Length != 1 || !int.TryParse(input, out int result) || result < 1 || result > 2)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 2.");
            return;
        }

        switch (input)
        {
            case "1":
                Part1.Run(args);
                break;
            case "2":
                Part2.Run(args);
                break;
        }
    }
}

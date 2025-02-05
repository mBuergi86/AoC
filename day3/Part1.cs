using System.Text.RegularExpressions;

public class Part1
{
    public static void Run(string[] args)
    {
        string path = @"item.txt";

        if (!File.Exists(path))
        {
            Console.WriteLine("The file does not exist.");
        }
        else
        {
            string line = File.ReadAllText(path);
            string pattern = @"mul\((\d+),\s*(\d+)\)";
            int sum = 0;

            MatchCollection matches = Regex.Matches(line, pattern);

            foreach (Match match in matches)
            {
                int num1 = int.Parse(match.Groups[1].Value);
                int num2 = int.Parse(match.Groups[2].Value);
                sum += num1 * num2;
            }

            Console.WriteLine(sum);
        }
    }
}

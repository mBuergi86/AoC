using System.Text.RegularExpressions;

public class Part2
{
    public static void Run(string[] args)
    {
        string path = @"item.txt";

        if (!File.Exists(path))
        {
            Console.WriteLine("The file does not exist.");
            return;
        }

        string line = File.ReadAllText(path);
        string pattern = @"(do\(\)|don't\(\))|mul\((\d+),\s*(\d+)\)";
        int sum = 0;
        bool enabled = true;

        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        MatchCollection matches = regex.Matches(line);

        foreach (Match match in matches)
        {
            if (match.Groups[1].Success)
            {
                string command = match.Groups[1].Value;
                if (command == "do()")
                    enabled = true;
                else if (command == "don't()")
                    enabled = false;
            }
            else if (match.Groups[2].Success && match.Groups[3].Success)
            {
                if (enabled)
                {
                    int num1 = int.Parse(match.Groups[2].Value);
                    int num2 = int.Parse(match.Groups[3].Value);
                    sum += num1 * num2;
                }
            }
        }

        Console.WriteLine(sum);
    }
}

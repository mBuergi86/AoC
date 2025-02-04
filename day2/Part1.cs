public class Part1
{
    public static void Run(string[] args)
    {
        string path = @"item.txt";
        List<List<int>> numbersList = new List<List<int>>();
        char[] stringSplit = { ' ' };
        int safeCount = 0;

        if (!File.Exists(path))
        {
            Console.WriteLine("The file does not exist.");
        }
        else
        {
            foreach (string line in File.ReadLines(path))
            {
                List<int> numbers = line.Trim()
                    .Split(stringSplit, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                numbersList.Add(numbers);
            }
        }

        foreach (var row in numbersList)
        {
            bool isSafe = true;
            bool? increasing = null;

            for (int i = 0; i < row.Count - 1; i++)
            {
                int difference = Math.Abs(row[i] - row[i + 1]);

                if (difference < 1 || difference > 3)
                {
                    isSafe = false;
                    break;
                }

                if (row[i] < row[i + 1])
                {
                    if (increasing == false)
                    {
                        isSafe = false;
                        break;
                    }

                    increasing = true;
                }
                else if (row[i] > row[i + 1])
                {
                    if (increasing == true)
                    {
                        isSafe = false;
                        break;
                    }

                    increasing = false;
                }
            }

            if (isSafe)
                safeCount++;
        }

        Console.WriteLine($"Result for safe: {safeCount}");
    }
}

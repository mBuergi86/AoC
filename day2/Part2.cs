public class Part2
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
            if (IsSafe(row))
            {
                safeCount++;
            }
            else
            {
                for (int i = 0; i < row.Count; i++)
                {
                    List<int> modifiedRow = new List<int>(row);
                    modifiedRow.RemoveAt(i);

                    if (IsSafe(modifiedRow))
                    {
                        safeCount++;
                        break;
                    }
                }
            }
        }

        Console.WriteLine($"Result for safe: {safeCount}");
    }

    public static bool IsSafe(List<int> row)
    {
        if (row.Count < 2)
        {
            return true;
        }

        bool? increasing = null;

        for (int i = 0; i < row.Count - 1; i++)
        {
            int difference = Math.Abs(row[i] - row[i + 1]);

            if (difference < 1 || difference > 3)
            {
                return false;
            }

            bool currentIncreasing = row[i] > row[i + 1];

            if (increasing == null)
            {
                increasing = currentIncreasing;
            }
            else if (increasing != currentIncreasing)
            {
                return false;
            }
        }
        return true;
    }
}

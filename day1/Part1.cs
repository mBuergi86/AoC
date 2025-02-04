public class Part1
{
    public static void Run(string[] args)
    {
        string path = @"item.txt";
        List<int> left = new List<int>();
        List<int> right = new List<int>();
        char[] separatingStrings = { ' ' };

        if (!File.Exists(path))
        {
            Console.WriteLine("The file does not exist.");
        }
        else
        {
            foreach (string line in File.ReadLines(path))
            {
                string[] parts = line.Trim()
                    .Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);

                if (
                    parts.Length == 2
                    && int.TryParse(parts[0], out int leftNum)
                    && int.TryParse(parts[1], out int rightNum)
                )
                {
                    left.Add(leftNum);
                    right.Add(rightNum);
                }
                else
                {
                    Console.WriteLine($"Skipping Invalid line: \"{line}\"");
                }
            }
        }

        if (left.Count != right.Count)
        {
            Console.WriteLine(
                "The number of left and right items are not equal. Please check the file."
            );
            return;
        }

        left = left.OrderBy(x => x).ToList();
        right = right.OrderBy(x => x).ToList();

        int sum = 0;

        for (int i = 0; i < left.Count; i++)
        {
            int leftValue = left[i];
            int rightValue = right[i];

            sum += Math.Abs(leftValue - rightValue);
        }

        Console.WriteLine($"The total sum is: {sum}");
    }
}

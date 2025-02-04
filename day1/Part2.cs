public class Part2
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
                // string[] parts = line.Trim()
                //     .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
        int count = 0;

        for (int i = 0; i < left.Count; i++)
        {
            int leftValue = left[i];

            for (int j = 0; j < right.Count; j++)
            {
                if (leftValue == right[j])
                {
                    count++;
                }
            }

            if (count >= 1)
            {
                sum += Math.Abs(leftValue * count);
                count = 0;
            }
        }

        Console.WriteLine($"The total sum is: {sum}");
    }
}

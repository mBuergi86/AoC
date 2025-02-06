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

        string[] lines = File.ReadAllLines(path);

        if (lines.Length < 3 || lines[0].Length < 3)
        {
            Console.WriteLine("Grid is not big enough.");
            return;
        }

        int count = 0;
        int Rows = lines.Length;
        int Cols = lines[0].Length;

        for (int y = 1; y < Rows - 1; y++)
        {
            for (int x = 1; x < Cols - 1; x++)
            {
                if (lines[y][x].Equals('A'))
                {
                    bool diagonal = (
                        (
                            $"{lines[y - 1][x - 1]}{lines[y + 1][x + 1]}".Equals("SM")
                            || $"{lines[y - 1][x - 1]}{lines[y + 1][x + 1]}".Equals("MS")
                        )
                        && (
                            $"{lines[y + 1][x - 1]}{lines[y - 1][x + 1]}".Equals("SM")
                            || $"{lines[y + 1][x - 1]}{lines[y - 1][x + 1]}".Equals("MS")
                        )
                    );

                    if (diagonal)
                    {
                        count++;
                    }
                }
            }
        }

        Console.WriteLine(count);
    }
}

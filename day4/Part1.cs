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
            string[] lines = File.ReadAllLines(path);

            if (lines.Length == 0)
            {
                Console.WriteLine("No lines in the file.");
                return;
            }

            int Rows = lines.Length;
            int Cols = lines[0].Length;
            char[,] grid = new char[Rows, Cols];

            for (int i = 0; i < Rows; i++)
            {
                if (lines[i].Length != Cols)
                {
                    Console.WriteLine("Lines in the file are not equal length.");
                    return;
                }
                for (int j = 0; j < Cols; j++)
                {
                    grid[i, j] = lines[i][j];
                }
            }

            int result = CountWordInstances(grid, "XMAS");

            Console.WriteLine(result);
        }
    }

    static int[] dx = { 1, -1, 0, 0, 1, 1, -1, -1 };
    static int[] dy = { 0, 0, 1, -1, 1, -1, 1, -1 };

    static int CountWordInstances(char[,] grid, string word)
    {
        int count = 0;
        int Rows = grid.GetLength(0);
        int Cols = grid.GetLength(1);
        int wordLength = word.Length;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (grid[i, j] == word[0])
                {
                    for (int k = 0; k < 8; k++)
                    {
                        int x = i,
                            y = j;
                        for (int l = 1; l < wordLength; l++)
                        {
                            x += dx[k];
                            y += dy[k];

                            if (x < 0 || x >= Rows || y < 0 || y >= Cols || grid[x, y] != word[l])
                                break;

                            if (l == wordLength - 1)
                                count++;
                        }
                    }
                }
            }
        }
        return count;
    }
}

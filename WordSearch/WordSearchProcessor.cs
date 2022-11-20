using System;

namespace WordSearch
{
    public static class WordSearchProcessor
    {
        static int[] x = { -1, -1, -1, 0, 0, 1, 1, 1 };
        static int[] y = { -1, 0, 1, -1, 1, -1, 0, 1 };

        public static bool CheckMatchingWord(char[,] Grid, int row, int col, string word, out int wordDirection)
        {          
            wordDirection = 0;
            if (Grid[row, col] != word[0])
            {
                return false;
            }

            int len = word.Length;
            
            for (int direction = 0; direction < 8; direction++)
            {               
                int k, rowPosition = row + x[direction], columnPosition = col + y[direction];

                for (k = 1; k < len; k++)
                {
                    if (rowPosition >= Grid.GetLength(0) || rowPosition < 0 || columnPosition >= Grid.GetLength(1) || columnPosition < 0)
                    {
                        break;
                    }

                    if (Grid[rowPosition, columnPosition] != word[k])
                    {
                        break;
                    }

                    rowPosition += x[direction];
                    columnPosition += y[direction];
                }

                if (k == len)
                {
                    wordDirection = direction;
                    return true;
                }
            }
            return false;
        }

        public static void FindPosition(char[,] Grid, String word)
        {
            for (int row = 0; row < Grid.GetLength(0); row++)
            {
                for (int col = 0; col < Grid.GetLength(1); col++)
                {
                    int dir;
                    if (CheckMatchingWord(Grid, row, col, word, out dir))
                    {                        
                        int rowIndex = row + x[dir] * (word.Length - 1); 
                        int colIndex = col + y[dir] * (word.Length - 1);

                        Console.WriteLine(word + "" + " found at (" + col + "," + row + ") to (" + colIndex + "," + rowIndex + ")");

                    }
                }
            }
        }
    }
}

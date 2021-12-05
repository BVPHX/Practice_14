using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Practice_13
{
    class MatrixEdit
    {
        public static void NumbersBelowZeroToPower(int[,] numbers, out int[,] processedArray)
        {
            processedArray = new int[numbers.GetLength(0), numbers.GetLength(1)];
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    processedArray[i, j] = numbers[i, j];
                    if (numbers[i, j] < 0)
                    {
                        processedArray[i, j] = (int)Math.Pow(numbers[i, j], 2);
                    }
                }
            }
        }
        public static void Fill(int numbersCount, out int[,] processedArray)
        {
            int[,] numbersArray = new int[numbersCount, numbersCount];
            Random randomNumber = new Random();
            for (int i = 0; i < numbersArray.GetLength(0); i++)
            {
                for (int j = 0; j < numbersArray.GetLength(1); j++)
                {
                    numbersArray[i, j] = randomNumber.Next(-50, 50);
                }
            }
            NumbersBelowZeroToPower(numbersArray, out processedArray);
        }
        public static void SaveMatrix(string path, int[,] matrix)
        {
            using (StreamWriter save = new StreamWriter(path))
            {
                save.WriteLine(matrix.GetLength(0));
                save.WriteLine(matrix.GetLength(1));
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        save.WriteLine(matrix[i, j]);
                    }

                }
            }
        }
        public static void OpenArray(string path, out int[,] savedArray)
        {
            using (StreamReader open = new StreamReader(path))
            {
                int arrayLenght = Convert.ToInt32(open.ReadLine());
                int arrayHeight = Convert.ToInt32(open.ReadLine());
                savedArray = new int[arrayLenght, arrayHeight];
                for (int i = 0; i < savedArray.GetLength(0); i++)
                {
                    for (int j = 0; j < savedArray.GetLength(1); j++)
                    {
                        savedArray[i, j] = Convert.ToInt32(open.ReadLine());
                    }
                }
            }
        }
    }
}

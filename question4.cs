using System;

namespace SortingAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] sampleArray = { 5, 2, 9, 1, 5, 6 };

            
            ISorter bubbleSorter = new Bubble();
            Console.WriteLine("Bubble Sort Örneği:");
            Console.WriteLine("Orijinal Dizi: " + ArrayToString(sampleArray));
            bubbleSorter.Execute(sampleArray);
            Console.WriteLine("Sıralı Dizi: " + ArrayToString(sampleArray));
            Console.WriteLine();

            ISorter quickSorter = new Quick();
            Console.WriteLine("Quick Sort Örneği:");
            Console.WriteLine("Orijinal Dizi: " + ArrayToString(sampleArray));
            quickSorter.Execute(sampleArray);
            Console.WriteLine("Sıralı Dizi: " + ArrayToString(sampleArray));

            Console.ReadLine();
        }

        static string ArrayToString(int[] array)
        {
            return "[" + string.Join(", ", array) + "]";
        }
    }

    
    public interface ISorter
    {
        string Description { get; }
        void Execute(int[] array);
    }


    public class Bubble : ISorter
    {
        public string Description => "Bubble Sort Sıralama Algoritması";

        public void Execute(int[] array)
        {
            int n = array.Length;
            int temp;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                     
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }

    public class Quick : ISorter
    {
        public string Description => "Quick Sort Sıralama Algoritması";

        public void Execute(int[] array)
        {
            Sort(0, array.Length - 1, array);
        }

        private void Sort(int leftValue, int rightValue, int[] array)
        {
            if (leftValue < rightValue)
            {
                int pivotIndex = Partition(leftValue, rightValue, array);

                Sort(leftValue, pivotIndex - 1, array);
                Sort(pivotIndex + 1, rightValue, array);
            }
        }

        private int Partition(int leftValue, int rightValue, int[] array)
        {
            int pivotValue = array[rightValue];
            int i = leftValue - 1;

            for (int j = leftValue; j < rightValue; j++)
            {
                if (array[j] < pivotValue)
                {
                    i++;

                   
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

     
            int tempSwap = array[i + 1];
            array[i + 1] = array[rightValue];
            array[rightValue] = tempSwap;

            return i + 1;
        }
    }
}

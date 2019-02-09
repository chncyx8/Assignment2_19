using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2_19
{
    class Program
    {
        static void Main(string[] args)
        {
            // left rotation
            Console.WriteLine("Left Rotation");
            int d = 4;
            int[] a = { 1, 2, 3, 4, 5 };
            int[] r = rotLeft(a, d);
            displayArray(r);

            // Maximum toys
            Console.WriteLine("\n\nMaximum toys");
            int k = 50;
            int[] prices = { 1, 12, 5, 111, 200, 1000, 10 };
            Console.WriteLine(maximumToys(prices, k));

            // Balanced sums
            Console.WriteLine("\n\nBalanced sums");
            List<int> arr = new List<int> { 1, 2, 3 };
            Console.WriteLine(balancedSums(arr));

            // Missing numbers
            Console.WriteLine("\n\nMissing numbers");
            int[] arr1 = { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206 };
            int[] brr = { 203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204 };
            int[] r2 = missingNumbers(arr1, brr);
            displayArray(r2);

            // grading students
            Console.WriteLine("\n\nGrading students");
            int[] grades = { 73, 67, 38, 33 };
            int[] r3 = gradingStudents(grades);
            displayArray(r3);

            // find the median
            Console.WriteLine("\n\nFind the median");
            int[] arr2 = { 0, 1, 2, 4, 6, 5, 3 };
            Console.WriteLine(findMedian(arr2));

            // closest numbers
            Console.WriteLine("\n\nClosest numbers");
            int[] arr3 = { 5, 4, 3, 2 };
            int[] r4 = closestNumbers(arr3);
            displayArray(r4);

            // Day of programmer
            Console.WriteLine("\n\nDay of Programmer");
            int year = 2017;
            Console.WriteLine(dayOfProgrammer(year));

            Console.WriteLine("Press any key to exit..");
            Console.ReadKey(true);
        }

        static void displayArray(int[] arr)
        {
            try
            {
                Console.WriteLine();
                foreach (int n in arr)
                {
                    Console.Write(n + " ");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured. Please try again with valid inputs.");
            }
        }

        static int[] rotLeft(int[] a, int d)
        {
            int[] b = new int[a.Length];
            try
            {               
                int index;
                int length = a.Length;
                int place;
                for (int i = 0; i < length; i++)
                {
                    index = i - d;
                    place = length + index;
                    if (index >= 0)
                    {
                        b[index] = a[i];
                    }
                    else
                    {
                        b[place] = a[i];
                    }
                }                
            }
            catch
            {
                Console.WriteLine("Exception occured while computing rotleft()");
            }
            return b;

        }
        static int maximumToys(int[] prices, int k)
        {
            int num = 0;
            int total = 0;
            try
            {               
                prices = SelectionSort(prices);
                foreach (int i in prices)
                {
                    total += i;
                    if (total < k)
                        num++;
                    else
                        break;
                }               
            }
            catch
            {
                Console.WriteLine("Exception occured while computing maximumToys()");
            }
            return num;

        }
        static String balancedSums(List<int> arr)
        {
            try
            {
                int j = arr.Count - 1;
                int i = 0, suml = 0, sumr = 0;
                while (i < arr.Count && j >= 0)
                {
                    if (suml == sumr && ((i - j) == 0))
                    {
                        return "YES";
                    }
                    else if (suml < sumr)
                    {
                        suml += arr[i++];
                    }
                    else
                    {
                        sumr += arr[j--];
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing balancedSum()");
            }

            return "NO";

        }
        // Complete the missingNumbers function below.
        static int[] missingNumbers(int[] arr, int[] brr)
        {
            {
                int min = brr[0], max = brr[0], diff = 100;
                int[] crr = new int[1];

                var listA = new List<int>(arr);
                var listB = new List<int>(brr);

                foreach (int i in brr)
                {
                    if (i > max)
                    {
                        max = i;
                    }
                    if (i < min)
                    {
                        min = i;
                    }
                }

                diff = max - min;

                if (diff <= 100)
                {

                    for (int i = 0; i < listA.Count; i++)
                    {
                        if (listB.Remove(listA[i]))
                        {
                            listA.RemoveAt(i--);
                        }
                    }
                    crr = listB.Distinct().ToArray();
                    crr = SelectionSort(crr);
                    //}
                    return crr;
                }
                else
                {
                    Console.WriteLine("The difference between max and min elements of original array is greater than 100");
                    return null;
                }
            }
        }


        // Complete the gradingStudents function below.
        static int[] gradingStudents(int[] grades)
        {
            return new int[] { };
        }

        // Complete the findMedian function below.
        static int findMedian(int[] arr)
        {
            return 0;
        }

        // Complete the closestNumbers function below.
        static int[] closestNumbers(int[] arr)
        {            
            int diff = int.MaxValue;
            List<int> b = new List<int>();
            arr = SelectionSort(arr);
            for (int i = 1; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i] - arr[i - 1]) < diff)
                {
                    b.Clear();
                    diff = Math.Abs(arr[i] - arr[i - 1]);
                }
                if (Math.Abs(arr[i] - arr[i - 1]) == diff)
                {
                    b.Add(arr[i - 1]);
                    b.Add(arr[i]);
                }
            }
            return b.ToArray();
        }

        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {
            bool isLeap = false;
            string date;
            double month = 0;
            int day = 0, days = 0;
            int[] monthsLeap = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] months = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (year == 1918)
            {
                month = Math.Ceiling((double)(256) / (double)(30));

                for (int i = 0; i < month - 1; i++)
                {
                    days += months[i];
                }

                day = 256 - days + 13;
            }
            else
            {
                if ((year > 1699) && (year < 1918))
                {
                    if ((year % 4) == 0)
                    {
                        isLeap = true;
                    }
                }
                else if ((year > 1918) && (year < 2701))
                {
                    if (((year % 400) == 0) || (((year % 4) == 0) && ((year % 100) != 0)))
                    {
                        isLeap = true;
                    }
                }
                else
                {
                    return "Invalid year entered. Please enter year between 1700 and 2700.";
                }
                if (isLeap)
                {
                    month = Math.Ceiling((double)(256) / (double)(30));
                    for (int i = 0; i < month - 1; i++)
                    {
                        days += monthsLeap[i];
                    }
                    day = 256 - days;
                }
                else
                {
                    month = Math.Ceiling((double)(256) / (double)(30));
                    for (int i = 0; i < month - 1; i++)
                    {
                        days += months[i];
                    }
                    day = 256 - days;
                }
            }

            date = Convert.ToString(day) + ".0" + Convert.ToString(month) + "." + Convert.ToString(year);
            return date;
        }
        static int[] SelectionSort(int[] arr2)
        {
            int min, temp;

            for (int i = 0; i < arr2.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < arr2.Length; j++)
                {
                    if (arr2[j] < arr2[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    temp = arr2[i];
                    arr2[i] = arr2[min];
                    arr2[min] = temp;
                }
            }
            return arr2;
        }
    }
}

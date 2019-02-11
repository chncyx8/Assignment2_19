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

            Console.WriteLine("\n\nPress any key to exit..");
            Console.ReadKey(true);

            /*
             * Self-reflection-Yuxuan Cen: From this assignment, I started to realize
             * that there are many ways to solve a computational problem, each way may
             * lead to a completly different efficiency. When dealing with large amount
             * of data, efficiency becomes extremely importan. Because of that,  we 
             * should keep thinking and try our best to figure out better solutions when
             * solving computational problems.
            */

            /*
             * Self-reflection-Nikky Parashar: It was a good learning, spanning from 
             * handling array to list and using methods/libraries associated with them.
             * Eventhough this assigment covers basics of the programming, the wonders 
             * that can be done in terms of efficiency, logic and modularity is at par.
             * It would be more fun to deal with different and distinct libraries in 
             * upcoming assignments.
            */
        } //end of Main method

        static void displayArray(int[] arr)
        {
            try //execute the successfully if the incoming parameter is an array
            {
                foreach (int n in arr)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
            catch //throw exception if the incoming parameter is not an array
            {
                Console.WriteLine("Exception occured. Please try again with valid inputs.");
            }
        } //end of method: displayArray

        // Complete the rotLeft function below.
        static int[] rotLeft(int[] a, int d)
        {
                int[] b = new int[a.Length];                         
                int index;
                int length = a.Length;
                int place;
                if (d >= 0 && d <= length)  // d should not lower than 0 and greater than the length of the array.
                {
                    for (int i = 0; i < length; i++) // Use for loop to loop through the array.
                    {
                        index = i - d;  
                        place = length + index; // Use place and index to locate the elements.
                        if (index >= 0)
                        {
                            b[index] = a[i]; // Replace the index element by the current element.
                        }
                        else
                        {
                            b[place] = a[i]; // Replace the place element by the current element.
                        }
                    }
                    return b; // Return the new array.
                }
                else
                {
                   return null;               
                }                                
        } //end of method: rotLeft

        // Complete the maximumToys function below.
        static int maximumToys(int[] prices, int k)
        {
            int num = 0;
            int total = 0;                       
            prices = SelectionSort(prices);  // Call the SelectionSort method to sort the array.
            if (k >= 0) // k must greater or equal to 0.
            {
                foreach (int i in prices)  //Loop through the elements in the array.
                {
                    total += i; // Add up the elements in the sorted array.
                    if (total <= k) // The total amount in the array must lower than k.
                        num++;
                    else
                        break;
                }
                return num; // Return the maximum toys.
            }
            else
            {               
                Console.WriteLine("Exception occured. Please try again with valid inputs.");
                return 0;
            }
        } //end of method: maximumToys

        // Complete the balancedSums function below.
        static String balancedSums(List<int> arr)
        {            
                int j = arr.Count - 1;
                int i = 0, suml = 0, sumr = 0;  // Define the sum of the left side and the sum of the right side.
                while (i < arr.Count && j >= 0)
                {
                    if (suml == sumr && ((i - j) == 0)) // If the sum of left side and the sum of the right side, return YES.
                    {
                        return "YES"; 
                    }
                    else if (suml < sumr) // If the sum of left side is smaller than the sum of the right side.
                {
                        suml += arr[i++]; // Add more elements on the left side. 
                }
                    else // If the sum of right side is smaller than the sum of the left side.
                    {
                        sumr += arr[j--]; // Add more elements on the right side. 
                }
                }            
                return "NO";  // Else, return NO.
        } //end of method: balancedSums

        // Complete the missingNumbers function below.
        static int[] missingNumbers(int[] arr, int[] brr)
        {
            {
                int min = brr[0], max = brr[0], diff = 0; //initialize min and max elements of the arrays and difference between them

                if (arr.Length > brr.Length) //length of original array must be greater than length of missing array
                {
                    Console.WriteLine("The number of elements in missing array is greater than original array.");
                    return null; //returns nothing as the condition is not satisfied and throws as exception later
                }

                var listA = new List<int>(arr); //create list of the elements of missing array
                var listB = new List<int>(brr); //create list of the elements of original array

                foreach (int i in brr) //loop through each element of original array
                {
                    if (i > max) //current element of array must be greater than the current maximum value
                    {
                        max = i; //replace current maximum value with current element of original array
                    }
                    if (i < min) //current element of array must be less than the current minimum value
                    {
                        min = i; //replace current minimum value with current element of original array
                    }
                }

                diff = max - min; //store the difference between maximum and minimum values of original array

                if (diff <= 100) //difference must be less than or equal to 100
                {

                    for (int i = 0; i < listA.Count; i++) //loop through length of list
                    {
                        if (listB.Remove(listA[i])) //if element is found in both lists and is removed from list B (original list)
                        {
                            listA.RemoveAt(i--); //remove the element from list A at the previous position
                        }
                    }
                    int[] crr = listB.Distinct().ToArray(); //convert the list into array containing distinct values
                    crr = SelectionSort(crr); //sort the array in ascending order using Selection Sort method
                    //}
                    return crr; //return sorted array containing missing values
                }
                else
                {
                    Console.WriteLine("The difference between max and min elements of original array is greater than 100");
                    return null; //returns nothing as the condition is not satisfied and throws as exception later
                }
            }
        } //end of method: missingNumbers


        // Complete the gradingStudents function below.
        static int[] gradingStudents(int[] grades)
        {
            int[] r3 = new int[grades.Length]; //creates an array of same length as incoming array
            for (int i = 0; i < grades.Length; i++) //loop through all the elements of the array
            {
                if (grades[i] > 100) //cuurent element of the array must be greater than 100
                {
                    Console.WriteLine("Please enter grades between 0 and 100");
                    return null; //returns nothing as the condition is not satisfied and throws as exception later
                }
                else if ((grades[i] % 5 > 2) && !(grades[i] < 38)) //current element must have remainder greater than 2 on dividing by 5 and is not less than 38
                {
                    r3[i] = grades[i] + (5 - grades[i] % 5); //insert value in the resultant array after rounding it to next multiple of 5
                }
                else
                {
                    r3[i] = grades[i]; //insert value in the resultant array after rounding it to next multiple of 5
                }
            }
            return r3; //return resultant array with rounded values, wherever needed
        } //end of method: gradingStudents

        // Complete the findMedian function below.
        static int findMedian(int[] arr) 
        {
            int pos_med = 0; //intialize index of median in array 
            arr = SelectionSort(arr); //sort the array in ascending order using Selection Sort method

            pos_med = (arr.Length - 1) / 2; //store the index of median based on the middle value of the array

            return arr[pos_med]; //retunr median of the array

        } //end of method: findMedian

        // Complete the closestNumbers function below.
        static int[] closestNumbers(int[] arr)
        {            
            int diff = int.MaxValue; // Define the diff value.
            List<int> b = new List<int>(); // Use List to solve this problem.
            arr = SelectionSort(arr); // First sort the array using SelectionSort method.
            for (int i = 1; i < arr.Length; i++)  // loop through the elements in the array.
            {
                if (Math.Abs(arr[i] - arr[i - 1]) < diff) // If the difference between two adjacent numbers is lower than diff.
                {                   
                    diff = Math.Abs(arr[i] - arr[i - 1]); // The diff should equal to the difference between two adjacent values.
                }
                if (Math.Abs(arr[i] - arr[i - 1]) == diff) // If the difference between two adjacent values is equal to diff.
                {
                    b.Add(arr[i - 1]); // Add the adjacent values to List b.
                    b.Add(arr[i]);
                }
            }
            return b.ToArray(); // Return the new array.
        } //end of method: closestNumbers

        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {
            bool isLeap = false; //initialize value of year is leap or not to false
            string date;
            double month = 0;
            int day = 0, days = 0; //day id "dd" in "dd/mm/yyyy"; days is sum of days for dynamic number of months
            int[] monthsLeap = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; //array containing month's days in leap year
            int[] months = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; //array containing month'sdays in non-leap year

            if (year == 1918) //year must be 1918
            {
                month = Math.Ceiling((double)(256) / (double)(30)); //stores month

                for (int i = 0; i < month - 1; i++) //loops through January to previous month of stored month
                {
                    days += months[i]; //add number of days for each month
                }

                day = 256 - days + 13; //store day left after subtracting sum of days and 13 days (since 14th Feb was 32nd day of the year) from 256
            }
            else
            {
                if ((year > 1699) && (year < 1918)) //year must be between 1700 and 1918
                {
                    if ((year % 4) == 0) //check if entered year is a leap year as per julian calendar
                    {
                        isLeap = true; //set value of boolean isLeap to true
                    }
                }
                else if ((year > 1918) && (year < 2701)) //year must be between 1918 and 2700
                {
                    if (((year % 400) == 0) || (((year % 4) == 0) && ((year % 100) != 0))) //check if entered year is a leap year as per gregorian calendar
                    {
                        isLeap = true; //set value of boolean isLeap to true
                    }
                }
                else
                {
                    return "Invalid year entered. Please enter year between 1700 and 2700."; //year is outside range of 1700 and 2700
                }
                if (isLeap) //year is a leap year
                {
                    month = Math.Ceiling((double)(256) / (double)(30)); //stores month

                    for (int i = 0; i < month - 1; i++) //loops through January to previous month of stored month
                    {
                        days += monthsLeap[i]; //add number of days for each month of leap year array
                    }
                    day = 256 - days; //store day left after subtracting sum of days from 256
                }
                else //year is not a leap year
                {
                    month = Math.Ceiling((double)(256) / (double)(30)); //stores month

                    for (int i = 0; i < month - 1; i++) //loops through January to previous month of stored month
                    {
                        days += months[i]; //add number of days for each month of leap year array
                    }
                    day = 256 - days; //store day left after subtracting sum of days from 256
                }
            }

            date = Convert.ToString(day) + ".0" + Convert.ToString(month) + "." + Convert.ToString(year); // store date in format of dd.mm.yyyy
            return date; //returns date for 256th day of the year
        } //end of method: dayOfProgrammer

        //sorts array in ascending order using Selection Sort method
        static int[] SelectionSort(int[] arr2) 
        {
            int min, temp;

            for (int i = 0; i < arr2.Length - 1; i++) //loop through length of array
            {
                min = i; //initialize minimum value position to current index of array
                for (int j = i + 1; j < arr2.Length; j++) //loop through length of array starting from 2nd position
                {
                    if (arr2[j] < arr2[min]) //cuurent element of inner loop must be less than element at minimum element's position
                    {
                        min = j; //replace minimum value position to current index of array of inner loop
                    }
                }
                if (min != i) //minimum value position must not be equal to current index of array of outer loop
                {
                    temp = arr2[i]; //store element at current index of array of outer loop in temporary variable
                    arr2[i] = arr2[min]; //replace element at current index of array of outer loop with element at minimum element's position
                    arr2[min] = temp; //replace element at minimum element's position with temporary variable
                }
            }
            return arr2; //return sorted array in ascending order
        } //end of method: SelectionSort
    } //end of class: Program
} //end of namespace: Assignment2_19

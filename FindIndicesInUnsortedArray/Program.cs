using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given an array of integers, write a method to find indices m and n such that if
// you sorted elements m through n, the entire array would be sorted. 
// Minimize n - m

// Approach
// left: 1 2 4 7 10 11
// right: 6 7 16 18 19
// which leaves us with middle: 7 12

// Now find the last value in the left side that is greater than min(middle) => m
// Find the last value in the right side that is smaller than max(middle) => n
namespace FindIndicesInUnsortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 };

            Console.WriteLine("Test case 1");
            findUnsortedSequence(input1);

            Console.WriteLine("Test case 2");
            int[] input2 = {1, 2, 4, 3, 5, 8, 7, 9, 10};
            findUnsortedSequence(input2);
        }

        static int findEndOfLeftSubSequence(int[] arr)
        {
            int endOfLeft = 0;

            while ((endOfLeft + 1) < arr.Length)
            {
                if (arr[endOfLeft] > arr[endOfLeft + 1])
                {
                    break;
                }

                endOfLeft++;
            }

            return endOfLeft;
        }

        static int findStartOfRightSubSequence(int[] arr)
        {
            int startOfRight = arr.Length - 1;

            while ((startOfRight - 1) >= 0)
            {
                if (arr[startOfRight] < arr[startOfRight - 1])
                {
                    break;
                }

                startOfRight--;
            }

            return startOfRight;
        }

        static void findUnsortedSequence(int[] arr)
        {
            int end_left = findEndOfLeftSubSequence(arr);

            int start_right = findStartOfRightSubSequence(arr);

            int min_middle = end_left + 1;

            int max_middle = start_right - 1;

            int leftIndex = end_left;

            while ((leftIndex >= 0) && (arr[leftIndex] >= arr[min_middle]))
            {
                leftIndex--;
            }
            // when you are out of the loop arr[leftIndex] < arr[min_middle]
            // but you want the value that is greater than min_middle so increment
            leftIndex++;

            int rightIndex = start_right;

            while ((rightIndex < arr.Length) && (arr[rightIndex] <= arr[max_middle]))
            {
                rightIndex++;
            }
            // when you are out of the loop arr[rightIndex] > arr[max_middle]
            // but you want the value that is greater than max_middle so decrement
            rightIndex--;

            Console.WriteLine("m is {0} and n is {1}", leftIndex, rightIndex);
        }

    }
}

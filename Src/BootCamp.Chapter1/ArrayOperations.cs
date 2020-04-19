using System;

namespace BootCamp.Chapter1
{
    public static class ArrayOperations
    {
        public static void Sort(int[] array)
        {
            if (IsNullOrEmptyArray(array))
                return;

            //For each index of the array...
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)  
                {
                    //Check if each following index is smaller.
                    if (array[j] < array[i])
                    {
                        //Swap if so.
                        Swap(array, i, j);
                    }
                }
            }
            
            return;
        }

        public static void Reverse(int[] array)
        {
            if (IsNullOrEmptyArray(array))
                return;
            
            int temp;

            // only need to iterrate through half of the array to reverse.
            for (int i = 0; i < array.Length / 2; i++)
            {
                // Set temp to equal first element
                temp = array[i];
                // set first element to equal last element
                array[i] = array[(array.Length - 1) - i];
                // set last element to equal temp, or first element
                array[(array.Length - 1) - i] = temp;
                // increment i, meaning next loop will swap second and second-last elements etc.
            }
            WriteArray(array);
        }

        public static int[] RemoveLast(int[] array)
        {
            if (array == null)
                return null;

            array = RemoveAt(array, array.Length - 1);

            return array;
        }

        public static int[] RemoveFirst(int[] array)
        {
            array = RemoveAt(array, 0);

            return array;
        }

        public static int[] RemoveAt(int[] array, int index)
        {
            if (IsNullOrEmptyArray(array) || index < 0 || index > array.Length - 1)
                return array;

            // Create new array 1 element smaller than original
            var removeArray = new int[array.Length - 1];

            for (var i = 0; i < array.Length - 1; i++)
            {
                if (i == index)
                    break;
                // Add elements to the new array until we reach index to be removed.
                removeArray[i] = array[i];
            }
            for (var i = index; i < array.Length - 1; i++)
            {
                // Keep adding elements, skipping the specified index.
                removeArray[i] = array[i + 1];
            }

            return removeArray;
        }

        public static int[] InsertFirst(int[] array, int number)
        {
            array = InsertAt(array, number, 0);

            return array;
        }

        public static int[] InsertLast(int[] array, int number)
        {
            if (IsNullOrEmptyArray(array))             
                return new[] { number };

            array = InsertAt(array, number, array.Length);

            return array;
        }

        public static int[] InsertAt(int[] array, int number, int index)
        {
            if (IsNullOrEmptyArray(array) && (index != 0 && index != array.Length))
                return array;

            if (IsNullOrEmptyArray(array))
                return new[] { number };

            // Create index 1 size bigger than original.
            var insertArray = new int[array.Length + 1];

            for (var i = 0; i < index; i++)
            {
                // Add elements to the new array until we reach the index to be added.
                insertArray[i] = array[i];
            }

            // Add the new specified element.
            insertArray[index] = number;

            for (var i = index; i < array.Length; i++)
            {
                // continue adding elements from the original array, but 1 index further along in the new one.
                insertArray[i + 1] = array[i];
            }
            return insertArray;
        }



        // used to test solutions in console and see what code was outputting.
        public static void WriteArray(int[] array)
        {
            foreach (var number in array)
                Console.Write($"{number} ");
            Console.WriteLine();
        }

        public static bool IsNullOrEmptyArray(int[] array)     
        {
            if (array == null || array.Length == 0)
                return true;
            return false;
        }

        public static void Swap(int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

    }
}

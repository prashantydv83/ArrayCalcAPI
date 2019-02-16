using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArrayCalcAPI.Service
{
    public static class ArrayOperations
    {
        //
        public static void ReverseArray(int[] arraylist)
        {
            //no operation if array is empty or has a single item
            if (arraylist.Length < 2)
            {
                return;
            }

            int lowerbound = 0;
            int upperbound = arraylist.Length - 1;

            //interchange items to reverse the arraylist
            while (lowerbound < upperbound)
            {
                var temp = arraylist[lowerbound];
                arraylist[lowerbound] = arraylist[upperbound];
                arraylist[upperbound] = temp;
                lowerbound++;
                upperbound--;
            }
        }

        public static int[] DeleteAtPosition(int deletePosition, int[] arraylist)
        {
            List<int> sortedList = new List<int>();
            
            //subtracting 1 from deletePosition as Arrays are zero index based 
            deletePosition--;

            //no operation if deletePosition is out of range from arraylist length
            if (deletePosition >= arraylist.Length)
            {
                return arraylist;
            }

            //Adding array items to a new list except deleteposition item 
            for (int id = 0; id < arraylist.Length; id++)
            {
                if (id != deletePosition)
                {
                    sortedList.Add(arraylist[id]);
                }
            }
            return sortedList.ToArray();
        }
    }
}
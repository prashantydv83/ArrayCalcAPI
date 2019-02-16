using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayCalcContracts;

namespace ArrayCalcService
{
    /// <summary>
    /// Array Operations Class
    /// </summary>
    public class ArrayOperations : IArrayOperations
    {
        /// <summary>
        /// Reverses an input array.
        /// </summary>
        /// <param name="inputArray">arraylist</param>
        public void ReverseArray(int[] arraylist)
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

        /// <summary>
        /// Removes an element from input array at specified position.
        /// </summary>
        /// <param name="deletePosition">deletePosition</param>
        /// <param name="inputArray">inputArray</param>
        /// <returns>Modified Array</returns>
        public int[] DeleteAtPosition(int deletePosition, int[] arraylist)
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

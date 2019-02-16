using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayCalcContracts
{
    public interface IArrayOperations
    {
        void ReverseArray(int[] arraylist);
        int[] DeleteAtPosition(int deletePosition, int[] arraylist);
    }
}

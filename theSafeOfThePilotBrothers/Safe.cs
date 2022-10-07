using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theSafeOfThePilotBrothers
{
    public class Safe
    {
        int[,] _array;
        public int[,] Array { get { return _array; } }
        private int _n;
        public int Lenght { get { return _n; } }


        public Safe(int n)
        {
            _array = GetArray(n);
            _n = n;
        }

        private int[,] GetArray(int n)
        {
            int[,] sbytes = new int[n,n];

            Random rnd = new Random();

            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < n-1; j++)
                {
                    sbytes[i, j] = rnd.Next(0, 2);
                }
            }

            return sbytes;
        }

        public void ClickOnelement(int indexI, int indexJ)
        {
            // Само число
            ChangeValue(indexI, indexJ);

            // По вертикали после числа
            for (int i = indexI; i < _array.Length-1; i++)
            {
                ChangeValue(i, indexJ);
            }

            // По вертикали после числа
            for (int i = indexI - 1; i >= 0; i--)
            {
                ChangeValue(i, indexJ);
            }

            // По горизонтали
            for (int j = indexJ; j < _array.Length-1; j++)
            {
                ChangeValue(indexI, j);
            }
        }

        public void ChangeValue(int indexI, int indexJ)
        {
            if (_array[indexI, indexJ] == 0)
            {
                _array[indexI, indexJ] = 1;
                return;
            }
            _array[indexI, indexJ] = 0;
        }
    }
}

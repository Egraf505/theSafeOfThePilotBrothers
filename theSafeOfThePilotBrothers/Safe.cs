using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace theSafeOfThePilotBrothers
{
    public class Safe
    {
        Clasp[,] _array;
        public Clasp[,] Array { get { return _array; } }

        private int _n;
        public int Length { get { return _n; } }

        public event ChangeButtonEvent ChangeButton;
        public delegate void ChangeButtonEvent(int i, int j);


        public Safe(int n, ChangeButtonEvent changeButtonEvent)
        {
            _array = GetArray(n);
            _n = n;
            ChangeButton += changeButtonEvent;
        }

        private Clasp[,] GetArray(int n)
        {
            Clasp[,] clasps = new Clasp[n,n];

            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    clasps[i, j] = new Clasp(rnd.Next(0, 2), new Button());
                }
            }

            return clasps;
        }

        public void ClickOnelement(int indexI, int indexJ)
        {
            // Само число
            ChangeValue(indexI, indexJ, _array[indexI,indexJ].Button);


            // По вертикали после числа
            for (int i = indexI; i < Length; i++)
            {
                ChangeValue(i, indexJ, _array[i, indexJ].Button);
            }

            // По вертикали после числа
            for (int i = indexI - 1; i >= 0; i--)
            {
                ChangeValue(i, indexJ, _array[i, indexJ].Button);
            }

            // По горизонтали после числа
            for (int j = indexJ; j < Length; j++)
            {
                ChangeValue(indexI, j, _array[indexI, j].Button);
            }

            // По горизонтали перед числом
            for (int j = indexJ - 1; j >= 0; j--)
            {
                ChangeValue(indexI,j, _array[indexI, j].Button);
            }
        }

        public void ChangeValue(int indexI, int indexJ, Button button)
        {
            if (_array[indexI, indexJ].Num == 0)
            {
                _array[indexI, indexJ].Num = 1;
                ChangeButton.Invoke(indexI, indexJ);
                return;
            }
            _array[indexI, indexJ].Num = 0;
            ChangeButton.Invoke(indexI, indexJ);
        }

        public bool CheckArray()
        {         
            int countArray = 0;

            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    countArray += _array[i, j].Num;
                }
            }

            if (countArray == 0 || countArray == (_array.Length * _array.Length))
            {
                return true;
            }

            return false;
        }
    }
}

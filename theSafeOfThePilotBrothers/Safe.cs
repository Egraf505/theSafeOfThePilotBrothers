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
        public int Lenght { get { return _n; } }
        public event ChangeButtonEvent ChangeButton;
        public delegate void ChangeButtonEvent(Button button);


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

            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < n-1; j++)
                {
                    clasps[i, j] = new Clasp(rnd.Next(0, 2), new Button());
                }
            }

            return clasps;
        }

        public void ClickOnelement(int indexI, int indexJ, Button button)
        {
            // Само число
            ChangeValue(indexI, indexJ, button);


            // По вертикали после числа
            for (int i = indexI; i < _array.Length-1; i++)
            {
                ChangeValue(i, indexJ, button);
            }

            // По вертикали после числа
            for (int i = indexI - 1; i >= 0; i--)
            {
                ChangeValue(i, indexJ, button);
            }

            // По горизонтали после числа
            for (int j = indexJ; j < _array.Length-1; j++)
            {
                ChangeValue(indexI, j, button);
            }

            // По горизонтали перед числом
            for (int j = indexJ - 1; j >= 0; j--)
            {
                ChangeValue(indexI,j, button);
            }
        }

        public void ChangeValue(int indexI, int indexJ, Button button)
        {
            if (_array[indexI, indexJ].Num == 0)
            {
                _array[indexI, indexJ].Num = 1;
                return;
            }
            _array[indexI, indexJ].Num = 0;
            ChangeButton.Invoke(button);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace theSafeOfThePilotBrothers
{
    public class Clasp
    {
        private int _num;
        public int Num { get { return _num; } set { _num = value; } }

        private Button _button;
        public Button Button { get { return _button; } }

        public Clasp(int num, Button button)
        {
            _num = num;
            _button = button;
        }
    }
}

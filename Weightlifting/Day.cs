using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;

namespace Weightlifting
{
    public class Day
    {
        string _action1_value;
        string _action2_value;
        string _action3_value;

        string _atm1;
        string _set1;
        string _atm2;
        string _set2;
        string _atm3;
        string _set3;
       


        public string atm1 {
            get { return _atm1; }
            set { _atm1 = value; }
        }
        public string set1
        {
            get { return _set1; }
            set { _set1 = value; }
        }
        public string atm2
        {
            get { return _atm2; }
            set { _atm2 = value; }
        }

        public string set2
        {
            get { return _set2; }
            set { _set2 = value; }
        }
        public string atm3
        {
            get { return _atm3; }
            set { _atm3 = value; }
        }
        public string set3
        {
            get { return _set3; }
            set { _set3 = value; }
        }

        public string action1_value
        {
            get { return _action1_value; }
            set { _action1_value = value; }
        }
        public string action2_value
        {
            get { return _action2_value; }
            set { _action2_value = value; }
        }
        public string action3_value
        {
            get { return _action3_value; }
            set { _action3_value = value; }
        }

       
       
        
    }
}

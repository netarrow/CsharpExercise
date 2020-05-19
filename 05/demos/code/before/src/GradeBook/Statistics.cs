using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook
{
    public class Statistics
    {
        public double Average { get; set; }
        public double Max { get; set; }
        public double Lowest { get; set; }
        public override string ToString()
        {

            return $"Average{ Average} , Max{Max}, Lowest {Lowest}";
        }

    }
}

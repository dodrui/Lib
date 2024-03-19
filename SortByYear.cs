using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba10
{
    public class SortByYear : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Aircraft p1 = x as Aircraft;
            Aircraft p2 = y as Aircraft;
            if (p1.ProductionYear < p2.ProductionYear) return -1;
            else
                if (p1.ProductionYear == p2.ProductionYear) return 0;
            else return 1;
        }
    }
}

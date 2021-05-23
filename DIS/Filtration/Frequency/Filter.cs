using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Filtration.Frequency
{
    public class Filter
    {
        public int x { get; set; }

        public int y { get; set; }

        public int r1 { get; set; }

        public int r2 { get; set; }

        public Filter() { }

        public Filter(int x, int y, int r1, int r2)
        {
            this.x = x;
            this.y = y;
            this.r1 = r1;
            this.r2 = r2;
        }

        public Filter(string x, string y, string r1, string r2)
        {
            this.x = Convert.ToInt32(x);
            this.y = Convert.ToInt32(y);
            this.r1 = Convert.ToInt32(r1);
            this.r2 = Convert.ToInt32(r2);
        }
    }
}

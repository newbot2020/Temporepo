using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace one2many.Models
{
    public class Studentaction
    {
        public int id { get; set; }
        public Result Results { get; set; }
        public Classinfo Classinfos { get; set; }
        public Student Students { get; set; }

    }
}

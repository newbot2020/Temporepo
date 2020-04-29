using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace one2many.Models
{
    public class Result
    {
        public int id { get; set; }
        [Required]
        public string term { get; set; }
        [Required]
        public int termresult { get; set; }
        [Required]
        public int meritpostion { get; set; }
        [Required]
        public int Studentid { get; set; }
        [ForeignKey("Studentid")]

        public Student Students { get; set; }

        public int Classinfoid { get; set; }
        [ForeignKey("Classinfoid")]
        public Classinfo Classinfo { get; set; }
    }

}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace one2many.Models
{
    public class Classinfo
    {
        public int id { get; set; }
        [Required] 
        public int Class { get; set; }
        
       

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using one2many.Data;

namespace one2many.Controllers
{
    public class StudentsactionController : Controller
    {
       private readonly one2manyContext _context;

       public StudentsactionController(one2manyContext context)
           {
                _context = context;
           }
       public IActionResult Index()
         {
            return View(_context.Studentaction.Include(c=>c.Classinfos).Include(c=>c.Results).Include(c=>c.Students).ToList());
         }


    }
}
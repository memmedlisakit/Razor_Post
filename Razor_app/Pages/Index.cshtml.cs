using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_app.Models;

namespace Razor_app.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserBdContext _db;
        public IndexModel(UserBdContext db)
        {
            _db = db;
             Employee = new Employee();
             Employees = new List<Employee>();
        }


        [BindProperty]
        public Employee Employee { get; set; }

        public List<Employee> Employees { get; set; }

        public string[] Positions = new string[] { "Web Developer", "Desktop Developer", "Mobile Developer" };

        public async Task OnGet()
        {
            this.Employees = await _db.Employees.ToListAsync();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        { 
            await _db.Employees.AddAsync(this.Employee);
            await _db.SaveChangesAsync();
            Employees = await _db.Employees.ToListAsync();
            return Page();
        }
    }
}

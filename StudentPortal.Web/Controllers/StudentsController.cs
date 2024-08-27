using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentsController(ApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public async Task <IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                name = viewModel.name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subcribed = viewModel.Subcribed,
            };
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> StudentList()
        {
            var  students = await _dbContext.Students.ToListAsync();

            return View(students);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await _dbContext.Students.FindAsync(viewModel.id);

            if(student is not null) {
                student.name = viewModel.name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;    
                student.Subcribed = viewModel.Subcribed;

                await _dbContext.SaveChangesAsync();
                
            }
            return RedirectToAction("StudentList", "Students");
        }   
    }
}

using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;
using StudentProject.Services;

namespace StudentProject.Controllers
{
    public class StudentController : ControllerBase
    {
        IStudentService _studentService;
        public StudentController(IStudentService service)
        {
            _studentService = service;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = _studentService.GetStudentsList();
                if (students == null) return NotFound();
                return Ok(students);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/Rollno")]
        public IActionResult GetStudentsByRollno(string Rollno)
        {
            try
            {
                var students = _studentService.GetStudentDetailsByRollno(Rollno);
                if (students == null) return NotFound();
                return Ok(students);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveStudentDetails(Student employeeModel)
        {
            try
            {
                var model = _studentService.SaveStudentDetails(employeeModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteStudent(string Rollno)
        {
            try
            {
                var model = _studentService.DeleteStudent(Rollno);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}

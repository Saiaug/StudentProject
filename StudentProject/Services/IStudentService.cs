using StudentProject.Models;
using StudentProject.ViewModels;

namespace StudentProject.Services
{
    public interface IStudentService
    {
        List<Student> GetStudentsList();

        Student GetStudentDetailsByRollno(string Rollno);

        ResponseModel SaveStudentDetails(Student studentModel);

       // ResponseModel DeleteStudent(string Rollno);
    }
}

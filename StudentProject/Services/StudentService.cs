﻿using StudentProject.Models;
using StudentProject.ViewModels;
using System;

namespace StudentProject.Services
{
    public class StudentService : IStudentService
    {
        private StudentContext _context;
        public StudentService(StudentContext context)
        {
            _context = context;
        }

        public List<Student> GetStudentsList()
        {
            List<Student> studentList;
            try
            {
                studentList = _context.Set<Student>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return studentList;
        }


        public Student GetStudentDetailsByRollno(string Rollno)
        {
            Student stu;
            try
            {
                stu = _context.Find<Student>(Rollno);
            }
            catch (Exception)
            {
                throw;
            }
            return stu;
        }
        public ResponseModel SaveStudentDetails(Student studentModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Student _temp = GetStudentDetailsByRollno(studentModel.Rollno);
                //Student _temp = GetStudentsList();
                if (_temp != null)
                {
                    //_temp.Rollno = studentModel.Rollno;
                    _temp.Class = studentModel.Class;
                    _temp.StudentFirstName = studentModel.StudentFirstName;
                    _temp.StudentLastName = studentModel.StudentLastName;
                    _temp.Section = studentModel.Section;
                    _context.Update<Student>(_temp);
                    model.Messsage = "Student Details Updated Successfully";
                }
                else
                {
                    _context.Add<Student>(studentModel);
                    model.Messsage = "Student Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel DeleteStudent(string Rollno)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Student _temp = GetStudentDetailsByRollno(Rollno);
                if (_temp != null)
                {
                    _context.Remove<Student>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Student Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Student Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}

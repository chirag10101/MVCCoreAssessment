using Microsoft.AspNetCore.Mvc;
using MVCCoreAssessment.Models;
using System.Collections;
using System.Collections.Generic;

namespace MVCCoreAssessment.Controllers
{
    public class BatchController : Controller
    {
        static List<Student> students = null;
        public BatchController()
        {
            if (students == null)
            {
                students = new List<Student>()
                {
                new Student() { Id =1, Name="Deepak", Batch="B001", DateOfBirth= DateTime.Parse("20/10/2003"), Address = "New Delhi" },

                new Student() { Id =2, Name="Pawan", Batch="B001",DateOfBirth= DateTime.Parse("20/10/2003"), Address = "Noida" },

                new Student() { Id =3, Name="Deepti", Batch="B002", DateOfBirth= DateTime.Parse("20/10/2003"), Address = "Gurgaon" }
                };
            }
        }

        public static bool IsIdExist(int id)
        {
            if (students.Where(x => x.Id == id).FirstOrDefault() != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        public IActionResult Index()
        {
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                students.Add(student);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var student = students.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.msg = "There is no record with this ID";
                    return View();
                }
                else
                    return View(student);
            }
        }
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var student = students.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.msg = "There is no record wth this ID";
                    return View();
                }
                else
                    return View(student);
            }


        }
        [HttpPost]
        public IActionResult Delete(Student student, int id)
        {
            var temp = students.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
                students.Remove(temp);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var student = students.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(student);
            }

        }

        [HttpPost]
        public IActionResult Edit(Student student, int id)
        {
            var temp = students.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
            {
                foreach (Student stu in students)
                {
                    if (stu.Id == temp.Id)
                    {
                        stu.Batch = student.Batch;
                        stu.Address = student.Address;
                        stu.DateOfBirth = student.DateOfBirth;
                        stu.Name = student.Name;
                        break;
                    }


                }
            }
            return RedirectToAction("Index");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IITS_Programming_Club.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IITS_Programming_Club.Controllers
{
    public class StudentController : Controller
    {
        public DataContext db;
        public string cheakid;
        public string student_status,active_status,student_division,block_reason;
        public StudentController(DataContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            string cheak = "on";
            var active = db.student_info.Where(a => a.active_status == cheak).FirstOrDefault();
            if (active == null && HttpContext.Session.GetString("studentid") == null)
            {
                return View();
            }
            else if (HttpContext.Session.GetString("studentid") == null)
            {
                return RedirectToAction("Logout");
            }
            else
            {
                return RedirectToAction("StudentWork");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(StudentInfo af)
        {
            string msgg;
            string cheak = "on";
            var account = db.student_info.Where(a => a.student_id == af.student_id).FirstOrDefault();
            if (account != null)
            {
                string active_status = "Active";
                if (account.student_status == active_status)
                {
                    if (account.student_pass == af.student_pass)
                    {
                        HttpContext.Session.SetString("studentid", account.student_id);
                        account.active_status = "on";
                        cheakid = account.student_id;
                        student_status = "Active";
                        student_division = account.student_division;
                        block_reason = account.block_reason;
                        db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                        return View("StudentWork");
                    }
                    else
                    {
                        msgg = "Id or password is wrong";
                    }
                }
                else
                {
                    msgg = "You are Blocked!!!!! Contact with manager.";
                }
            }
            else
            {
                msgg = "Id or password is wrong";
            }
            ViewBag.message = msgg;
            return View();
        }
        public IActionResult StudentWork()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Editprofile(string id)
        {
            string msg;
            StudentInfo ad = db.student_info.Find(id);
            if (ad == null)
            {
                msg = "This ID is not available";
                ViewBag.message = msg;
                return View("AdminWork");
            }
            else
            {
                cheakid = ad.student_id;
                return View(ad);
            }

        }
        [HttpPost]
        public IActionResult EditProfile(StudentInfo ad)
        {
            ad.student_id = HttpContext.Session.GetString("studentid");
            ad.student_status = "Active";
            ad.active_status = null;
            db.Entry(ad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return View("StudentWork");
        }



        //to do list part
        public IActionResult StudentToDo(string id)
        {
            return View(db.todolist.ToList().Where(x=>x.student_id==id));
        }

        [HttpGet]
        public IActionResult CreateToDo()
        {
            return View("CreateToDo", new ToDoList());
        }
        [HttpPost]
        public IActionResult CreateToDo(ToDoList todo)
        {
            todo.student_id = HttpContext.Session.GetString("studentid");
                db.todolist.Add(todo);
                db.SaveChanges();
                return RedirectToAction("StudentWork");
        }
        [HttpGet]
        public IActionResult EditToDo(int id)
        {
            ToDoList ad = db.todolist.Find(id);
            return View(ad);
        }
        [HttpPost]
        public IActionResult EditToDo(ToDoList ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return View("StudentWork");
            }
            else
            {
                return View(ad);
            }
        }
        [HttpGet]
        public IActionResult DeleteToDo(int id)
        {
            ToDoList aa = db.todolist.Single(x => x.id == id);
            db.todolist.Remove(aa);
            db.SaveChanges();
            return View("StudentWork");
        }

        //Complain Part

        public IActionResult AddComplain()
        {
            return View("AddComplain", new Complain());
        }
        [HttpPost]
        public IActionResult AddComplain(Complain ntc)
        {
            string mmsg;
            string id = HttpContext.Session.GetString("studentid");
            if (id == ntc.student_id)
            {
                var account = db.complain_info.Where(a => a.student_id == ntc.student_id).FirstOrDefault();
                if (account==null)
                {
                    mmsg = "Your complain has been recorded. If necessary Admin will take action. Thank You";
                    db.complain_info.Add(ntc);
                    db.SaveChanges();
                    ViewBag.message = mmsg;
                    return View("StudentWork");
                }
                else
                {
                    mmsg = "Your previous complain is in the queue. Wait until Admin Fix that issue. If emergency contact with the Manager.";
                    ViewBag.message = mmsg;
                    return View("StudentWork");
                }
            }
            else
            {
                mmsg = "Your ID was wrong";
                ViewBag.message = mmsg;
                return View("StudentWork");
            }
        }





        [HttpGet]
        public IActionResult Logout()
        {
            string cheak = "on";
            var account = db.student_info.Where(a => a.active_status == cheak).FirstOrDefault();
            if(account.active_status != null )account.active_status = null;
            db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            HttpContext.Session.Clear();
            ViewBag.message = null;
            return RedirectToAction("Index");
        }

    }
}
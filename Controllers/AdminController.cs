using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IITS_Programming_Club.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Configuration;
using System.Web;
using System.IO;


namespace IITS_Programming_Club.Controllers
{
    
    public class AdminController : Controller
    {

        public  DataContext db;
        public AdminController(DataContext _db)
        {
            db = _db;
        }
        
        public IActionResult Index()
        {
            string cheak = "active";
            var active = db.admin_info.Where(a => a.active_status == cheak).FirstOrDefault();
            if (active == null && HttpContext.Session.GetString("adminid") == null)
            {
                return View();
            }
            else if (HttpContext.Session.GetString("adminid" )==null)
            {
                return RedirectToAction("Logout");
            }
            else
            {
                return RedirectToAction("AdminWork");
            }
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View("AdminAddAdmin", new Admin());
        }
        [HttpPost]
        public IActionResult AddAdmin(Admin admin)
        {
            string msg;
            var account = db.admin_info.Where(a => a.admin_id == admin.admin_id).FirstOrDefault();
            if (account == null)
            {
                db.admin_info.Add(admin);
                db.SaveChanges();
                return RedirectToAction("AdminWork");
            }
            else
            {
                msg = "Already exist as an Admin.";
            }
            ViewBag.message = msg;
            return View("AdminAddAdmin");

        }
        public IActionResult AdminWork()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Admin af)
        {
            string msg;
            string cheak = "active";
            var account = db.admin_info.Where(a => a.admin_id == af.admin_id).FirstOrDefault();
            if (account != null)
            {
                if (account.admin_pass == af.admin_pass)
                {
                    msg = "Id or password is wrong";
                    HttpContext.Session.SetString("adminid", account.admin_id);
                    account.active_status = cheak;
                    db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("AdminWork");
                }
                else
                {
                    msg = "Id or password is wrong";
                }
            }
            else
            {
                msg = "Id or password is wrong";
            }
            ViewBag.message = msg;
            return View();
           
            
        }
        public IActionResult AllAdmin()
        {
            return View(db.admin_info.ToList());
        }
        [HttpGet]
        public IActionResult DeleteAdmin(string id)
        {
            Admin a = db.admin_info.Single(x => x.admin_id == id);
            db.admin_info.Remove(a);
            db.SaveChanges();
            return View("AdminWork");
        }

        

        //all notice
        public IActionResult AddNotice()
        {
            return View("AddNotice", new Notice());
        }
        [HttpPost]
        public IActionResult AddNotice(Notice ntc)
        {
            string msg;
            var account = db.notice.Where(a => a.notice_id == ntc.notice_id).FirstOrDefault();
            if (account == null)
            {
                db.notice.Add(ntc);
                db.SaveChanges();
                return RedirectToAction("AdminWork");
            }
            else
            {
                msg = "Already exist as an Notice ID.";
            }
            ViewBag.message = msg;
            return View("AddNotice");
        }

        public IActionResult AllNotice()
        {
            return View(db.notice.ToList());
        }
        [HttpGet]
        public IActionResult DeleteNotice(string id)
        {
            Notice aa = db.notice.Single(x => x.notice_id == id);
            db.notice.Remove(aa);
            db.SaveChanges();
            return View("AdminWork");
        }
        [HttpGet]
        public IActionResult Editprofile(string id)
        {
            string msg;
            Admin ad = db.admin_info.Find(id);
            if (ad == null)
            {
                msg = "This ID is not available";
                ViewBag.message = msg;
                return View("AdminWork");
            }
            else
            {
                return View(ad);
            }
            
        }
        [HttpPost]
        public IActionResult EditProfile(Admin ad)
        {
            if(ModelState.IsValid)
            {
                db.Entry(ad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return View("Index");
            }
            else
            {
                return View(ad);
            }
        }


        //reset pass for admin part
        [HttpGet]
        public IActionResult ResetPassAdmin(string id)
        {
            string msg;
            Admin ad = db.admin_info.Find(id);
            if (ad == null)
            {
                msg = "This ID is not available";
                ViewBag.message = msg;
                return View("AdminWork");
            }
            else
            {
                return View(ad);
            }

        }
        [HttpPost]
        public IActionResult ResetPassAdmin(Admin ad)
        {
            string name = ad.admin_name;
            string phone = ad.admin_phone;
            string mail = ad.admin_mail;
            string address = ad.admin_address;
            string active_status = null;
            if (ModelState.IsValid)
            {
                ad.admin_name = name;
                ad.admin_address = address;
                ad.admin_mail = mail;
                ad.admin_phone = phone;
                ad.active_status = active_status;
                db.Entry(ad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return View("AdminWork");
            }
            else
            {
                return View(ad);
            }
        }


        //reset pass for student
        [HttpGet]
        public IActionResult ResetPassStudent(string id)
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
                return View(ad);
            }

        }
        [HttpPost]
        public IActionResult ResetPassStudent(StudentInfo ad)
        {
            string name = ad.student_name;
            string id = ad.student_id;
            string codeforcs = ad.codeforces_handle;
            string codechef = ad.codechef_handle;
            string vjudge = ad.vjudge_handle;
            string atcoder = ad.atcoder_handle;
            string active_status = null;
            if (ModelState.IsValid)
            {
                ad.student_name = name;
                ad.student_id = id;
                ad.codeforces_handle = codeforcs;
                ad.codechef_handle = codechef;
                ad.vjudge_handle = vjudge;
                ad.atcoder_handle = atcoder;
                ad.active_status = active_status;
                db.Entry(ad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return View("AdminWork");
            }
            else
            {
                return View(ad);
            }
        }




        //student part

        public IActionResult AddStudent()
        {
            return View("AddStudent", new StudentInfo());
        }
        [HttpPost]
        public IActionResult AddStudent(StudentInfo ntc)
        {
            string msg;
            var account = db.student_info.Where(a => a.student_id == ntc.student_id).FirstOrDefault();
            if (account == null)
            {
                db.student_info.Add(ntc);
                db.SaveChanges();
                return RedirectToAction("AdminWork");
            }
            else
            {
                msg = "Already exist as an Notice ID.";
            }
            ViewBag.message = msg;
            return View("AddStudent");
        }

        public IActionResult AllStudent()
        {
            return View(db.student_info.ToList());
        }
        [HttpGet]
        public IActionResult DeleteStudent(string id)
        {
            StudentInfo aa = db.student_info.Single(x => x.student_id == id);
            db.student_info.Remove(aa);
            db.SaveChanges();
            return View("AdminWork");
        }

        public IActionResult AllComplain()
        {
            return View(db.complain_info.ToList());
        }
        [HttpGet]
        public IActionResult DeleteComplain(string id)
        {
            Complain aaaaa = db.complain_info.Single(x => x.student_id == id);
            db.complain_info.Remove(aaaaa);
            db.SaveChanges();
            return View("AdminWork");
        }


        //serch part
        public IActionResult SearchAdmin(string id)
        {
            var account = db.admin_info.Where(a => a.admin_id == id).FirstOrDefault();
            if (account == null)
            {
                return View("Admin " + id + " is not found");
            }
            else
            {
                return View(db.admin_info.Where(a => a.admin_id == id).ToList());
            }
            
        }
        public IActionResult SearchStudent(string id)
        {
            var account = db.student_info.Where(a => a.student_id == id).FirstOrDefault();
            if (account == null)
            {
                return View("Student " + id + " is not found");
            }
            else
            {
                return View(db.student_info.Where(a => a.student_id == id).ToList());
            }

        }

        //all event part
        public IActionResult AddEvent()
        {
            return View("AddEvent", new Event());
        }
        [HttpPost]
        public IActionResult AddEvent(Event ntc)
        {
            string msg;
            var account = db.event_info.Where(a => a.event_id == ntc.event_id).FirstOrDefault();
            if (account == null)
            {
                db.event_info.Add(ntc);
                db.SaveChanges();
                return RedirectToAction("AdminWork");
            }
            else
            {
                msg = "Already exist as an Notice ID.";
            }
            ViewBag.message = msg;
            return View("AddNotice");
        }

        public IActionResult AllEvent()
        {
            return View(db.event_info.ToList());
        }
        [HttpGet]
        public IActionResult DeleteEvent(string id)
        {
            Event aa = db.event_info.Single(x => x.event_id == id);
            db.event_info.Remove(aa);
            db.SaveChanges();
            return View("AdminWork");
        }


        public IActionResult EventEdit(string id)
        {
            string msg;
            Event ad = db.event_info.Find(id);
            if (ad == null)
            {
                msg = "This ID is not available";
                ViewBag.message = msg;
                return View("AllEvent");
            }
            else
            {
                return View(ad);
            }

        }
        [HttpPost]
        public IActionResult EventEdit(Event ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return View("AdminWork");
            }
            else
            {
                return View(ad);
            }
        }

        //class schedule part
        public IActionResult AddClass()
        {
            return View("AddClass", new ClassSchedule());
        }
        [HttpPost]
        public IActionResult AddClass(ClassSchedule ntc)
        {
            string msg;
            var account = db.class_info.Where(a => a.group == ntc.group).FirstOrDefault();
            if (account == null)
            {
                db.class_info.Add(ntc);
                db.SaveChanges();
                return RedirectToAction("AdminWork");
            }
            else
            {
                account = db.class_info.Where(a => a.date == ntc.date).FirstOrDefault();
                if (account == null)
                {
                    db.class_info.Add(ntc);
                    db.SaveChanges();
                    return RedirectToAction("AdminWork");
                }
                else
                {
                    msg = "Already exist as an Class.";
                }
            }
            ViewBag.message = msg;
            return View("AdminWork");
        }

        public IActionResult AllClass()
        {
            return View(db.class_info.ToList());
        }

        public IActionResult ClassEdit(int id)
        {
            string msg;
            ClassSchedule ad = db.class_info.Find(id);
            if (ad == null)
            {
                msg = "This ID is not available";
                ViewBag.message = msg;
                return View("AllClass");
            }
            else
            {
                return View(ad);
            }

        }
        [HttpPost]
        public IActionResult ClassEdit(ClassSchedule ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return View("AdminWork");
            }
            else
            {
                return View(ad);
            }
        }

        //Programmer of the week part
        public IActionResult AddProgrammer()
        {
            return View("AddProgrammer", new Programmer());
        }
        [HttpPost]
        public IActionResult AddProgrammer(Programmer ntc)
        {
            string msg;
            var account = db.prog_of_week.Where(a => a.week == ntc.week).FirstOrDefault();
            if (account == null)
            {
                db.prog_of_week.Add(ntc);
                db.SaveChanges();
                return RedirectToAction("AdminWork");
            }
            else
            {
                account = db.prog_of_week.Where(a => a.week == ntc.week).FirstOrDefault();
                if (account == null)
                {
                    db.prog_of_week.Add(ntc);
                    db.SaveChanges();
                    return RedirectToAction("AdminWork");
                }
                else
                {
                    msg = "Already exist as an Programmer of this week.";
                }
                
            }
            ViewBag.message = msg;
            return View("AdminWork");
        }

        public IActionResult AllProgrammer()
        {
            return View(db.prog_of_week.ToList());
        }
        [HttpGet]
        public IActionResult ProgrammerEdit(int id)
        {
            string msg;
            Programmer ad = db.prog_of_week.Find(id);
            if (ad == null)
            {
                msg = "This ID is not available";
                ViewBag.message = msg;
                return View("AllProgrammer");
            }
            else
            {
                return View(ad);
            }

        }
        [HttpPost]
        public IActionResult ProgrammerEdit(Programmer ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return View("AdminWork");
            }
            else
            {
                return View(ad);
            }
        }



        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            string cheak = "active";
            var active = db.admin_info.Where(a => a.active_status == cheak).FirstOrDefault();
            if (active != null) 
            {
                active.active_status = null;
                db.Entry(active).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            } 
            return RedirectToAction("Index");
        }
    }
}
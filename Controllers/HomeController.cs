using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IITS_Programming_Club.Models;
using Microsoft.CodeAnalysis;

namespace IITS_Programming_Club.Controllers
{
    public class HomeController : Controller
    {
        public DataContext dbh;
        public HomeController(DataContext _db)
        {
            dbh = _db;
        }

        
        public IActionResult Index()
        {
            bool cheak = false;
            ClassSchedule cls = new ClassSchedule();
            cls = dbh.class_info.Where(a => a.isDone == cheak && a.group=="Advance").FirstOrDefault();
            Programmer prog = new Programmer();
            prog = dbh.prog_of_week.Where(a => a.isDone == cheak).FirstOrDefault();
            Home hm = new Home();
            StudentInfo stu = new StudentInfo();

            try
            {
               stu =  dbh.student_info.Where(a => a.student_id == prog.id).FirstOrDefault();
            }
            catch(Exception e)
            {
                stu = null;
            }
            if (stu != null)
            {
                hm.student_id = stu.student_id;
                hm.student_name = stu.student_name;
                hm.codeforces_handle = stu.codeforces_handle;
            }
            else
            {
                hm.student_id = null;
                hm.student_name = null;
                hm.codeforces_handle = null;
            }
            if(cls!=null)
            {
                hm.class_advance = cls.group;
                hm.room_advance = cls.room_no;
                hm.date_advance = cls.date;
                hm.time_advance = cls.time;
                hm.change_plan_advance = cls.change_plan;
            }
            cls = dbh.class_info.Where(a => a.isDone == cheak && a.group == "Intermediate").FirstOrDefault();
            if (cls != null)
            {
                hm.class_intermediate = cls.group;
                hm.room_intermediate = cls.room_no;
                hm.date_intermediate = cls.date;
                hm.time_intermediate = cls.time;
                hm.change_plan_intermediate = cls.change_plan;
            }
            cls = dbh.class_info.Where(a => a.isDone == cheak && a.group == "Beginner").FirstOrDefault();
            if (cls != null)
            {
                hm.class_beginner = cls.group;
                hm.room_begineer = cls.room_no;
                hm.time_begineer = cls.time;
                hm.date_begineer = cls.date;
                hm.change_plan_begineer = cls.change_plan;
            }
            return View(hm);
        }
        public IActionResult AllNotice()
        {
            return View(dbh.notice.ToList());
        }
        public IActionResult AllEvent()
        {
            return View(dbh.event_info.ToList());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using beltPlate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace beltPlate.Controllers
{

    public class ActivityController : Controller
    {
        private UserContext _context;
        public ActivityController(UserContext context)
        {
            _context = context;
        }

        public IActionResult ActivityMaker()
        {
            var currentUser = HttpContext.Session.GetObjectFromJson<User>("currentUser");
            ViewBag.firstName = currentUser.firstName;
            return View("CreateActivity");
        }

        public IActionResult AddActivity(ActivityViewModel activity)
        {
            DateTime todaysDate = DateTime.Now;
            ViewBag.rightNow = todaysDate;
            User currentUser = HttpContext.Session.GetObjectFromJson<User>("currentUser");
            if(ModelState.IsValid && activity.dateOfActivity > todaysDate)
            {
                Models.Activity newActivity = new Models.Activity()
                {
                    title = activity.title,
                    userId = currentUser.userId,
                    timeOfActivity = activity.timeOfActivity,
                    dateOfActivity = activity.dateOfActivity,
                    duration = activity.duration,
                    description = activity.description,
                    createdAt = DateTime.Now,
                    updatedAt = DateTime.Now,
                };
                ViewBag.Inc = activity.timeIncrement;
                _context.Activities.Add(newActivity);
                _context.SaveChanges();
                Rsvp newRsvp = new Rsvp()
                {
                    userId = currentUser.userId,
                    activityId = newActivity.activityId,
                    createdAt = DateTime.Now,
                    updatedAt = DateTime.Now,
                };
                _context.Rsvps.Add(newRsvp);
                _context.SaveChanges();
                RedirectToAction("Success");
            }else{
                ViewBag.errors = ModelState.Values;
                foreach(var error in ViewBag.errors)
                {
                    System.Console.WriteLine(error);
                }
                return View("CreateActivity");
            }
            return RedirectToAction("Success", "Home");
        }

        public IActionResult ViewActivity(int activityId)
        {
            Models.Activity currentActivity = _context.Activities.Include(rez => rez.rsvps).SingleOrDefault(act => act.activityId == activityId);
            currentActivity.rsvps = _context.Rsvps.Where(rez => rez.activityId == currentActivity.activityId).Include(Rsvp => Rsvp.User).ToList();
            _context.SaveChanges();
            ViewBag.activityId = activityId;
            return View("ViewActivity", currentActivity);
        }

        public IActionResult RsvpToActivity(int activityId)
        {
            var currentUser = HttpContext.Session.GetObjectFromJson<User>("currentUser");
            System.Console.WriteLine(currentUser.lastName);
            var currentActivity = _context.Activities.SingleOrDefault(act => act.activityId == activityId);
            Rsvp addRsvp = new Rsvp
            {
                userId = currentUser.userId,
                activityId = activityId
            };
            currentActivity.rsvps = _context.Rsvps.Where(rez => rez.activityId == currentActivity.activityId).Include(rsvp => rsvp.User).Include(wed => wed.Activity).ToList();
            System.Console.WriteLine(currentActivity.rsvps.Count);     
            _context.Rsvps.Add(addRsvp);
            _context.SaveChanges();
            return RedirectToAction("ViewActivity", currentActivity);

        }

        public IActionResult UnRsvpToActivity(int activityId)
        {
            var currentUser = HttpContext.Session.GetObjectFromJson<User>("currentUser");
            Models.Activity activityToLeave = _context.Activities.SingleOrDefault(act => act.activityId == activityId);
            var rsvpToLeave = _context.Rsvps.SingleOrDefault(rez => rez.userId == currentUser.userId && rez.activityId == activityId);
            _context.Rsvps.Remove(rsvpToLeave);
            _context.SaveChanges();
            return RedirectToAction("Success", "Home");
        }

        public IActionResult DeleteActivity(int activityId)
        {
            var currentUser = HttpContext.Session.GetObjectFromJson<User>("currentUser");
            Models.Activity activityToBeDeleted = _context.Activities.SingleOrDefault(act => act.activityId == activityId);
            List<Rsvp> rsvpsToBeDeleted = _context.Rsvps.Where(rez => rez.activityId == activityId).ToList();
            if(currentUser.userId == activityToBeDeleted.userId)
            {
                foreach(var rez in rsvpsToBeDeleted)
                {
                    _context.Rsvps.Remove(rez);
                }
                _context.Activities.Remove(activityToBeDeleted);
                _context.SaveChanges();
            }
            return RedirectToAction("Success", "Home");
        }
    }
}
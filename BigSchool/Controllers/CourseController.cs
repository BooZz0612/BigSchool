﻿using BigSchool.Models;
using BigSchool.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CourseController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList(),
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories= _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LectureId = User.Identity.GetUserId(),
                Datetime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place,
            };
            _dbContext.Coureses.Add(course);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    } 
}
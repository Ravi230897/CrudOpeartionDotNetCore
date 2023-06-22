using Cart.DataAccess.Data;
using CrudOpeartionDotNetCore.Data;
using CrudOpeartionDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CrudOpeartionDotNetCore.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var departments = _context.Catego.Select(p =>
            new DepartmentView
            {
                DepartmentId = p.DepartmentId,
                Name = p.Name
            }).ToList();
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentView model)
        {
            ModelState.Remove("DepartmentId");
            if (ModelState.IsValid)
            {
                Department department = new Department 
                { 
                    Name = model.Name
                };
                _context.Catego.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            DepartmentView model = new DepartmentView();
            Department department = _context.Catego.Find(id);
            if (department != null)
            {
                model = new DepartmentView
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name
                };
                
            }

            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentView model)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department { DepartmentId = model.DepartmentId, Name = model.Name};

                _context.Catego.Update(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

﻿using HomeworkPustok.DAL;
using HomeworkPustok.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeworkPustok.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class GenreController : Controller
    {
        private readonly PustokDbContext _context;
        public GenreController(PustokDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            var data=_context.Genres.Include(x=>x.Books).ToList();
            return View(data);
        }
        public IActionResult Update(int id)
        {

            var data=_context.Genres.FirstOrDefault(x => x.Id==id);
            if (data == null) RedirectToAction("Error");
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var data = _context.Genres.FirstOrDefault(x => x.Name.Trim().ToLower() == genre.Name.ToLower().Trim());
            if (data!=null && data.Id != genre.Id)
            {
                ModelState.AddModelError("Name","Bu adli genre artiq movcuddur.");
                return View();
            }
            _context.Genres.FirstOrDefault(x=>x.Id==genre.Id).Name=genre.Name;
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genre genre) 
        {
            if(!ModelState.IsValid) { return View(); }
            if (_context.Genres.FirstOrDefault(x=>x.Name==genre.Name)!=null)
            {
                ModelState.AddModelError("Name", "Bu adli genre artiq movcuddur");
                return View();
            }
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (_context.Genres.FirstOrDefault(x => x.Id == id) == null)
            {
                return RedirectToAction("Error");
            }
            _context.Genres.Remove(_context.Genres.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}

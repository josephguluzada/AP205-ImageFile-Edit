using Microsoft.AspNetCore.Mvc;
using PustokAP205.DAL;
using PustokAP205.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokAP205.Areas.Manage.Controllers
{
    [Area("manage")]
    public class FeatureController : Controller
    {
        private readonly AppDbContext _context;

        public FeatureController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Feature> features = _context.Features.ToList();

            return View(features);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);
            if (feature == null) return NotFound();

            return View(feature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Feature feature)
        {
            Feature existFeature = _context.Features.FirstOrDefault(x => x.Id == feature.Id);
            if (existFeature == null) return NotFound();

            existFeature.Title = feature.Title;
            existFeature.SubTitle = feature.SubTitle;
            existFeature.Icon = feature.Icon;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
        
        public IActionResult Delete(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);
            if (feature == null) return Json(new { status = 404 });

            _context.Features.Remove(feature);
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}

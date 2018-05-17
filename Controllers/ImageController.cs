﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoApp.WebMvc.Models;

namespace DemoApp.WebMvc.Controllers
{
    public class ImageController : Controller
    {
        private static List<Image> _images = new List<Image>
        {
            new Image{Id=1, DisplayName= "Image1", Description = "desc1", Height= 100, Width = 100 },
            new Image{Id=2, DisplayName= "Image2", Description = "desc2", Height= 100, Width = 100 },
            new Image{Id=3, DisplayName= "Image3", Description = "desc3", Height= 100, Width = 100 }
        };
        // GET: Image

        public ActionResult Index()
        {
            return View(_images);
        }

        // GET: Image/Details/5
        public ActionResult Details(int id)
        {
            var image = _images.FirstOrDefault(d => d.Id == id);
            return View(image);
        }

        // GET: Image/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Image image)
        {
            _images.Add(image);

            return RedirectToAction("Index");
        }

        // GET: Image/Edit/5
        public ActionResult Edit(int id)
        {
            var image = _images.FirstOrDefault(i => i.Id == id);
            return View(image);
        }

        // POST: Image/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Image image)
        {
            var img = _images.FirstOrDefault(x => x.Id == id);
            if (img == null)
            {
                return RedirectToAction("Index");
            }

            img.Height = image.Height;
            img.Width = image.Width;
            img.DisplayName = image.DisplayName;
            img.Description = image.Description;
            img.ImageUrl = image.ImageUrl;

            return RedirectToAction("Index");
        }

        // GET: Image/Delete/5
        public ActionResult Delete(int id)
        {
            var image = _images.FirstOrDefault(i => i.Id == id);
            return View(image);
        }

        // POST: Image/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Image image)
        {
            var img = _images.FirstOrDefault(f => f.Id == id);
            if(img == null)
            {
                return RedirectToAction("Index");
            }

            _images.Remove(img);
            return RedirectToAction("Index");
        }

        [HandleError]
        public ActionResult Error()
        {
            throw new Exception();
        }

        [OutputCache(Duration = 15)]
        public ActionResult Cache()
        {
            return View();
        }
    }
}

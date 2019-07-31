using Microsoft.AspNetCore.Mvc;
using PackerTracker.Models;
using System.Collections.Generic;

namespace PackerTracker.Controllers
{
    public class PackersController : Controller
    {
        [HttpGet("/packers")]
        public ActionResult Index()
        {
            List<Packer> allPackers = Packer.GetAll();
            return View(allPackers);
        }

        [HttpGet("/packers/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/packers")]
        public ActionResult Create(string itemName, int itemPrice, bool purchased, bool packed)
        {
            Packer myPacker = new Packer(itemName, itemPrice, purchased, packed);
            return RedirectToAction("Index");
        }

        [HttpPost("/packers/delete")]
        public ActionResult DeleteAll()
        {
            Packer.ClearAll();
             return RedirectToAction("Index");
        }
        
        [HttpGet("/packers/{id}")]
        public ActionResult Show(int id)
        {
            Packer foundPacker = Packer.Search(id);
            return View(foundPacker);
        }

        [HttpGet("/packers/unpacked")]
        public ActionResult Unpacked()
        {
            List<Packer> allPackers = Packer.GetAll();
            return View(allPackers);
        }

        [HttpGet("/packers/{id}/edit")]
        public ActionResult Edit(int id)
        {
            Packer foundPacker = Packer.Search(id);
            return View(foundPacker);
        }

        [HttpPost("/packers/{id}")]
        public ActionResult Update(int id, string itemName, int itemPrice, bool purchased, bool packed)
        {
            Packer foundPacker = Packer.Search(id);
            foundPacker.ItemName = itemName;
            foundPacker.ItemPrice = itemPrice;
            foundPacker.Purchased = purchased;
            foundPacker.Packed = packed;
            return RedirectToAction("Unpacked");
        }
    }
}
using GestaoPets.DAL;
using GestaoPets.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoPets.Controllers
{
    public class PetController : Controller
    {
        public IActionResult Index()
        {
            List<Pet> listaPets = new List<Pet>();
            PetDAL petDAL = new PetDAL();

            listaPets = petDAL.ListarPets();

            return View(listaPets);
        }


        public IActionResult Create()
        {
            return View();
        }

        
        public IActionResult Details(int id)
        {
            PetDAL petDAL = new PetDAL();
            Pet pet = petDAL.ObterPet(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        
        public IActionResult Edit(int id)
        {
            PetDAL petDAL = new PetDAL();
            Pet pet = petDAL.ObterPet(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }
        
        public IActionResult Delete(int id)
        {
            PetDAL petDAL = new PetDAL();
            Pet pet = petDAL.ObterPet(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            PetDAL petDAL = new PetDAL();
            petDAL.DeletePet(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create([Bind] Pet pet)
        {
            if (ModelState.IsValid)
            {
                PetDAL petDAL = new PetDAL();
                petDAL.AddPet(pet);
                return RedirectToAction("Index");
            }
            return View(pet);
        }

        [HttpPost]
        public IActionResult Edit([Bind] Pet pet)
        {
            if (ModelState.IsValid)
            {
                PetDAL petDAL = new PetDAL();
                petDAL.UpdatePet(pet);
                return RedirectToAction("Index");
            }
            return View(pet);
        }
    }
}

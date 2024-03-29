﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using SuperheroesApp.Data;
using SuperheroesApp.Models;

namespace SuperheroesApp.Controllers
{
    public class SuperheroesController : Controller
    {
        private ApplicationDbContext _context; //SuperheroesContext

        public SuperheroesController(ApplicationDbContext context) //class name
        {
            _context = context;
        }
                       
        // GET: SuperheroesController
        public ActionResult Index()
        {
            //LINQ query to retrieve all rows from table (all superheroes)
            var superheroes = _context.Superheroes.ToList(); ;
            return View(superheroes);
        }

        // GET: SuperheroesController/Details/5
        public ActionResult Details(int id)
        {
            //LINQ query to find SPECIFIC row from table (specific superhero that matches the id passed in)
            var superhero = _context.Superheroes.Find(id);
            return View(superhero);
        }

        // GET: SuperheroesController/Create
        public ActionResult Create()
        {
            //leave this as is
            return View();
        }

        // POST: SuperheroesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                //LINQ query to add a superhero to to the table
                superhero = new Superhero()
                {
                    Name = superhero.Name,
                    AlterEgo = superhero.AlterEgo,
                    PrimaryAbility = superhero.PrimaryAbility,
                    SecondaryAbility = superhero.SecondaryAbility,
                    Catchphrase = superhero.Catchphrase
                };
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(superhero);
            }
        }

        // GET: SuperheroesController/Edit/5
        public ActionResult Edit(int id)
        {
            var superhero = _context.Superheroes.Find(id);
            return View(superhero);
        }

        // POST: SuperheroesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                //LINQ query to edit details relating to the superhero
                //var superhero = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault()
                //superhero = new Superhero() //this clears the existing info though so need to change this line of code
                //{
                //    Id = id,
                //    Name = superhero.Name,
                //    AlterEgo = superhero.AlterEgo,
                //    PrimaryAbility = superhero.PrimaryAbility,
                //    SecondaryAbility = superhero.SecondaryAbility,
                //    Catchphrase = superhero.Catchphrase
                //};
                var existingSuperhero = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
                existingSuperhero.Name = superhero.Name;
                existingSuperhero.AlterEgo = superhero.AlterEgo;
                existingSuperhero.PrimaryAbility = superhero.PrimaryAbility;
                existingSuperhero.SecondaryAbility = superhero.SecondaryAbility;
                existingSuperhero.Catchphrase = superhero.Catchphrase;

                superhero = existingSuperhero;
                
                _context.Superheroes.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(superhero);
            }
        }

        // GET: SuperheroesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperheroesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            //superhero = new Superhero()
            //{
            //    Id = id
            //};
            
            try
            {
                //LINQ query to delete a superhero from the table
                superhero = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
                _context.Superheroes.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(superhero);
            }
        }
    }
}

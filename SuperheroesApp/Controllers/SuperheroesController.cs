using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroesApp.Data;
using SuperheroesApp.Models;

namespace SuperheroesApp.Controllers
{
    public class SuperheroesController : Controller
    {
        private ApplicationDbContext _context; //SuperheroesContext

        public SuperheroesController(ApplicationDbContext context) //class name
        {
            _context = context; //test
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
            return View();
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuperheroesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                //LINQ query to edit details relating to the superhero
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

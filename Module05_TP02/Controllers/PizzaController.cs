using BO;
using Module05_TP02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPModule5_1.Utils;

namespace Module05_TP02.Controllers
{
    public class PizzaController : Controller
    {

        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDbPizza.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            CreatePizzaVM pizzaVm = new CreatePizzaVM { Ingredients = FakeDbPizza.Instance.Ingredients, Pates = FakeDbPizza.Instance.Pates };
            return View(pizzaVm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(CreatePizzaVM pizzaVm)
        {
            try
            {
                List<Ingredient> ingredients = new List<Ingredient>();
                foreach (int ing in pizzaVm.IngredientsChoisis)
                {
                    ingredients.Add(FakeDbPizza.Instance.Ingredients.FirstOrDefault(i => i.Id == ing));
                }

                Pizza pizza = new Pizza(FakeDbPizza.Instance.PizzaID, pizzaVm.Nom, FakeDbPizza.Instance.Pates.FirstOrDefault(p => p.Id == pizzaVm.IdPate), ingredients);

                FakeDbPizza.Instance.Pizzas.Add(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                pizzaVm.Ingredients = FakeDbPizza.Instance.Ingredients;
                pizzaVm.Pates = FakeDbPizza.Instance.Pates;
                pizzaVm.Erreur = "Une erreur a eu lieu";
                return View(pizzaVm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
            List<int> ingredients = new List<int>();
            foreach (Ingredient ing in pizza.Ingredients)
            {
                ingredients.Add(ing.Id);
            }
            EditPizzaVM pizzaVm = new EditPizzaVM { Id= id, Nom=pizza.Nom, IngredientsChoisis= ingredients, IdPate=pizza.Pate.Id,  Ingredients = FakeDbPizza.Instance.Ingredients, Pates = FakeDbPizza.Instance.Pates };
            return View(pizzaVm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(EditPizzaVM pizzaVm)
        {
            try
            {
                List<Ingredient> ingredients = new List<Ingredient>();
                foreach (int ing in pizzaVm.IngredientsChoisis)
                {
                    ingredients.Add(FakeDbPizza.Instance.Ingredients.FirstOrDefault(i => i.Id == ing));
                }

                Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == pizzaVm.Id);
                pizza.Nom = pizzaVm.Nom;
                pizza.Pate = FakeDbPizza.Instance.Pates.FirstOrDefault(p => p.Id == pizzaVm.IdPate);
                pizza.Ingredients = ingredients;
                return RedirectToAction("Index");
            }
            catch
            {
                pizzaVm.Ingredients = FakeDbPizza.Instance.Ingredients;
                pizzaVm.Pates = FakeDbPizza.Instance.Pates;
                pizzaVm.Erreur = "Une erreur a eu lieu";
                return View(pizzaVm);
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(Pizza pizza)
        {
            try
            {
                Pizza pizzaTodelete = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == pizza.Id);
                FakeDbPizza.Instance.Pizzas.Remove(pizzaTodelete);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

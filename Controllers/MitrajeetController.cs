using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mitrajeet_MVC.DataAccess;
using Mitrajeet_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrajeet_MVC.Controllers
{
    public class MitrajeetController : Controller
    {
        
        MitrajeetDataAccessLayer mda = new MitrajeetDataAccessLayer();
        public MitrajeetController()
        {
            MitrajeetDataAccessLayer mda = new MitrajeetDataAccessLayer();
        }

        // GET all : MitrajeetController
        public ActionResult Index()
        {
            IEnumerable<MitrajeetModel> mModel = mda.GetAllMitrajeet();
            return View(mModel);
        }

        // GET: MitrajeetController/Details/5
        public ActionResult Details(int id)
        {
            MitrajeetModel mjModel = mda.GetMitrajeetDataById(id);
            return View(mjModel);
        }


        [HttpPost("/Mitrajeet/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MitrajeetModel model)
        {
            try
            {
                // TODO: Add insert logic here  
                mda.AddMitrajeet(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                //throw ex;
                return BadRequest();
            }
        }



        // GET: MitrajeetController/Create
        public ActionResult Create()
        {
            MitrajeetModel model = new MitrajeetModel();

            List<string> countries = mda.GetCountries();
            model.Countries = countries.Select(country => new SelectListItem
            {
                Text = country,
                Value = country
            }).ToList();

            List<string> states = mda.GetStates();
            model.States = states.Select(state => new SelectListItem
            {
                Text = state,
                Value = state
            }).ToList();


            return View(model);
        }

        // POST: MitrajeetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: MitrajeetController/Edit/5
        //[HttpGet("/Mitrajeet/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            MitrajeetModel model = mda.GetMitrajeetDataById(id);
            return View(model);
        }


        [HttpPost("/Mitrajeet/Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MitrajeetModel model)
        {
            try
            {
                // TODO: Add update logic here  
                mda.UpdateMitrajeet(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // POST: MitrajeetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: MitrajeetController/Delete/5
        public ActionResult Delete(int id)
        {
            MitrajeetModel mjModel = mda.GetMitrajeetDataById(id);
            return View(mjModel);
        }

        // POST: MitrajeetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
                //Not binding
            {
                mda.DeleteMitrajeet(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}

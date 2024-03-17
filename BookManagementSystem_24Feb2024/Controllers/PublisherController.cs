using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMS.DataLayer;
using BMS.DataModel;
using BMS.DataLayer.Publisher;
using Microsoft.AspNetCore.Http;

namespace BookManagementSystem_24Feb2024.Controllers
{

    public class PublisherController : BaseController
    {
        private readonly IPublisherRepository repository;

        public PublisherController(IPublisherRepository publisher)
        {
            //repository = new PublisherRepository();
            repository = publisher;
        }
        public IActionResult Index()
        {
            //string SessionValue = HttpContext.Session.GetString("Mykey");
            //if(SessionValue != null)
            //{
            //    ViewBag.Msg = SessionValue;
            //}
            var data = repository.GetPublishers();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Publisher model)
        {
            if (ModelState.IsValid)
            {
                if (repository.Add(model))
                {
                    Notify("Save", "Record Created Successfully.", MessagetType.success);

                    return RedirectToAction(nameof(Index));
                }
            }
           
            Notify("Error", "Record not created.", MessagetType.error);

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var publisher = repository.GetPublisher(id);

            if (publisher != null)
                return View(publisher);
            else
                return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Publisher model)
        {
            if (repository.Update(model))
            {
                Notify("Save", "Record Update Successfully.", MessagetType.success);

                return RedirectToAction(nameof(Index));
            }
            Notify("Error", "Record not updated.", MessagetType.error);
            return View(model);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (repository.Remove(id))
            {
                Notify("Removed", "Record Removed Successfully.", MessagetType.success);
            }
            else
            {
                Notify("Error", "Record not removed.", MessagetType.error);

            }

            return RedirectToAction(nameof(Index));

        }
    }
}

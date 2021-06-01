using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TechOneAssessment.Models;

namespace TechOneAssessment.Controllers
{
    public class HomeController : Controller
    {
        // GET: NumbersToWord
        public ActionResult Index()
        {
            return View();
        }

        // POST: /NumbersToWord/ConvertToWords
        [HttpPost]
        public ActionResult Index(IndexViewModel model)
        {
            if (model.Numbers > 0)
            {
                model.Words = NumbersToWords.ConvertToWords(model.Numbers);
            }
            
            return View(model);
        }


    }
   

        
    




}
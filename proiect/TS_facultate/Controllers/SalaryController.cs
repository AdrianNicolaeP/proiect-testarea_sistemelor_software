using Microsoft.AspNetCore.Mvc;
using TS_facultate.Models;
using TS_facultate.Services;

namespace TS_facultate.Controllers
{
    public class SalaryController : Controller
    {

        private readonly SalaryService _service;

        public SalaryController(SalaryService salaryService)
        {
            _service = salaryService;
        }

        [HttpGet]
        public IActionResult Salary()
        {
            return View("~/Views/FormUI.cshtml");
        }

[HttpPost]
        public IActionResult Rezultat(Salary model)
        {
            try
            {
                model.Net = _service.CalculeazaNet(model.Brut, model.Tara);
                model.Mesaj = "Calcul realizat cu succes";
            }
            catch (Exception ex)
            {
                model.Mesaj = ex.Message;
            }

            return View("~/Views/ResultsUI.cshtml", model);
        }
    



}
}

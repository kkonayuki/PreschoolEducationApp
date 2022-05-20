using Microsoft.AspNetCore.Mvc;
using PreschoolEducationApp.Interfaces;
using PreschoolEducationApp.Models;

namespace PreschoolEducationApp.Controllers
{
    public class ParentController : Controller
    {

        private readonly IParentRepository _parentRepository;

        public ParentController(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var parents = await _parentRepository.GetAllAsync();
            return View(parents);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var parent = await _parentRepository.GetByIdAsync(id);
            return View(parent);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Parent parent)
        {
            if (!ModelState.IsValid)
                return View(parent);
            

            _parentRepository.Add(parent);
            return RedirectToAction("Index");
        }
    }
}

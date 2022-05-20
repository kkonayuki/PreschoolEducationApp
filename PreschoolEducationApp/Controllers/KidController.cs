using Microsoft.AspNetCore.Mvc;
using PreschoolEducationApp.Interfaces;
using PreschoolEducationApp.Models;
using PreschoolEducationApp.ViewModels;

namespace PreschoolEducationApp.Controllers
{
    public class KidController : Controller
    {
        private readonly IKidRepository _kidRepository;

        public KidController(IKidRepository kidRepository)
        {
            _kidRepository = kidRepository;
        }
        public async Task<IActionResult> Index()
        {
            var kids = await _kidRepository.GetAllAsync();
            return View(kids);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var kid = await _kidRepository.GetByIdAsync(id);
            return View(kid);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kid kid)
        {
            if (!ModelState.IsValid)
                return View(kid);


            _kidRepository.Add(kid);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var kid = await _kidRepository.GetByIdAsync(id);
            if (kid == null) return View("Error");

            var kidVM = new EditKidViewModel
            {
                FirstName = kid.FirstName,
                LastName = kid.LastName,
                AddressId = kid.AddressId,
                Address = kid.Address,
                Age = kid.Age,
                KidGroups = kid.KidGroups,
            };
            return View(kidVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditKidViewModel kidVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit kid");
                return View("Edit", kidVM);
            }

            var kid = new Kid
            {
                Id = id,
                FirstName = kidVM.FirstName,
                LastName = kidVM.LastName,
                Age = kidVM.Age,
                AddressId = kidVM.AddressId,
                Address = kidVM.Address,
                KidGroupId = kidVM.KidGroupId,
                KidGroups = kidVM.KidGroups,
            };

            _kidRepository.Update(kid);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var kid = await _kidRepository.GetByIdAsync(id);
            if (kid == null) return View("Error");
            return View(kid);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var kidDetails = await _kidRepository.GetByIdAsync(id);

            if (kidDetails == null)
            {
                return View("Error");
            }



            _kidRepository.Delete(kidDetails);
            return RedirectToAction("Index");
        }

        
    }
}


using Microsoft.AspNetCore.Mvc;
using PreschoolEducationApp.Interfaces;
using PreschoolEducationApp.Models;
using PreschoolEducationApp.ViewModels;

namespace PreschoolEducationApp.Controllers
{
    public class TeacherController : Controller
    {

        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return View(teachers);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            return View(teacher);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (!ModelState.IsValid)
                return View(teacher);

            _teacherRepository.Add(teacher);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null) return View("Error");

            var teacherVM = new EditTeacherViewModel
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                AddressId = teacher.AddressId,
                Address = teacher.Address,
                Age = teacher.Age,
                PhoneNumber = teacher.PhoneNumber,
                KidGroupId = teacher.KidGroupId,
                KidGroup = teacher.KidGroup,
            };
            return View(teacherVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditTeacherViewModel teacherVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit teacher");
                return View("Edit", teacherVM);
            }

            var teacher = new Teacher
            {
                Id = id,
                FirstName = teacherVM.FirstName,
                LastName = teacherVM.LastName,
                PhoneNumber = teacherVM.PhoneNumber,
                Age = teacherVM.Age,
                AddressId = teacherVM.AddressId,
                Address = teacherVM.Address,
                KidGroupId = teacherVM.KidGroupId,
                KidGroup = teacherVM.KidGroup,
            };

            _teacherRepository.Update(teacher);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null) return View("Error");
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var teacherDetails = await _teacherRepository.GetByIdAsync(id);

            if (teacherDetails == null)
            {
                return View("Error");
            }

            

            _teacherRepository.Delete(teacherDetails);
            return RedirectToAction("Index");
        }
    }
}
